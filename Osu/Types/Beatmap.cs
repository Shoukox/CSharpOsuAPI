namespace tgbot_final.Bot.Osu.Types
{
    public class Beatmap
    {
        public string beatmapset_id { get; set; }
        public string beatmap_id { get; set; }
        public string total_length { get; set; }
        public string hit_length { get; set; }
        public string version { get; set; }
        public string file_md5 { get; set; }
        public string diff_size { get; set; }
        public string diff_overall { get; set; }
        public string diff_approach { get; set; }
        public string diff_drain { get; set; }
        public string mode { get; set; }
        public string count_normal { get; set; }
        public string count_slider { get; set; }
        public string count_spinner { get; set; }
        public string submit_date { get; set; }
        public string approved_date { get; set; }
        public string last_update { get; set; }
        public string artist { get; set; }
        public string artist_unicode { get; set; }
        public string title { get; set; }
        public string title_unicode { get; set; }
        public string creator { get; set; }
        public string creator_id { get; set; }
        public string bpm { get; set; }
        public string source { get; set; }
        public string tags { get; set; }
        public string genre_id { get; set; }
        public string language_id { get; set; }
        public string favourite_count { get; set; }
        public string rating { get; set; }
        public string storyboard { get; set; }
        public string video { get; set; }
        public string download_unavailable { get; set; }
        public string audio_unavailable { get; set; }
        public string playcount { get; set; }
        public string passcount { get; set; }
        public string packs { get; set; }
        public string max_combo { get; set; }
        public string diff_aim { get; set; }
        public string diff_speed { get; set; }
        public string difficultyrating { get; set; }
        private string approved { get; set; }
        public string GetApproved()
        {
            if (approved == "1") return "Ranked";
            return "not Ranked";
        }
    }
}
