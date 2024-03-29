﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using CA41;

namespace CA41
{
    public static class NorthwindContextProceduresExtensions
    {
        public static NorthwindContextProcedures GetProcedures(this NorthwindContext context)
        {
            return new NorthwindContextProcedures(context);
        }
    }

    public partial class NorthwindContextProcedures
    {
        private readonly NorthwindContext _context;

        public NorthwindContextProcedures(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<SalesbyYearResult[]> SalesbyYearAsync(DateTime? Beginning_Date, DateTime? Ending_Date, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Beginning_Date",
                    Value = Beginning_Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "Ending_Date",
                    Value = Ending_Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<SalesbyYearResult>("EXEC @returnValue = [dbo].[Sales by Year] @Beginning_Date, @Ending_Date", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
