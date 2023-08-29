namespace ManajemenAlatLaboratorium.API.Contracts.Alat;

public record AlatResponse(
    int Id,
    string? Nama,
    string? Deskripsi,
    int Total
);