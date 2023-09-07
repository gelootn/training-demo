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

        public async Task Run()
        {
            _logger.LogInformation("Run started");
            
            // NOTIFICATION
            await Notify();
            await TriggerWrongNotification();
            
            // REQUEST
            await RequestResponse();
            await OneWay();
            await TriggerWrongRequest();
            await TriggerErrorRequest();
            
            _logger.LogInformation("Run completed");
        }

        private async Task TriggerErrorRequest()
        {
            await _notifierMediatorService.TriggerErrorRequest();
        }
        private async Task Notify()
        {
            await _notifierMediatorService.Notify("Test Message");
        }
        private async Task RequestResponse()
        {
            string response = await _notifierMediatorService.RequestResponse();
            _logger.LogInformation("In App: {Response}", response);
        }
        private async Task OneWay()
        {
            await _notifierMediatorService.OneWay();
        }
        private async Task TriggerWrongRequest()
        {
            try
            {
                await _notifierMediatorService.TriggerWrongRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in TriggerWrongRequest");

            }
        }
        private async Task TriggerWrongNotification()
        {
            try
            {
                await _notifierMediatorService.TriggerNotifyWrong();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in TriggerWrongNotification");
            }
        }
    }
}
