namespace Core.Entities
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Article { get; set; }
        public int PublishingYear { get; set; }
        public int Count { get; set; }
    }
}