
using Microsoft.EntityFrameworkCore;
using SUP_INV1._0.Data;
using SUP_INV1._0.Models;

namespace SUP_INV1._0
{
    public class ShelfLifeBackgroundService: BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public ShelfLifeBackgroundService(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var farmProducts = await context.FarmProducts.ToListAsync();
                    foreach (var product in farmProducts)
                    {
                        product.Maximum_Shelf_Life_Days -= 1;
                        if (product.Maximum_Shelf_Life_Days == 1)
                        {
                            // Implement your notification logic here
                            await SendNotification(product);
                        }
                    }
                    await context.SaveChangesAsync();
                }
                await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
            }
        }
        private async Task SendNotification(FarmProducts product)
        {
            // Your notification logic (e.g., email, SMS, push notification)
            Console.WriteLine($"Product {product.FID}is about to expire!");
            // Example: await EmailService.SendEmailAsync("admin@example.com", "Product Expiry Notice", $"Product {product.Id} is about to expire!"); }
        }
    }
}
