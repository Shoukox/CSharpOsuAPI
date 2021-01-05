namespace tgbot_final.Bot.Osu.Types
{
    public class Score
    {
        public string beatmap_id { get; set; }
        public string score_id { get; set; }
        public string score { get; set; }
        public string maxcombo { get; set; }
        public string count50 { get; set; }
        public string count100 { get; set; }
        public string count300 { get; set; }
        public string countmiss { get; set; }
        public string countkatu { get; set; }
        public string countgeki { get; set; }
        public string perfect { get; set; }
        public string enabled_mods { get; set; }
        public string user_id { get; set; }
        public string date { get; set; }
        public string rank { get; set; }
        public string pp { get; set; }
        public string replay_available { get; set; }
    }
}
