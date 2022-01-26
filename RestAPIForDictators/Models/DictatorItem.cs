namespace RestAPIForDictators.Models
{
    public class DictatorItem
    {
        public long? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public string? Description { get; set; }
    }
}
