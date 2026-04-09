namespace AlohaWorld.Models;

public enum AlertSeverity { Info, Warning, Danger }

public class TravelAlert
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public AlertSeverity Severity { get; set; }
    public string CountryCode { get; set; } = string.Empty;
    public string CountryName { get; set; } = string.Empty;
    public DateTime IssuedDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsActive => ExpiryDate == null || ExpiryDate > DateTime.Now;

    public string BadgeClass => Severity switch
    {
        AlertSeverity.Danger => "badge bg-danger",
        AlertSeverity.Warning => "badge bg-warning text-dark",
        _ => "badge bg-info text-dark"
    };
}
