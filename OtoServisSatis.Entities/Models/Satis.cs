using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtoServisSatis.Entities.Models;

public class Satis : IEntity
{
    public int Id { get; set; }
    [DisplayName("Arac")]
    public int AracId { get; set; }
    [DisplayName("Musteri")]
    public int MusteriId { get; set; }
    [DisplayName("Satis Fiyati")]
    public decimal SatisFiyati { get; set; }
    [DisplayName("Satis Tarihi")]
    public DateTime SatisTarihi { get; set; }
    
    [DisplayName("Arac")]
    public virtual Arac? Arac { get; set; }
    [DisplayName("Musteri")]
    public virtual Musteri? Musteri { get; set; }
}