using System;
using System.IO;
using System.Threading.Tasks;

namespace Akka.Exercise.Application.Services.Downloader.Messages
{
   public class DownloadStarted
    {
        public Uri DownloadUrl { get; }
        public DownloadStarted(Uri downloadUrl)
        {
            DownloadUrl = downloadUrl;
        }
    }

    public class DownloadProgess
    {
        public Uri DownloadUrl { get; }
        public long BytesReceived { get;}
        public long TotalBytes { get; }
        public double Progess => 
            (((double)BytesReceived / (double)TotalBytes) * 100) ;
        public DownloadProgess(Uri downloadUrl,long bytesReceived,long totalBytes)
        {
            DownloadUrl = downloadUrl;
            BytesReceived = bytesReceived;
            TotalBytes = totalBytes;
        }
    }

    public class StreamProcess
    {
        public Task<Stream> Stream { get; }
        public long BytesReceived { get; }
        public long TotalBytes { get; }
        public int Progess => (int)(BytesReceived / TotalBytes) * 100;
        public Exception Exception { get; }

        public StreamProcess(Exception exception)
        {
            Exception = exception;
        }
        public StreamProcess(Task<Stream> stream, long bytesReceived, long totalBytes)
        {
            Stream = stream;
            BytesReceived = bytesReceived;
            TotalBytes = totalBytes;
        }
    }

    public class ContinueStreamDownload
    {
        public Stream Stream { get; }
        public long BytesReceived { get; }
        public long TotalBytes { get; }
        public int Progess => (int) (BytesReceived / TotalBytes) * 100;
            
        public ContinueStreamDownload(Stream stream, long bytesReceived, long totalBytes)
        {
            Stream = stream;
            BytesReceived = bytesReceived;
            TotalBytes = totalBytes;
        }
    }

    public class DownloadCompleted
    {
        public Uri DownloadUrl { get; }
        public string DownloadedPath { get; }
        public DownloadCompleted(Uri downloadUrl,string downloadedPath)
        {
            DownloadUrl = downloadUrl;
            DownloadedPath = downloadedPath;
        }
    }
}