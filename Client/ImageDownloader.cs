using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace TimerConsole
{
    internal static class HttpClientUtility
    {
        internal static async Task DownloadAsync(string uriString, string fileName)
        {
            using HttpClient client = new();
            using Stream s = await client.GetStreamAsync(new Uri(uriString));
            using FileStream fs = new(fileName, FileMode.Create);
            await s.CopyToAsync(fs);
        }

        internal static async Task<string> GetJson(string url)
        {
            using HttpClient httpClient = new();
            return await httpClient.GetStringAsync(url);
        }
    }
}

//// See https://aka.ms/new-console-template for more information
//using TimerConsole;

//foreach (Card card in JsonUtility.Deserialize<Rootobject>(await HttpClientUtility.GetJson("https://raw.githubusercontent.com/Latepate64/duel-masters-json/master/DuelMastersCards.json")).cards)
//{
//    foreach (Printing printing in card.printings.Where(p => !string.IsNullOrEmpty(p.image)))
//    {
//        await HttpClientUtility.DownloadAsync(printing.image, $"{card.name}.jpg");
//    }
//}