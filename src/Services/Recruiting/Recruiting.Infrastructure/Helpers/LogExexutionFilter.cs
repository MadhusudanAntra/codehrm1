using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Recruiting.Infrastructure.Helpers;

public class LogExecutionTimeFilter : IActionFilter
{
    private readonly ILogger<LogExecutionTimeFilter> _logger;
    private readonly Stopwatch _stopwatch;

    public LogExecutionTimeFilter(ILogger<LogExecutionTimeFilter> logger)
    {
        _logger = logger;
        _stopwatch = new Stopwatch();
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch.Start();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();
        var elapsedTime = _stopwatch.ElapsedMilliseconds;
        var controllerName = context.RouteData.Values["controller"].ToString();
        var actionName = context.RouteData.Values["action"].ToString();
        _logger.LogInformation("Action {ActionName} in controller {ControllerName} took {ElapsedTime} ms to execute.", actionName, controllerName, elapsedTime);
    }
}