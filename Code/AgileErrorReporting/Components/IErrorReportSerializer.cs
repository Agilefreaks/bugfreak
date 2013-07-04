namespace AgileErrorReporting.Components
{
    public interface IErrorReportSerializer
    {
        string Serialize(ErrorReport report);
    }
}
