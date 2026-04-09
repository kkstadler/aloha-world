namespace AlohaWorld.Models;

public class CountryRestriction
{
    public string CountryCode { get; set; } = string.Empty;  // ISO 3166-1 alpha-2
    public string CountryName { get; set; } = string.Empty;
    public string Continent { get; set; } = string.Empty;
    public RestrictionLevel PitbullRestriction { get; set; }
    public bool RequiresMicrochip { get; set; }
    public bool RequiresRabiesVaccination { get; set; }
    public int? QuarantineDays { get; set; }
    public string Notes { get; set; } = string.Empty;
    public List<string> BannedBreeds { get; set; } = new();

    public string RestrictedColor => PitbullRestriction switch
    {
        RestrictionLevel.Banned => "#d9534f",
        RestrictionLevel.QuarantineRequired => "#f0ad4e",
        RestrictionLevel.Restricted => "#f7c948",
        RestrictionLevel.MicrochipRequired => "#5bc0de",
        RestrictionLevel.Allowed => "#5cb85c",
        _ => "#aaaaaa"
    };

    public string RestrictionLabel => PitbullRestriction switch
    {
        RestrictionLevel.Banned => "Banned",
        RestrictionLevel.QuarantineRequired => "Quarantine Required",
        RestrictionLevel.Restricted => "Restricted",
        RestrictionLevel.MicrochipRequired => "Microchip Required",
        RestrictionLevel.Allowed => "Allowed",
        _ => "Unknown"
    };
}
