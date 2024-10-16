using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tem8.Models;
using tem8.Models.TrongTaiModels;

namespace tem8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrongTaiAPIController : ControllerBase
    {

        QlgiaiBongDaContext db = new QlgiaiBongDaContext();

        [HttpGet("{matrandau}")]
        public IEnumerable<TrongTaiTheoTranDau> GetCauThuTheoMa(string matrandau)
        {
            var lstMaTrongTaiTranDau = db.TrongtaiTrandaus.AsNoTracking()
                .Where(x => x.TranDauId == matrandau)
                .Select(x => x.TrongTaiId)
                .ToList();

            var trongtais = (from p in db.Trongtais
                           where lstMaTrongTaiTranDau.Contains(p.TrongTaiId)
                           select new TrongTaiTheoTranDau
                           {
                             HoVaTen=p.HoVaTen,
                             Anh=p.Anh,
                             NgaySinh=p.NgaySinh,
                             QueHuong = p.QueHuong,
                             SoNamKinhNghiem=p.SoNamKinhNghiem,
                             TrongTaiId = p.TrongTaiId
                           }).ToList();
          
            return trongtais;
        }


    }
}
