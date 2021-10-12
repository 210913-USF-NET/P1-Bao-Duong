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

        public List<Customer> SearchCustomer(string name)
        {
            return _context.Customers
                .Where(r => r.Username.Contains(name))
                .Select(r => new Customer()
                {
                    Id = r.Id,
                    Username = r.Username,
                    Email = r.Email,
                    Password = r.Password
                }).ToList();
        }

        //-------------------------------------------------------

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

        public List<Item> GetItemList()
        {
            return _context.Items
                .Select(
                r => new Item()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Price = r.Price,
                }).ToList();
        }

        public List<CheckOut> GetCheckOutList()
        {
            return _context.CheckOuts
                .Select(
                r => new CheckOut()
                {
                    Id = r.Id,
                    Item = r.Item,
                    Price = r.Price,
                    Quantity = r.Quantity,
                    Size = r.Size,
                    TotalPrice = r.TotalPrice
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

        public CheckOut AddCheckOut(CheckOut checkOut)
        {
            checkOut = _context.Add(checkOut).Entity;

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return checkOut;
        }

        public Order AddOrder(Order order)
        {
            order = _context.Add(order).Entity;

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return order;
        }

        //-------------------------------------------------------

        public Store DeleteStore(Store store)
        {
            store = _context.Remove(store).Entity;

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return store;
        }

        public void DeleteCheckOut(int id)
        {
            _context.CheckOuts.Remove(GetCheckOutById(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        //-------------------------------------------------------

        public Item GetItemSizes(int id)
        {
            Item itemId = _context.Items
                .Include(r => r.Size)
                .FirstOrDefault(r => r.Id == id);

            return new Item()
            {
                Id = itemId.Id,
                Name = itemId.Name,
                Price = itemId.Price,

                Size = itemId.Size.Select(r => new Size()
                {
                    Id = r.Id,
                    ClothingSize = r.ClothingSize,
                    SizeQuantity = r.SizeQuantity,
                    ItemId = r.ItemId
                }).ToList()
            };
        }

        public CheckOut GetCheckOutById(int id)
        {
            CheckOut checkOut = _context.CheckOuts
                .AsNoTracking()
                .FirstOrDefault(r => r.Id == id);

            return new CheckOut()
            {
                Id = checkOut.Id,
                Item = checkOut.Item,
                Price = checkOut.Price,
                Quantity = checkOut.Quantity,
                Size = checkOut.Size,
                TotalPrice = checkOut.TotalPrice
            };
        }

        public Store GetStoreItem(int id)
        {
            Store store = _context.Stores
                .Include(r => r.Item)
                .FirstOrDefault(r => r.Id == id);

            return new Store()
            {
                Id = store.Id,
                Address = store.Address,
                City = store.City,
                State = store.State,

                Item = store.Item.Select(r => new Item()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Price = r.Price,
                    Size = r.Size
                }).ToList()
            };
        }

        //-------------------------------------------------------

        public void GetForeignKey(int id)
        {
            _context.Items
                .Where(r => r.Id == id)
                .FirstOrDefault();
        }
    }
}