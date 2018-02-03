namespace Lykke.Service.RaiblocksSign.Core.Domain
{
    public interface IRaiBlock
    {
        string type { get; set; }
        string account { get; set; }
        string destination { get; set; }
        string source { get; set; }
        string amount { get; set; }
        string work { get; set; }
        string previous { get; set; }
        string balance { get; set; }

        string signature { get; set; }
    }
}
