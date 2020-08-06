using BLL;
using Infrastructure;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    [Authorize]
    public class BadController : Controller
    {
        private BadBs obj;
        private VoyageBs voy;
        private ShippinglineBs slBs;
        private ContainerBs ctBs;

        public BadController()
        {
            obj = new BadBs();
            voy = new VoyageBs();
            slBs = new ShippinglineBs();
            ctBs = new ContainerBs();
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Create(Bad bad, int id)
        {
            // Recupérer seulement les informations du voyage sélectionné
            ViewData["bad"] = obj.getAll().Where(b => b.VoyageID == id);
            ViewData["voy"] = voy.getById(id);

            // Vérifier si les données entrées sont correctes
            if (ModelState.IsValid)
            {
                //bad = Helper.Model2Entity.ToBad(badMeta);

                bad.Status = false;
                // ajouter le voyage id en param dans le bad courant
                bad.VoyageID = id;

                byte[] pdfArray = Helper.Model2Entity.Pdf2ByteArray(bad.PdfFile);
                bad.PDF = pdfArray;

                // Insérer les données du Bad
                obj.Insert(bad);

                TempData["SuccessMsg"] = "DO is successfully created.";

                // Rediriger la vue ver la création d'un nouveau bad
                return RedirectToAction("Create", "Bad", new { id = id });
            }

            return View(bad);
        }

        [HttpGet]
        public FileResult DownLoadDoFile(int id)
        {
            var bad = obj.getById(id);

            return File(bad.PDF, "application/pdf");
        }


        public JsonResult GetBadByID(int id)
        {
            var bads = obj.getAll().Where(b => b.BadID == id).Select(x => new { statut = x.Status });

            return Json(bads, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewBad(int id)
        {
            ViewData["voyInfos"] = voy.getById(id);
            var bads = obj.getAll().Where(b => b.VoyageID == id).Select(x => new Bad { 
                BadID = x.BadID,
                BLNumber = x.BLNumber,
                ConsigneeAddress = x.ConsigneeAddress,
                ConsigneeName = x.ConsigneeName,
                Container = x.Container,
                CountContainer = x.Container.Count(),
                CustomerAddress = x.CustomerAddress,
                CustomerEmail = x.CustomerEmail,
                CustomerName = x.CustomerName,
                CustomerNinea = x.CustomerNinea,
                CustomerPhoneNumber = x.CustomerPhoneNumber,
                DateEmission = x.DateEmission,
                DateValidite = x.DateValidite,
                NotifyParty = x.NotifyParty,
                PDF = x.PDF,
                ShipperAddress = x.ShipperAddress,
                ShipperName = x.ShipperName,
                Status = x.Status,
                Voyage = x.Voyage,
                VoyageID = x.VoyageID,
            });
            return View(bads);
        }

        public JsonResult GetBadsByVoyage(int id)
        {
            var bads = obj.getAll().Where(b => b.VoyageID == id);

            string value = string.Empty;
            value = JsonConvert.SerializeObject(bads, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(new { data =  value }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult SaveAndSend(int id, string modalPassword)
        {
            var bl = obj.getById(id);
            var msg = CheckPassword(modalPassword);

            if(msg == "Success")
            {
                bl.Status = true;
                obj.Update(bl);
                return Json(new { Success = "Success", Message = "DO is save and sent successfully" }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Success = "Failed", Message = "Sending the Do was unsuccessful" }, JsonRequestBehavior.AllowGet);
        }

        public string CheckPassword(string modalPassword)
        {
            //var userPassword = Session["UserPassword"].ToString();
            ShippingLine sl = slBs.getById(int.Parse(User.Identity.Name));

            var userPassword = sl.Password.ToString();

            if (modalPassword == userPassword)
                return "Success";
            return "Password invalid.";
        }

    }
}