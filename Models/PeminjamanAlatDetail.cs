using System.ComponentModel.DataAnnotations;

namespace ManajemenAlatLaboratorium.API.Models;

public class PeminjamanAlatDetail
{
    public int Id { get; set; }

    [Required]
    public Alat? Alat { get; set; }
    
    [Required]
    public int? Jumlah { get; set; }

    // [Required]
    // public PeminjamanAlat? PeminjamanAlat { get; set; }
}