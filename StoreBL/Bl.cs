using System;
using System.Collections.Generic;
using DL;
using Models;

namespace StoreBL
{
    public class Bl : IBl
    {
        private IRepo _repo;

        public Bl (IRepo repo) {
            this._repo = repo;
        }

        public List<Store> GetStoreList()
        {
            return _repo.GetStoreList();
        }

        public List<Customer> GetCustomerList()
        {
            return _repo.GetCustomerList();
        }

        public List<Item> GetItemList()
        {
            return _repo.GetItemList();
        }


        //-------------------------------------------------------------

        public Store AddStore(Store store)
        {
            return _repo.AddStore(store);
        }

        public Customer AddCustomer(Customer customer)
        {
            return _repo.AddCustomer(customer);
        }

        //-------------------------------------------------------------

        public Store DeleteStore(Store store)
        {
            return _repo.DeleteStore(store);
        }

        //-------------------------------------------------------------

        public Item GetItemSizes(int id)
        {
            return _repo.GetItemSizes(id);
        }

    }
}