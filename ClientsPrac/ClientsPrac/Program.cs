using dApp.Net;

namespace dApp
{
    public class MainScript
    {
        public static readonly string Url = @"https://www.sourcejump.net/leaderboards";
        public static readonly string Browser = @"C:\Program Files\Google\Chrome\Application\chrome.exe";

        public static async Task Main()
        {
            var dynamicHtml = new DynamicHtmlLoader(Url, Browser);
            var html = await dynamicHtml.GetDynamicHtmlAsync();

            Console.WriteLine(html);
        }
    }
}