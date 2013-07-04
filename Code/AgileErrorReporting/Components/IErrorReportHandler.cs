using System;

namespace AgileErrorReporting.Components
{
    public interface IErrorReportHandler : IDisposable
    {
        event EventHandler HandleComplete;

        void Handle(ErrorReport errorReport);
    }
}
