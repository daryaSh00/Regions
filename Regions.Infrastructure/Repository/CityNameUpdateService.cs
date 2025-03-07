using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Regions.Application.Common.Interfaces;

namespace Regions.Infrastructure.Repository
{
    public class CityNameUpdateService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public CityNameUpdateService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("CityNameUpdateService started at: " + DateTime.Now);
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                var nextRun = DateTime.Today.AddHours(22); 

                if (now > nextRun)
                {
                    Console.WriteLine("Running immediately because it's past 10 PM");
                    UpdateCities();
                    nextRun = nextRun.AddDays(1); 
                }

                var delay = nextRun - now;
                Console.WriteLine($"Next run scheduled at: {nextRun}, Delay: {delay.TotalMinutes} minutes");
                await Task.Delay(delay, stoppingToken);

                UpdateCities();
            }

            void UpdateCities()
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                    var cities = unitOfWork.City.GetAll();
                    Console.WriteLine($"Found {cities.Count()} cities to update at: {DateTime.Now}");
                    foreach (var city in cities)
                    {
                        city.Name = $"*{city.Name}";
                        unitOfWork.City.Update(city);
                        Console.WriteLine($"Updated city: {city.Name}");
                    }
                    unitOfWork.Save();
                    Console.WriteLine($"Changes saved at: {DateTime.Now}");
                }
            }
        }
    }
}

