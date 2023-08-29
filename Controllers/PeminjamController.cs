using ManajemenAlatLaboratorium.API.Contracts.Peminjam;
using ManajemenAlatLaboratorium.API.Models;
using ManajemenAlatLaboratorium.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManajemenAlatLaboratorium.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeminjamController : ControllerBase
{
    private readonly IPeminjamService _service;

    public PeminjamController(IPeminjamService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreatePeminjam(CreatePeminjamRequest request)
    {
        var peminjam = new Peminjam {
            Nama = request.Nama,
            Alamat = request.Alamat,
            Email = request.Email,
            NomorHandphone = request.NomorHandphone,
            Aktif = request.Aktif
        };

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdPeminjam = _service.CreatePeminjam(peminjam);

        if (createdPeminjam == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(
            actionName: nameof(GetPeminjamById),
            routeValues: new { id = createdPeminjam.Id },
            value: createdPeminjam
        );
    }

    [HttpGet("{id}")]
    public IActionResult GetPeminjamById(int id)
    {
        var peminjam = _service.GetPeminjamById(id);

        if (peminjam == null)
        {
            return NotFound();
        }

        var response = new PeminjamResponse(
            peminjam.Id,
            peminjam.Nama,
            peminjam.Alamat,
            peminjam.Email,
            peminjam.NomorHandphone,
            peminjam.Aktif
        );

        return Ok(response);
    }

    [HttpGet]
    public IEnumerable<Peminjam> GetAllPeminjam()
    {
        var peminjams = _service.GetAllPeminjam();

        return peminjams;
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePeminjam(int id, UpdatePeminjamRequest request)
    {
        var peminjam = new Peminjam {
            Nama = request.Nama,
            Alamat = request.Alamat,
            Email = request.Email,
            NomorHandphone = request.NomorHandphone,
            Aktif = request.Aktif
        };

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var success = _service.UpdatePeminjam(id, peminjam);

        if(!success)
        {
            return BadRequest();
        }

        return NoContent();
    }
}