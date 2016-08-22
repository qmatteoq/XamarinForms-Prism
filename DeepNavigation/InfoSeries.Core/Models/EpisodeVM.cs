using System;
using System.Collections.Generic;

namespace InfoSeries.Core.Models
{
    public class EpisodeVM
    {
        public int Id { get; set; }
        public string Director { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public int SeasonNumber { get; set; }
        public int TvdbId { get; set; }
        public string Overview { get; set; }
        public DateTimeOffset? FirstAired { get; set; }
        public List<string> Writers { get; set; }
        public string Image { get; set; }
        public string ImdbId { get; set; }
        public int SerieId { get; set; }
        public string SerieName { get; set; }
        public ImagesSerieVM SeriesImage { get; set; }
    }
}
