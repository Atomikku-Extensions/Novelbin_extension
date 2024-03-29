﻿namespace Novelbin.Core.Domain.Models
{
    public class Data
    {
        public WebConfiguration WebConfiguration { get; set; }
        public FileConfiguration FileConfiguration { get; set; }
        public List<ChapterOld>? Chapters { get; set; }

        public Data(
            WebConfiguration webConfiguration,
            FileConfiguration fileConfiguration)
        {
            WebConfiguration = webConfiguration;
            FileConfiguration = fileConfiguration;
        }
    }
}