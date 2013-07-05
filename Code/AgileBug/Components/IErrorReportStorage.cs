namespace AgileBug.Components
{
    public interface IErrorReportStorage
    {
        bool TryStore(ErrorReport report);
    }
}