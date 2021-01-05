using System;
using System.Runtime.CompilerServices;

namespace Insurance.Common
{
    /// <summary>
    /// The logger which will be injected into insurance layers' classes
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        /// <param name="memberName">filled automatically which indicates what was the caller method </param>
        /// <param name="sourceFilePath">filled automatically which indicates what was the source file</param>
        /// <param name="sourceLineNumber">filled automatically which indicates what was the line number</param>
        void LogException(Exception exception, string message, 
            [CallerMemberName] string memberName = "", 
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        void LogInformation(string message);

        void LogError(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "");
    }
}
