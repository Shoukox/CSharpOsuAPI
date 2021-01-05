# CSharpOsuAPI
A library that allow you to work with osu API!
For Example:
Getting main class osuApi osuapi = new osuApi(osuToken);

string name = "Shoukko";
User user = await osuapi.GetUserInfoByNameAsync(name);
Console.WriteLine($"{user.username} {user.accuracy} {user.total_score} {user.count_rank_ss}");


Uses Newtonsoft.Json
