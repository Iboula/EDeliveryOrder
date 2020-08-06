using BLL;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    [Authorize]
    public class VoyageController : Controller
    {
        private VoyageBs obj;
        private PortBs obj_Pt;
        public VoyageController()
        {
            obj = new VoyageBs();
            obj_Pt = new PortBs();
        }

        // GET: Voyage
        public ActionResult Index()
        {
            int shippingLineID = int.Parse(HttpContext.User.Identity.Name);
            var voyages = obj.getAllById(shippingLineID).Select(x => new Voyage { 
                VoyageID = x.VoyageID,  
                VoyageNumber = x.VoyageNumber,  
                VesselName = x.VesselName,
                Port = x.Port,
                Port1 = x.Port1,
                Port2 = x.Port2,
                Port3 = x.Port3,
                PortOfRecept = x.PortOfRecept,  
                PortOfLoading = x.PortOfLoading,  
                PortOfFinalPlaceOfDevlivery = x.PortOfFinalPlaceOfDevlivery,
                PortOfDischarge = x.PortOfDischarge,
                ETD = x.ETD,
                ETA = x.ETA,
                Bad = x.Bad,
                CountBad = x.Bad.Count(),
            });
            return View(voyages);
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Create(Voyage voyage)
        {
            voyage.ShippingLineID = int.Parse(HttpContext.User.Identity.Name);

            var port = obj_Pt.getAll().ToList();
            ViewBag.PortOfLoading = new SelectList(port, "id", "NOM");
            ViewBag.PortOfDischarge = new SelectList(port, "id", "NOM");
            ViewBag.PortOfFinalPlaceOfDevlivery = new SelectList(port, "id", "NOM");
            ViewBag.PortOfRecept = new SelectList(port, "id", "NOM");

            if (ModelState.IsValid)
            {
                var id = obj.Insert(voyage);
                TempData["SuccessMsg"] = "Voyage is successfully created.";
                return RedirectToAction("Index");
            }
            return View(voyage);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            var voyage = obj.getById(id);
            var port = obj_Pt.getAll().ToList();
            ViewBag.PortOfLoading = new SelectList(port, "id", "NOM");
            ViewBag.PortOfDischarge = new SelectList(port, "id", "NOM");
            ViewBag.PortOfFinalPlaceOfDevlivery = new SelectList(port, "id", "NOM");
            ViewBag.PortOfRecept = new SelectList(port, "id", "NOM");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (voyage == null)
            {
                return HttpNotFound();
            }

            return View(voyage);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Voyage voyage)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    obj.Update(voyage);
                    TempData["SuccessMsg"] = "Updated Success.";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = "Failed. " + ex.Message.ToString();
                return RedirectToAction("Edit");
            }

        }
    }
}