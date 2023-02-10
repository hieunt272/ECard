using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Xml.Linq;
using ECard.Models;

namespace ECard.ViewModel
{
    public class ListContactViewModel
    {
        public PagedList.IPagedList<Contact> Contacts { get; set; }
        public string Name { get; set; }
    }
}