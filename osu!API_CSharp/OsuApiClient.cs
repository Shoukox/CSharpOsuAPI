using osu_API_CSharp.Models.Enums;
using osu_API_CSharp.Types;
using osu_API_CSharp.Types.Enums;
using System.Xml.Linq;
using osu_API_CSharp.Utils;
using Newtonsoft.Json;
using osu_API_CSharp.Models;
using System.Text.RegularExpressions;

namespace osu_API_CSharp
{
    public class osuApiClient
    {
        private readonly string apiToken;
        private readonly string baseUrl = "https://osu.ppy.sh/api";

        public osuApiClient(string apiToken)
        {
            this.apiToken = apiToken;
        }

        /// <summary>
        /// Get osu! user by defined parameters
        /// </summary>
        /// <param name="user">specify a user_id or a username to return metadata from</param>
        /// <param name="mode">mode (0 = osu!, 1 = Taiko, 2 = CtB, 3 = osu!mania). Optional, default value is 0.</param>
        /// <param name="type">specify if <paramref name="user"/> is a user_id or a username. Use <c>EUserType.String</c> for usernames or <c>EUserType.Id</c> for user_ids. Optional, default behaviour is automatic recognition (may be problematic for usernames made up of digits only).</param>
        /// <param name="event_days">Max number of days between now and last event date. Range of 1-31. Optional, default value is 1.</param>
        /// <returns></returns>
        public async Task<User> GetUserAsync(string user, int mode = 0, EUserType? type = null, int event_days = 1)
        {
            if (string.IsNullOrEmpty(user))
                throw new ArgumentNullException(nameof(user));

            string url = baseUrl + $"/get_user"
                .AddUrlParameter("k", $"{apiToken}", true)
                .AddUrlParameter("event_days", $"{event_days}")
                .AddUrlParameter("m", $"{mode}")
                .AddUrlParameter("u", $"{user}");

            if (type.HasValue)
                url = url.AddUrlParameter("type", $"{type.ToString()}");

            var response = await MakeRequest.Create().GetResponse(url);
            var users = await response.ReadResponseAndConvertJSONTo<User[]>();
            return users.First();
        }

        /// <summary>
        /// Get Beatmaps by defined parameters
        /// </summary>
        /// <param name="since">return all beatmaps ranked or loved since this date. Must be a MySQL date. In UTC</param>
        /// <param name="beatmapSetId">specify a beatmapset_id to return metadata from.</param>
        /// <param name="beatmapId">specify a beatmap_id to return metadata from.</param>
        /// <param name="user">specify a user_id or a username to return metadata from.</param>
        /// <param name="type">specify if <paramref name="user"/> is a user_id or a username. Use <c>EUserType.String</c> for usernames or <c>EUserType.Id</c> for user_ids. Optional, default behaviour is automatic recognition (may be problematic for usernames made up of digits only).</param>
        /// <param name="mode">mode (0 = osu!, 1 = Taiko, 2 = CtB, 3 = osu!mania). Optional, maps of all modes are returned by default.</param>
        /// <param name="convertedMapsInclduded">specify whether converted beatmaps are included (0 = not included, 1 = included). Only has an effect if m is chosen and not 0. Converted maps show their converted difficulty rating. Optional, default is 0.</param>
        /// <param name="beatmapHash">the beatmap hash. It can be used, for instance, if you're trying to get what beatmap has a replay played in, as .osr replays only provide beatmap hashes (example of hash: a5b99395a42bd55bc5eb1d2411cbdf8b). Optional, by default all beatmaps are returned independently from the hash.</param>
        /// <param name="limit">the amount of results. Optional, default and maximum are 500.</param>
        /// <param name="mods">mods that applies to the beatmap requested. Optional, default is 0. (Note that requesting multiple mods is supported, but it should not contain any non-difficulty-increasing mods or the return value will be invalid.)</param>
        /// <returns></returns>
        public async Task<Beatmap[]> GetBeatmapsAsync
            (long? beatmapId = null, DateTime? since = null, long? beatmapSetId = null, string? user = null,
            EUserType? type = null, int? mode = null, int? convertedMapsInclduded = null, string? beatmapHash = null,
            int? limit = null, EMods? mods = null)
        {
            string url = baseUrl + $"/get_beatmaps"
                .AddUrlParameter("k", $"{apiToken}", true);

            if (since.HasValue)
                url = url.AddUrlParameter("since", $"{since.Value.FormatMySQL()}");
            if (beatmapId.HasValue)
                url = url.AddUrlParameter("b", $"{beatmapId}");
            if (beatmapSetId.HasValue)
                url = url.AddUrlParameter("s", $"{beatmapSetId}");
            if (!String.IsNullOrEmpty(user))
                url = url.AddUrlParameter("u", $"{user}");
            if (type.HasValue)
                url = url.AddUrlParameter("type", $"{type.ToString()}");
            if (mode.HasValue)
                url = url.AddUrlParameter("m", $"{mode}");
            if (convertedMapsInclduded.HasValue)
                url = url.AddUrlParameter("a", $"{convertedMapsInclduded}");
            if (!String.IsNullOrEmpty(beatmapHash))
                url = url.AddUrlParameter("h", $"{beatmapHash}");
            if (limit.HasValue)
                url = url.AddUrlParameter("limit", $"{limit}");
            if (mods.HasValue)
                url = url.AddUrlParameter("mods", $"{mods}");

            var response = await MakeRequest.Create().GetResponse(url);
            var beatmaps = await response.ReadResponseAndConvertJSONTo<Beatmap[]>();
            return beatmaps;
        }

