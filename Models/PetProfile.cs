namespace AlohaWorld.Models;

public enum PetType { Dog, Cat, Bird, Rabbit, Other }
public enum RestrictionLevel { Banned, QuarantineRequired, Restricted, MicrochipRequired, Allowed }

public class PetProfile
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public PetType Type { get; set; }
    public string Breed { get; set; } = string.Empty;
    public int AgeYears { get; set; }
    public string OwnerName { get; set; } = string.Empty;
    public string OwnerEmail { get; set; } = string.Empty;
    public Address HomeAddress { get; set; } = new();
    public List<HealthRecord> HealthRecords { get; set; } = new();
    public List<string> Tags { get; set; } = new();
    public string? MicrochipNumber { get; set; }
    public string? PassportNumber { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}

public class Address
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public string FullAddress => $"{Street}, {City}, {State} {PostalCode}, {Country}";
}
