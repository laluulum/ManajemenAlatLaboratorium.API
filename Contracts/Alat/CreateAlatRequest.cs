namespace ManajemenAlatLaboratorium.API.Contracts.Alat;

public record CreateAlatRequest(
    string Nama,
    string Deskripsi,
    int Total
);