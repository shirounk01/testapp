namespace testapp.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
