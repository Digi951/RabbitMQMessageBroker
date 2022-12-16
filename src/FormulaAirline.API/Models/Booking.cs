namespace FormulaAirline.API.Models;

public class Booking
{
    public Int32 Id { get; set; }
    public String PassangerName { get; set; } = String.Empty;
    public String PassportNb { get; set; } = String.Empty;
    public String From { get; set; } = String.Empty;
    public String To { get; set; } = String.Empty;
    public Int32 Status { get; set; }
}
