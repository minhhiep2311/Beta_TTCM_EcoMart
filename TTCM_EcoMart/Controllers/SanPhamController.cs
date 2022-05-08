using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTCM_EcoMart.Models;
namespace TTCM_EcoMart.Controllers
{
    public class SanPhamController : Controller
    {
        Beta_E_CommerceEntities db = new Beta_E_CommerceEntities();
        // GET: SanPham
        public ActionResult MenProducts()
        {
            return View();
        }
        // Lấy ra tất cả các loại giày "Nam" đã có trong database và hiển thị lên partialView
        public PartialViewResult MenCategories()
        {
            return PartialView(db.tblCategories.ToList());
        }
        // Lấy ra toàn bộ sản phẩm theo giới tính "Nam"
        public PartialViewResult AllMenProductsPartialView()
        {
            //var data = (from p in db.tblProducts join c in db.tblCategories on p.Category_ID equals c.Category_ID where c.Gender == 1 select new
            //{
            //    p.Category_ID, p.product_ID, p.product_Name, p.prices
            //}).ToList();
            var data = (from p in db.tblProducts where p.tblCategory.Gender == 1 select p).ToList();
            ViewBag.MenProducts = data;
            return PartialView();
        }
        //Lấy ra các sản phẩm theo loại của "Nam" đã được hiển thị
        public PartialViewResult Categorize_men_product(string Category_ID, byte Gender)
        {
            var data = (from p in db.tblProducts where p.tblCategory.Category_ID == Category_ID & 
                        p.tblCategory.Gender == Gender
                        select p).ToList();
            ViewBag.Categorize_men_product = data;
            return PartialView();
        }

    }
}