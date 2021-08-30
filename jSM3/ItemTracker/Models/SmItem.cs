namespace jSM3.ItemTracker.Models
{
    public class SmItem
    {
        public string? Name { get; init; }
        public bool Owned { get; set; }
        
        public bool Equipped { get; set; }
        
        public SmItem()
        {
            Owned = false;
            Equipped = false;
        }

    }
}