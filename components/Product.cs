namespace Cubereum_automation_project.components 
{
    /// <summary>
    /// Stores the Product search results
    /// </summary>
    public class Product
    {
        string productName;
        string price;

        public string ProductName { get => productName; set => productName = value; }
        public string Price { get => price; set => price = value; }
    }
}