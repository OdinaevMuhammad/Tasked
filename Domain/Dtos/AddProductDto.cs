namespace Domain.Dtos;

public class AddProductDto {
    public int Id{get;set;}
    public string ProductName{get;set;}
    public int Supplied{get;set;}
    public DateTime OrderDate{get;set;}
    public decimal TotalAmount{get;set;}
}
