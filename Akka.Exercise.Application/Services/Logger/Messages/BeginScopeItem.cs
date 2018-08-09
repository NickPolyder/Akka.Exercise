namespace Akka.Exercise.Application.Services.Logger.Messages
{
    public class BeginScopeItem 
    {
        public object State { get; }

        public BeginScopeItem(object state)
        {
            State = state;
        }


    }
}