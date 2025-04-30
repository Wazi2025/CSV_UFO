//Define UFO class. This will contain all info per UFO sighting
public class UFO
{
    public DateTime Observed { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Shape { get; set; }
    public DateTime Duration_Seconds { get; set; }
    public string? DurationHoursMinutes { get; set; }
    public string? Comments { get; set; }
    public DateTime DatePosted { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
}