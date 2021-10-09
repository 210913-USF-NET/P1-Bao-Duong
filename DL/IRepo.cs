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

        public Store AddStore(Store store);

        public Customer AddCustomer(Customer customer);

        //----------------------------------------

        public Store DeleteStore(Store store);
    }
}