using Application.Interface;
using Domain.Configuration;
using Domain.Repository;

namespace Job
{
    public class JobExecutor : BackgroundService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly ILogger<JobExecutor> _logger;
        private MaintenanceRepository _maintenanceRepository;
        private Alert _alert;
        private MaintenanceService _maintenanceService;
        private EmailService _emailService;

        public JobExecutor(
            IHostApplicationLifetime hostApplicationLifetime,
            ILogger<JobExecutor> logger,
            MaintenanceRepository maintenanceRepository,
            Alert alert,
            MaintenanceService maintenanceService,
            EmailService emailService)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _logger = logger;
            _maintenanceRepository = maintenanceRepository;
            _alert = alert;
            _maintenanceService = maintenanceService;
            _emailService = emailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var emails = await _emailService.GetEmails();

            foreach (var email in emails)
            {
                DateTime nextMaintenance = _maintenanceService.GetNextMaintenanceDate(_alert.FirstAlert);

                _logger.LogInformation($"Getting maintenances that should make on next {_alert.FirstAlert}.");
                var maintenancesFirstAlert = await _maintenanceRepository.GetMaintenances(email.Id, nextMaintenance);

                if (maintenancesFirstAlert.Any())
                {
                    _logger.LogInformation("Sending email.");

                    _emailService.SendEmail(email.Email, maintenancesFirstAlert.ToList());
                }

                _logger.LogInformation($"Getting maintenances that should make on next {_alert.SecondAlert}.");
                var maintenancesSecondAlert = await _maintenanceRepository.GetMaintenances(email.Id, nextMaintenance);

                if (maintenancesSecondAlert.Any())
                {
                    _logger.LogInformation("Sending email.");

                    _emailService.SendEmail(email.Email, maintenancesSecondAlert.ToList());
                }


                _logger.LogInformation($"Getting maintenances that should make on next {_alert.ThirdAlert}.");
                var maintenancesThirdAlert = await _maintenanceRepository.GetMaintenances(email.Id, nextMaintenance);

                if (maintenancesThirdAlert.Any())
                {
                    _logger.LogInformation("Sending email.");

                    _emailService.SendEmail(email.Email, maintenancesThirdAlert.ToList());
                }
            }

            await Task.Delay(1000, stoppingToken);

            _hostApplicationLifetime.StopApplication();
        }
    }
}