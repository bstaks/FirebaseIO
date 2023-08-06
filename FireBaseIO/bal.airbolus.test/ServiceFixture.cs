using Moq;
using Microsoft.Extensions.Logging;

namespace bal.airbolus.test;

[TestClass]
public class ServiceFixture
{
    private Mock<ILogger<Service>> _logger;
    private IService _service;

    [TestInitialize]
    public void Initialize()
    {
        _logger = new Mock<ILogger<Service>>();
        _service = new Service(_logger.Object);
    }

    [TestMethod]
    public async Task VerifyGetClientReturnIsValidResponse()
    {
        var client = await _service.GetClient();

        Assert.IsNotNull(client);
    }

     [TestMethod]
    public async Task VerifyGetRatesReturnIsValidResponse()
    {
        var rates = await _service.GetRates();
        
        Assert.IsNotNull(rates);
    }

     [TestMethod]
    public async Task VerifyGetExpertsReturnIsValidResponse()
    {
        var experts = await _service.GetExperts();
        
        Assert.IsNotNull(experts);
    }
}