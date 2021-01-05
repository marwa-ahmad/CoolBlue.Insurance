using System;
using System.Runtime.CompilerServices;

namespace Insurance.Common
{
    /// <summary>
    /// Logger which uses Serilog for logging
    /// </summary>
    public class SerilogLogger : ILogger
    {
        private Serilog.ILogger logger;
        public SerilogLogger(Serilog.ILogger serilogLogger)
        {
            logger = serilogLogger;
        }

        public void LogException(Exception exception, string message = "", 
            [CallerMemberName] string memberName = "", 
            [CallerFilePath] string sourceFilePath = "", 
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            var customMessage =
                $"CallerMemberName: [{memberName}].{Environment.NewLine}" +
                $"CallerFilePath: [{sourceFilePath}].{Environment.NewLine}" +
                $"CallerLineNumber: [{sourceLineNumber}].{Environment.NewLine}" +
                $"Message: [{message}]";

            logger.Error(exception, customMessage);
        }

        public void LogInformation(string message)
        {
            logger.Information(message);
        }

        public void LogError(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            var customMessage =
                $"CallerMemberName: [{memberName}].{Environment.NewLine}" +
                $"CallerFilePath: [{sourceFilePath}].{Environment.NewLine}" +
                $"Error: [{message}]";

            logger.Error(customMessage);
        }
    }
}
