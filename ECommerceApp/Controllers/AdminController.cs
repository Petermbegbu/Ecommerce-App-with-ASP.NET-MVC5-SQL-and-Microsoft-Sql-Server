using ECommerceApp.Models;
using ECommerceApp.Repositories;
using ECommerceApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace ECommerceApp.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        public UnitOfWork _unitOfWork;
        public AdminController()
        {
            _context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork();
        }

        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categories()
        {
            var viewModel = new RandomViewModel
            {
                Tbl_Categories = _unitOfWork.GetRepository<Tbl_Category>().GetAllIQueryable()
                                        .Where(c => c.IsDelete == false).ToList()
            };

            return View(viewModel);
        }

        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(RandomViewModel viewModel)
        {
            var category = viewModel.Tbl_Category;

            _unitOfWork.GetRepository<Tbl_Category>().Add(category);
            //Tbl_Category category;
            //if(Id != 0)
            //{
            //    category = JsonConvert.DeserializeObject<Tbl_Category>(JsonConvert
            //        .SerializeObject(_unitOfWork.GetRepository<Tbl_Category>().GetFirstOrDefault(Id)));
            //}
            //else
            //{
            //    category = new Tbl_Category();
            //}
            return RedirectToAction("Categories");
        }

        public ActionResult CategoryEdit(int Id)
        {
            var viewModel = new RandomViewModel
            {
                Tbl_Category = _unitOfWork.GetRepository<Tbl_Category>().GetFirstOrDefault(Id)
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CategoryEdit(RandomViewModel viewModel)
        {
            var category = viewModel.Tbl_Category;

            try
            {
                _unitOfWork.GetRepository<Tbl_Category>().Update(category);
            }
            catch (DbEntityValidationException e)
            {
                Console.Write(e);
            }

            return RedirectToAction("Categories");
        }

        public ActionResult Product()
        {
            var viewModel = new RandomViewModel
            {
                Tbl_Products = _unitOfWork.GetRepository<Tbl_Product>().GetAllIQueryable()
                                    .Where(c => c.IsDelete == false).ToList()
            };
            return View(viewModel);
        }

        public ActionResult ProductEdit(int Id)
        {
            var viewModel = new RandomViewModel
            {
                Tbl_Categories = _unitOfWork.GetRepository<Tbl_Category>().GetAll(),
                Tbl_Product = _unitOfWork.GetRepository<Tbl_Product>().GetFirstOrDefault(Id)
            };
            return View(viewModel);
        }

        //[HttpPost]
        //public ActionResult ProductEdit(RandomViewModel viewModel, HttpPostedFileBase file)
        //{
        //    string pic = null;
        //    if (file != null)
        //    {
        //        pic = System.IO.Path.GetFileName(file.FileName);
        //        string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
        //        file.SaveAs(path);
        //    }

        //    viewModel.Tbl_Product.ModifiedDate = DateTime.Now;

        //    //int Id = viewModel.Tbl_Product.Id;
        //    //var dbProduct = _unitOfWork.GetRepository<Tbl_Product>().GetFirstOrDefault(Id);
        //    //string productImage = dbProduct.ProductImage;
        //    //viewModel.Tbl_Product.ProductImage = (file != null) ? pic : productImage;

        //    viewModel.Tbl_Product.ProductImage = pic;

        //    var product = viewModel.Tbl_Product;

        //    //viewModel.Tbl_Product.ProductImage = (file != null) ? pic : product.ProductImage;

        //    try
        //    {
        //        _unitOfWork.GetRepository<Tbl_Product>().Update(product);
        //    }
        //    catch(DbEntityValidationException e)
        //    {
        //        Console.Write(e);
        //    }

        //    return RedirectToAction("Product");
        //}


        [HttpPost]
        public ActionResult ProductEdit(RandomViewModel viewModel, HttpPostedFileBase file)
        {
            int Id = viewModel.Tbl_Product.Id;
            var dbProduct = _context.Tbl_Products.Single(p => p.Id == Id);
            
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                file.SaveAs(path);
            }

            dbProduct.ModifiedDate = DateTime.Now;
            dbProduct.Description = viewModel.Tbl_Product.Description;
            dbProduct.ProductImage = (pic != null) ? pic : dbProduct.ProductImage;

            _context.SaveChanges();

            return RedirectToAction("Product");
        }


        public ActionResult ProductAdd()
        {
            var viewModel = new RandomViewModel
            {
                Tbl_Categories = _unitOfWork.GetRepository<Tbl_Category>().GetAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ProductAdd(RandomViewModel viewModel, HttpPostedFileBase file)
        {
            var product = viewModel.Tbl_Product;

            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/ProductImg/"), pic);
                file.SaveAs(path);
            }

            product.ProductImage = pic;
            product.CreateDate = DateTime.Now;

            try
            {
                _unitOfWork.GetRepository<Tbl_Product>().Add(product);
            }
            catch (DbEntityValidationException e)
            {
                Console.Write(e);
            }

            return RedirectToAction("Product");
        }

        public ActionResult Order()
        {
            var viewModel = new RandomViewModel
            {
                Tbl_OrderTransactions = _context.Tbl_OrderTransactions.Include(t => t.OrderDetail).ToList()
            };

            return View(viewModel);
        }

    }
}
