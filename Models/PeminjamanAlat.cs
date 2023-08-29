using System.ComponentModel.DataAnnotations;

namespace ManajemenAlatLaboratorium.API.Models;

public class PeminjamanAlat
{
    public int Id { get; set; }

    public DateTime TanggalPeminjaman { get; set; }

    public DateTime TanggalPengembalian { get; set; }

    public DateTime? DikembalikanPadaTanggal { get; set; }

    [Required]
    public Peminjam? Peminjam { get; set; }

    public ICollection<PeminjamanAlatDetail>? Details { get; set; }
}