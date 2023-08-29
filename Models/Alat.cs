using System.ComponentModel.DataAnnotations;

namespace ManajemenAlatLaboratorium.API.Models;

public class Alat
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Nama { get; set; }

    public string? Deskripsi { get; set; }

    public int Total { get; set; }
}