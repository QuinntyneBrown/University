using University.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace University.Api.Interfaces
{
    public interface IUniversityDbContext
    {
        DbSet<Cellphone> Cellphones { get; }
        DbSet<Book> Books { get; }
        DbSet<Student> Students { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
