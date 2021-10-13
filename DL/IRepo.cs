using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IRepo
    {
        List<Customer> SearchCustomer(string name);

        //----------------------------------------

        List<Store> GetStoreList();

        List<Customer> GetCustomerList();

        List<Item> GetItemList();

        List<CheckOut> GetCheckOutList();

        List<Order> GetOrderList();

        List<Size> GetSizeList();

        //----------------------------------------

        Store AddStore(Store store);

        Customer AddCustomer(Customer customer);

        CheckOut AddCheckOut(CheckOut checkOut);

        Order AddOrder(Order order);

        //----------------------------------------

        Size UpdateSize(Size size);

        //----------------------------------------

        Store DeleteStore(Store store);

        void DeleteCheckOut(int id);

        //----------------------------------------

        Item GetItemSizes(int id);

        CheckOut GetCheckOutById(int id);

        Store GetStoreItem(int id);

        Order GetOrderStore(int id);

        //----------------------------------------
    }
}