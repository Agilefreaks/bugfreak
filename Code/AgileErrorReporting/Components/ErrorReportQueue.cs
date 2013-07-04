using System.Linq;
using AgileErrorReporting.Collections;

namespace AgileErrorReporting.Components
{
    public class ErrorReportQueue : ObservableList<ErrorReport>, IErrorReportQueue
    {
        public void Enqueue(ErrorReport errorReport)
        {
            Add(errorReport);
        }

        public ErrorReport Dequeue()
        {
            var item = this.FirstOrDefault();

            if (item != null)
            {
                Remove(item);
            }

            return item;
        }
    }
}
