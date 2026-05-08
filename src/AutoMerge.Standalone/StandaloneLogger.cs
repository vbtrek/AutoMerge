using System;

namespace AutoMerge
{
    /// <summary>
    /// Standalone logger implementation that writes to console or debug output
    /// </summary>
    public class StandaloneLogger : LoggerBase
    {
        protected override void WriteMessage(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
            Console.WriteLine(message);
        }
    }
}
