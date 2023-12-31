﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProvaPowerTools.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace ProvaPowerTools.Models
{
    public partial class AziendaContext
    {
        private IAziendaContextProcedures _procedures;

        public virtual IAziendaContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new AziendaContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public IAziendaContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<getTotalePerAnnoResult>().HasNoKey().ToView(null);
        }
    }

    public partial class AziendaContextProcedures : IAziendaContextProcedures
    {
        private readonly AziendaContext _context;

        public AziendaContextProcedures(AziendaContext context)
        {
            _context = context;
        }

        public virtual async Task<List<getTotalePerAnnoResult>> getTotalePerAnnoAsync(int? anno, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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
                    ParameterName = "anno",
                    Value = anno ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<getTotalePerAnnoResult>("EXEC @returnValue = [dbo].[getTotalePerAnno] @anno", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<int> getTotalePerAnno2Async(int? anno, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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
                    ParameterName = "anno",
                    Value = anno ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[getTotalePerAnno2] @anno", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
