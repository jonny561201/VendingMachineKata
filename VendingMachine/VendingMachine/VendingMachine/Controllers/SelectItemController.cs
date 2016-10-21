using VendingMachine.Models;
using VendingMachine.VendingMachine.Status;
using VendingMachine.VendingMachine.Validators;

namespace VendingMachine.VendingMachine.Controllers
{
    public class SelectItemController
    {
        private readonly IStockStatus _stockStatus;
        private readonly IAvailableChangeStatus _changeStatus;
        private readonly IStockPurchaseValidator _itemValidator;

        public SelectItemController(IStockPurchaseValidator itemValidator, IStockStatus stockStatus, IAvailableChangeStatus changeStatus)
        {
            _itemValidator = itemValidator;
            _stockStatus = stockStatus;
            _changeStatus = changeStatus;
        }

        public string SelectItemForPurchase(VendingStock vendingStock, decimal tenderedAmount)
        {
            if (_stockStatus.HasAvailableItem(vendingStock) && _itemValidator.CanPurchase(vendingStock, tenderedAmount))
            {
                _changeStatus.DepositChange(vendingStock.Cost);
                _changeStatus.MakeChange(vendingStock.Cost, tenderedAmount);
                _stockStatus.PurchaseItem(vendingStock);
            }
            return "";
        }
    }
}
