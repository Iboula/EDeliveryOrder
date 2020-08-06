using BLL;
using BotDetect.Web.Mvc;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UI.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private BADEntities bd;
        private ShippingLine obj;

        public LoginController()
        {
            bd = new BADEntities();
            obj = new ShippingLine();
        }

        // GET: Login
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToLocal(returnUrl);
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [CaptchaValidationActionFilter("CaptchaCode", "LoginCaptcha", "Wrong Captcha!")]
        public ActionResult Index(ShippingLine model, string returnUrl)
        {
            try
            {
                // Verification.    
                if (ModelState.IsValid)
                {
                    // Initialization.    
                    var loginInfo = Authentication(model.Login, model.Password);
                    // Verification.    
                    if (loginInfo != null)
                    {
                        Session["UserPassword"] = loginInfo.Password;
                        Session["Name"] = loginInfo.Name;
                        FormsAuthentication.SetAuthCookie(loginInfo.ShippingLineID.ToString(), false);
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        // Setting.    
                        //ModelState.AddModelError(string.Empty, "Login et/ou mot de passe incorrect.");
                        TempData["ErrorMsg"] = "Login et/ou mot de passe incorrect.";
                        return Redirect("/");
                    }
                }
                else
                {
                    // Reset the captcha if your app's workflow continues with the same view
                    MvcCaptcha.ResetCaptcha("LoginCaptcha");
                }
            }
            catch (Exception ex)
            {
                // Info    
                Console.Write(ex);
            }
            // If we got this far, something failed, redisplay form    
            return this.View(model);
        }

        public ShippingLine Authentication(string username, string password)
        {
            return bd.ShippingLine.FirstOrDefault(u => u.Login == username && u.Password == password);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "Login");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                // Verification.    
                if (Url.IsLocalUrl(returnUrl))
                {
                    // Info.    
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                // Info    
                throw ex;
            }
            // Info.    
            return this.RedirectToAction("Index", "Voyage");
        }
    }
}