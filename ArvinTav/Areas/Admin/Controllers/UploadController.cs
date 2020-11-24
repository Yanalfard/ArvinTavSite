using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;

namespace ArvinTav.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin,Marketer,Content")]
    public class UploadController : Controller
    {
        // GET: Admin/Upload
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadCategoryImage()
        {
            string _imgname = string.Empty;

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["UploadCategoryImageFile"];
                if (pic.ContentLength > 0)
                {
                    if (pic.ContentType != "image/png" && pic.ContentType != "image/jpeg" && pic.ContentType != "image/jpg")
                    {
                        var Erorr = "0";
                        return Json(Erorr);
                    }
                    else
                    {

                        if (pic.ContentLength > 3000000)
                        {
                            var Erorr = "0";
                            return Json(Erorr);
                        }
                        else
                        {
                            var img = Bitmap.FromStream(pic.InputStream);

                            if (img.Width > 600 || img.Height > 600)
                            {
                                var Erorr = "0";
                                return Json(Erorr);
                            }
                            else
                            {
                                var fileName = Path.GetFileName(pic.FileName);
                                var _ext = Path.GetExtension(pic.FileName);

                                _imgname = Guid.NewGuid().ToString();
                                var _comPath = Server.MapPath("/Document/img/Category/") + _imgname + _ext;
                                _imgname = _imgname + _ext;

                                ViewBag.Msg = _comPath;
                                var path = _comPath;

                                // Saving Image in Original Mode
                                pic.SaveAs(path);
                            }
                        }
                    }

                }
            }
            return Json(_imgname);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadPackageImage()
        {
            string _imgname = string.Empty;

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["UploadPackageImageFile"];
                if (pic.ContentLength > 0)
                {
                    if (pic.ContentType != "image/png" && pic.ContentType != "image/jpeg" && pic.ContentType != "image/jpg")
                    {
                        var Erorr = "0";
                        return Json(Erorr);
                    }
                    else
                    {

                        if (pic.ContentLength > 3000000)
                        {
                            var Erorr = "0";
                            return Json(Erorr);
                        }
                        else
                        {
                            var img = Bitmap.FromStream(pic.InputStream);

                            if (img.Width > 600 || img.Height > 600)
                            {
                                var Erorr = "0";
                                return Json(Erorr);
                            }
                            else
                            {
                                var fileName = Path.GetFileName(pic.FileName);
                                var _ext = Path.GetExtension(pic.FileName);

                                _imgname = Guid.NewGuid().ToString();
                                var _comPath = Server.MapPath("/Document/img/Package/") + _imgname + _ext;
                                _imgname = _imgname + _ext;

                                ViewBag.Msg = _comPath;
                                var path = _comPath;

                                // Saving Image in Original Mode
                                pic.SaveAs(path);

                            }
                        }
                    }

                }
            }
            return Json(_imgname);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFileMassage()
        {
            string _imgname = string.Empty;

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["UploadFileMassage"];
                if (pic.ContentLength > 0)
                {


                    if (pic.ContentType != "image/png" && pic.ContentType != "image/jpeg" && pic.ContentType != "image/jpg")
                    {
                        var Erorr = "0";
                        return Json(Erorr);
                    }
                    else
                    {

                        if (pic.ContentLength > 3000000)
                        {
                            var Erorr = "0";
                            return Json(Erorr);
                        }
                        else
                        {
                            var img = Bitmap.FromStream(pic.InputStream);

                            if (img.Width > 600 || img.Height > 600)
                            {
                                var Erorr = "0";
                                return Json(Erorr);
                            }
                            else
                            {
                                var fileName = Path.GetFileName(pic.FileName);
                                var _ext = Path.GetExtension(pic.FileName);

                                _imgname = Guid.NewGuid().ToString();
                                var _comPath = Server.MapPath("/Document/File/TicketFile/") + _imgname + _ext;
                                _imgname = _imgname + _ext;

                                ViewBag.Msg = _comPath;
                                var path = _comPath;

                                // Saving Image in Original Mode
                                pic.SaveAs(path);

                            }
                        }
                    }
                }
            }
            return Json(_imgname);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadSpiderImage()
        {
            string _imgname = string.Empty;

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["UploadSpiderImage"];

                if (pic.ContentLength > 0)
                {
                    if (pic.ContentType != "image/png" && pic.ContentType != "image/jpeg" && pic.ContentType != "image/jpg")
                    {
                        var Erorr = "0";
                        return Json(Erorr);
                    }
                    else
                    {
                        if (pic.ContentLength > 3000000)
                        {
                            var Erorr = "0";
                            return Json(Erorr);
                        }
                        else
                        {
                            var img = Bitmap.FromStream(pic.InputStream);

                            if (img.Width > 600 || img.Height > 600)
                            {
                                var Erorr = "0";
                                return Json(Erorr);
                            }
                            else
                            {

                                var fileName = Path.GetFileName(pic.FileName);
                                var _ext = Path.GetExtension(pic.FileName);

                                _imgname = Guid.NewGuid().ToString();
                                var _comPath = Server.MapPath("/Document/img/Spider/") + _imgname + _ext;
                                _imgname = _imgname + _ext;

                                ViewBag.Msg = _comPath;
                                var path = _comPath;

                                // Saving Image in Original Mode
                                pic.SaveAs(path);

                            }
                        }
                    }
                }
            }
            return Json(_imgname);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadPartnerLogo()
        {
            string _imgname = string.Empty;

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["UploadPartnerImageFile"];
                if (pic.ContentLength > 0)
                {
                    if (pic.ContentType != "image/png" && pic.ContentType != "image/jpeg" && pic.ContentType != "image/jpg")
                    {
                        var Erorr = "0";
                        return Json(Erorr);
                    }
                    else
                    {

                        if (pic.ContentLength > 3000000)
                        {
                            var Erorr = "0";
                            return Json(Erorr);
                        }
                        else
                        {
                            var img = Bitmap.FromStream(pic.InputStream);

                            if (img.Width > 600 || img.Height > 600)
                            {
                                var Erorr = "0";
                                return Json(Erorr);
                            }
                            else
                            {
                                var fileName = Path.GetFileName(pic.FileName);
                                var _ext = Path.GetExtension(pic.FileName);

                                _imgname = Guid.NewGuid().ToString();
                                var _comPath = Server.MapPath("/Document/img/Partner/") + _imgname + _ext;
                                _imgname = _imgname + _ext;

                                ViewBag.Msg = _comPath;
                                var path = _comPath;

                                // Saving Image in Original Mode
                                pic.SaveAs(path);
                            }
                        }
                    }
                }
            }
            return Json(_imgname);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadCustomerLogo()
        {
            string _imgname = string.Empty;

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["UploadCustomerImageFile"];
                if (pic.ContentLength > 0)
                {
                    if (pic.ContentType != "image/png" && pic.ContentType != "image/jpeg" && pic.ContentType != "image/jpg")
                    {
                        var Erorr = "0";
                        return Json(Erorr);
                    }
                    else
                    {

                        if (pic.ContentLength > 3000000)
                        {
                            var Erorr = "0";
                            return Json(Erorr);
                        }
                        else
                        {
                            var img = Bitmap.FromStream(pic.InputStream);

                            if (img.Width > 600 || img.Height > 600)
                            {
                                var Erorr = "0";
                                return Json(Erorr);
                            }
                            else
                            {
                                var fileName = Path.GetFileName(pic.FileName);
                                var _ext = Path.GetExtension(pic.FileName);

                                _imgname = Guid.NewGuid().ToString();
                                var _comPath = Server.MapPath("/Document/img/Customer/") + _imgname + _ext;
                                _imgname = _imgname + _ext;

                                ViewBag.Msg = _comPath;
                                var path = _comPath;

                                // Saving Image in Original Mode
                                pic.SaveAs(path);
                            }
                        }
                    }
                }
            }
            return Json(_imgname);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadProjectImage()
        {
            string _imgname = string.Empty;

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["UploadProjectImageFile"];
                if (pic.ContentLength > 0)
                {

                    if (pic.ContentType != "image/png" && pic.ContentType != "image/jpeg" && pic.ContentType != "image/jpg")
                    {
                        var Erorr = "0";
                        return Json(Erorr);
                    }
                    else
                    {

                        if (pic.ContentLength > 3000000)
                        {
                            var Erorr = "0";
                            return Json(Erorr);
                        }
                        else
                        {
                            var img = Bitmap.FromStream(pic.InputStream);

                            if (img.Width > 600 || img.Height > 600)
                            {
                                var Erorr = "0";
                                return Json(Erorr);
                            }
                            else
                            {
                                var fileName = Path.GetFileName(pic.FileName);
                                var _ext = Path.GetExtension(pic.FileName);

                                _imgname = Guid.NewGuid().ToString();
                                var _comPath = Server.MapPath("/Document/img/Project/") + _imgname + _ext;
                                _imgname = _imgname + _ext;

                                ViewBag.Msg = _comPath;
                                var path = _comPath;

                                // Saving Image in Original Mode
                                pic.SaveAs(path);
                            }
                        }
                    }

                }
            }
            return Json(_imgname);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadSliderImage()
        {
            string _imgname = string.Empty;

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["UploadSliderImageFile"];
                if (pic.ContentLength > 0)
                {

                    if (pic.ContentType != "image/png" && pic.ContentType != "image/jpeg" && pic.ContentType != "image/jpg")
                    {
                        var Erorr = "0";
                        return Json(Erorr);
                    }
                    else
                    {

                        if (pic.ContentLength > 3000000)
                        {
                            var Erorr = "0";
                            return Json(Erorr);
                        }
                        else
                        {
                            var img = Bitmap.FromStream(pic.InputStream);

                            if (img.Width > 600 || img.Height > 600)
                            {
                                var Erorr = "0";
                                return Json(Erorr);
                            }
                            else
                            {
                                var fileName = Path.GetFileName(pic.FileName);
                                var _ext = Path.GetExtension(pic.FileName);

                                _imgname = Guid.NewGuid().ToString();
                                var _comPath = Server.MapPath("/Document/img/Slider/") + _imgname + _ext;
                                _imgname = _imgname + _ext;

                                ViewBag.Msg = _comPath;
                                var path = _comPath;

                                // Saving Image in Original Mode
                                pic.SaveAs(path);
                            }
                        }
                    }
                }
            }
            return Json(_imgname);
        }

    }
}