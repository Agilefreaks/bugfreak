using System.Text;

namespace AgileErrorReporting.Components
{
    public class FormErrorReportSerializer : IErrorReportSerializer
    {
        private const string Format = "{0}={1}";
        private const string Separator = "&";

        public string Serialize(ErrorReport report)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(string.Format(Format, "message", report.Message));
            stringBuilder.Append(Separator);
            stringBuilder.Append(string.Format(Format, "source", report.Source));
            stringBuilder.Append(Separator);
            stringBuilder.Append(string.Format(Format, "stackTrace", report.StackTrace));

            foreach (var data in report.AdditionalData)
            {
                stringBuilder.Append(Separator);
                stringBuilder.Append(string.Format(Format, data.Key, data.Value));
            }

            return stringBuilder.ToString();
        }
    }
}