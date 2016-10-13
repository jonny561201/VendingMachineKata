using System;
using VendingMachine.Models;
using VendingMachine.VendingMachine.Status;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachine.Controllers
{
    public class SelectItemController
    {
        private readonly IStockPurchaseValidator _itemValidator;
        private readonly IStockStatus _stockStatus;

        public SelectItemController(IStockPurchaseValidator itemValidator, IStockStatus stockStatus)
        {
            _itemValidator = itemValidator;
            _stockStatus = stockStatus;
        }

        public void Select(VendingStock vendingStock, decimal tenderedAmount)
        {
            if (_stockStatus.HasAvailableItem(vendingStock))
            {
                _stockStatus.PurchaseItem(vendingStock);
            }

            _itemValidator.CanPurchase(vendingStock, tenderedAmount);
        }
    }
}
