using csharp_example_wad.Models;
using csharp_example_wad.Repositories;
using csharp_example_wad.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using csharp_example_wad.ViewModels;

namespace csharp_example_wad.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepository<Customer> customerRepository;
        private readonly IRepository<CustomerType> customerTypeRepository;

        public CustomerController()
        {
            customerRepository = new Repository<Customer>();
            customerTypeRepository = new Repository<CustomerType>();
        }


        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/GetCustomers
        public ActionResult GetCustomers(int? typeId)
        {
            var result = customerRepository.Get();

            if (typeId != null)
            {
                result = result.Where(x => x.TypeId == typeId);
            }

            var data = result.Select(x => new CustomerViewModels(x));

            return Json(new
            {
                data = data,
                message = "Success",
                statusCode = 200
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Customer/GetCustomerTypes
        public ActionResult GetCustomerTypes()
        {
            var data = customerTypeRepository.Get();

            return Json(new
            {
                data = data,
                message = "Success",
                statusCode = 200
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
