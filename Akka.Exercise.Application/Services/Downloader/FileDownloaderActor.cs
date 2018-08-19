using Akka.Actor;
using Akka.Exercise.Application.Services.Downloader.Messages;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Akka.Exercise.Application.Services.Downloader
{
    public class FileDownloaderActor : ReceiveActor, IWithUnboundedStash
    {
        private IActorRef _actorRequestedDownload;
        private Uri _downloadingUri;
        private HttpClient _httpClient;

        public IStash Stash { get; set; }

        public FileDownloaderActor()
        {
            _httpClient = new HttpClient();
            Become(Idle);
        }

        protected override void PreRestart(Exception reason, object message)
        {
            Stash.UnstashAll();
            base.PreRestart(reason, message);
        }

        public void Idle()
        {
            Receive<DownloadRequest>(req => OnDownloadRequest(req));
        }

        private void OnDownloadRequest(DownloadRequest req)
        {
            _actorRequestedDownload = Sender;
            _downloadingUri = req.DownloadUri;
            BecomeStacked(Downloading);
            _httpClient
                .GetAsync(_downloadingUri, HttpCompletionOption.ResponseHeadersRead)
                .ContinueWith(task =>
                {
                    try
                    {
                        var response = task.Result;
                        response.EnsureSuccessStatusCode();
                        var contentLength = response.Content.Headers.ContentLength.GetValueOrDefault();
                        var stream =  response.Content.ReadAsStreamAsync();
                        return new StreamProcess(stream, 0, contentLength);
                    }
                    catch (Exception ex) 
                    {
                        return new StreamProcess(ex);
                    }

                }).PipeTo(Self);
        }
        
        public void Downloading()
        {
            Receive<DownloadRequest>(req => Stash.Stash());
            Receive<StreamProcess>(req => OnStreamProcess(req));
            Receive<ContinueStreamDownload>(req => OnStreamDownload(req));
            Receive<DownloadCompleted>(message => { OnCompleteMessage(message); });
        }
        
        public void OnStreamProcess(StreamProcess message)
        {
            if (message.Exception != null)
            {
                _actorRequestedDownload.Tell(new ErrorMessage(Self,message.Exception));
                RevertProcess();
                return;
            }

            message.Stream
                .ContinueWith(tsk => new ContinueStreamDownload(tsk.Result, message.BytesReceived, message.TotalBytes))
                .PipeTo(Self);
        }

        public void OnStreamDownload(ContinueStreamDownload message)
        {
            byte[] buffer = new byte[4096];
            int totalBytes = (int)message.TotalBytes;
            int bytesReceived = (int)message.BytesReceived;
            using (var writer = System.IO.File.OpenWrite("C:\\Repos\\downloaded.zip"))
            {
                do
                {
                    // Read may return anything from 0 to 10.
                    int actualBytesRead = message.Stream.Read(buffer, 0, buffer.Length - 1);
                    writer.Write(buffer, 0, actualBytesRead);
                    bytesReceived += actualBytesRead;
                    totalBytes -= actualBytesRead;
                    _actorRequestedDownload.Tell(new DownloadProgess(_downloadingUri, bytesReceived, message.TotalBytes));

                } while (totalBytes > 0);
            }
            message.Stream.Close();
            Self.Tell(new DownloadCompleted(_downloadingUri, "C:\\Repos\\downloaded.zip"), _actorRequestedDownload);
        }

        private void OnCompleteMessage(DownloadCompleted message)
        {
            _actorRequestedDownload.Tell(message);
            RevertProcess();
        }

        private void RevertProcess()
        {
            _actorRequestedDownload = null;
            UnbecomeStacked();
            Stash.UnstashAll();
        }

        public static Props CreateProps() => Props.Create<FileDownloaderActor>();
    }
}