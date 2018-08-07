namespace Lykke.Service.RaiblocksSign.Core.Domain
{
    public interface IRaiBlock
    {
        string type { get; set; }
        string account { get; set; }
        string representative { get; set; }
        string link { get; set; }
        string balance { get; set; }
        string previous { get; set; }
        string work { get; set; }

        string signature { get; set; }
    }
}
