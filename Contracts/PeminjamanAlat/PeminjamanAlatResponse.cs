namespace ManajemenAlatLaboratorium.API.Contracts.PeminjamanAlat;

public record PeminjamanAlatResponse(
    int Id,
    DateTime TanggalPeminjaman,
    DateTime TanggalPengembalian,
    DateTime? DikembalikanPadaTanggal,
    Models.Peminjam Peminjam,
    List<PeminjamanAlatDetailResponse>? DetailPeminjamanAlat
);