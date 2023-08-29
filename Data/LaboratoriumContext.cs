using ManajemenAlatLaboratorium.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ManajemenAlatLaboratorium.API.Data;

public class LaboratoriumContext : DbContext
{
    public LaboratoriumContext(DbContextOptions<LaboratoriumContext> options) : base(options)
    {
    }

    public DbSet<Alat> Alats => Set<Alat>();
    public DbSet<Peminjam> Peminjams => Set<Peminjam>();
    public DbSet<PeminjamanAlat> PeminjamanAlats => Set<PeminjamanAlat>();
    public DbSet<PeminjamanAlatDetail> PeminjamanAlatDetails => Set<PeminjamanAlatDetail>();
}