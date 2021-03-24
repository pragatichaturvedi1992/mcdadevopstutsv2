using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.UI.Models
{
    public class InventoryItemViewModel
    {
        [BindProperty]
        public string Id { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        [DisplayName("Item Type")]
        public string ItemType { get; set; }
        [BindProperty]
        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }
        [BindProperty]
        [DisplayName("Price")]
        public double ItemPrice { get; set; }
        [BindProperty]
        [DisplayName("Quantity")]
        public int ItemQuantity { get; set; }
        [BindProperty]
        [DisplayName("Sold Out")]
        public bool IsSoldOut { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}