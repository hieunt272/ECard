using Helpers;
using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECard.DAL;
using ECard.Models;
using ECard.ViewModel;
using System.Data.Entity;
using System.Runtime.InteropServices;
using Antlr.Runtime.Tree;

namespace ECard.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();

        #region Contact
        public ActionResult ListContact(int? page, string name)
        {
            var pageNumber = page ?? 1;
            const int pageSize = 15;
            var contact = _unitOfWork.ContactRepository.GetQuery(orderBy: l => l.OrderByDescending(a => a.Id));

            if (!string.IsNullOrEmpty(name))
            {
                contact = contact.Where(l => l.FullName.Contains(name));
            }
            var model = new ListContactViewModel
            {
                Contacts = contact.ToPagedList(pageNumber, pageSize),
                Name = name
            };
            return View(model);
        }
        [HttpPost]
        public bool DeleteContact(int contactId = 0)
        {
            var contact = _unitOfWork.ContactRepository.GetById(contactId);
            if (contact == null)
            {
                return false;
            }
            _unitOfWork.ContactRepository.Delete(contact);
            _unitOfWork.Save();
            return true;
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}