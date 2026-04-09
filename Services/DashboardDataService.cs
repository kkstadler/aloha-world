using AlohaWorld.Models;

namespace AlohaWorld.Services;

public class DashboardDataService
{
    public PetProfile GetPrimaryPet()
    {
        return new PetProfile
        {
            Id = 1,
            Name = "Koa",
            Type = PetType.Dog,
            Breed = "American Pit Bull Terrier",
            AgeYears = 4,
            OwnerName = "Kaile Stadler",
            OwnerEmail = "kaile@aloha-world.com",
            MicrochipNumber = "985141002631498",
            PassportNumber = "EU-PET-2024-00441",
            ImageUrl = "https://placedog.net/400/300?id=1",
            Tags = new List<string> { "Vaccinated", "Microchipped", "EU Passport", "Neutered" },
            HomeAddress = new Address
            {
                Street = "1600 Amphitheatre Parkway",
                City = "Mountain View",
                State = "CA",
                Country = "United States",
                PostalCode = "94043",
                Latitude = 37.4221,
                Longitude = -122.0841
            },
            HealthRecords = GetHealthRecords(1)
        };
    }

    public List<PetProfile> GetHouseholdPets()
    {
        return new List<PetProfile>
        {
            GetPrimaryPet(),
            new PetProfile
            {
                Id = 2,
                Name = "Lani",
                Type = PetType.Cat,
                Breed = "Domestic Shorthair",
                AgeYears = 6,
                OwnerName = "Kaile Stadler",
                OwnerEmail = "kaile@aloha-world.com",
                MicrochipNumber = "985141002644321",
                ImageUrl = "https://placekitten.com/400/300",
                Tags = new List<string> { "Vaccinated", "Microchipped", "Indoor" },
                HomeAddress = new Address
                {
                    Street = "1600 Amphitheatre Parkway",
                    City = "Mountain View",
                    State = "CA",
                    Country = "United States",
                    PostalCode = "94043",
                    Latitude = 37.4221,
                    Longitude = -122.0841
                },
                HealthRecords = GetHealthRecords(2)
            },
            new PetProfile
            {
                Id = 3,
                Name = "Maka",
                Type = PetType.Dog,
                Breed = "Golden Retriever",
                AgeYears = 2,
                OwnerName = "Kaile Stadler",
                OwnerEmail = "kaile@aloha-world.com",
                ImageUrl = "https://placedog.net/400/300?id=5",
                Tags = new List<string> { "Vaccinated", "Puppy Training" },
                HomeAddress = new Address
                {
                    Street = "1600 Amphitheatre Parkway",
                    City = "Mountain View",
                    State = "CA",
                    Country = "United States",
                    PostalCode = "94043",
                    Latitude = 37.4221,
                    Longitude = -122.0841
                },
                HealthRecords = GetHealthRecords(3)
            }
        };
    }

    public List<HealthRecord> GetHealthRecords(int petId)
    {
        var baseDate = DateTime.Now;
        return petId switch
        {
            1 => new List<HealthRecord>
            {
                new() { Id=1, PetId=1, Type=RecordType.Vaccination, Title="Rabies Vaccine", Description="Annual rabies vaccination", Date=baseDate.AddMonths(-10), NextDueDate=baseDate.AddMonths(2), VetName="Dr. Mele Fonoti", ClinicName="Aloha Animal Clinic" },
                new() { Id=2, PetId=1, Type=RecordType.Vaccination, Title="DHPP Combo", Description="Distemper, Hepatitis, Parvovirus, Parainfluenza", Date=baseDate.AddMonths(-11), NextDueDate=baseDate.AddMonths(1), VetName="Dr. Mele Fonoti", ClinicName="Aloha Animal Clinic" },
                new() { Id=3, PetId=1, Type=RecordType.Checkup, Title="Annual Wellness Exam", Description="Full physical examination, blood panel", Date=baseDate.AddMonths(-6), NextDueDate=baseDate.AddMonths(6), VetName="Dr. Mele Fonoti", ClinicName="Aloha Animal Clinic" },
                new() { Id=4, PetId=1, Type=RecordType.Treatment, Title="Tapeworm Treatment", Description="Required for EU entry compliance", Date=baseDate.AddDays(-5), VetName="Dr. Mele Fonoti", ClinicName="Aloha Animal Clinic" }
            },
            2 => new List<HealthRecord>
            {
                new() { Id=5, PetId=2, Type=RecordType.Vaccination, Title="Rabies Vaccine", Description="Annual rabies vaccination", Date=baseDate.AddMonths(-8), NextDueDate=baseDate.AddMonths(4), VetName="Dr. Mele Fonoti", ClinicName="Aloha Animal Clinic" },
                new() { Id=6, PetId=2, Type=RecordType.Checkup, Title="Dental Cleaning", Description="Tartar removal, tooth inspection", Date=baseDate.AddMonths(-3), VetName="Dr. Hina Paloma", ClinicName="Pacific Vet Center" }
            },
            _ => new List<HealthRecord>
            {
                new() { Id=7, PetId=3, Type=RecordType.Vaccination, Title="Rabies Vaccine", Description="Puppy series - dose 2", Date=baseDate.AddMonths(-2), NextDueDate=baseDate.AddDays(20), VetName="Dr. Mele Fonoti", ClinicName="Aloha Animal Clinic" },
                new() { Id=8, PetId=3, Type=RecordType.Vaccination, Title="Bordetella", Description="Kennel cough prevention", Date=baseDate.AddMonths(-2), NextDueDate=baseDate.AddDays(15), VetName="Dr. Mele Fonoti", ClinicName="Aloha Animal Clinic" }
            }
        };
    }

