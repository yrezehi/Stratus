using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;

namespace Static.Configurations.Interceptors
{

    // ref https://stackoverflow.com/questions/73469589/how-to-get-table-name-from-idbcommandinterceptor-in-entityframework
    public class LoggingInterceptor : DbCommandInterceptor
    {
        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext) { }
    }
}
