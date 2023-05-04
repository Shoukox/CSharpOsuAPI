<h1>CSharpOsuAPI - fully asynchronous library to work with osu! API V1</h1> (An update for V2 is coming soon)

<h3>First, create an instance of the client to work with:</h3>

```csharp
  //Creating new instance of osuClient
  osuApiClient osuClient = new osuApiClient("your_token");
```

<h3>All the functions of osu!API V1 have been integrated into the library. Here is an example of how to use it:</h3>

```csharp
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
```
