using KioskManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KioskManagementApp.Controllers
{
    public class ItemController : Controller
    {
        private AppDbContext _ctx = new AppDbContext();

        // GET: Danh sách sản phẩm
        [HttpGet]
        public ActionResult ItemList()
        {
                var itemList = _ctx.Item.ToList();
                return View(itemList);
        }

        // GET: Số lượng sản phẩm trong kho với từng Kiosk
        [HttpGet]
        public ActionResult StockQuantity()
        {
            
                var stockQuantity = _ctx.KioskItem.ToList(); 

                return View(stockQuantity);
           
        }


    }
}