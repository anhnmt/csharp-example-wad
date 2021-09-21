using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace csharp_example_wad.Models
{
    public class CustomerType
    {
        [Key]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}