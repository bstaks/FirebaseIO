namespace dal.airbolus.Models;
public class Client
{
    public List<string> Discounts { get; set; }
    public string Name { get; set; }
}

/// <summary>
/// 
/// </summary>
public class ClientRoot
{
    /// <summary>
    /// 
    /// </summary>
    public List<Client> Clients { get; set; }
}