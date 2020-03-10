using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Emit;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace StudentsEnrollmentsDemo.Handlers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public virtual Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            if (context.ExceptionContext.CatchBlock.IsTopLevel)
            {
                return HandleAsyncCore(context, cancellationToken);
            }
            else
            {
                return Task.FromResult(0);
            }
        }

        public virtual Task HandleAsyncCore(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            HandleCore(context);
            return Task.FromResult(0);
        }

        public virtual void HandleCore(ExceptionHandlerContext context)
        {
            System.Diagnostics.Debug.Print("Exception Handler ========> Can send message to App Insights here");
        }
    }
}