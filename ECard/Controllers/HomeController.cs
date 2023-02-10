using ECard.DAL;
using ECard.Models;
using ECard.ViewModel;
using Helpers;
using PagedList;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ECard.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private static string Email => WebConfigurationManager.AppSettings["email"];
        private static string Password => WebConfigurationManager.AppSettings["password"];
        public ConfigSite ConfigSite => (ConfigSite)HttpContext.Application["ConfigSite"];

        #region Home
        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                Banners = _unitOfWork.BannerRepository.GetQuery(b => b.Active, o => o.OrderBy(b => b.Sort)),
            };

            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult Header()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public PartialViewResult Footer()
        {
            var model = new FooterViewModel
            {
                Banners = _unitOfWork.BannerRepository.GetQuery(b => b.Active)
            };
            return PartialView(model);
        }
        #endregion

        [Route("lien-he")]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public JsonResult ContactForm(Contact model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = false, msg = "Hãy điền đúng định dạng." });
            }
            _unitOfWork.ContactRepository.Insert(model);
            _unitOfWork.Save();
            var subject = "Email liên hệ từ website: " + Request.Url?.Host;
            var body = $"<p>Tên người liên hệ: {model.FullName},</p>" +
                       $"<p>Email: {model.Email},</p>" +
                       $"<p>Số điện thoại: {model.Mobile},</p>" +
                       $"<p>Tiêu đề: {model.Title},</p>" +
                       $"<p>Nội dung: {model.Body}</p>" +
                       $"<p>Đây là hệ thống gửi email tự động, vui lòng không phản hồi lại email này.</p>";
            Task.Run(() => HtmlHelpers.SendEmail("gmail", subject, body, ConfigSite.Email, Email, Email, Password, "Hiệu Chuẩn 3D"));

            return Json(new { status = true, msg = "Gửi liên hệ thành công.\nChúng tôi sẽ liên lạc với bạn sớm nhất có thể." });
        }

        #region Product
        [Route("san-pham")]
        public ActionResult AllProduct(int? page, string sort = "date-desc")
        {
            var pageNumber = page ?? 1;
            var pageSize = 9;
            var products = _unitOfWork.ProductRepository.GetQuery(p => p.Active, o => o.OrderByDescending(p => p.CreateDate));

            switch (sort)
            {
                case "date-asc":
                    products = products.OrderBy(a => a.CreateDate);
                    break;
                default:
                    products = products.OrderByDescending(a => a.CreateDate);
                    break;
            }

            var model = new CategoryProductViewModel
            {
                Products = products.ToPagedList(pageNumber, pageSize)
            };
            return View(model);
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}