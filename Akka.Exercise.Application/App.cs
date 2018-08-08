using Akka.Actor;
using Autofac;

namespace Akka.Exercise.Application
{
    public class App
    {
        public IContainer Container { get; private set; }

        public ActorSystem AkkaSystem => Container.Resolve<ActorSystem>();

        private readonly string _appName;
        public App()
        { }

        public App(string appName)
        {
            _appName = appName;
        }

        protected virtual void PreStart()
        { }
        
        public void Start()
        {
            PreStart();
            //TODO: Start
            var containerBuilder = new ContainerBuilder();
            ConfigureServices(containerBuilder);
            Container = containerBuilder.Build();
            PostStart();
        }

        protected virtual void PostStart()
        { }

        protected virtual void PreConfigureServices(ContainerBuilder containerBuilder)
        {  }

        protected void ConfigureServices(ContainerBuilder containerBuilder)
        {
            PreConfigureServices(containerBuilder);

            containerBuilder.RegisterInstance(ActorSystem.Create(_appName));

            PostConfigureServices(containerBuilder);
        }

        protected virtual void PostConfigureServices(ContainerBuilder containerBuilder)
        { }
    }
}
