namespace ManajemenAlatLaboratorium.API.Contracts.PeminjamanAlat;

public record CreatePeminjamanAlatRequest(
    DateTime TanggalPeminjaman,
    int PeminjamId,
    List<PeminjamanAlatDetailCreate> DetailPeminjamanAlat
);