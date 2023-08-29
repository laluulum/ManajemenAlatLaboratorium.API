using ManajemenAlatLaboratorium.API.Data;
using ManajemenAlatLaboratorium.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ManajemenAlatLaboratorium.API.Services;

public class PeminjamService : IPeminjamService
{
    private readonly LaboratoriumContext _context;

    public PeminjamService(LaboratoriumContext context)
    {
        _context = context;
    }

    public Peminjam? CreatePeminjam(Peminjam peminjam)
    {
        _context.Peminjams.Add(peminjam);
        int rowsAffected = _context.SaveChanges();

        if (rowsAffected == 0)
        {
            return null;
        }

        return peminjam;
    }

    public IEnumerable<Peminjam> GetAllPeminjam()
    {
        var peminjams = _context.Peminjams
            .AsNoTracking()
            .ToList();

        return peminjams;
    }

    public Peminjam? GetPeminjamById(int id)
    {
        var peminjam = _context.Peminjams
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == id);

        if (peminjam == null)
        {
            return null;
        }

        return peminjam;
    }

    public bool UpdatePeminjam(int id, Peminjam peminjam)
    {
        var peminjamToUpdate = _context.Peminjams
            .SingleOrDefault(p => p.Id == id);

        if (peminjamToUpdate == null)
        {
            return false;
        }

        peminjamToUpdate.Nama = peminjam.Nama;
        peminjamToUpdate.Email = peminjam.Email;
        peminjamToUpdate.NomorHandphone = peminjam.NomorHandphone;
        peminjamToUpdate.Aktif = peminjam.Aktif;

        int rowsAffected = _context.SaveChanges();

        if (rowsAffected == 0)
        {
            return false;
        }

        return true;
    }
}
