using FollowMe.Web;
using FollowMe.Web.Controllers;
using Helezon.FollowMe.WebUI.Helpers;
using Helezon.FollowMe.WebUI.Models.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Helezon.FollowMe.WebUI.Controllers
{

    public class FileUploadController :  BaseController
    {
        public ActionResult Index(FileControllerIndexViewModel model)
        {
            if (model.EntityId.IsNullOrWhiteSpace())
            {
                Failure = "Gerekli Bilgilere Ulaşılamadı";
                return RedirectToLocal(model.ReturnUrl);
            } 

            //var IpAddress = HttpContext.Request.UserHostAddress;
            //var UserAgent = HttpContext.Request.UserAgent;
            //var PathAndQuery = HttpContext.Request.Url == null ? "" : HttpContext.Request.Url.PathAndQuery;
            //var HttpReferer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.PathAndQuery;

            //SetImageData(model);
            return View(model);
        }

        FilesHelper filesHelper;
        String tempPath = "~/Uploaded/";
        String serverMapPath = "~/Files/Uploaded/";
      
        private string StorageRoot
        {
            get { return Path.Combine(HostingEnvironment.MapPath(serverMapPath)); }
        }
        private string UrlBase = "/Files/Uploaded/";
        String DeleteURL = "/FileUpload/DeleteFile/?file=";
        String DeleteType = "GET";
        public FileUploadController()
        {
            filesHelper = new FilesHelper(DeleteURL, DeleteType, StorageRoot, UrlBase, tempPath, serverMapPath);
        }

   
        //public ActionResult Show(string entitytype)
        //{
        //    JsonFiles ListOfFiles = filesHelper.GetFileList(entitytype);
        //    var model = new FilesViewModel()
        //    {
        //        Files = ListOfFiles.files
        //    };

        //    return View(model);
        //}

        public ActionResult Edit(FileControllerIndexViewModel model)
        {
            if (model.EntityId.IsNullOrWhiteSpace())
            {
                Failure = "Gerekli Bilgilere Ulaşılamadı";
                return RedirectToLocal(model.ReturnUrl);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Upload(FileControllerIndexViewModel model)
        {
            var resultList = new List<ViewDataUploadFilesResult>();

            var CurrentContext = HttpContext;

            filesHelper.UploadAndShowResults(CurrentContext, resultList, model.Entitytype);
            JsonFiles files = new JsonFiles(resultList);

            bool isEmpty = !resultList.Any();
            if (isEmpty)
            {
                return Json("Error ");
            }
            else
            {
                SaveImages(resultList, model);
                 return Json(files);
            }
        }

        private void SaveImages(List<ViewDataUploadFilesResult> resultList, FileControllerIndexViewModel model)
        {
            var entityTypeId = model.Entitytype.AsInt();
            var Entitytype = (EntityType)entityTypeId;
            foreach (var item in resultList)
            {
                var filename = item.name; 

                switch (Entitytype)
                {
                    case EntityType.None:
                        break;
                    case EntityType.Person:
                        GetPersonnelPictureService().Insert(new Entities.Models.PersonnelPicture
                        {
                            CompanyId = model.CompanyId,
                            PersonnelId = model.EntityId,
                            Extension = Path.GetExtension(filename),
                            //Id = model.ImageId.AsInt(),
                            Name = Path.GetFileNameWithoutExtension(filename),
                            CreatedOn = DateTime.UtcNow,
                            CreatedBy = User.Identity.GetUserId()
                        });
                        break;
                    case EntityType.Company:
                        GetCompanyPictureService().Insert(new Entities.Models.CompanyPicture
                        {
                            CompanyId = model.CompanyId,
                            Name = Path.GetFileNameWithoutExtension(filename),
                            Extension= Path.GetExtension(filename),
                            //Id = model.ImageId.AsInt(),
                            CreatedOn = DateTime.UtcNow,
                            CreatedBy = User.Identity.GetUserId()
                        });
                        break;
                    case EntityType.ZetaCodeNormalIplik:
                        GetZetaCodeNormalIplikPictureService().Insert(new Entities.Models.ZetaCodeNormalIplikPicture
                        {
                            CompanyId = model.CompanyId,
                            ZetaCodeNormalIplikId = model.EntityId.AsInt(),
                            Name = Path.GetFileNameWithoutExtension(filename),
                            Extension = Path.GetExtension(filename),
                            //Id = model.ImageId.AsInt(),
                            CreatedOn = DateTime.UtcNow,
                            CreatedBy = User.Identity.GetUserId()
                        });
                        break;
                    default:
                        break;
                }
            }
    
            UnitOfWorkAsync.SaveChanges();
        }

        public JsonResult GetFileList(string entitytype, string entityid,string companyid)
        {
            var entityTypeId = entitytype.AsInt();
            var Entitytype = (EntityType)entityTypeId;
            var r = new List<ViewDataUploadFilesResult>();
            String fullPath = Path.Combine(StorageRoot);
            switch (Entitytype)
            {
                case EntityType.None:
                    break;
                case EntityType.Person:
                    var personnelPictures = GetPersonnelPictureService().GetAllByPersonnelId(entityid, companyid);
                    if (personnelPictures != null)
                    {                      
                        foreach (var picture in personnelPictures)
                        {
                            var temp = Path.Combine(fullPath, picture.Name + picture.Extension);
                            if (System.IO.File.Exists(temp))
                            {
                                FileInfo file = new FileInfo(temp);
                                int SizeInt = unchecked((int)file.Length);
                                r.Add(UploadResult(file.Name, SizeInt, file.FullName, entitytype));
                            }
                        }                      
                    }
                    break;
                case EntityType.Company:
                    var companyPictures = GetCompanyPictureService().GetAllByCompanyId(companyid);
                    if (companyPictures != null)
                    {
                        foreach (var picture in companyPictures)
                        {
                            var temp = Path.Combine(fullPath, picture.Name + picture.Extension);
                            if (System.IO.File.Exists(temp))
                            {
                                FileInfo file = new FileInfo(temp);
                                int SizeInt = unchecked((int)file.Length);
                                r.Add(UploadResult(file.Name, SizeInt, file.FullName, entitytype));
                            }
                        }
                    }
                    break;
                case EntityType.ZetaCodeNormalIplik:
                    var normalIplikPictures = GetZetaCodeNormalIplikPictureService().GetAllById(entityid.AsInt(), companyid);
                    if (normalIplikPictures != null)
                    {
                        foreach (var picture in normalIplikPictures)
                        {
                            var temp = Path.Combine(fullPath, picture.Name + picture.Extension);
                            if (System.IO.File.Exists(temp))
                            {
                                FileInfo file = new FileInfo(temp);
                                int SizeInt = unchecked((int)file.Length);
                                r.Add(UploadResult(file.Name, SizeInt, file.FullName, entitytype));
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            JsonFiles files = new JsonFiles(r);
            return Json(files, JsonRequestBehavior.AllowGet);
        }


        public ViewDataUploadFilesResult UploadResult(String FileName, int fileSize, String FileFullPath, string entitytype)
        {
            String getType = System.Web.MimeMapping.GetMimeMapping(FileFullPath);
            var result = new ViewDataUploadFilesResult()
            {
                name = FileName,
                size = fileSize,
                type = getType,
                url = UrlBase + FileName,
                deleteUrl = DeleteURL + FileName + "&entitytype=" + entitytype,
                thumbnailUrl = CheckThumb(getType, FileName),
                deleteType = DeleteType,
                entitytype = entitytype,
                filename = Path.GetFileNameWithoutExtension(FileName),
            };
            return result;
        }

        public String CheckThumb(String type, String FileName)
        {
            var splited = type.Split('/');
            if (splited.Length == 2)
            {
                string extansion = splited[1].ToLower();
                if (extansion.Equals("jpeg") || extansion.Equals("jpg") || extansion.Equals("png") || extansion.Equals("gif"))
                {
                    String thumbnailUrl = UrlBase + "thumbs/" + Path.GetFileNameWithoutExtension(FileName) + "80x80.jpg";
                    return thumbnailUrl;
                }
                else
                {
                    if (extansion.Equals("octet-stream")) //Fix for exe files
                    {
                        return "/Content/Free-file-icons/48px/exe.png";

                    }
                    if (extansion.Contains("zip")) //Fix for exe files
                    {
                        return "/Content/Free-file-icons/48px/zip.png";
                    }
                    String thumbnailUrl = "/Content/Free-file-icons/48px/" + extansion + ".png";
                    return thumbnailUrl;
                }
            }
            else
            {
                return UrlBase + "/thumbs/" + Path.GetFileNameWithoutExtension(FileName) + "80x80.jpg";
            }

        }

        [HttpGet]
        public JsonResult DeleteFile(string file,string entitytype)
        {
            var entityTypeId = entitytype.AsInt();
            var Entitytype = (EntityType)entityTypeId;
            switch (Entitytype)
            {
                case EntityType.None:
                    break;
                case EntityType.Person:
                    GetPersonnelPictureService().DeleteByImageName(Path.GetFileNameWithoutExtension(file));
                    break;
                case EntityType.Company:
                    GetCompanyPictureService().DeleteByImageName(Path.GetFileNameWithoutExtension(file));
                    break;
                case EntityType.ZetaCodeNormalIplik:
                    GetZetaCodeNormalIplikPictureService().DeleteByImageName(Path.GetFileNameWithoutExtension(file));
                    break;
                default:
                    break;
            }        

            filesHelper.DeleteFile(file);
            UnitOfWorkAsync.SaveChanges();
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SetFeaturedPicture(string filename, string entitytype)
        {
            try
            {
                var entityTypeId = entitytype.AsInt();
                var Entitytype = (EntityType)entityTypeId;
                switch (Entitytype)
                {
                    case EntityType.None:
                        break;
                    case EntityType.Person:
                        GetPersonnelPictureService().SetFeaturedPicture(filename);
                        break;
                    case EntityType.Company:
                        GetCompanyPictureService().SetFeaturedPicture(filename);
                        break;
                    case EntityType.ZetaCodeNormalIplik:
                        GetZetaCodeNormalIplikPictureService().SetFeaturedPicture(filename);
                        break;
                    default:
                        break;
                }
                UnitOfWorkAsync.SaveChanges();
                return Json(new MyJsonResult() { SuccessMessage = "Vitrin Resmi Seçildi" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new MyJsonResult() { ErrorMessage = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }

        }

    }

    public class MyJsonResult
    {
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public MyJsonResult()
        {
            ErrorMessage = string.Empty;
            SuccessMessage = string.Empty;
        }
        public object Data { get; set; }
    }
}