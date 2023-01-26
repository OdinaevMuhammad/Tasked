using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;
public class CustomerDto
{
   
    public int  Id{get;set;}
      [Required(ErrorMessage = "First name should not be empty")]
    public string FirstName{get;set;}
      [Required(ErrorMessage = "LastName name should not be empty")]
    public string LastName{get;set;}
    public string PhoneNumber{get;set;}
    public string Email{get;set;}
}