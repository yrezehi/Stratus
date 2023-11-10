using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace Static.Configuration.Interceptors
{
    public class LoggingInterceptor : DbCommandInterceptor
    {
        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Log.Info(String.Format(command.CommandText));
        }
    }
}
