using FollowMe.Web;
using FollowMe.Web.Controllers;
using Helezon.FollowMe.WebUI.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Helezon.FollowMe.WebUI.Controllers
{
    public class FileController : BaseController
    {
        // GET: File
        public ActionResult Index(FileControllerIndexViewModel model)
        {
            if (model.EntityId.IsNullOrWhiteSpace()) {
                Failure = "Gerekli Bilgilere Ulaşılamadı";
                return RedirectToLocal(model.ReturnUrl);
            }

            SetImageData(model);
            return View(model);
        }

        private void SetImageData(FileControllerIndexViewModel model)
        {
            var entityTypeId = model.Entitytype.AsInt();

            if (entityTypeId < 1)            
                return;            


            var Entitytype = (EntityType)entityTypeId;
            switch (Entitytype)
            {
                case EntityType.None:
                    break;
                case EntityType.Person:
                    var personnelImage = PersonnelImageService.GetPersonnelImageByPersonnelId(model.EntityId,model.CompanyId);
                    model.ImageId = personnelImage.Id.ToString();
                    model.ImageName = personnelImage.Name;
                    break;
                case EntityType.Company:
                   var companyImage =  CompanyImageService.GetCompanyImageByCompanyId(model.EntityId);
                    model.ImageId = companyImage.Id.ToString();
                    model.ImageName = companyImage.Name;
                    break;
                default:
                    break;
            }
        }

        private string SaveImage(object imageBaseData)
        {
            throw new NotImplementedException();
        }

        public JsonResult SendPicture(FileControllerIndexViewModel model)
        {

            var entityTypeId = model.Entitytype.AsInt();

            if (entityTypeId < 1)
            {
                return Json(new MyAjaxResponse
                {
                    Failure = "Bilgiler Eksik Gönderildi"
                }, JsonRequestBehavior.AllowGet);
            }

            var filename = string.Empty;

            var Entitytype = (EntityType)entityTypeId;
            switch (Entitytype)
            {
                case EntityType.None:
                    break;
                case EntityType.Person:
                    filename = SaveImage(model.ImageBaseData);
                    PersonnelImageService.InsertOrUpdate(new Entities.Models.PersonnelImage
                    {
                        CompanyId = model.CompanyId,
                        PersonnelId = model.EntityId,
                        Id = model.ImageId.AsInt(),
                        Name = filename,
                        CreatedOn = DateTime.UtcNow,
                        CreatedBy = User.Identity.GetUserId()
                    });
                    break;
                case EntityType.Company:
                    filename = SaveImage(model.ImageBaseData);
                    CompanyImageService.InsertOrUpdate(new Entities.Models.CompanyImage
                    {
                        CompanyId = model.CompanyId,
                        Name = filename,
                        Id = model.ImageId.AsInt(),
                        CreatedOn = DateTime.UtcNow,
                        CreatedBy = User.Identity.GetUserId()
                    });
                    break;
                default:
                    break;
            }
            UnitOfWorkAsync.SaveChanges();
            return
                Json(new MyAjaxResponse
                    {
                        Data = "~/Content/Pictures/" + filename
                    }, JsonRequestBehavior.AllowGet);
        }

        public string SaveImage(string imageBaseData)
        {
            var filename = Guid.NewGuid() + ".jpg";
            var convert = imageBaseData.Replace("data:image/png;base64,", string.Empty);
            using (var ms = new MemoryStream(Convert.FromBase64String(convert)))
            {
                using (var bm2 = new Bitmap(ms))
                {
                    bm2.Save(Server.MapPath("~/Content/Images/" + filename));
                }
            }
            return filename;
        }
    }
}