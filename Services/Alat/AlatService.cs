using ManajemenAlatLaboratorium.API.Data;
using ManajemenAlatLaboratorium.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ManajemenAlatLaboratorium.API.Services;

public class AlatService : IAlatService
{
    private readonly LaboratoriumContext _context;

    public AlatService(LaboratoriumContext context)
    {
        _context = context;
    }

    public Alat? CreateAlat(Alat alat)
    {
        _context.Alats.Add(alat);
        int rowAffected = _context.SaveChanges();

        if (rowAffected == 0)
        {
            return null;
        }

        return alat;
    }

    public bool DeleteAlat(int id)
    {
        var alatToDelete = _context.Alats.Find(id);

        if (alatToDelete == null)
        {
            return false;
        }
        
        _context.Alats.Remove(alatToDelete);
        int rowsAffected = _context.SaveChanges();

        if (rowsAffected == 0)
        {
            return false;
        }

        return true;
    }

    public Alat? GetAlatById(int id)
    {
        var alat = _context.Alats
            .AsNoTracking()
            .FirstOrDefault(a => a.Id == id);

        return alat;
    }

    public IEnumerable<Alat> GetAllAlat()
    {
        var alats = _context.Alats
            .AsNoTracking()
            .ToList();

        return alats;
    }

    public bool UpdateAlat(int id, Alat alat)
    {
        var alatToUpdate = _context.Alats
            .SingleOrDefault(a => a.Id == id);

        if (alatToUpdate == null)
        {
            return false;
        }

        alatToUpdate.Nama = alat.Nama;
        alatToUpdate.Deskripsi = alat.Deskripsi;
        alatToUpdate.Total = alat.Total;

        int rowsAffected = _context.SaveChanges();

        if (rowsAffected == 0)
        {
            return false;
        }

        return true;
    }
}
