using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace StudentsEnrollmentsDemo.Handlers
{
    public class GlobalExceptionLogger : IExceptionLogger
    {
        public virtual Task LogAsync(ExceptionLoggerContext context,
                                 CancellationToken cancellationToken)
        {
            if (context.ExceptionContext.CatchBlock.IsTopLevel)
            {
                return LogAsyncCore(context, cancellationToken);
            }
            else
            {
                return Task.FromResult(0);
            }
        }

        public virtual Task LogAsyncCore(ExceptionLoggerContext context,
                                         CancellationToken cancellationToken)
        {
            LogCore(context);
            return Task.FromResult(0);
        }

        public virtual void LogCore(ExceptionLoggerContext context)
        {
            System.Diagnostics.Debug.Print("Exception Logger ========> "+context.ExceptionContext.Exception.ToString());
        }

    }
}