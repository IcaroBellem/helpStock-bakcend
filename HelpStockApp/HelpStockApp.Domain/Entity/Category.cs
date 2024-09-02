namespace HelpStockApp.Domain.Entity
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name; 
        }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
