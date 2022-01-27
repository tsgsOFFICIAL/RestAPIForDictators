namespace RestAPIForDictators.Models
{
    public class DictatorItem
    {
        public long? id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public int? birthYear { get; set; }
        public int? deathYear { get; set; }
        public string? description { get; set; }
    }
}
