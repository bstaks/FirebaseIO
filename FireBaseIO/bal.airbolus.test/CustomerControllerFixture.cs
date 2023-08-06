using Moq;
using Microsoft.Extensions.Logging;
using bal.airbolus;
using arbolus.Controllers;
using dal.airbolus.Models;

namespace bal.airbolus.test;

[TestClass]
public class CustomerControllerFixture
{
    private Mock<ILogger<CustomerController>> _logger;
    private Mock<IService> _service;
    private CustomerController _customerController;

    [TestInitialize]
    public void Initialize()
    {
        _logger = new Mock<ILogger<CustomerController>>();
        _service = new Mock<IService>();
        _customerController = new CustomerController(_service.Object, _logger.Object);

        _service.Setup(m => m.GetClient()).ReturnsAsync(() => new ClientRoot() { Clients = new List<Client>() { new Client() { Discounts = new List<string>(), Name = "Client 1" } } });
    }

    [TestMethod]
    public async Task VerifyCalculatePriceReturnValidResponse()
    {
        var result = await _customerController.CalculatePrice("Expert 1", "Client 1");
        Assert.AreEqual(result, 0);
    }

}