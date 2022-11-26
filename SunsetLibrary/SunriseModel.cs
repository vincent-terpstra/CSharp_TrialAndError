namespace SunsetLibrary;

public class SunriseResults
{
    public SunriseModel Results { get; set; }
    private string Status { get; set; }
}


public class SunriseModel
{
       public DateTime Sunrise { get; set; }
       public DateTime Sunset { get; set; }
}