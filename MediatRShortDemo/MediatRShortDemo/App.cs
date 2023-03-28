using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatRShortDemo
{
    public class App
    {
        private readonly ILogger<App> _logger;
        private readonly IMediatorService _notifierMediatorService;
        public App(
            ILogger<App> logger,
            IMediatorService notifierMediatorService
            )
        {
            _logger = logger;
            _notifierMediatorService = notifierMediatorService;
        }

        public void Run()
        {
            _logger.LogInformation("Run started");
            Notify();
            RequestResonse();
            OneWay();
            _logger.LogInformation("Run completed");
        }

        private void Notify()
        {
            _notifierMediatorService.Notify("Test Message");
        }

        private void RequestResonse()
        {
            string response = _notifierMediatorService.RequestResponse();
            Console.WriteLine($"In App: {response}");
        }

        private void OneWay()
        {
            _notifierMediatorService.OneWay();
        }
    }
}
