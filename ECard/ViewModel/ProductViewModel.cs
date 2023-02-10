using ECard.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace ECard.ViewModel
{
    public class ListProductViewModel
    {
        public PagedList.IPagedList<Product> Products { get; set; }
        public string Name { get; set; }
        public string Sort { get; set; }
    }

    public class InsertProductViewModel
    {
        public Product Product { get; set; }
    }
}