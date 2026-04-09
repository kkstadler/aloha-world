namespace AlohaWorld.Models;

public enum RecordType { Vaccination, Checkup, Treatment, Test, Surgery }

public class HealthRecord
{
    public int Id { get; set; }
    public int PetId { get; set; }
    public RecordType Type { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public DateTime? NextDueDate { get; set; }
    public string VetName { get; set; } = string.Empty;
    public string ClinicName { get; set; } = string.Empty;
    public bool IsUpcoming => NextDueDate.HasValue && NextDueDate.Value > DateTime.Now && NextDueDate.Value <= DateTime.Now.AddDays(30);
    public bool IsOverdue => NextDueDate.HasValue && NextDueDate.Value < DateTime.Now;
}
