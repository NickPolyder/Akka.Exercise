using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Exercise.Application.Services.Downloader;
using Akka.Exercise.Application.Services.Downloader.Messages;

namespace Akka.Exercise.Console
{
    class Program
    {
        private static ActorSystem _actorSystem;
        static void Main(string[] args)
        {
            _actorSystem = ActorSystem.Create("MySystem");
            var dummyActor = _actorSystem.ActorOf(DummyActor.CreateProps());
            var downloadActor = _actorSystem.ActorOf(FileDownloaderActor.CreateProps());
            
            downloadActor.Tell(new DownloadRequest(new Uri("http://simple-site.local/CQRSlite.zip")),dummyActor);
            System.Console.WriteLine("To exit press any key.");
            System.Console.ReadKey();

            _actorSystem.Terminate();
            _actorSystem.WhenTerminated.GetAwaiter().GetResult();
        }
    }
}
