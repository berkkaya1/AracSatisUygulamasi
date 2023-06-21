using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities.Models;

public class Arac : IEntity
{
    public int Id { get; set; }
    
    [Display(Name = "Marka Adi"), Required(ErrorMessage = "{0} Bos Birakilamaz")]
    public int MarkaId { get; set; }
    
    [StringLength(50), Required(ErrorMessage = "{0} Bos Birakilamaz")]
    public string Renk { get; set; }
    
    [Display(Name = "Fiyati")]
    public decimal Fiyat { get; set; }
    
    [StringLength(50), Required(ErrorMessage = "{0} Bos Birakilamaz")]
    public string Model { get; set; }
    
    [StringLength(50),  Required(ErrorMessage = "{0} Bos Birakilamaz")]
    [Display(Name = "Kasa Tipi")]
    public string KasaTipi { get; set; }
    
    [Display(Name = "Model Yili")]
    public int ModelYili { get; set; }
    
    [Display(Name = "Satista mi?")]
    public bool SatistaMi { get; set; }
    
    [Display(Name = "Anasayfa")]
    public bool Anasayfa { get; set; }
    
    [Required(ErrorMessage = "{0} Bos birakilamaz")]
    public string Notlar { get; set; }

    [StringLength(100)]
    public string? Resim1 { get; set; }
    [StringLength(100)]
    public string? Resim2 { get; set; }
    [StringLength(100)]
    public string? Resim3 { get; set; }
    
    public virtual Marka? Marka { get; set; } //arac sinifi ile marka arasinda FK
    
    
}