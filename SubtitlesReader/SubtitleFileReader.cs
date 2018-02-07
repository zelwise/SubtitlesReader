using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SubtitlesReader
{
    public class SubtitleFileReader
    {
        public static SubtitleFile ReadFile(string filePath)
        {
            var subtitleFile = new SubtitleFile(filePath);

            var newLine = true;
            var lineIndex = 1;
            var subtitleItem = new SubtitleItem();
            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    if (newLine)
                    {
                        subtitleItem = new SubtitleItem {Id = int.Parse(line)};
                        lineIndex = 1;
                    }

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        newLine = true;
                        subtitleFile.Items.Add(subtitleItem);
                    }
                    else
                    {
                        newLine = false;
                        if (lineIndex == 2)
                        {
                            subtitleItem.TimeString = line;
                        }
                        else if (lineIndex > 2)
                        {
                            subtitleItem.Content += " " + Regex.Replace(line, @"<[^>]*>", String.Empty);
                        }
                    }
                    lineIndex++;
                }
            }


            return subtitleFile;
        }
    }
}
