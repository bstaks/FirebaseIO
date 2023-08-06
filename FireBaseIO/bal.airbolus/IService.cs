using dal.airbolus.Models;

namespace bal.airbolus;
public interface IService{
  Task<ClientRoot> GetClient();

  Task<ExpertRoot> GetExperts();

  Task<IDictionary<string,object>> GetRates();
}