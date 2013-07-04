using System.Windows;
using System.Windows.Threading;

namespace AgileErrorReporting.WPF
{
    public class AgileReporter
    {
        public static void Hook()
        {
            var app = Application.Current;

            AgileErrorReporting.AgileReporter.Init();
            app.Exit += OnExit;
            app.DispatcherUnhandledException += OnException;
        }

        private static void OnException(object sender, DispatcherUnhandledExceptionEventArgs eventArgs)
        {
            AgileErrorReporting.AgileReporter.Instance.BeginReport(eventArgs.Exception);
            
            eventArgs.Handled = true;
        }

        private static void OnExit(object sender, ExitEventArgs exitEventArgs)
        {
            var app = Application.Current;

            app.DispatcherUnhandledException -= OnException;
            app.Exit -= OnExit;
            AgileErrorReporting.AgileReporter.Dispose();
        }
    }
}
