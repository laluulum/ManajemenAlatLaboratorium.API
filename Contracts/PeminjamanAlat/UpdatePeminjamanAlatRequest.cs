namespace ManajemenAlatLaboratorium.API.Contracts.PeminjamanAlat;

public record UpdatePeminjamanAlatRequest(
    DateTime TanggalPeminjaman,
    DateTime? DikembalikanPadaTanggal,
    int PeminjamId,
    List<PeminjamanAlatDetailCreate>? DetailPeminjamanAlat
);