        /// <summary>
        /// Get scores by defined parameters
        /// </summary>
        /// <param name="beatmapId">specify a beatmap_id to return score information from</param>
        /// <param name="user">specify a user_id or a username to return score information for.</param>
        /// <param name="mode">mode (0 = osu!, 1 = Taiko, 2 = CtB, 3 = osu!mania). Optional, default value is 0.</param>
        /// <param name="mods">specify a mod or mod combination</param>
        /// <param name="type">specify if <paramref name="user"/> is a user_id or a username. Use <c>EUserType.String</c> for usernames or <c>EUserType.Id</c> for user_ids. Optional, default behaviour is automatic recognition (may be problematic for usernames made up of digits only).</param>
        /// <param name="limit">the number of results from the top (range between 1 and 100 - defaults to 50).</param>
        /// <returns></returns>
        public async Task<Score[]> GetScoresAsync(long beatmapId, string? user = null, int mode = 0, EMods? mods = null, EUserType? type = null, int limit = 50)
        {
            string url = baseUrl + $"/get_scores"
                .AddUrlParameter("k", $"{apiToken}", true)
                .AddUrlParameter("b", $"{beatmapId}")
                .AddUrlParameter("mode", $"{mode}")
                .AddUrlParameter("limit", $"{limit}");

            if (type.HasValue)
                url = url.AddUrlParameter("type", $"{type.ToString()}");
            if (!String.IsNullOrEmpty(user))
                url = url.AddUrlParameter("u", $"{user}");
            if (mods.HasValue)
                url = url.AddUrlParameter("mods", $"{mods.Value}");

            var response = await MakeRequest.Create().GetResponse(url);
            var scores = await response.ReadResponseAndConvertJSONTo<Score[]>();
            return scores;
        }

        /// <summary>
        /// Get user's best scores.
        /// </summary>
        /// <param name="user">specify a user_id or a username to return best scores from</param>
        /// <param name="mode">mode (0 = osu!, 1 = Taiko, 2 = CtB, 3 = osu!mania). Optional, default value is 0.</param>
        /// <param name="limit">amount of results (range between 1 and 100 - defaults to 10).</param>
        /// <param name="type">specify if <paramref name="user"/> is a user_id or a username. Use <c>EUserType.String</c> for usernames or <c>EUserType.Id</c> for user_ids. Optional, default behaviour is automatic recognition (may be problematic for usernames made up of digits only).</param>
        /// <returns></returns>
        public async Task<Score[]> GetUserBestScoresAsync(string user, int mode = 0, int limit = 10, EUserType? type = null)
        {
            string url = baseUrl + $"/get_user_best"
               .AddUrlParameter("k", $"{apiToken}", true)
               .AddUrlParameter("u", $"{user}")
               .AddUrlParameter("mode", $"{mode}")
               .AddUrlParameter("limit", $"{limit}");

            if (type.HasValue)
                url = url.AddUrlParameter("type", $"{type.ToString()}");

            var response = await MakeRequest.Create().GetResponse(url);
            var bestScores = await response.ReadResponseAndConvertJSONTo<Score[]>();
            return bestScores;
        }

