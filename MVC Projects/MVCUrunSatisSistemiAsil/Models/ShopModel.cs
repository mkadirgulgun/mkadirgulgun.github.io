using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCUrunSatisSistemi.Models;


//public class Shop
//{
//    [Required]
//    public string Name { get; set; }
//    [Required]
//    public double Price { get; set; }
//    [Required]
//    public string Currency { get; set; }
//    [Required]
//    public int Stock { get; set; }
//    [Required]
//    public string ImgUrl { get; set; }
//}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class Payment
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public decimal Amount { get; set; }
    public bool IsPaymentSuccessful { get; set; }
}

public class CheckoutViewModel
{
    public List<Product> Products { get; set; }
    public string PaymentError { get; set; }
}
