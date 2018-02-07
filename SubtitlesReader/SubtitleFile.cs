using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitlesReader
{
    public class SubtitleFile
    {
        public List<SubtitleItem> Items { get; set; }
        public string FilePath { get; set; }

        public SubtitleFile(string filePath)
        {
            FilePath = filePath;
            Items = new List<SubtitleItem>();
        }
    }
}
