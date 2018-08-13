using System;
using Akka.Actor;
using Akka.Exercise.Application.Options;
using Akka.Exercise.Application.Services.Logger;
using Autofac;

namespace Akka.Exercise.Application
{
    public class App : IDisposable
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

        #region Start

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

        #endregion

        #region Configuration

        protected virtual void PreConfigureServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterInstance(LoggingOptions.Default());
        }

        protected void ConfigureServices(ContainerBuilder containerBuilder)
        {
            PreConfigureServices(containerBuilder);

            containerBuilder.RegisterInstance(ActorSystem.Create(_appName));

            containerBuilder.Register<ILoggingService>((context =>
            {
                var system = context.Resolve<ActorSystem>();
                var options = context.Resolve<LoggingOptions>();
                return new LoggingService(system.ActorSelection(options.ActorSelectionUrl));
            })).SingleInstance();
            
            PostConfigureServices(containerBuilder);
        }

        protected virtual void PostConfigureServices(ContainerBuilder containerBuilder)
        { }

        #endregion

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                AkkaSystem?.Dispose();
                Container?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
