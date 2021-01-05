# osuApiSharp
A library that allow you to work with osu API!
For Example:
Getting main class osuApi osuapi = new osuApi(osuToken);

string name = "Shoukko";
User user = await osuapi.GetUserInfoByNameAsync(name);
Console.WriteLine($"{osuapi.username} {osuapi.accuracy} {osuapi.total_score} {osuapi.count_rank_ss}");
