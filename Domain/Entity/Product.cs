namespace Domain.Entities;
public class Product {
    public int Id{get;set;}
    public string ProductName{get;set;}
    public int Supplied{get;set;}
    public DateTime OrderDate{get;set;}
    public decimal TotalAmount{get;set;}
    public List<OrderItem> OrderItems{get;set;}
}
