using System;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Status;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachine.Controllers
{
    public class SelectItemController
    {
        private readonly IStockPurchaseValidator _itemValidator;

        public SelectItemController(IStockPurchaseValidator itemValidator, IStockStatus stockStatus)
        {
            _itemValidator = itemValidator;
        }

        public void Select(VendingStock vendingStock, decimal tenderedAmount)
        {
            _itemValidator.CanPurchase(vendingStock, tenderedAmount);
        }
    }
}
