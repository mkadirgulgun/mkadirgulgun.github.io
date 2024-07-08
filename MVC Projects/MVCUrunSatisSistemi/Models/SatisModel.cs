using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCUrunSatisSistemi.Models;

public class Satis
{
    [Required]
    public string Name { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int Total { get; set; }

}

