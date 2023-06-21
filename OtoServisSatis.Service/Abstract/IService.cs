using Microsoft.EntityFrameworkCore.Internal;
using OtoServisSatis.Data.Abstract;
using OtoServisSatis.Entities.Models;

namespace OtoServisSatis.Service.Abstract;

public interface IService<T> : IRepository<T> where T: class, IEntity, new()
{
    
}