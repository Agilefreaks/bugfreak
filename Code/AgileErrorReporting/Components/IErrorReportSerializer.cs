namespace AgileErrorReporting.Components
{
    public interface IErrorReportSerializer
    {
        string GetContentType();

        string Serialize(ErrorReport report);
    }
}
