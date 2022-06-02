using PuppeteerSharp;

namespace dApp.Net
{
    public class DynamicHtmlLoader
    {
        public string Url { get; init; }
        public string BrowserPath { get; init; }

        public DynamicHtmlLoader(string url, string browserPath)
        {
            if (url is null || browserPath is null)
            {
                throw new ArgumentNullException();
            }

            Url = url;
            BrowserPath = browserPath;
        }

        public async Task<string> GetDynamicHtmlAsync()
        {
            var options = new LaunchOptions
            {
                Headless = true,
                Product = Product.Chrome,
                ExecutablePath = BrowserPath
            };

            var browser = await Puppeteer.LaunchAsync(options, null);
            var page = await browser.NewPageAsync();
            var response = await page.GoToAsync(Url);

            if (response.Ok)
            {
                return await page.GetContentAsync();
            }
            else
            {
                return await Task.Run(() =>
                {
                    return string.Empty;
                });
            }
        }
    }
}
