using ECommerceApp.Models;
using ECommerceApp.Repositories;
using ECommerceApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace ECommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public UnitOfWork _unitOfWork;
        public HomeController()
        {
            _context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Index(int HomePageNumber = 1)
        {
            //The HomePageNumber parameter value is also sent from the Index view

            int perPageCount = 8;

            //Getting all Products
            var viewModel = new RandomViewModel
            {
                Tbl_Products = _unitOfWork.GetRepository<Tbl_Product>().GetAll()
            };

            //Implementing Pagination on the Index Page
            viewModel.HomePageNumber = HomePageNumber;

            double TotalPages = Math.Ceiling(Convert.ToDouble(viewModel.Tbl_Products.Count()) / perPageCount);
            viewModel.HomeTotalPages = TotalPages;

            viewModel.Tbl_Products = viewModel.Tbl_Products.Skip((HomePageNumber - 1) * perPageCount).Take(perPageCount).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            // This Action is an overload that responds to only HttpPost Request for searching.
            // Search parameter value is gotten from the index view page.

            /* Implementing product search on the home page */
           
            RandomViewModel viewModel = null;
            
            if (string.IsNullOrEmpty(search))
            {
                viewModel = new RandomViewModel
                {
                    Tbl_Products = _unitOfWork.GetRepository<Tbl_Product>().GetAll()
                };
            }
            else
            {
                viewModel = new RandomViewModel
                {
                    Tbl_Products = _unitOfWork.GetRepository<Tbl_Product>().GetAll()
                                              .Where(p => p.ProductName.ToUpper().Contains(search.ToUpper())).ToList()
                };
            }
            return View(viewModel);
        }

        public ActionResult Description( int Id )
        {
            RandomViewModel viewModel = new RandomViewModel();

            //Getting the complete product and Category from database 
            Tbl_Product product = _context.Tbl_Products.Include(p => p.Category).FirstOrDefault(p => p.Id == Id);

            //Getting products to display on the description page as related products
            List<Tbl_Product> products = _unitOfWork.GetRepository<Tbl_Product>().GetAll();
            
            viewModel.Tbl_Product = product;
            viewModel.Tbl_Products = products;

            return View(viewModel);
        }
        
        public ActionResult AddToCart(int Id, int HomePageNumber = 1, bool checkOutPage = false, bool descriptionPage = false)
        {
            // Id and HomePageNumber parameter values are gotten from the Index view page.

            /* 
                When adding product to cart, if the Session has no product list, the first scope will be executed
                else, the second scope will be executed.
            */

            int pageNo = HomePageNumber;
            var check = false;

            var product = _unitOfWork.GetRepository<Tbl_Product>().GetFirstOrDefault(Id);

            if (Session["cart"] == null)
            {
                List<RandomViewModel> cartList = new List<RandomViewModel>
                {
                    new RandomViewModel { Tbl_Product =  product, Quantity = 1 }
                };

                Session["cart"] = cartList;
                Session.Timeout = 30;
            }
            else
            {
                /*
                    Checking if the product is already in Cart.
                    This is necessary bcos we only want to increase the quantity of the product
                    rather than having a duplicate of the product.
                */

                List<RandomViewModel> cartList = (List<RandomViewModel>)Session["cart"];

                foreach(var item in cartList)
                {
                    if (item.Tbl_Product.Id == Id)
                    {
                        item.Quantity += 1;                     
                        check = true;
                        break;
                    }
                }

                if (check == false)
                {
                    cartList.Add(
                           new RandomViewModel { Tbl_Product = product, Quantity = 1 }
                    );
                }

                Session["cart"] = cartList;
            }


            /*
            Here, i check the page calling the AddToCart Action and then pass the url of the page to the url variable, 
            after which i redirect the Action to the url
            */
            string url = "";
            if (checkOutPage == true || descriptionPage == true)
            {
                url = "/Home/CheckOut";
            }
            else
            {
                url = "/?HomePageNumber=" + pageNo;
            }

            return Redirect(url);
        }    

        public ActionResult RemoveFromCart(int Id, bool checkOutPage = false)
        {
            /*
                Removing item from cart requires us to put all content in Session back to cartList and then use
                the Remove() provided by the List object to do so, after which we put the cartList values back 
                to the Session.
            */

            List<RandomViewModel> cartList = (List<RandomViewModel>)Session["cart"];

            foreach (var item in cartList)
            {
                if(item.Tbl_Product.Id == Id)
                {
                    cartList.Remove(item);
                    break;
                }
            }

            Session["cart"] = cartList;

            string url = (checkOutPage == true) ? "/Home/CheckOut" : "/Home/Index" ;

            return Redirect(url);
        }

        public ActionResult CheckOut()
        {
            return View();
        }

        public ActionResult DecreaseQty(int Id)
        {
            /* 
                When decrementing a product quantity, its limit should be 1. 
                You dont want the number of product quantity to count 0.
            */

            if (Session["cart"] != null)
            {
                List<RandomViewModel> cartList = (List<RandomViewModel>)Session["cart"];

                foreach (var item in cartList)
                {
                    if (item.Tbl_Product.Id == Id)
                    {
                        if (item.Quantity == 1)
                        {
                            break;
                        }
                        else
                        {
                            item.Quantity -= 1;
                            break;
                        }
                    }
                }
            }

            return Redirect("/Home/CheckOut");
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}