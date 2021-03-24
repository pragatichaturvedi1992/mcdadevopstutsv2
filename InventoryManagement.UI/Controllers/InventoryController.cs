using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InventoryManagement.UI.Common;
using InventoryManagement.UI.Models;
using InventoryManagment.UI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace InventoryManagement.UI.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IStoreManagementRepository _inventoryRepo;

        public InventoryController(ILogger<InventoryController> logger, IStoreManagementRepository storeManagementRepository)
        {
            _logger = logger;
            _inventoryRepo = storeManagementRepository;
        }

        public async Task<IActionResult> Index()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            
            var inventoryItems = await _inventoryRepo.GetInventoryItemsByUser(currentUserId);

            return View(inventoryItems);
        }

        public IActionResult Create()
        {
            var inventoryItem = new InventoryItemViewModel {};

            ViewData["ItemTypes"] = GetItemTypes();

            return View(inventoryItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await _inventoryRepo.CreateInventoryItem(model);

                return RedirectToAction(nameof(Index));
            }

            ViewData["ItemTypes"] = GetItemTypes();

            return View(model);
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            InventoryItemViewModel inventoryItem = await _inventoryRepo.GetInventoryItem(id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            InventoryItemViewModel inventoryItem = await _inventoryRepo.GetInventoryItem(id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            ViewData["ItemTypes"] = GetItemTypes();

            return View(inventoryItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, InventoryItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _inventoryRepo.UpdateInventoryItem(id, model);

                return RedirectToAction(nameof(Index));
            }

            ViewData["ItemTypes"] = GetItemTypes();

            return View(model);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            InventoryItemViewModel inventoryItem = await _inventoryRepo.GetInventoryItem(id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return View(inventoryItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            await _inventoryRepo.DeleteInventoryItem(id);

            return RedirectToAction(nameof(Index));
        }

        public IEnumerable<SelectListItem> GetItemTypes()
        {
            return Enum.GetNames(typeof(ItemTypeEnum)).Cast<string>().Select(item => new SelectListItem
            {
                Value = item,
                Text = item
            });
        }

    }
}