using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem


namespace NSExt;

public static class LoggerExtensions
{
    private static string CallerInfoMessage(object message,
                                            string callerName,
                                            string callerFilePath,
                                            int    callerLineNumber)
    {
        return
            $"{message} <s:{Thread.CurrentThread.ManagedThreadId}#{callerName}@{Path.GetFileName(callerFilePath)}:{callerLineNumber}>";
    }

    public static void Debug(this ILogger              me,
                             object                    message,
                             [CallerMemberName] string callerName       = null,
                             [CallerFilePath]   string callerFilePath   = null,
                             [CallerLineNumber] int    callerLineNumber = 0)
    {
        me.LogDebug(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber));
    }


    public static void Error(this ILogger              me,
                             object                    message,
                             Exception                 ex               = null,
                             [CallerMemberName] string callerName       = null,
                             [CallerFilePath]   string callerFilePath   = null,
                             [CallerLineNumber] int    callerLineNumber = 0)
    {
        if (ex is null)
            me.LogError(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber));
        else
            me.LogError(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber), ex);
    }

    public static void Fatal(this ILogger              me,
                             object                    message,
                             Exception                 ex               = null,
                             [CallerMemberName] string callerName       = null,
                             [CallerFilePath]   string callerFilePath   = null,
                             [CallerLineNumber] int    callerLineNumber = 0)
    {
        if (ex is null)
            me.LogCritical(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber));
        else
            me.LogCritical(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber), ex);
    }


    public static void Info(this ILogger              me,
                            object                    message,
                            [CallerMemberName] string callerName       = null,
                            [CallerFilePath]   string callerFilePath   = null,
                            [CallerLineNumber] int    callerLineNumber = 0)
    {
        me.LogInformation(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber));
    }

    public static void Warn(this ILogger              me,
                            object                    message,
                            [CallerMemberName] string callerName       = null,
                            [CallerFilePath]   string callerFilePath   = null,
                            [CallerLineNumber] int    callerLineNumber = 0)
    {
        me.LogWarning(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber));
    }
}
