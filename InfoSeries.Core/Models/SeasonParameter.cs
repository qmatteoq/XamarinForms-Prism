namespace InfoSeries.Core.Models
{
    public class SeasonParameter
    {
        public int SeriesId { get; set; }

        public SeasonVM SelectedSeason { get; set; }

        public SeasonParameter(int id, SeasonVM season)
        {
            SeriesId = id;
            SelectedSeason = season;
        }
    }
}
