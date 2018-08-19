using System;

namespace Akka.Exercise.Application.Services.Downloader.Messages
{
    public class DownloadRequest
    {
        public Uri DownloadUri { get; }
        public DownloadRequest(Uri downloadUri)
        {
            DownloadUri = downloadUri;
        }
    }
}