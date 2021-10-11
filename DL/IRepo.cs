using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IRepo
    {
        List<Store> GetStoreList();

        List<Customer> GetCustomerList();

        List<Item> GetItemList();

        List<CheckOut> GetCheckOutList();

        //----------------------------------------

        Store AddStore(Store store);

        Customer AddCustomer(Customer customer);

        CheckOut AddCheckOut(CheckOut checkOut);

        //----------------------------------------

        Store DeleteStore(Store store);

        //----------------------------------------

        Item GetItemSizes(int id);
    }
}