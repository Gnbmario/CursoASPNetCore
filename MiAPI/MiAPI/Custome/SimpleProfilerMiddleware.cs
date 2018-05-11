using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MiAPI.Custome
{
    public class SimpleProfilerMiddleware
    {
        private RequestDelegate _next;
        private ILogger _logger;

        public SimpleProfilerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("Profiler");
        }

        public async Task Invoke(HttpContext context)
        {
            var watch = Stopwatch.StartNew();
            await _next(context);

            var path = context.Response.StatusCode;
            var statusCode = context.Response.StatusCode;
            var logString = $"Path= '{path}', status = {statusCode}, time = {watch.Elapsed}";

            _logger.LogInformation(logString);
        }
    }

}
