namespace products;

public class Product
{
    public int productNumber { get; set; }
    public string productName { get; set; }
    public string? scrumMaster { get; set; }
    public string? productOwner { get; set; }
    public List<string>? developerNames { get; set; }
    public DateOnly startDate { get; set; }
    public string? methodology { get; set; }

    public Product(int productNumber, string productName, string? scrumMaster, string? productOwner, List<string>? developerNames, DateOnly startDate, string? methodology)
    {
        this.productNumber = productNumber;
        this.productName = productName;
        this.scrumMaster = scrumMaster;
        this.productOwner = productOwner;
        this.developerNames = developerNames;
        this.startDate = startDate;
        this.methodology = methodology;
    }
}

public class Products
{
    public List<Product> products { get; set; }
    public int count { get; set; }

    public Products()
    {
        products = new List<Product>();
        count = 0;
    }
}
