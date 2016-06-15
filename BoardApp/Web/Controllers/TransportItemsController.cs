using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using DAL.Interfaces;
using Domain;
using Microsoft.AspNet.Identity;
using Web.ViewModels;

namespace Web.Controllers
{
    public class TransportItemsController : Controller
    {
        //private DataBaseContext db = new DataBaseContext();

        private IUOW _uow;

        public TransportItemsController(IUOW uow)
        {
            _uow = uow;
        }

        // GET: TransportItems
        public ActionResult Index()
        {
            var transportItems = _uow.TransportItems.GetAllIncluding(t => t.TransportItemType).
				Where(t => t.OwnerId == User.Identity.GetUserId<int>());
            return View(transportItems.ToList());
        }

        // GET: TransportItems/Details/5
        public ActionResult Details(int? id)
        {
			var vm = new TransportItemDetailsViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            vm.TransportItem = _uow.TransportItems.GetById(id);

            if (vm.TransportItem == null)
            {
                return HttpNotFound();
            }

	        vm.AttributeValues = _uow.TransportItemAndAttributeValues.All.Where(r => r.TransportItemId == vm.TransportItem.TransportItemId).ToList();

            return View(vm);
        }

        // GET: TransportItems/Create
        public ActionResult Create()
        {
			var _vm = new TransportItemCreateViewModel() {
				TransportItemTypeSelectList = new SelectList(_uow.TransportItemTypes.All, "TransportItemTypeId", "Name")
			};

            return View(_vm);
        }

        // POST: TransportItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransportItemCreateViewModel vm)
        {
            if (ModelState.IsValid)
            {
				vm.TransportItem.OwnerId = User.Identity.GetUserId<int>();

				_uow.TransportItems.Add(vm.TransportItem);
                _uow.Commit();

                return RedirectToAction("Index");
            }

			vm.TransportItemTypeSelectList = new SelectList(_uow.TransportItemTypes.All, "TransportItemTypeId", "Name", vm.TransportItem.TransportItemTypeId);

            return View(vm);
        }

        // GET: TransportItems/Edit/5
        public ActionResult Edit(int? id)
        {
			var vm = new TransportItemEditViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            vm.TransportItem = _uow.TransportItems.GetForUser((int) id, User.Identity.GetUserId<int>());

            if (vm.TransportItem == null)
            {
                return HttpNotFound();
            }

            vm.TransportItemTypeSelectList = new SelectList(_uow.TransportItemTypes.All, "TransportItemTypeId", "Name", vm.TransportItem.TransportItemTypeId);

			vm.TransportItemTypeAttributeValues = 
				new MultiSelectList(_uow.TransportItemTypeAttributeValues.All.
				Where(t => t.TransportItemTypeAttribute.TransportItemTypeId == vm.TransportItem.TransportItemTypeId), 
				"TransportItemTypeAttributeValueId", "Value");

			vm.AttributeValues = _uow.TransportItemAndAttributeValues.All.Where(r => r.TransportItemId == vm.TransportItem.TransportItemId).ToList();

			return View(vm);
        }

        // POST: TransportItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransportItemEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
	            vm.TransportItem.OwnerId = User.Identity.GetUserId<int>();

				_uow.TransportItems.Update(vm.TransportItem);

	            if (vm.SelectedAttributeValueIds.Count > 0 || vm.SelectedAttributeValueIds != null)
	            {
		            foreach (var attributeValueId in vm.SelectedAttributeValueIds)
		            {
			            if (_uow.TransportItemAndAttributeValues.CombinationNotExists(vm.TransportItem.TransportItemId, attributeValueId))
			            {
							_uow.TransportItemAndAttributeValues.Add(new TransportItemAndAttributeValue
							{
								TransportItemId = vm.TransportItem.TransportItemId,
								TransportItemTypeAttributeValueId = attributeValueId
							});
						}
		            }
	            }

				_uow.Commit();

                return RedirectToAction("Index");
            }

            vm.TransportItemTypeSelectList = new SelectList(_uow.TransportItemTypes.All, "TransportItemTypeId", "Name", vm.TransportItem.TransportItemTypeId);

            return View(vm);
        }

        // GET: TransportItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            TransportItem transportItem = _uow.TransportItems.GetById(id);

            if (transportItem == null)
            {
                return HttpNotFound();
            }

            return View(transportItem);
        }

        // POST: TransportItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _uow.TransportItems.Delete(id);
            _uow.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               _uow.TransportItems.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
