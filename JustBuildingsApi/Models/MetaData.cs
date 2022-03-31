namespace JustBuildingsApi.Models
{
    public class MetaData
    {
        public long Id { get; set; }
        public string? Label { get; set; }
        public string? Type { get; set; }
        public ICollection<VariablePoint>? Variables { get; set; }
    }
}