using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class DBRepo : IRepo
    {
        private InvincibleDBContext _context;

        public DBRepo(InvincibleDBContext context)
        {
            this._context = context;
        }

        public List<Store> GetStoreList()
        {
            return _context.Stores
                .Select(
                r => new Store()
                {
                    Id = r.Id,
                    Address = r.Address,
                    City = r.City,
                    State = r.State
                }).ToList();
        }

        public List<Customer> GetCustomerList()
        {
            return _context.Customers
                .Select(
                r => new Customer()
                {
                    Id = r.Id,
                    Username = r.Username,
                    Password = r.Password,
                    Email = r.Email
                }).ToList();
        }

        //-------------------------------------------------------

        public Store AddStore(Store store)
        {
            store = _context.Add(store).Entity;

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return store;
        }

        public Customer AddCustomer(Customer customer)
        {
            customer = _context.Add(customer).Entity;

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return customer;
        }

        //-------------------------------------------------------

        public Store DeleteStore(Store store)
        {
            store = _context.Remove(store).Entity;

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return store;
        }

        
    }
}