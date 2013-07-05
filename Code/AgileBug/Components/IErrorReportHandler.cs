using System;

namespace AgileBug.Components
{
    public interface IErrorReportHandler : IDisposable
    {
        event EventHandler HandleComplete;

        void Handle(ErrorReport errorReport);
    }
}
