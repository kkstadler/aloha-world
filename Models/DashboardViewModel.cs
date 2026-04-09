namespace AlohaWorld.Models;

public class DashboardViewModel
{
    // Primary pet profile
    public PetProfile? Pet { get; set; }

    // All pets in household
    public List<PetProfile> HouseholdPets { get; set; } = new();

    // Address to display on map (from pet's home address)
    public Address? MapAddress { get; set; }

    // Country restriction data for Europe/Asia map
    public List<CountryRestriction> CountryRestrictions { get; set; } = new();

    // Active travel alerts — card hidden when null/empty
    public List<TravelAlert>? TravelAlerts { get; set; }

    // Upcoming health records — card hidden when null/empty
    public List<HealthRecord>? UpcomingHealthEvents { get; set; }

    // Statistics
    public DashboardStats Stats { get; set; } = new();

    // Restriction summary counts for legend
    public Dictionary<RestrictionLevel, int> RestrictionCounts =>
        CountryRestrictions
            .GroupBy(c => c.PitbullRestriction)
            .ToDictionary(g => g.Key, g => g.Count());

    // Helpers for conditional rendering
    public bool HasTravelAlerts => TravelAlerts?.Any() == true;
    public bool HasUpcomingHealth => UpcomingHealthEvents?.Any() == true;
    public bool HasPetPassport => Pet?.PassportNumber != null;
    public bool HasMicrochip => Pet?.MicrochipNumber != null;
}

public class DashboardStats
{
    public int TotalPets { get; set; }
    public int CountriesAllowed { get; set; }
    public int CountriesBanned { get; set; }
    public int CountriesRestricted { get; set; }
    public int UpcomingVaccinations { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.Now;
}
