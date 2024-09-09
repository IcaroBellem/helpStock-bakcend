using HelpStockApp.Domain.Validation;

namespace HelpStockApp.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, name is required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short. minimum 3 characters");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short. minimum 5 characters");
            DomainExceptionValidation.When(String.IsNullOrEmpty(description), "Invalid description, Description is required");
            DomainExceptionValidation.When(price < 0, "Invalid price, price negative value is unlikely");
            DomainExceptionValidation.When(stock < 0, "Invalid stock, stock can't be less than 0 ");
            DomainExceptionValidation.When(image.Length > 250, "Invalid URL, too long, Give a Valid URL");
        }

    }
}
