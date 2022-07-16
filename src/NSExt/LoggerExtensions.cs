// @program: NSExt
// @file: LoggerExtensions.cs
// @author: tao ke
// @mailto: taokeu@gmail.com
// @created: 07/15/2022 20:36

using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

// ReSharper disable UnusedMember.Global

namespace NSExt;

public static class LoggerExtensions
{
    private static string CallerInfoMessage(object message,
                                            string callerName,
                                            string callerFilePath,
                                            int    callerLineNumber)
    {
        return
            $"[{Thread.CurrentThread.ManagedThreadId}#{callerName}@{Path.GetFileName(callerFilePath)}:{callerLineNumber}] {message}";
    }

    public static void Debug(this ILogger              me,
                             object                    message,
                             [CallerMemberName] string callerName       = null,
                             [CallerFilePath]   string callerFilePath   = null,
                             [CallerLineNumber] int    callerLineNumber = 0)
    {
        // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
        me.LogDebug(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber));
    }


    public static void Error(this ILogger              me,
                             object                    message,
                             [CallerMemberName] string callerName       = null,
                             [CallerFilePath]   string callerFilePath   = null,
                             [CallerLineNumber] int    callerLineNumber = 0)
    {
        // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
        me.LogError(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber));
    }

    public static void Fatal(this ILogger              me,
                             object                    message,
                             [CallerMemberName] string callerName       = null,
                             [CallerFilePath]   string callerFilePath   = null,
                             [CallerLineNumber] int    callerLineNumber = 0)
    {
        // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
        me.LogCritical(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber));
    }


    public static void Info(this ILogger              me,
                            object                    message,
                            [CallerMemberName] string callerName       = null,
                            [CallerFilePath]   string callerFilePath   = null,
                            [CallerLineNumber] int    callerLineNumber = 0)
    {
        // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
        me.LogInformation(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber));
    }

    public static void Warn(this ILogger              me,
                            object                    message,
                            [CallerMemberName] string callerName       = null,
                            [CallerFilePath]   string callerFilePath   = null,
                            [CallerLineNumber] int    callerLineNumber = 0)
    {
        // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
        me.LogWarning(CallerInfoMessage(message, callerName, callerFilePath, callerLineNumber));
    }
}
