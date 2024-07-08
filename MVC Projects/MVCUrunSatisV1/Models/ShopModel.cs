using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCUrunSatisSistemi.Models;


public class Shop
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Price { get; set; }
    [Required]
    public string Currency { get; set; }
    [Required]
    public int Stock { get; set; }
    [Required]
    public string ImgUrl { get; set; }
}

public class PaymentViewModel
{
    public int SelectedProduct { get; set; }
    public int Payment { get; set; }
    public string ErrorMessage { get; set; }
    public double Change { get; set; }
}