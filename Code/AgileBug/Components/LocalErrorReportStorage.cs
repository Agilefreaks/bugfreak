namespace AgileBug.Components
{
    public class LocalErrorReportStorage : ILocalErrorReportStorage
    {
        public bool TryStore(ErrorReport report)
        {
            return true;
        }
    }
}