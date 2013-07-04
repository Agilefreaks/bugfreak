namespace AgileErrorReporting
{
    public interface IErrorReportQueue
    {
        void Enqueue(ErrorReport errorReport);
    }
}