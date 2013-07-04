namespace AgileErrorReporting
{
    public interface IErrorReportSerializer
    {
        string Serialize(ErrorReport report);
    }
}
