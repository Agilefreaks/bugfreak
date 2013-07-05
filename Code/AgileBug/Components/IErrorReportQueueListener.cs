using System;

namespace AgileBug.Components
{
    public interface IErrorReportQueueListener : IDisposable
    {
        void Listen(IErrorReportQueue reportQueue);
    }
}