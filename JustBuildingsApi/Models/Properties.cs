namespace JustBuildingsApi.Models
{
    public class Properties
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? StreetAddress { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}