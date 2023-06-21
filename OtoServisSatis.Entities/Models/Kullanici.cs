using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtoServisSatis.Entities.Models;

public class Kullanici :IEntity
{
    public int Id { get; set; }
    
    [Display(Name = "Adı"), Required(ErrorMessage = "{0} Bos Birakilamaz")]
    public string Ad { get; set; }
    
    [StringLength(50),Display(Name = "Soyadi"), Required(ErrorMessage = "{0} Bos Birakilamaz")]
    public string SoyAd { get; set; }
    
    [StringLength(50),Required(ErrorMessage = "{0} Bos Birakilamaz")]
    public string Email { get; set; }
    public string? Telefon { get; set; }
    public string? KullaniciAdi { get; set; }
    public string Sifre { get; set; }
    public bool AktifMi { get; set; }
   
    [Display(Name = "Eklenme Tarihi"),ScaffoldColumn(false)]
    public DateTime? EklenmeTarihi { get; set; } = DateTime.Now;
   
    [Display(Name = "Rol"),Required(ErrorMessage = "{0} Bos Birakilimaz")]
    public int RolId { get; set; }
    
    public virtual Rol? Rol { get; set; }
}