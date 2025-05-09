//Define UFO class. This will contain all info per UFO sighting
public class UFO
{
    public DateTime Observed { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Shape { get; set; }
    public string? Duration_Seconds { get; set; }
    public string? DurationHoursMinutes { get; set; }
    public string? Comments { get; set; }
    //public DateOnly DatePosted { get; set; }
    public DateOnly DatePosted { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
}

public class DateObject
{
    public DateOnly DateOnlyValue { get; set; }
    public DateTime DateTimeValue { get; set; }
}