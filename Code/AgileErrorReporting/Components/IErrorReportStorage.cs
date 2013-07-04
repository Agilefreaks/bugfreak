namespace AgileErrorReporting.Components
{
    public interface IErrorReportStorage
    {
        bool TryStore(ErrorReport report);
    }
}