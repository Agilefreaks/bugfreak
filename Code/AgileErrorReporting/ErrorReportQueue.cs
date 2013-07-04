using AgileErrorReporting.Collections;

namespace AgileErrorReporting
{
    public class ErrorReportQueue : ObservableList<ErrorReport>, IErrorReportQueue
    {
        public void Enqueue(ErrorReport errorReport)
        {
            Add(errorReport);
        }
    }
}
