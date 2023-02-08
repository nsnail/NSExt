// ReSharper disable TemplateIsNotCompileTimeConstantProblem

namespace NSExt.Extensions;

/// <summary>
///     LoggerExtensions
/// </summary>
public static class LoggerExtensions
{
    private const string _MESSAGE_S_THREADID_CALLERNAME_CALLERFILEPATH_CALLERLINENUMBER
        = "{Message} <s:{CallerName}@{CallerFilePath}:{CallerLineNumber}>";

    private static readonly Action<ILogger, string, string, string, string, Exception> _logDebug
        = LoggerMessage.Define<string, string, string, string>(LogLevel.Debug, default
                                                             , _MESSAGE_S_THREADID_CALLERNAME_CALLERFILEPATH_CALLERLINENUMBER);

    private static readonly Action<ILogger, string, string, string, string, Exception> _logError
        = LoggerMessage.Define<string, string, string, string>(LogLevel.Error, default
                                                             , _MESSAGE_S_THREADID_CALLERNAME_CALLERFILEPATH_CALLERLINENUMBER);

    private static readonly Action<ILogger, string, string, string, string, Exception> _logFatal
        = LoggerMessage.Define<string, string, string, string>(LogLevel.Critical, default
                                                             , _MESSAGE_S_THREADID_CALLERNAME_CALLERFILEPATH_CALLERLINENUMBER);

    private static readonly Action<ILogger, string, string, string, string, Exception> _logInfo
        = LoggerMessage.Define<string, string, string, string>(LogLevel.Information, default
                                                             , _MESSAGE_S_THREADID_CALLERNAME_CALLERFILEPATH_CALLERLINENUMBER);

    private static readonly Action<ILogger, string, string, string, string, Exception> _logWarn
        = LoggerMessage.Define<string, string, string, string>(LogLevel.Warning, default
                                                             , _MESSAGE_S_THREADID_CALLERNAME_CALLERFILEPATH_CALLERLINENUMBER);

    /// <summary>
    ///     Debug
    /// </summary>
    public static void Debug(this             ILogger me, object message, [CallerMemberName] string callerName = null
                           , [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
    {
        _logDebug(me, message.ToString(), callerName, Path.GetFileName(callerFilePath)
            ,         callerLineNumber.ToString(CultureInfo.InvariantCulture), null);
    }

    /// <summary>
    ///     Error
    /// </summary>
    public static void Error(this             ILogger me, object message, [CallerMemberName] string callerName = null
                           , [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
    {
        _logError(me, message.ToString(), callerName, Path.GetFileName(callerFilePath)
            ,         callerLineNumber.ToString(CultureInfo.InvariantCulture), null);
    }

    /// <summary>
    ///     Fatal
    /// </summary>
    public static void Fatal(this               ILogger me, object message, Exception ex = null
                           , [CallerMemberName] string  callerName = null, [CallerFilePath] string callerFilePath = null
                           , [CallerLineNumber] int     callerLineNumber = 0)
    {
        _logFatal(me, message.ToString(), callerName, Path.GetFileName(callerFilePath)
            ,         callerLineNumber.ToString(CultureInfo.InvariantCulture), ex);
    }

    /// <summary>
    ///     Info
    /// </summary>
    public static void Info(this             ILogger me, object message, [CallerMemberName] string callerName = null
                          , [CallerFilePath] string  callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
    {
        _logInfo(me, message.ToString(), callerName, Path.GetFileName(callerFilePath)
           ,         callerLineNumber.ToString(CultureInfo.InvariantCulture), null);
    }

    /// <summary>
    ///     Warn
    /// </summary>
    public static void Warn(this             ILogger me, object message, [CallerMemberName] string callerName = null
                          , [CallerFilePath] string  callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0)
    {
        _logWarn(me, message.ToString(), callerName, Path.GetFileName(callerFilePath)
           ,         callerLineNumber.ToString(CultureInfo.InvariantCulture), null);
    }
}