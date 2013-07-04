using AgileErrorReporting.Collections;

namespace AgileErrorReporting.Components
{
    public class ErrorReportQueue : ObservableList<ErrorReport>, IErrorReportQueue
    {
        public void Enqueue(ErrorReport errorReport)
        {
            Add(errorReport);
        }
    }
}
