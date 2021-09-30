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

        public Customer AddCustomer(Customer customer) {
            return _repo.AddCustomer(customer);
        }

        public List<Customer> GetCustomerList() {
            return _repo.GetCustomerList();
        }

        public List<Item> GetStore()
        {
            return _repo.GetStore();
        }

        public Item GetOneItemById(int id)
        {
            return _repo.GetOneItemById(id);
        }

        public Store GetOneStoreById(int id)
        {
            return _repo.GetOneStoreById(id);
        }

        public Order AddOrder(Order order)
        {
            return _repo.AddOrder(order);
        }

        public Order GetOrderById(int id)
        {
            return _repo.GetOrderById(id);
        }

        public List<Store> GetStores()
        {
            return _repo.GetStores();
        }

        public Size UpdateSize(Size size)
        {
            return _repo.UpdateSize(size);
        }

        public List<Customer> SearchCustomer (string search)
        {
            return _repo.SearchCustomer(search);
        }

        public Customer GetOneCustById(int id)
        {
            return _repo.GetOneCustById(id);
        }
    }
}