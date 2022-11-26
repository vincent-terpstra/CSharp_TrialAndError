namespace SunsetLibrary;

public static class ComicProcessor
{
    public static async Task<ComicModel> LoadComic(int comicNumber = 0)
    {
        string url = comicNumber == 0
            ? @$"https://xkcd.com/info.0.json"
            : @$"https://xkcd.com/{comicNumber}/info.0.json";

        using HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            ComicModel comic = await response.Content.ReadAsAsync<ComicModel>();
            return comic;
        }

        throw new Exception(response.ReasonPhrase);
    }
}