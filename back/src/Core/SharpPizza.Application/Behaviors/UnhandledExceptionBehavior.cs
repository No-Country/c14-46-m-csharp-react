using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace SharpPizza.Application.Behaviors
{
    public class UnhandledExceptionBehavior<TRequest, TResponse>
                            : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
        }
        
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
                try
                {
                    return await next();
                }
                catch(Exception ex)
                {
                    var requestName = typeof(TRequest).Name;
                    _logger.LogError(ex, "Application Request: Sucedio una exception para el request {Name} {@Request}", requestName, request);
                    throw new Exception("Application Request con Errores");
                }
        }
    }
}