    public List<TravelAlert> GetTravelAlerts()
    {
        return new List<TravelAlert>
        {
            new() { Id=1, Title="UK Entry Requirements Updated", Message="As of Jan 2024, pet travel to the UK requires AHC form, microchip, and rabies titre test with 30-day wait.", Severity=AlertSeverity.Warning, CountryCode="GB", CountryName="United Kingdom", IssuedDate=DateTime.Now.AddDays(-10) },
            new() { Id=2, Title="Norway Tapeworm Treatment Mandatory", Message="Dogs entering Norway must be treated for Echinococcus tapeworm 1-5 days before entry.", Severity=AlertSeverity.Warning, CountryCode="NO", CountryName="Norway", IssuedDate=DateTime.Now.AddDays(-5) },
            new() { Id=3, Title="Japan Rabies Quarantine", Message="Dogs arriving in Japan face mandatory 180-day quarantine unless all conditions are met in advance.", Severity=AlertSeverity.Danger, CountryCode="JP", CountryName="Japan", IssuedDate=DateTime.Now.AddDays(-20) }
        };
    }

    public List<CountryRestriction> GetCountryRestrictions()
    {
        return new List<CountryRestriction>
        {
            // Europe
            new() { CountryCode="GB", CountryName="United Kingdom", Continent="Europe", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=true, RequiresRabiesVaccination=true, BannedBreeds=new(){"Pit Bull Terrier","Japanese Tosa","Dogo Argentino","Fila Brasileiro"}, Notes="Dangerous Dogs Act 1991 bans pit bulls outright." },
            new() { CountryCode="DE", CountryName="Germany", Continent="Europe", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=true, RequiresRabiesVaccination=true, BannedBreeds=new(){"American Pit Bull","Staffordshire Bull Terrier"}, Notes="Banned in Bavaria, NRW and other states. Federal states vary." },
            new() { CountryCode="DK", CountryName="Denmark", Continent="Europe", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=true, RequiresRabiesVaccination=true, BannedBreeds=new(){"Pit Bull Terrier","Tosa Inu"}, Notes="Banned nationwide under Dog Act 2010." },
            new() { CountryCode="NO", CountryName="Norway", Continent="Europe", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=true, RequiresRabiesVaccination=true, BannedBreeds=new(){"Pit Bull Terrier","American Staffordshire"}, Notes="Banned under Animal Welfare Act. Tapeworm treatment required." },
            new() { CountryCode="BE", CountryName="Belgium", Continent="Europe", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=true, RequiresRabiesVaccination=true, BannedBreeds=new(){"Pit Bull Terrier"}, Notes="Breed-specific legislation in multiple municipalities." },
            new() { CountryCode="RO", CountryName="Romania", Continent="Europe", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=true, RequiresRabiesVaccination=true, BannedBreeds=new(){"Pit Bull","Rottweiler","Mastiff"}, Notes="Law 205/2004 bans aggressive breeds." },
            new() { CountryCode="PL", CountryName="Poland", Continent="Europe", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=true, RequiresRabiesVaccination=true, BannedBreeds=new(){"American Pit Bull"}, Notes="Requires muzzle and leash in public. Permit needed." },
            new() { CountryCode="FR", CountryName="France", Continent="Europe", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=true, RequiresRabiesVaccination=true, BannedBreeds=new(){"Category 1 (Attack dogs)"}, Notes="Two-category system: Category 1 effectively banned, Category 2 restricted." },
            new() { CountryCode="ES", CountryName="Spain", Continent="Europe", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="PPP law requires muzzle, leash, liability insurance, and permit." },
            new() { CountryCode="PT", CountryName="Portugal", Continent="Europe", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="Decree-Law 315/2009 classifies pit bulls as dangerous breeds." },
            new() { CountryCode="RU", CountryName="Russia", Continent="Europe", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=false, RequiresRabiesVaccination=true, Notes="2019 law restricts 12 dangerous breeds including American Pit Bull." },
            new() { CountryCode="UA", CountryName="Ukraine", Continent="Europe", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=false, RequiresRabiesVaccination=true, Notes="Breed restrictions vary by city; Kyiv requires registration." },
            new() { CountryCode="NL", CountryName="Netherlands", Continent="Europe", PitbullRestriction=RestrictionLevel.MicrochipRequired, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="BSL repealed in 2008; individual dog behavior assessed instead." },
            new() { CountryCode="IT", CountryName="Italy", Continent="Europe", PitbullRestriction=RestrictionLevel.MicrochipRequired, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="BSL repealed in 2012; microchip and liability insurance recommended." },
            new() { CountryCode="SE", CountryName="Sweden", Continent="Europe", PitbullRestriction=RestrictionLevel.MicrochipRequired, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="No breed ban; individual assessment. EU pet passport accepted." },
            new() { CountryCode="FI", CountryName="Finland", Continent="Europe", PitbullRestriction=RestrictionLevel.MicrochipRequired, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="No BSL. Microchip required for all dogs." },
            new() { CountryCode="CH", CountryName="Switzerland", Continent="Europe", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="Canton-level restrictions. Some cantons ban pit bulls." },
            new() { CountryCode="AT", CountryName="Austria", Continent="Europe", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="State-level laws; Vienna, Lower Austria restrict pit bulls." },
            new() { CountryCode="CZ", CountryName="Czech Republic", Continent="Europe", PitbullRestriction=RestrictionLevel.MicrochipRequired, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="No national BSL; microchip mandatory." },
            new() { CountryCode="HU", CountryName="Hungary", Continent="Europe", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=true, RequiresRabiesVaccination=true, BannedBreeds=new(){"American Pit Bull","Argentine Dogo"}, Notes="Government Decree 35/1997 bans several breeds." },
            new() { CountryCode="GR", CountryName="Greece", Continent="Europe", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="Dangerous breeds require muzzle, leash, and third-party insurance." },
            new() { CountryCode="TR", CountryName="Turkey", Continent="Europe", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=false, RequiresRabiesVaccination=true, Notes="Restricted in urban areas; leash and muzzle required." },

            // Asia
            new() { CountryCode="JP", CountryName="Japan", Continent="Asia", PitbullRestriction=RestrictionLevel.QuarantineRequired, RequiresMicrochip=true, RequiresRabiesVaccination=true, QuarantineDays=180, Notes="Strict 180-day quarantine unless all pre-arrival conditions met precisely." },
            new() { CountryCode="SG", CountryName="Singapore", Continent="Asia", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=true, RequiresRabiesVaccination=true, QuarantineDays=30, BannedBreeds=new(){"Pit Bull","Akita","Boerboel","Dogo Argentino"}, Notes="10 banned breeds; all dogs require quarantine." },
            new() { CountryCode="MY", CountryName="Malaysia", Continent="Asia", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=true, RequiresRabiesVaccination=true, QuarantineDays=14, BannedBreeds=new(){"American Pit Bull","Staffordshire Bull Terrier"}, Notes="Banned breeds; all imported dogs face quarantine." },
            new() { CountryCode="HK", CountryName="Hong Kong", Continent="Asia", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=true, RequiresRabiesVaccination=true, QuarantineDays=30, Notes="Pit bulls require special licence; all dogs quarantined." },
            new() { CountryCode="TW", CountryName="Taiwan", Continent="Asia", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=true, RequiresRabiesVaccination=true, QuarantineDays=21, Notes="Dangerous breed registration required; quarantine on arrival." },
            new() { CountryCode="CN", CountryName="China", Continent="Asia", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=false, RequiresRabiesVaccination=true, Notes="City-level BSL; many cities ban large dogs above weight limits." },
            new() { CountryCode="KR", CountryName="South Korea", Continent="Asia", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="2023 Animal Protection Act designates pit bulls as aggressive; muzzle mandatory." },
            new() { CountryCode="IN", CountryName="India", Continent="Asia", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=false, RequiresRabiesVaccination=true, Notes="2023 Ministry of Agriculture advises against pit bull ownership; many states restricting." },
            new() { CountryCode="TH", CountryName="Thailand", Continent="Asia", PitbullRestriction=RestrictionLevel.MicrochipRequired, RequiresMicrochip=true, RequiresRabiesVaccination=true, QuarantineDays=14, Notes="No BSL nationally; microchip required; quarantine on import." },
            new() { CountryCode="PH", CountryName="Philippines", Continent="Asia", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=true, RequiresRabiesVaccination=true, Notes="Some local government units ban pit bulls." },
            new() { CountryCode="ID", CountryName="Indonesia", Continent="Asia", PitbullRestriction=RestrictionLevel.QuarantineRequired, RequiresMicrochip=true, RequiresRabiesVaccination=true, QuarantineDays=14, Notes="14-day quarantine required; permit system for import." },
            new() { CountryCode="AE", CountryName="UAE", Continent="Asia", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=true, RequiresRabiesVaccination=true, BannedBreeds=new(){"Pit Bull","Rottweiler","Mastiff"}, Notes="Multiple breeds banned; strict import controls." },
            new() { CountryCode="IL", CountryName="Israel", Continent="Asia", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=true, RequiresRabiesVaccination=true, BannedBreeds=new(){"American Pit Bull Terrier"}, Notes="Banned under Dangerous Dogs Regulations 2004." },
            new() { CountryCode="SA", CountryName="Saudi Arabia", Continent="Asia", PitbullRestriction=RestrictionLevel.Banned, RequiresMicrochip=false, RequiresRabiesVaccination=true, BannedBreeds=new(){"Pit Bull","Rottweiler"}, Notes="Banned; dogs generally not permitted as pets in public." },
            new() { CountryCode="PK", CountryName="Pakistan", Continent="Asia", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=false, RequiresRabiesVaccination=false, Notes="Some provinces restrict; pit bulls used in illegal dog fighting." },
            new() { CountryCode="KZ", CountryName="Kazakhstan", Continent="Asia", PitbullRestriction=RestrictionLevel.Restricted, RequiresMicrochip=false, RequiresRabiesVaccination=true, Notes="2022 law restricts 19 dangerous breeds including pit bull." }
        };
    }

