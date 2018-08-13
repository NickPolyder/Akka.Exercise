namespace Akka.Exercise.Application.Options
{
    public class LoggingOptions
    {
        public string ActorSelectionUrl { get; set; }



        public static LoggingOptions Default()
        {
            return new LoggingOptions
            {
                ActorSelectionUrl = "/logging"
            };
        }
    }
}