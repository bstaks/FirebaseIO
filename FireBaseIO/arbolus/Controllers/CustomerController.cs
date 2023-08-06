using Microsoft.AspNetCore.Mvc;
using bal.airbolus;

namespace arbolus.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IService _service;
    private readonly ILogger<CustomerController> _logger;

    /// <summary>
    /// Default Constructor
    /// </summary>
    public CustomerController(IService service, ILogger<CustomerController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet(Name = "CalculatePrice")]
    public async Task<decimal> CalculatePrice(string expertName, string clientName)
    {
        _logger.LogInformation("Called Calculate API");
        
        decimal price = 0;

        var client = await _service.GetClient();
        var experts = await _service.GetExperts();

        var expert = experts?.Experts.FirstOrDefault(m => m.Name == expertName);

        var clientInfo = client.Clients.FirstOrDefault(m => m.Name == clientName);
        if (clientInfo != null)
        {
            var calls = expert?.Calls.Where(m => m.Client == clientInfo.Name).ToList();
           
            if (calls?.Count > 0)
            {
                var durationOfCall = calls.OrderByDescending(m => m.Duration).FirstOrDefault();
                price = CalculatePriceByDuation(expert.HourlyRate, durationOfCall.Duration) * 45;
            }
        }

        // TO DO Rate Convertion
        // var rates = await _service.GetRates();
        // End TO DO

        return await Task.Run(() => price);

    }

    private decimal CalculatePriceByDuation(int hourlyRate, int callDuration)
    {
        if (callDuration < 60)
        {
            var price = GetPrice(hourlyRate);
            return price;
        }

        return hourlyRate;
    }

    private decimal GetPrice(decimal price)
    {
        decimal hourlyRate = price / 60;
        return hourlyRate;
    }
}