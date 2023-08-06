using Microsoft.Extensions.Logging;
using dal.airbolus.Models;
using dal.airbolus.Constants;
using System.Text.Json;

namespace bal.airbolus;

public class Service : IService
{
    #region  Private Member

    private readonly ILogger<Service> _servicelog;
    private JsonSerializerOptions _options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    #endregion

    #region  Default Constructor

    public Service(ILogger<Service> logger)
    {
        _servicelog = logger;
    }

    #endregion

    public async Task<ClientRoot> GetClient()
    {
        _servicelog.Log(LogLevel.Debug, "Called GetClient Methods");
        string bodyContent = await GetResponse(Constant.ClientEndPoint);
        return JsonSerializer.Deserialize<ClientRoot>(bodyContent, _options);
    }

    public async Task<ExpertRoot> GetExperts()
    {
        _servicelog.Log(LogLevel.Debug, "Called GetExperts Methods");
        string bodyContent = await GetResponse(Constant.ExpertsEndPoint);
        return JsonSerializer.Deserialize<ExpertRoot>(bodyContent, _options);
    }


    public async Task<IDictionary<string, object>> GetRates()
    {
        _servicelog.LogInformation("GetRates Method calls");
        string bodyContent = await GetResponse(Constant.ReateEndPoint);
        return JsonSerializer.Deserialize<IDictionary<string, object>>(bodyContent, _options);
    }

    #region  Private Methods

    private static async Task<string> GetResponse(string endPoint)
    {
        var client = Client();
        var result = await client.GetAsync(endPoint);
        string bodyContent = await result.Content.ReadAsStringAsync();
        return bodyContent;
    }

    private static HttpClient Client()
    {
        var client = new HttpClient();
        return client;
    }

    #endregion Private Methods
}