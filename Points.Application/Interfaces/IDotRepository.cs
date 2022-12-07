using System.Collections.Generic;
using System.Threading.Tasks;
using Points.Domain.Entities;
using Points.Domain.ViewModels;

namespace Points.Application.Interfaces
{
    public interface IDotRepository
    {
        Task<Dot> CreateDot(DotViewModel dot);
        Task<bool> RemoveDot(int dotId);
        Task<IEnumerable<Dot>> GetAllDots();
        Task<bool> SaveDotAsync();
    }
}