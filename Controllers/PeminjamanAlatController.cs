using ManajemenAlatLaboratorium.API.Contracts.PeminjamanAlat;
using ManajemenAlatLaboratorium.API.Models;
using ManajemenAlatLaboratorium.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManajemenAlatLaboratorium.API.Controllers;

[ApiController]
[Route("api/peminjaman-alat")]
public class PeminjamanAlatController : ControllerBase
{
    private readonly IPeminjamanAlatService _service;

    public PeminjamanAlatController(IPeminjamanAlatService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreatePeminjamanAlat(CreatePeminjamanAlatRequest request)
    {
        var peminjam = _service.GetPeminjamById(request.PeminjamId);

        if (peminjam == null)
        {
            return BadRequest("Peminjam does not exist");
        }

        var alats = _service.GetAlatByIds(request.DetailPeminjamanAlat.Select(dpa => dpa.AlatId).ToList());

        if (alats == null)
        {
            return BadRequest("Alat does not exist");
        }

        var details = new List<PeminjamanAlatDetail>();

        foreach (var detail in request.DetailPeminjamanAlat)
        {
            details.Add(new PeminjamanAlatDetail {
                Alat = alats.FirstOrDefault(a => a.Id == detail.AlatId),
                Jumlah = detail.Jumlah
            });
        }

        var peminjamanAlat = new PeminjamanAlat {
            TanggalPeminjaman = request.TanggalPeminjaman,
            Peminjam = peminjam,
            Details = details
        };

        var createdPeminjamanAlat = _service.CreatePeminjamanAlat(peminjamanAlat);

        if (createdPeminjamanAlat == null)
        {
            return BadRequest();
        }

        var detailResponse = new List<PeminjamanAlatDetailResponse>();
        createdPeminjamanAlat.Details!.ToList().ForEach(d => {
            detailResponse.Add(new PeminjamanAlatDetailResponse(
                d.Id,
                d.Jumlah!.Value,
                new AlatDetailResponse(
                    d.Alat!.Id,
                    d.Alat!.Nama!,
                    d.Alat.Deskripsi!
                )
            ));
        });

        var response = new PeminjamanAlatResponse(
            createdPeminjamanAlat.Id,
            createdPeminjamanAlat.TanggalPeminjaman,
            createdPeminjamanAlat.TanggalPengembalian,
            createdPeminjamanAlat.DikembalikanPadaTanggal,
            createdPeminjamanAlat.Peminjam!,
            detailResponse
        );

        return CreatedAtAction(
            actionName: nameof(GetPeminjamanAlatById),
            routeValues: new { id = response.Id },
            value: response
        );
    }

    [HttpGet("{id}")]
    public IActionResult GetPeminjamanAlatById(int id)
    {
        var peminjamanAlat = _service.GetPeminjamanAlatById(id);

        if (peminjamanAlat == null)
        {
            return NotFound();
        }

        var detailResponse = new List<PeminjamanAlatDetailResponse>();
        peminjamanAlat.Details!.ToList().ForEach(d =>
        {
            detailResponse.Add(new PeminjamanAlatDetailResponse(
                d.Id,
                d.Jumlah!.Value,
                new AlatDetailResponse(
                    d.Alat!.Id,
                    d.Alat!.Nama!,
                    d.Alat.Deskripsi!
                )
            ));
        });

        var response = new PeminjamanAlatResponse(
            peminjamanAlat.Id,
            peminjamanAlat.TanggalPeminjaman,
            peminjamanAlat.TanggalPengembalian,
            peminjamanAlat.DikembalikanPadaTanggal,
            peminjamanAlat.Peminjam!,
            detailResponse
        );

        return Ok(response);
    }

    [HttpGet]
    public IEnumerable<PeminjamanAlatResponse> GetAllPeminjamanAlat()
    {
        var peminjamanAlats = _service.GetAllPeminjamanAlat();
        
        if (!peminjamanAlats.Any())
        {
            return new List<PeminjamanAlatResponse>();
        }

        var responses = new List<PeminjamanAlatResponse>();

        peminjamanAlats.ToList().ForEach(peminjamanAlat => {
            var detailResponse = new List<PeminjamanAlatDetailResponse>();
            peminjamanAlat.Details!.ToList().ForEach(d =>
            {
                detailResponse.Add(new PeminjamanAlatDetailResponse(
                    d.Id,
                    d.Jumlah!.Value,
                    new AlatDetailResponse(
                        d.Alat!.Id,
                        d.Alat!.Nama!,
                        d.Alat.Deskripsi!
                    )
                ));
            });

            var response = new PeminjamanAlatResponse(
                peminjamanAlat.Id,
                peminjamanAlat.TanggalPeminjaman,
                peminjamanAlat.TanggalPengembalian,
                peminjamanAlat.DikembalikanPadaTanggal,
                peminjamanAlat.Peminjam!,
                detailResponse
            );

            responses.Add(response);
        });

        return responses;
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePeminjamanAlat(int id, UpdatePeminjamanAlatRequest request)
    {
        bool isPengembalian = _service.IsPengembalianOnly(id, request);

        if (isPengembalian)
        {
            return NoContent();
        }

        var peminjam = _service.GetPeminjamById(request.PeminjamId);

        if (peminjam == null)
        {
            return BadRequest("Peminjam does not exist");
        }

        var alats = _service.GetAlatByIds(request.DetailPeminjamanAlat!.Select(dpa => dpa.AlatId).ToList());

        if (alats == null)
        {
            return BadRequest("Alat does not exist");
        }

        var details = new List<PeminjamanAlatDetail>();

        foreach (var detail in request.DetailPeminjamanAlat!)
        {
            details.Add(new PeminjamanAlatDetail
            {
                Alat = alats.FirstOrDefault(a => a.Id == detail.AlatId),
                Jumlah = detail.Jumlah
            });
        }

        var peminjamanAlat = new PeminjamanAlat
        {
            TanggalPeminjaman = request.TanggalPeminjaman,
            DikembalikanPadaTanggal = request.DikembalikanPadaTanggal,
            Peminjam = peminjam,
            Details = details
        };

        var updateSuccess = _service.UpdatePeminjamanAlat(id, peminjamanAlat);

        if (!updateSuccess)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePeminjamanAlat(int id)
    {
        var success = _service.DeletePeminjamanAlat(id);

        if (!success)
        {
            return BadRequest();
        }

        return NoContent();
    }
}