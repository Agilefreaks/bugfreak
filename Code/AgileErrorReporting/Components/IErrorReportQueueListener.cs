using System;

namespace AgileErrorReporting.Components
{
    public interface IErrorReportQueueListener : IDisposable
    {
        void Listen(IErrorReportQueue reportQueue);
    }
}