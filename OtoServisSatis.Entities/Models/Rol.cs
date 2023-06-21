using System.ComponentModel.DataAnnotations;

namespace OtoServisSatis.Entities.Models;

public class Rol : IEntity
{
    public int Id { get; set; }
    
    [StringLength(50),Display(Name = "Ad"), Required(ErrorMessage = "{0} Bos Birakilamaz")]
    public string Ad { get; set; }
}