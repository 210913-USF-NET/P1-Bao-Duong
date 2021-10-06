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

        //----------------------------------------

        public Store AddStore(Store store);

        public Customer AddCustomer(Customer customer);

        //----------------------------------------

        public Store DeleteStore(Store store);
    }
}