using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities.Models;

public class Musteri : IEntity
{
    public int Id { get; set; }
    
    [Display(Name = "Arac")]
    public int AracId { get; set; }
    [StringLength(50)]
    [Display(Name = "Adi"),Required(ErrorMessage = "{0} Bos birakilamaz")]
    public string Ad { get; set; }
    [StringLength(50)]
    [Display(Name = "Soyadi"),Required(ErrorMessage = "{0} Bos birakilamaz")]
    public string SoyAd { get; set; }
    [StringLength(11)]
    [Display(Name = "TC Numarasi")]
    public string? TcNo { get; set; }
    [StringLength(50),Required(ErrorMessage = "{0} Bos birakilamaz")]
    public string Email { get; set; }

    [StringLength(500)]
    public string? Adress { get; set; }
    [StringLength(15)]
    public string? Telefon { get; set; }
    public string? Notlar { get; set; }
    
    [Display(Name = "Arac")]
    public virtual Arac? Arac { get; set; }
}