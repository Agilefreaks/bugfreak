namespace AgileErrorReporting.Components
{
    public interface IErrorReportQueue
    {
        void Enqueue(ErrorReport errorReport);
    }
}