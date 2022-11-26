namespace SunsetLibrary;

public static class SunriseProcessor
{
    public static async Task<SunriseModel> LoadSunriseModel()
    {
        double 
            lat = 43.7364399,
            lng = -81.7061067;
        string url = $"https://api.sunrise-sunset.org/json?lat={lat}&lng={lng}&date=today";

        using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var results = await response.Content.ReadAsAsync<SunriseResults>();
            return results.Results;
        }

        throw new Exception(response.ReasonPhrase);
    }
}