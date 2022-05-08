using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TTCM_EcoMart.Models;

namespace TTCM_EcoMart.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        Beta_E_CommerceEntities db = new Beta_E_CommerceEntities();

        [HttpPost]
        public ActionResult SearchResults(FormCollection f, int? page)
        {
            string searchkey = f["txtsearch"].ToString();
            List<tblProduct> lstSearchResults = db.tblProducts.Where(n => n.product_Name.Contains(searchkey)).ToList();
            //List<tblProduct> lstSearchResults = db.tblProducts.SqlQuery("SELECT * FROM tblProduct WHERE product_Name LIKE '%" + searchkey + "%'").ToList();
            int pagenumber = (page ?? 1);
            int pagesize = 12;
            if (lstSearchResults.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm bạn tìm kiếm";
                //nếu không tìm thấy sản phẩm nào thì xuất ra toàn bộ sản phẩm
                return View(db.tblProducts.OrderBy(n => n.product_Name).ToPagedList(pagenumber, pagesize));
            }
            ViewBag.keyword = searchkey;
            ViewBag.ThongBao = $"{lstSearchResults.Count} results for {searchkey}";
            return View(lstSearchResults.OrderBy(n => n.product_Name).ToPagedList(pagenumber, pagesize));
        }
        [HttpGet]
        public ActionResult SearchResults(int? page, string searchkey)
        {
            ViewBag.keyword = searchkey;
            List<tblProduct> lstSearchResults = db.tblProducts.Where(n => n.product_Name.Contains(searchkey)).ToList();
            int pagenumber = (page ?? 1);
            int pagesize = 12;
            if (lstSearchResults.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm bạn tìm kiếm";
                //nếu không tìm thấy sản phẩm nào thì xuất ra toàn bộ sản phẩm
                return View(db.tblProducts.OrderBy(n => n.product_Name).ToPagedList(pagenumber, pagesize));
            }

            ViewBag.ThongBao = $"{lstSearchResults.Count} results for '{searchkey}'";
            return View(lstSearchResults.OrderBy(n => n.product_Name).ToPagedList(pagenumber, pagesize));
        }
    }
}