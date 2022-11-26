using System.Collections.Generic;

namespace AsyncProgressApp;

public class ProgressReportModel
{
    public int PercentageComplete { get; set; } = 0;
    public WebsiteDataModel CurrentSite { get; set; } = new();
}