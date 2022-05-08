using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTCM_EcoMart.Models;

namespace TTCM_EcoMart.Controllers
{
    public class NguoiDungController : Controller
    {
        Beta_E_CommerceEntities db = new Beta_E_CommerceEntities();

        // GET: NguoiDung
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(FormCollection f)
        {
            //if (ModelState.IsValid)
            //{


            //    var f_password = password;
            //    var data = db.tblAccounts.Where(s => s.Customer_email.Equals(email) && s.Customer_password.Equals(f_password)).ToList();
            //    if (data.Count() > 0)
            //    {
            //        //add session
            //        Session["FullName"] = data.FirstOrDefault().Customer_name;
            //        Session["Email"] = data.FirstOrDefault().Customer_email;
            //        Session["idUser"] = data.FirstOrDefault().Customer_ID;
            //        return RedirectToAction("Index", "Home");
            //    }
            //    //else
            //    //{
            //    //    ViewBag.error = "Login failed";
            //    //    return RedirectToAction("DangNhap", "NguoiDung");
            //    //}
            //}
            //return View();
            string email = f["Email"];
            string matkhau = f["Password"];

            tblAccount kh = db.tblAccounts.SingleOrDefault(n => n.Customer_email == email && n.Customer_password == matkhau);

            if (kh != null)
            {
                ViewBag.Id_nguoidung = kh.Customer_ID;

                ViewBag.Success = "Chúc mừng đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Failed = "Sai tên tài khoản hoặc mật khẩu";
                return View();
            }
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(tblAccount cs)
        {
            if (ModelState.IsValid)
            {
                string str = "U";
                int count = 0;
                string res = str + count.ToString();
                bool flag = false;
                tblAccount getAccID;
                tblAccount getEmail; 
                tblAccount getPhone;
                
                bool afterCheck = true;
                while (flag == false)
                {
                    getAccID = db.tblAccounts.SingleOrDefault(n => n.Account_ID.Equals(res));
                    if (getAccID != null)
                    {
                        count++;
                        res = str + count.ToString();
                    }
                    else
                    {
                        //flag = true;
                        getEmail = db.tblAccounts.SingleOrDefault(n => n.Customer_email.Equals(cs.Customer_email));
                        getPhone = db.tblAccounts.SingleOrDefault(n => n.Customer_phone.Equals(cs.Customer_phone));
                        if (getEmail != null )
                        {
                            ViewBag.Email = "Phone number has been used";
                            flag = true;
                            afterCheck = false;
                            return View();
                        }
                        else if(getPhone != null)
                        {
                            ViewBag.Phone = "Phone number has been used";
                            flag = true;
                            afterCheck = false;
                            return View();
                        }
                        else
                        {
                            flag = true;
                            afterCheck = true; // Nếu đúng ta mới gán afterCheck = true
                        }
                        
                    }
                }
                if(afterCheck == true)
                {
                    cs.Account_ID = res;
                    cs.Customer_ID = null;
                    cs.ID_wishlist = "wl" + count;
                    cs.User_Role = 1;
                    //DateTime dt = DateTime.Parse("2001-02-26");
                    cs.DateOfBirth = null;
                    cs.Customer_gender = 1;
                    cs.CreatedDate = DateTime.Now;
                    db.tblAccounts.Add(cs);
                    db.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message1 = "Đăng ký tài khoản thành công!!";
                    return RedirectToAction("DangNhap", "NguoiDung");
                }
            }


            return View();
        }
    }
        //create a string MD5
        //public static string GetMD5(string str)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] fromData = System.Text.Encoding.UTF8.GetBytes(str);
        //    byte[] targetData = md5.ComputeHash(fromData);
        //    string byte2String = null;

        //    for (int i = 0; i < targetData.Length; i++)
        //    {
        //        byte2String += targetData[i].ToString("x2");

        //    }
        //    return byte2String;
        //}

}
