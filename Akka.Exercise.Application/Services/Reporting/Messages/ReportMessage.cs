using System;

namespace Akka.Exercise.Application.Services.Reporting.Messages
{
    public class ReportMessage
    {
        public Guid RequestId { get; }

        public string Source { get; }
        public long ReceivedBytes { get; }
        public long TotalBytes { get; }
        public ReportMessage(string source,long receivedBytes,long totalBytes):this(Guid.NewGuid(),source,receivedBytes,totalBytes)
        { }

        public ReportMessage(Guid requestId,string source, long receivedBytes, long totalBytes)
        {
            RequestId = requestId;
            Source = source;
            ReceivedBytes = receivedBytes;
            TotalBytes = totalBytes;

        }
    }
}