    public DashboardViewModel BuildDashboard()
    {
        var pet = GetPrimaryPet();
        var allRecords = GetHouseholdPets().SelectMany(p => p.HealthRecords).ToList();
        var upcoming = allRecords.Where(r => r.IsUpcoming).ToList();
        var restrictions = GetCountryRestrictions();

        return new DashboardViewModel
        {
            Pet = pet,
            HouseholdPets = GetHouseholdPets(),
            MapAddress = pet.HomeAddress,
            CountryRestrictions = restrictions,
            TravelAlerts = GetTravelAlerts(),
            UpcomingHealthEvents = upcoming.Any() ? upcoming : null,
            Stats = new DashboardStats
            {
                TotalPets = 3,
                CountriesAllowed = restrictions.Count(r => r.PitbullRestriction == RestrictionLevel.Allowed || r.PitbullRestriction == RestrictionLevel.MicrochipRequired),
                CountriesBanned = restrictions.Count(r => r.PitbullRestriction == RestrictionLevel.Banned),
                CountriesRestricted = restrictions.Count(r => r.PitbullRestriction == RestrictionLevel.Restricted),
                UpcomingVaccinations = upcoming.Count(r => r.Type == RecordType.Vaccination),
                LastUpdated = DateTime.Now
            }
        };
    }
}
