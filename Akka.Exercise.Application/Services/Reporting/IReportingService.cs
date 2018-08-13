using System.Threading.Tasks;
using Akka.Actor;
using Akka.Exercise.Application.Services.Reporting.Messages;

namespace Akka.Exercise.Application.Services.Reporting
{
    public interface IReportingService
    {
        void Report(ReportMessage reportMessage, IActorRef sender = null);
    }
}