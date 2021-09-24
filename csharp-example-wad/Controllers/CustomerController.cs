using csharp_example_wad.Models;
using csharp_example_wad.Repositories;
using csharp_example_wad.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using csharp_example_wad.ViewModels;
using System.Text.RegularExpressions;

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
        [HttpPost]
        public ActionResult Index(int? typeId)
        {
            IEnumerable<Customer> result;

            if (typeId != null)
            {
                result = customerRepository.Get(x => x.TypeId == typeId);
            } else
            {
                result = customerRepository.Get();
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
        public ActionResult Create(Customer customer)
        {
            var errors = new Dictionary<string, string>();

            try
            {
                if (ModelState.IsValid)
                {
                    var check = customerRepository.CheckDuplicate(x => x.Id == customer.Id);

                    if (check)
                    {
                        errors.Add("Id", "Customer Id is duplicated!");

                        return Json(new
                        {
                            statusCode = 400,
                            message = "Error",
                            data = errors
                        }, JsonRequestBehavior.AllowGet);
                    }

                    var checkPhone = customerRepository.CheckDuplicate(x => x.Phone == customer.Phone);

                    if (checkPhone)
                    {
                        errors.Add("Phone", "Phone is duplicated!");

                        return Json(new
                        {
                            statusCode = 400,
                            message = "Error",
                            data = errors
                        }, JsonRequestBehavior.AllowGet);
                    }

                    customerRepository.Add(customer);

                    return Json(new
                    {
                        statusCode = 200,
                        message = "Success"
                    }, JsonRequestBehavior.AllowGet);
                }

                foreach (var k in ModelState.Keys)
                    foreach (var err in ModelState[k].Errors)
                    {
                        var key = Regex.Replace(k, @"(\w+)\.(\w+)", @"$2");
                        if (!errors.ContainsKey(key))
                            errors.Add(key, err.ErrorMessage);
                    }

                return Json(new
                {
                    statusCode = 400,
                    message = "Error",
                    data = errors
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    statusCode = 500,
                    message = "Error",
                    data = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
