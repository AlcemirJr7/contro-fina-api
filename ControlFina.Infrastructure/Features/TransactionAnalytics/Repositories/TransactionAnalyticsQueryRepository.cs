using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetBiggerTransactionLastAndCurrentMonth;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetExpenseLastAndCurrentMonth;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueLastAndCurrentMonth;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueVsExpenseMonthlyByYear;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionCategoryByPeriod;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsCategoryMonthlyByYear;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsDailyByPeriod;
using ControlFina.Core.Features.TransactionAnalytics.Repositories;
using ControlFina.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text;

namespace ControlFina.Infrastructure.Features.TransactionAnalytics.Repositories;

public class TransactionAnalyticsQueryRepository : ITransactionAnalyticsQueryRepository
{
    private readonly AppDbContext _dbContext;
    public TransactionAnalyticsQueryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetTransactionsCategoryByPeriodQueryResponse>> GetTransactionCategoryByPeriodAsync(int days, bool debitsOnly = true, CancellationToken cancellationToken = default)
    {
		var queryString = new StringBuilder();
		object[] queryParams = [new NpgsqlParameter("days", days)];

        queryString.AppendLine(@"
			select con2.category, 
				   con2.sumValue,
				   con2.totalValue,
				   round((con2.SumValue/con2.TotalValue) * 100, 2) as PercValue
			  from (select con1.category,
						   sum(con1.value) as SumValue,
						   (sum(sum(con1.value)) over ()) as TotalValue
			          from (select c.description as Category,
				 				   t.transacation_date,
								   t.value
							  from tb_transaction t
					       left join tb_category c on (c.""Id"" = t.category_id)
						     where 1 = 1");
		
		if (debitsOnly)
			queryString.AppendLine("and t.is_debit = true");

		queryString.AppendLine(@"
			 and t.transacation_date >= (current_date - :days)
					order by t.transacation_date desc) con1
                    group by con1.category) con2
             order by con2.SumValue");

        return await _dbContext.Database.SqlQueryRaw<GetTransactionsCategoryByPeriodQueryResponse>(
            queryString.ToString(),
            queryParams
        ).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<GetTransactionsDailyByPeriodQueryResponse>> GetTransactionsDailyByPeriodAsync(int days, bool debitsOnly = true, CancellationToken cancellationToken = default)
    {
        var queryString = new StringBuilder();
        object[] queryParams = [new NpgsqlParameter("days", days)];

        queryString.AppendLine(@"
			select c.description as Category,
	               t.transacation_date as TransactionDate,
	               sum(t.value) as SumValue
                from tb_transaction t
              left join tb_category c on (c.""Id"" = t.category_id)
               where 1 = 1");

		if (debitsOnly)
			queryString.AppendLine("and t.is_debit = true");

		queryString.AppendLine(@"
				and t.transacation_date >= (current_date - :days)
			group by c.description, t.transacation_date
			order by t.transacation_date, 3");

        return await _dbContext.Database.SqlQueryRaw<GetTransactionsDailyByPeriodQueryResponse>(
           queryString.ToString(),
           queryParams
        ).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<GetRevenueVsExpenseMonthlyByYearQueryResponse>> GetRevenueVsExpenseMonthlyByYearAsync(int year, CancellationToken cancellationToken = default)
    {
        var query = await _dbContext.Database.SqlQueryRaw<GetRevenueVsExpenseMonthlyByYearQueryResponse>(
            @"select con3.firstOfMonth,
						sum(con3.expenseValue) as expenseValue,
						sum(con3.revenueValue) as revenueValue,
						sum(con3.revenueValue) - abs(sum(con3.expenseValue)) as remainingValue,
						case 
							when sum(con3.revenueValue) <> 0 then
							  round(abs(sum(con3.expenseValue))/sum(con3.revenueValue) * 100, 2)
							else 0
						end  as percExpenseValue
					from (select con2.transactiontype,
	   							con2.firstOfMonth,
								case 
								  when con2.transactiontype = 'Despesa' then sum(con2.sumvalue)
								  else 0
								end as expenseValue,
								case 
									when con2.transactiontype = 'Receita' then sum(con2.sumvalue)
									else 0
								end as revenueValue
							from (select case 
										   when con1.sumvalue < 0 then 'Despesa' 
										   else 'Receita' 
		   							     end as transactionType,
			   						con1.firstOfMonth,
		   							con1.sumValue
							from (select t.first_of_month  as firstOfMonth,
										 sum(t.value) as sumValue
		    						from tb_transaction t
								left join tb_category c on (c.""Id"" = t.category_id)
									where extract(year from t.first_of_month) = :year
									group by t.first_of_month, c.description
									order by t.first_of_month
		    						) con1
								) con2
						group by con2.transactiontype, con2.firstOfMonth
						order by con2.firstOfMonth
					) con3
				group by con3.firstOfMonth",
			new NpgsqlParameter("year", year)
		).ToListAsync(cancellationToken: cancellationToken);

		return query;        
    }

    public async Task<IEnumerable<GetExpenseLastAndCurrentMonthQueryResponse>> GetExpenseLastAndCurrentMonthAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Database.SqlQueryRaw<GetExpenseLastAndCurrentMonthQueryResponse>(
            @"select con2.firstofmonth,
					 con2.expenseValue,
					 coalesce(lead(con2.expensevalue) over (), 0) as lastExpenseValue,
				     coalesce(lead(con2.expensevalue) over (), 0) - con2.expensevalue as diffLastExpenseValue,
					 case
	   					when coalesce(lead(con2.expensevalue) over (), 0) <> 0 then
	   						round((con2.expensevalue - coalesce(lead(con2.expensevalue) over (), 0))/con2.expensevalue * 100, 2)
	   					else 0
					 end as percLastExpense
				from (
 					select con1.*
					  from (
	  					select (DATE_TRUNC('month', CURRENT_DATE))::date as firstOfMonth, 
							   coalesce(sum(t.value), 0) as expenseValue
					      from tb_transaction t
						 where t.is_debit = true
					       and t.first_of_month = (DATE_TRUNC('month', CURRENT_DATE))::date
						union 
						select (DATE_TRUNC('month', CURRENT_DATE) - INTERVAL '1 month')::date as firstOfMonth, 
							   coalesce(sum(t.value), 0) as expenseValue
						  from tb_transaction t
						 where t.is_debit = true
						   and t.first_of_month = (DATE_TRUNC('month', CURRENT_DATE) - INTERVAL '1 month')::date
					) con1
					order by con1.firstOfMonth desc
			) con2"
        ).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<GetRevenueLastAndCurrentMonthQueryResponse>> GetRevenueLastAndCurrentMonthAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Database.SqlQueryRaw<GetRevenueLastAndCurrentMonthQueryResponse>(
            @"select con2.firstofmonth,
   					 con2.revenueValue,
					 coalesce(lead(con2.revenueValue) over (), 0) as lastRevenueValue,
				     con2.revenueValue - coalesce(lead(con2.revenueValue) over (), 0) diffLastRevenueValue,
					 case
	   					when coalesce(lead(con2.revenueValue) over (), 0) <> 0 then
	   						round((con2.revenueValue - coalesce(lead(con2.revenueValue) over (), 0))/con2.revenueValue * 100, 2)
	   					else 0
					 end as percLastRevenue
				from (
 					select con.*
					  from (
	  					select (DATE_TRUNC('month', CURRENT_DATE))::date as firstOfMonth, 
							   coalesce(sum(t.value), 0) as revenueValue
					      from tb_transaction t
						 where t.is_debit = false
					       and t.first_of_month = (DATE_TRUNC('month', CURRENT_DATE))::date
						union 
						select (DATE_TRUNC('month', CURRENT_DATE) - INTERVAL '1 month')::date as firstOfMonth, 
							   coalesce(sum(t.value), 0) as revenueValue
						  from tb_transaction t
						 where t.is_debit = false
						   and t.first_of_month = (DATE_TRUNC('month', CURRENT_DATE) - INTERVAL '1 month')::date
					) con
					order by con.firstOfMonth desc 
			) con2"
        ).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<GetBiggerRevenueLastAndCurrentMonthQueryResponse>> GetBiggerTransactionLastAndCurrentMonthAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Database.SqlQueryRaw<GetBiggerRevenueLastAndCurrentMonthQueryResponse>(
            @"select con1.firstofmonth,
					con1.category,
					con1.value,
					coalesce(lag(con1.value) over (), 0) as lastValue,
					coalesce(lag(con1.value) over (), 0) - con1.value as diffValue,
					case
					  when coalesce(lag(con1.value) over (), 0) <> 0 then
						round((con1.value - coalesce(lag(con1.value) over (), 0))/con1.value * 100, 2)
					  else 0
					end as percValue
				from (select con.* 
						from (select t.first_of_month as firstOfMonth,
			   						 c.description as category,
			   						 sum(t.value) as value
								from tb_transaction t
							left join tb_category c on (c.""Id"" = t.category_id)
								where t.is_debit = true
								and t.first_of_month = (DATE_TRUNC('month', CURRENT_DATE))::date
							group by t.first_of_month, c.description
							order by 3
							limit 1
					) con
					union
					select con.* 
						from (select t.first_of_month as firstOfMonth,
			   						 c.description as category,
									 sum(t.value) as value
								from tb_transaction t
							left join tb_category c on (c.""Id"" = t.category_id)
								where t.is_debit = true
								and t.first_of_month = (DATE_TRUNC('month', CURRENT_DATE) - INTERVAL '1 month')::date
							group by t.first_of_month, c.description
							order by 3
							limit 1
					) con
			) con1
			order by con1.firstOfMonth desc"
        ).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<GetTransactionsCategoryMonthlyByYearQueryResponse>> GetTransactionsCategoryMonthlyByYearAsync(int year, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Database.SqlQueryRaw<GetTransactionsCategoryMonthlyByYearQueryResponse>(
            @"select t.first_of_month as firstOfMonth,
					 c.description as category,
				     sum(t.value) as sumValue
				from tb_transaction t
			  left join tb_category c on (c.""Id"" = t.category_id)
			   where t.is_debit = true
				 and extract(year from t.first_of_month) = :year
			  group by t.first_of_month, c.description",
			new NpgsqlParameter("year", year)
        ).ToListAsync(cancellationToken: cancellationToken);
    }
}	
