using System;

namespace InfoSeries.Core.Models
{
    public class SerieSearch
    {
        public int Id { get; set; }
        public string Language { get; set; }
        public string Name { get; set; }
        public string Banner { get; set; }
        public string Poster { get; set; }
        public string Overview { get; set; }
        public DateTimeOffset? FirstAired { get; set; }
        public string Network { get; set; }
        public string ImdbId { get; set; }
        public SearchProviderType SearchProviderType { get; set; }
    }

    public enum SearchProviderType
    {
        External,
        Internal
    }
}
