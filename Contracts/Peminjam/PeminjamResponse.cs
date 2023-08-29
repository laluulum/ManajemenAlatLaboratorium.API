namespace ManajemenAlatLaboratorium.API.Contracts.Peminjam;

public record PeminjamResponse(
    int Id,
    string? Nama,
    string? Alamat,
    string? Email,
    string? NomorHandphone,
    bool Aktif
);