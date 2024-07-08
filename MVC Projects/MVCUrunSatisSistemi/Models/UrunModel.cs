using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCUrunSatisSistemi.Models;


public class Urun
{
    [Required]
    public string Name { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public string Currency { get; set; }
    [Required]
    public int Stock { get; set; }
    [Required]
    public string ImgUrl { get; set; }
}