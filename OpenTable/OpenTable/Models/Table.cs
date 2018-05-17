namespace OpenTable.Models
{
    public class Table
    {
        public int Id { get; set; }
        public double Left { get; set; }
        public double Top { get; set; }
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}