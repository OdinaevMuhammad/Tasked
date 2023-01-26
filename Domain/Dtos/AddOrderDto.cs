namespace Domain.Dtos;
public class AddOrderDto{
    public int Id{get;set;}
    public string OrderNumber{get;set;}
    public int CustomerId{get;set;}
    public  DateTime OrderDate{get;set;}
    public decimal TotalAmount{get;set;}

}
