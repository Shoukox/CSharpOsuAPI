using Newtonsoft.Json;
using osu_API_CSharp;
using osu_API_CSharp.Types.Enums;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating new instance of osuClient
            osuApiClient osuClient = new osuApiClient("67368ae869a6b45f012b6a7a8536ee65226ad257");

            //Getting user
            var user = osuClient.GetUserAsync("Shoukko").Result;
            Console.WriteLine($"Username: {user.Username}\nPPCount: {user.PPRaw}\n");

            //Getting beatmap
            var beatmap = osuClient.GetBeatmapsAsync(1811527).Result.First();
            Console.WriteLine($"BM Name: {beatmap.Title}\nBM Diff: {beatmap.Difficultyrating}\n");

            //Getting scores
            var scores = osuClient.GetScoresAsync(1811527, "Shoukko", type: EUserType.String).Result;
            Console.WriteLine($"Score's date: {scores.First().Date}\nScore's pp: {scores.First().PP}\n");

            //Getting user's best scores
            var bestScores = osuClient.GetUserBestScoresAsync("Shoukko", type: EUserType.String).Result;
            Console.WriteLine($"The best score: {bestScores.First().PP}\n");

            //Getting user's recent scores
            var recentScores = osuClient.GetUserRecentScoresAsync("Shoukko", type: EUserType.String).Result;
            Console.WriteLine($"Recent scores count: {recentScores.Length}\n");

            //Getting information about multiplayer match
            var multiplayerMatch = osuClient.GetMultiplayerMatchInfoAsync(107936575).Result;
            Console.WriteLine($"Multiplayer match name: {multiplayerMatch.Match.Name}\nGames count: {multiplayerMatch.Games.Length}\n");

            //Getting replay
            var replay = osuClient.GetReplayDataAsync(1690353, "Shoukko", EUserType.String).Result;
            Console.WriteLine($"Replay: {replay.Content.Substring(0, 10)}... (and a lot of characters)\n");
        }
    }
}