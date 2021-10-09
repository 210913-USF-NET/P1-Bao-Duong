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

        //----------------------------------------

        Store AddStore(Store store);

        Customer AddCustomer(Customer customer);

        //----------------------------------------

        Store DeleteStore(Store store);
    }
}