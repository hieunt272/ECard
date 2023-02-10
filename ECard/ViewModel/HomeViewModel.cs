using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECard.Models;
using System.Drawing.Drawing2D;
using System.Web.UI.WebControls;

namespace ECard.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Banner> Banners { get; set; }
    }

    public class HeaderViewModel
    {

    }
    public class FooterViewModel
    {
        public IEnumerable<Banner> Banners { get; set; }
    }

    public class CategoryProductViewModel
    {
        public IPagedList<Product> Products { get; set; }
    }
}