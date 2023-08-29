using System.ComponentModel.DataAnnotations;

namespace ManajemenAlatLaboratorium.API.Models;

public class Peminjam
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Nama { get; set; }

    [Required]
    [MaxLength(300)]
    public string? Alamat { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [Phone]
    public string? NomorHandphone { get; set; }

    public bool Aktif { get; set; }
}