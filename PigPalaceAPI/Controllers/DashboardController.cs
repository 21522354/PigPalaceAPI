using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PigPalaceAPI.Data;
using PigPalaceAPI.Model;

namespace PigPalaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly PigPalaceDBContext _context;
        private readonly IMapper _mapper;

        public DashboardController(PigPalaceDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("GetCommonField")]
        public async Task<IActionResult> GetCommonField(Guid FarmID)
        {
            DashBoardModel model = new DashBoardModel();
            var totalPigs = await _context.HEOs.Where(x => x.FarmID == FarmID).CountAsync();
            var totalBarns = await _context.CHUONGHEOs.Where(x => x.FarmID == FarmID).CountAsync();
            var totalEmployees = await _context.Users.Where(x => x.FarmID == FarmID).CountAsync();
            var totalCustomer = 12;
            var listXuatHeo = await _context.HOADONHEOs.Where(x => x.FarmID == FarmID && x.LoaiHoaDon == "Phiếu xuất heo").ToListAsync();
            float totalExportPig = 0;
            foreach (var item in listXuatHeo)
            {
                totalExportPig += item.TongTien;
            }
            var listNhapHeo = await _context.HOADONHEOs.Where(x => x.FarmID == FarmID && x.LoaiHoaDon == "Phiếu nhập heo").ToListAsync();
            float totalInportsPig = 0;
            foreach (var item in listNhapHeo)
            {
                totalInportsPig += item.TongTien;
            }
            var listHoaDonHangHoa = await _context.HOADONHANGHOAs.Where(x => x.FarmID == FarmID).ToListAsync();
            float totalImportGoods = 0;
            foreach (var item in listHoaDonHangHoa)
            {
                totalImportGoods += item.TongTien;
            }
            var totalExpense = totalExportPig + totalImportGoods;
            var totalSales = totalInportsPig;
            var income = totalSales - totalExpense; 
            var listFeedCost = await _context.HOADONHANGHOAs.Where(x => x.FarmID == FarmID && x.LoaiHangHoa == "Thức ăn").ToListAsync();
            float feedCost = 0;
            foreach (var item in listFeedCost)
            {
                feedCost += item.TongTien;
            }
            model.TotalPigs = totalPigs;
            model.TotalBarns = totalBarns;
            model.TotalEmployees = totalEmployees;
            model.TotalCustomer = totalCustomer;
            model.TotalSales = totalSales;
            model.TotalIncomes = income;
            model.TotalExpense = totalExpense;
            model.FeedCost = feedCost;
            return Ok(model);
        }
        [HttpGet("GetCoCauHeo")]
        public async Task<IActionResult> GetCoCauHeo(Guid FarmID)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);   
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var listHeo = await _context.HEOs.Where(x => x.FarmID == FarmID).GroupBy(x => x.MaGiongHeo).Select(x => new { MaGiong = x.Key, Total = x.Count() }).ToListAsync();
            var totalHeo = await _context.HEOs.Where(x => x.FarmID == FarmID).CountAsync();
            var listCoCauHeoModel = new List<CoCauHeoModel>();
            foreach (var item in listHeo)
            {
                var coCauHeo = new CoCauHeoModel(); 
                var giongHeo = await _context.GIONGHEOs.FirstOrDefaultAsync(x => x.MaGiongHeo == item.MaGiong);
                coCauHeo.TenGiongHeo = giongHeo.TenGiongHeo;
                coCauHeo.Rate = ((float)item.Total / totalHeo) * 100;
                listCoCauHeoModel.Add(coCauHeo);
            }
            return Ok(listCoCauHeoModel); 
        }
        [HttpGet("GetTotalImportAndExportPigByMonth")]
        public async Task<IActionResult> GetTotalImportAndExportPigByMonth(Guid FarmID , int Year)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            List<PigByMonthModel> listPigByMonth = new List<PigByMonthModel>();
            for (int i = 1; i <= 12; i++)
            {
                var totalImport = await _context.HOADONHEOs.Where(x => x.FarmID == FarmID && x.LoaiHoaDon == "Phiếu nhập heo" && x.NgayLap.Month == i && x.NgayLap.Year == Year).ToListAsync();
                int totalImportPigInMonth = 0;
                foreach (var item in totalImport)
                {
                    var listCTPhieuHeo = await _context.CT_HOADONHEOs.Where(x => x.MaHoaDon == item.MaHoaDon).ToListAsync();
                    totalImportPigInMonth += listCTPhieuHeo.Count();
                }
                var totalExport = await _context.HOADONHEOs.Where(x => x.FarmID == FarmID && x.LoaiHoaDon == "Phiếu xuất heo" && x.NgayLap.Month == i && x.NgayLap.Year == Year).ToListAsync();
                int totalExportPigInMonth = 0;
                foreach (var item in totalExport)
                {
                    var listCTPhieuHeo = await _context.CT_HOADONHEOs.Where(x => x.MaHoaDon == item.MaHoaDon).ToListAsync();
                    totalExportPigInMonth += listCTPhieuHeo.Count();
                }
                var pigByMonth = new PigByMonthModel();
                pigByMonth.Month = i;
                pigByMonth.TotalImport = totalImportPigInMonth;
                pigByMonth.TotalExport = totalExportPigInMonth;
                listPigByMonth.Add(pigByMonth);
            }
            return Ok(listPigByMonth);
        }
        [HttpGet("GetSalesOverview")]
        public async Task<IActionResult> GetSalesOverview(Guid FarmID, int Year)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            List<SalesOverviewModel> salesOverviewModels = new List<SalesOverviewModel>();
            for (int i = 1; i <= 12; i++)
            {
                var totalSalesPig = await _context.HOADONHEOs.Where(x => x.FarmID == FarmID && x.LoaiHoaDon == "Phiếu xuất heo" && x.NgayLap.Month == i && x.NgayLap.Year == Year).ToListAsync();
                float totalSalesInMonth = 0;
                foreach (var item in totalSalesPig)
                {
                    totalSalesInMonth += item.TongTien;
                }
                var totalExpenseHangHoa = await _context.HOADONHANGHOAs.Where(x => x.FarmID == FarmID && x.NgayLap.Month == i && x.NgayLap.Year == Year).ToListAsync();
                float totalExpenseInMonth = 0;
                foreach (var item in totalExpenseHangHoa)
                {
                    totalExpenseInMonth += item.TongTien;
                }
                var totalExpensePig = await _context.HOADONHEOs.Where(x => x.FarmID == FarmID && x.LoaiHoaDon == "Phiếu nhập heo" && x.NgayLap.Month == i && x.NgayLap.Year == Year).ToListAsync();
                foreach (var item in totalExpensePig)
                {
                    totalExpenseInMonth += item.TongTien;
                }
                var salesOverviewModel = new SalesOverviewModel();
                salesOverviewModel.Month = i;
                salesOverviewModel.TotalSales = totalSalesInMonth;
                salesOverviewModel.TotalExpense = totalExpenseInMonth;
                salesOverviewModels.Add(salesOverviewModel);
            }
            return Ok(salesOverviewModels); 
        }
        [HttpGet("GetInvoices")]
        public async Task<IActionResult> GetInvoices(Guid FarmID, int Year)
        {
            var farm = await _context.PigFarms.FirstOrDefaultAsync(x => x.FarmID == FarmID);
            if (farm == null)
            {
                return NotFound("Farm not found");
            }
            var listInvoiceModel = new List<InvoiceModel>();        
            var listHoaDonNhapHeo = await _context.HOADONHEOs.Where(x => x.FarmID == FarmID && x.LoaiHoaDon == "Phiếu nhập heo" && x.NgayLap.Year == Year).ToListAsync();
            foreach (var item in listHoaDonNhapHeo)
            {
                var invoiceModel = new InvoiceModel();
                invoiceModel.InvoiceID = item.MaHoaDon;
                invoiceModel.InvoiceType = "Import";
                invoiceModel.InvoiceName = "Pig import";
                invoiceModel.Price = item.TongTien;
                invoiceModel.Status = item.TrangThai;
                listInvoiceModel.Add(invoiceModel);
            }
            var listHoaDonXuatHeo = await _context.HOADONHEOs.Where(x => x.FarmID == FarmID && x.LoaiHoaDon == "Phiếu xuất heo" && x.NgayLap.Year == Year).ToListAsync();
            foreach (var item in listHoaDonXuatHeo)
            {
                var invoiceModel = new InvoiceModel();
                invoiceModel.InvoiceID = item.MaHoaDon;
                invoiceModel.InvoiceType = "Export";
                invoiceModel.InvoiceName = "Pig export";
                invoiceModel.Price = item.TongTien;
                invoiceModel.Status = item.TrangThai;
                listInvoiceModel.Add(invoiceModel);
            }
            var listHoaDonHangHoa = await _context.HOADONHANGHOAs.Where(x => x.FarmID == FarmID && x.NgayLap.Year == Year).ToListAsync();
            foreach (var item in listHoaDonHangHoa)
            {
                var invoiceModel = new InvoiceModel();
                invoiceModel.InvoiceID = item.MaHoaDon;
                invoiceModel.InvoiceType = "Import";
                if(item.LoaiHangHoa == "Thức ăn")
                {
                    invoiceModel.InvoiceName = "Feed Import";
                }
                else if(item.LoaiHangHoa == "Thuốc")
                {
                    invoiceModel.InvoiceName = "Medicine Import";
                }
                else if(item.LoaiHangHoa == "Vắc xin")
                {
                    invoiceModel.InvoiceName = "Vaccine Import";
                }
                else
                {
                    invoiceModel.InvoiceName = "Goods Import";
                }
                invoiceModel.Price = item.TongTien;
                invoiceModel.Status = item.TrangThai;
                listInvoiceModel.Add(invoiceModel);
            }
            return Ok(listInvoiceModel);
        }
    }
    public class InvoiceModel
    {
        public string InvoiceID { get; set; }
        public string InvoiceType { get; set; }
        public string InvoiceName { get; set; }
        public float Price { get; set; }
        public string Status { get; set; }          
    }
    public class SalesOverviewModel
    {
        public int Month { get; set; }
        public float TotalSales { get; set; }
        public float TotalExpense { get; set; }
    }
    public class PigByMonthModel
    {
        public int Month { get; set; }
        public int TotalImport { get; set; }
        public int TotalExport { get; set; }    
    }
    public class CoCauHeoModel
    {
        public string TenGiongHeo { get; set; }     
        public float Rate { get; set; }
    }
}
