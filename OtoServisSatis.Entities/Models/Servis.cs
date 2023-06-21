using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities.Models;

public class Servis : IEntity
{
    public int Id { get; set; }
    
    [DisplayName("Servise Gelis Tarihi")]
    public DateTime ServiseGelisTarihi { get; set; }
    
    [DisplayName("Arac Sorunu"),Required(ErrorMessage = "{0} Bos Birakilamaz!")]
    public string AracSorunu { get; set; }
    
    [DisplayName("Servis Ucreti")]
    public decimal ServisUcreti { get; set; }
    
    [DisplayName("Servisten Cikis Tarihi")]
    public DateTime ServistenCikisTarihi { get; set; }
    
    [DisplayName("Yapilan Islemler")]
    public string? YapilanIslemler { get; set; }
    
    [DisplayName("Garanti Kapsaminda mi?")]
    public bool GarantiKapsamindaMi { get; set; }
    
    [StringLength(15)]
    [DisplayName("Arac Plaka"),Required(ErrorMessage = "{0} Bos Birakilamaz!")]
    public string AracPlaka { get; set; }
    
    [StringLength(50),Required(ErrorMessage = "{0} Bos Birakilamaz!")]
    public string Marka { get; set; }
    
    [StringLength(50)]
    public string? Model { get; set; }
    
    [StringLength(50)]
    [DisplayName("Kasa Tipi")]
    public string? KasaTipi { get; set; }
    
    [StringLength(50)]
    [DisplayName("Sase No")]
    public string? SaseNo { get; set; }
    
    [Required(ErrorMessage = "{0} Bos Birakilamaz!")]
    public string Notlar { get; set; }
    
}