        /// <summary>
        /// Get user's recent scores
        /// </summary>
        /// <param name="user">specify a user_id or a username to return recent plays from (required).</param>
        /// <param name="mode">mode (0 = osu!, 1 = Taiko, 2 = CtB, 3 = osu!mania). Optional, default value is 0.</param>
        /// <param name="limit">amount of results (range between 1 and 50 - defaults to 10).</param>
        /// <param name="type">specify if <paramref name="user"/> is a user_id or a username. Use <c>EUserType.String</c> for usernames or <c>EUserType.Id</c> for user_ids. Optional, default behaviour is automatic recognition (may be problematic for usernames made up of digits only).</param>
        /// <returns></returns>
        public async Task<Score[]> GetUserRecentScoresAsync(string user, int mode = 0, int limit = 10, EUserType? type = null)
        {
            string url = baseUrl + $"/get_user_recent"
                .AddUrlParameter("k", $"{apiToken}", true)
                .AddUrlParameter("u", $"{user}")
                .AddUrlParameter("mode", $"{mode}")
                .AddUrlParameter("limit", $"{limit}");

            if (type.HasValue)
                url = url.AddUrlParameter("type", $"{type.ToString()}");

            var response = await MakeRequest.Create().GetResponse(url);
            var recentScores = await response.ReadResponseAndConvertJSONTo<Score[]>();
            return recentScores;
        }

        /// <summary>
        /// Get information about multiplayer match
        /// </summary>
        /// <param name="matchId">match id to get information from (required).</param>
        /// <returns></returns>
        public async Task<MultiplayerMatch> GetMultiplayerMatchInfoAsync(long matchId)
        {
            string url = baseUrl + $"/get_match"
                .AddUrlParameter("k", $"{apiToken}", true)
                .AddUrlParameter("mp", $"{matchId}");

            var response = await MakeRequest.Create().GetResponse(url);
            var multiplayerMatch = await response.ReadResponseAndConvertJSONTo<MultiplayerMatch>();
            return multiplayerMatch;
        }

        /// <summary>
        /// Get replay data
        /// </summary>
        /// <param name="beatmapId">the beatmap ID (not beatmap set ID!) in which the replay was played (required).</param>
        /// <param name="user">the user that has played the beatmap (required).</param>
        /// <param name="type">specify if <paramref name="user"/> is a user_id or a username. Use <c>EUserType.String</c> for usernames or <c>EUserType.Id</c> for user_ids. Optional, default behaviour is automatic recognition (may be problematic for usernames made up of digits only).</param>
        /// <param name="m">the mode the score was played in.</param>
        /// <param name="scoreId">specify a score id to retrieve the replay data for. May be passed instead of <paramref name="beatmapId"/> and <paramref name="user"/> </param>
        /// <param name="mods">specify a mod or mod combination</param>
        /// <returns></returns>
        public async Task<Replay> GetReplayDataAsync(long beatmapId, string user, EUserType? type = null, int? mode = null, long? scoreId = null, EMods? mods = null)
        {
            string url = baseUrl + $"/get_replay"
               .AddUrlParameter("k", $"{apiToken}", true)
               .AddUrlParameter("b", $"{beatmapId}")
               .AddUrlParameter("u", $"{user}");

            if (type.HasValue)
                url = url.AddUrlParameter("type", $"{type.ToString()}");
            if (mode.HasValue)
                url = url.AddUrlParameter("m", $"{mode}");
            if (scoreId.HasValue)
                url = url.AddUrlParameter("s", $"{scoreId}");
            if(mods.HasValue)
                url = url.AddUrlParameter("mods", $"{mods.Value}");

            var response = await MakeRequest.Create().GetResponse(url);
            var replay = await response.ReadResponseAndConvertJSONTo<Replay>();
            return replay;
        }
    }
}