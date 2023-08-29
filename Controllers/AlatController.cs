using ManajemenAlatLaboratorium.API.Contracts.Alat;
using ManajemenAlatLaboratorium.API.Models;
using ManajemenAlatLaboratorium.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManajemenAlatLaboratorium.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlatController : ControllerBase
{
    private readonly IAlatService _service;

    public AlatController(IAlatService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateAlat(CreateAlatRequest request)
    {
        var alat = new Alat {
            Nama = request.Nama,
            Deskripsi = request.Deskripsi,
            Total = request.Total
        };

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var createdAlat = _service.CreateAlat(alat);

        if (createdAlat == null)
        {
            return BadRequest();
        }

        return CreatedAtAction(
            actionName: nameof(GetAlatById),
            routeValues: new { id = alat.Id },
            value: alat
        );
    }

    [HttpGet("{id}")]
    public IActionResult GetAlatById(int id)
    {
        var alat = _service.GetAlatById(id);

        if (alat == null)
        {
            return NotFound();
        }

        var response = new AlatResponse(
            alat.Id,
            alat.Nama,
            alat.Deskripsi,
            alat.Total
        );

        return Ok(response);
    }

    [HttpGet]
    public IEnumerable<Alat> GetAllAlat()
    {
        var alats = _service.GetAllAlat();

        return alats;
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAlat(int id, UpdateAlatRequest request)
    {
        var alat = new Alat {
            Nama = request.Nama,
            Deskripsi = request.Deskripsi,
            Total = request.Total
        };

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var success = _service.UpdateAlat(id, alat);

        if (!success)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAlat(int id)
    {
        var success = _service.DeleteAlat(id);

        if (!success)
        {
            return BadRequest();
        }

        return NoContent();
    }
}