using System;
using Akka.Actor;
using Akka.Exercise.Application.Services.Downloader.Messages;

namespace Akka.Exercise.Console
{
    public class DummyActor:ReceiveActor
    {
        public DummyActor()
        {
            Receive<DownloadStarted>(started => System.Console.WriteLine($"Download Started: {started.DownloadUrl}"));

            Receive<DownloadProgess>(progess => 
                System.Console.WriteLine($"Download Progress: {progess.DownloadUrl}" +
                                                                         $"{Environment.NewLine}" +
                                                                         $"Progress: {progess.Progess}%{Environment.NewLine}" +
                                                                         $"Bytes Received: {progess.BytesReceived}{Environment.NewLine}" +
                                                                         $"Bytes Total:    {progess.TotalBytes}"));

            Receive<DownloadCompleted>(completed => System.Console.WriteLine($"Download Completed: {completed.DownloadUrl}" +
                                                                             $"{Environment.NewLine}" +
                                                                             $"File: {completed.DownloadedPath}"));
        }



        public static Props CreateProps() => Props.Create(() => new DummyActor());
    }
}