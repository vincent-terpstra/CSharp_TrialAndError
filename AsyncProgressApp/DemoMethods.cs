using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgressApp;

public static class DemoMethods
{
    private static List<string> PrepData()
    {
        return new List<string>()
        {
            "https://www.yahoo.com",
            "https://www.google.com",
            //"https://www.microsoft.com",
            "https://www.cnn.com",
            "https://www.amazon.com",
            "https://www.facebook.com",
            "https://www.twitter.com",
            "https://www.codeproject.com",
            //"https://www.stackoverflow.com",
            "https://en.wikipedia.org/wiki/.NET_Framework"
        };
    }
    
    public static List<WebsiteDataModel> RunDownload()
    {
        List<string> websites = PrepData();
        List<WebsiteDataModel> output = new();

        foreach (var website in websites)
        {
            WebsiteDataModel results = DownloadWebsite(website);
            output.Add(results);
        }

        return output;
    }

    private static WebsiteDataModel DownloadWebsite(string website)
    {
        using WebClient client = new ();
        
        return new WebsiteDataModel()
        {
            WebsiteData = client.DownloadString(website),
            WebsiteUrl = website
        };
    }

    public static async Task<List<WebsiteDataModel>> RunDownloadAsync(
            IProgress<ProgressReportModel> progress,
            CancellationToken cancellationToken)
    {
        List<string> websites = PrepData();
        List<WebsiteDataModel> output = new();

        ProgressReportModel report = new();

        foreach (var siteUrl in websites)
        {
            //cancellationToken.ThrowIfCancellationRequested();
            if (cancellationToken.IsCancellationRequested)
                return output;

            var current = await DownloadWebsiteAsync(siteUrl);
            
            output.Add(current);
            report.PercentageComplete = (output.Count * 100) / websites.Count;
            report.CurrentSite = current;
            
            progress.Report(report);
        }

        return output;
    }

    private static async Task<WebsiteDataModel> DownloadWebsiteAsync(string website)
    {
        using WebClient client = new ();
        
        return new WebsiteDataModel()
        {
            WebsiteData = await client.DownloadStringTaskAsync(website),
            WebsiteUrl = website
        };
    }

    public static async Task<List<WebsiteDataModel>> RunDownloadParallelAsync()
    {
        List<string> websites = PrepData();
        List<Task<WebsiteDataModel>> output = new();

        foreach (var website in websites)
        {
            output.Add(DownloadWebsiteAsync(website));
        }

        return (await Task.WhenAll(output)).ToList();
    }

    public static async Task<List<WebsiteDataModel>> RunDownloadParallelAsyncV2(IProgress<ProgressReportModel> progress)
    {
        List<string> websites = PrepData();
        List<WebsiteDataModel> output = new();
        ProgressReportModel report = new();

        await Task.Run(() =>
        {
            Parallel.ForEach<string>(websites, (siteUrl) =>
            {
                var data = DownloadWebsite(siteUrl);
                output.Add(data);
                report.CurrentSite = data;
                report.PercentageComplete = (output.Count * 100) / websites.Count;
                progress.Report(report);
            });
        });


    return output;
    }
    
}