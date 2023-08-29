namespace ManajemenAlatLaboratorium.API.Contracts.Alat;

public record UpdateAlatRequest(
    string Nama,
    string Deskripsi,
    int Total
);