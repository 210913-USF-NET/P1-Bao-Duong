using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IRepo
    {
        List<Store> GetStoreList();

        List<Customer> GetCustomerList();

        List<Item> GetItemList();

        //----------------------------------------

        Store AddStore(Store store);

        Customer AddCustomer(Customer customer);

        //----------------------------------------

        Store DeleteStore(Store store);

        //----------------------------------------

        Item GetItemSizes(int id);
    }
}