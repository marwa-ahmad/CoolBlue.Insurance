using Insurance.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;

namespace Insurance.Api
{
    /// <summary>
    /// Custom exception handling middleware
    /// reference: https://weblog.west-wind.com/posts/2016/oct/16/error-handling-and-exceptionfilter-dependency-injection-for-aspnet-core-apis
    /// </summary>
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;
        private IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        
        public ApiExceptionFilter(ILogger logger)
        {
            _logger = logger;
            InitializeExceptionHandlers();
        }

        private void InitializeExceptionHandlers()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>()
            {
                { typeof(ProductTypeNotFoundException), HandleProductTypeNotFoundException},
                { typeof(ProductNotFoundException), HandleProductNotFoundException},
                { typeof(SurchargeRateProductTypeNotFoundException), HandleSurchargeRateProductTypeNotFoundException},
                { typeof(ProductTypeAlreadyHasSurchargeRateException), HandleProductTypeAlreadyHasSurchargeRateException},
                { typeof(CreateSurchareRateException), HandleCreateSurchareRateException}

            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandelException(context);
            base.OnException(context);
        }

        private void HandelException(ExceptionContext context)
        {
            Type exceptionType = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(exceptionType))
            {
                _exceptionHandlers[exceptionType].Invoke(context);
                return;
            }
            HandleOtherExceptionTypes(context);
        }

        private void HandleProductTypeNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as ProductTypeNotFoundException;
            _logger.LogException(exception, exception.Message);

            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status204NoContent,
                Title = $"Opps!!{exception.Message}"
            };
            context.Result = new ObjectResult(customResultObject);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        private void HandleProductNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as ProductNotFoundException;
            _logger.LogException(exception, exception.Message);

            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status204NoContent,
                Title = $"Opps!!{exception.Message}"
            };
            context.Result = new ObjectResult(customResultObject);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        private void HandleSurchargeRateProductTypeNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as SurchargeRateProductTypeNotFoundException;
            _logger.LogException(exception, exception.Message);

            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status204NoContent,
                Title = $"Opps!! {exception.Message}"
            };
            context.Result = new ObjectResult(customResultObject);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        private void HandleCreateSurchareRateException(ExceptionContext context)
        {
            var exception = context.Exception as CreateSurchareRateException;
            _logger.LogException(exception, exception.Message);

            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status204NoContent,
                Title = $"Opps!! {exception.Message}"
            };
            context.Result = new ObjectResult(customResultObject);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        private void HandleProductTypeAlreadyHasSurchargeRateException(ExceptionContext context)
        {
            var exception = context.Exception as ProductTypeAlreadyHasSurchargeRateException;
            _logger.LogException(exception, exception.Message);

            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = $"Opps!! {exception.Message}"
            };
            context.Result = new ObjectResult(customResultObject);

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.ExceptionHandled = true;
        }

        private void HandleOtherExceptionTypes(ExceptionContext context)
        {
            if (context.Exception is AggregateException)
            {
                foreach (var innerException in ((AggregateException)(context.Exception)).Flatten().InnerExceptions)
                {
                    _logger.LogException(innerException, innerException.Message);
                }
            }
            else
            {
                _logger.LogException(context.Exception, context.Exception.Message);
            }
            
            var customResultObject = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Opps!! An error happended while processing the request."
            };
            context.Result = new ObjectResult(customResultObject);
            context.ExceptionHandled = true;
        }
    }
}
