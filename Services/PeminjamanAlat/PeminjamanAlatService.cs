using System.Reflection;
using ManajemenAlatLaboratorium.API.Contracts.PeminjamanAlat;
using ManajemenAlatLaboratorium.API.Data;
using ManajemenAlatLaboratorium.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ManajemenAlatLaboratorium.API.Services;

public class PeminjamanAlatService : IPeminjamanAlatService
{
    private readonly LaboratoriumContext _context;

    public PeminjamanAlatService(LaboratoriumContext context)
    {
        _context = context;
    }

    public PeminjamanAlat? CreatePeminjamanAlat(PeminjamanAlat peminjamanAlat)
    {
        var now = DateTime.Now;

        if (peminjamanAlat.TanggalPeminjaman == DateTime.MinValue)
        {
            peminjamanAlat.TanggalPeminjaman = now;
        }

        peminjamanAlat.TanggalPengembalian = now.AddDays(7);

        _context.PeminjamanAlats.Add(peminjamanAlat);
        if (_context.SaveChanges() == 0)
        {
            return null;
        }

        return peminjamanAlat;
    }

    // private List<PeminjamanAlatDetail>? CreatePeminjamanAlatDetail(PeminjamanAlat peminjamanAlat)
    // {
    //     foreach (var detail in peminjamanAlat.Details!)
    //     {
    //         _context.PeminjamanAlatDetails.Add(detail);
    //     }

    //     int rowsAffected = _context.SaveChanges();

    //     if (rowsAffected != peminjamanAlat.Details.Count)
    //     {
    //         return null;
    //     }

    //     return peminjamanAlat.Details.ToList();
    // }

    public IEnumerable<PeminjamanAlat> GetAllPeminjamanAlat()
    {
        var peminjamanAlats = _context.PeminjamanAlats
            .AsNoTracking()
            .Include(pa => pa.Peminjam)
            .Include(pa => pa.Details!)
                .ThenInclude(d => d.Alat)
            .ToList();

        return peminjamanAlats;
    }

    public PeminjamanAlat? GetPeminjamanAlatById(int id)
    {
        var peminjamanAlat = _context.PeminjamanAlats
            .AsNoTracking()
            .Include(pa => pa.Peminjam)
            .Include(pa => pa.Details!)
                .ThenInclude(d => d.Alat)
            .FirstOrDefault(pa => pa.Id == id);

        return peminjamanAlat;
    }

    public bool UpdatePeminjamanAlat(int id, PeminjamanAlat peminjamanAlat)
    {
        var peminjamanAlatToUpdate = _context.PeminjamanAlats
            .Include(pa => pa.Peminjam)
            .Include(pa => pa.Details!)
                .ThenInclude(d => d.Alat)
            .SingleOrDefault(pa => pa.Id == id);
        
        if (peminjamanAlatToUpdate == null)
        {
            return false;
        }

        if (peminjamanAlat.DikembalikanPadaTanggal != DateTime.MinValue)
        {
            peminjamanAlatToUpdate.DikembalikanPadaTanggal = peminjamanAlat.DikembalikanPadaTanggal;
        }

        if (peminjamanAlat.TanggalPeminjaman != peminjamanAlatToUpdate.TanggalPeminjaman && peminjamanAlat.TanggalPeminjaman != DateTime.MinValue)
        {
            peminjamanAlatToUpdate.TanggalPeminjaman = peminjamanAlat.TanggalPeminjaman;
            peminjamanAlatToUpdate.TanggalPengembalian = peminjamanAlatToUpdate.TanggalPeminjaman.AddDays(7);
        }

        if (peminjamanAlatToUpdate.Peminjam != peminjamanAlat.Peminjam)
        {
            peminjamanAlatToUpdate.Peminjam = peminjamanAlat.Peminjam;
        }

        if (peminjamanAlatToUpdate.Details != peminjamanAlat.Details)
        {
            // foreach (var detail in peminjamanAlatToUpdate.Details!)
            // {
            //     _context.PeminjamanAlatDetails.Remove(detail);
            // }

            _context.PeminjamanAlatDetails.RemoveRange(peminjamanAlatToUpdate.Details!);

            peminjamanAlatToUpdate.Details = peminjamanAlat.Details;
        }

        int rowsAffected = _context.SaveChanges();

        if (rowsAffected == 0)
        {
            return false;
        }

        return true;
    }

    public List<Alat>? GetAlatByIds(List<int> alatIds)
    {
        var alats = _context.Alats
            .Where(a => alatIds.Contains(a.Id))
            .ToList();
        
        if (alats.Count == 0)
        {
            return null;
        }

        return alats;
    }

    public Peminjam? GetPeminjamById(int id)
    {
        var peminjam = _context.Peminjams
            .FirstOrDefault(p => p.Id == id);

        return peminjam;
    }

    public bool IsPengembalianOnly(int id, UpdatePeminjamanAlatRequest request)
    {
        if (request.PeminjamId == 0 &&
            request.TanggalPeminjaman == DateTime.MinValue &&
            request.DetailPeminjamanAlat == null &&
            request.DikembalikanPadaTanggal != DateTime.MinValue && 
            request.DikembalikanPadaTanggal != null)
        {
            using var transaction = _context.Database.BeginTransaction();
            int rowsAffected = _context.Database
                .ExecuteSqlInterpolated($"UPDATE PeminjamanAlats SET DikembalikanPadaTanggal = {request.DikembalikanPadaTanggal} WHERE Id = {id}");

            if (rowsAffected > 0)
            {
                transaction.Commit();
                return true;
            }
            else
            {
                transaction.Rollback();
                return false;
            }
        }

        return false;
    }

    public bool DeletePeminjamanAlat(int id)
    {
        var peminjamanAlat = _context.PeminjamanAlats
            .Include(pa => pa.Peminjam)
            .Include(pa => pa.Details!)
                .ThenInclude(d => d.Alat)
            .SingleOrDefault(pa => pa.Id == id);

        if (peminjamanAlat == null)
        {
            return false;
        }

        _context.PeminjamanAlatDetails.RemoveRange(peminjamanAlat.Details!);
        _context.PeminjamanAlats.Remove(peminjamanAlat);
        
        int rowsAffected = _context.SaveChanges();

        if (rowsAffected == 0)
        {
            return false;
        }

        return true;
    }
}
