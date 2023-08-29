namespace ManajemenAlatLaboratorium.API.Contracts.PeminjamanAlat;

public record PeminjamanAlatDetailResponse(
    int Id,
    int JumlahDipinjam,
    AlatDetailResponse Alat
);

public record AlatDetailResponse(
    int Id,
    string NamaAlat,
    string Deskripsi
);