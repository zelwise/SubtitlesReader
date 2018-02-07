namespace SubtitlesReader
{
    public class SubtitleItem
    {
        public int Id { get; set; }
        public string TimeString { get; set; }
        public string TimeStringStart {
            get
            {
                if (!string.IsNullOrWhiteSpace(TimeString))
                {
                    return TimeString.Substring(0, 8);
                }
                return string.Empty;
            }
        }
        public string Content { get; set; }
    }
}
