using csharp_example_wad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace csharp_example_wad.ViewModels
{
    public class CustomerViewModels
    {
        public CustomerViewModels(Customer customer)
        {
            Id = customer.Id;
            FullName = customer.FullName;
            Address = customer.Address;
            Phone = customer.Phone;
            Gender = customer.Gender;
            TypeId = customer.TypeId;
            TypeName = customer.Type?.TypeName;
        }

        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}