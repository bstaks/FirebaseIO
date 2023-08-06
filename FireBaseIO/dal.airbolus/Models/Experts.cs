namespace dal.airbolus.Models;

public class Expert
{
    public List<Call> Calls { get; set; }
    public string Currency { get; set; }
    public int HourlyRate { get; set; }
    public string Name { get; set; }
}

public class Call
{
    public string Client { get; set; }
    public int Duration { get; set; }
}

public class ExpertRoot{
    public List<Expert> Experts{get;set;}
}