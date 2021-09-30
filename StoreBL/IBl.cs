using System;
using System.Collections.Generic;
using Models;
using DL;

namespace StoreBL
{
    public interface IBl
    {
        Customer AddCustomer(Customer customer);
        
        List<Customer> GetCustomerList();

        List<Item> GetStore();

        Item GetOneItemById(int id);

        Store GetOneStoreById(int id);

        Customer GetOneCustById(int id);

        Order AddOrder(Order order);

        Order GetOrderById(int id);
        
        List<Store> GetStores();

        Size UpdateSize(Size size);

        List<Customer> SearchCustomer (string search);
    }
}