using System;
using System.Collections.Generic;
using Models;
using DL;

namespace StoreBL
{
    public interface IBl
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