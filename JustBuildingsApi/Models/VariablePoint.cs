namespace JustBuildingsApi.Models
{
    public class VariablePoint
    {
        public long Id { get; set; }
        public string? Variable { get; set; }
        public decimal? Value { get; set; }
        public string? Label { get; set; }
    }
}