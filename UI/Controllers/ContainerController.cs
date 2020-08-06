using BLL;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    [Authorize]
    public class ContainerController : Controller
    {
        private ContainerBs obj;
        private BadBs obj_b;

        public ContainerController()
        {
            obj = new ContainerBs();
            obj_b = new BadBs();
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Create(Container container, int id)
        {
            // ajouter le bad id en param dans le container courant
            container.BadID = id;

            ViewData["voyBad"] = obj_b.getById(id).VoyageID;

            // Vérifier si les données entrées sont correctes
            if (ModelState.IsValid)
            {
                // Insérer les données du container
                obj.Insert(container);

                TempData["SuccessMsg"] = "Container is successfully created.";
                // Rediriger la vue ver la création d'un nouveau container
                return RedirectToAction("Create", "Container", new { id = id });
            }
            return View(container);
        }

    }
}