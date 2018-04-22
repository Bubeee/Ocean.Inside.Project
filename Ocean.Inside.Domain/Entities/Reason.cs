namespace Ocean.Inside.Domain.Entities
{
    public class Reason
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }

        public virtual Image Picture { get; set; }
    }
}