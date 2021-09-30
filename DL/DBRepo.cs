using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model = Models;
using Entity = DL.Entities;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class DBRepo : IRepo
    {
        private Entity.InvincibleDBContext _context;
        
        public DBRepo(Entity.InvincibleDBContext context) {
            this._context = context;
        }

        /// <summary>
        /// Add customer to datatbase and returns Model.Customer by Customer customer
        /// </summary>
        /// <param name="id">Model.Customer customer</param>
        /// <returns>Model.Customer</returns>
        public Model.Customer AddCustomer(Model.Customer customer) {
            Entity.Customer newCust = new Entity.Customer() {
                Username = customer.Username,
                Password = customer.Password,
                Email = customer.Email
            };

            newCust = _context.Add(newCust).Entity;

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Customer() {
                Id = newCust.Id,
                Username = newCust.Username,
                Password = newCust.Password,
                Email = newCust.Email
            };
        }

        /// <summary>
        /// return a list of Model.Customer
        /// </summary>
        /// <param name="id">None</param>
        /// <returns>Model.Customer</returns>
        public List<Model.Customer> GetCustomerList() {
            return _context.Customers.Select(
                r => new Model.Customer() {
                    Id = r.Id,
                    Username = r.Username,
                    Password = r.Password,
                    Email = r.Email
                }
            ).ToList();
        }

        public List<Item> GetStore()
        {
            return _context.Items.Select(
                r => new Model.Item() {
                    Id = r.Id,
                    Name = r.Name,
                    Price = (decimal)r.Price,

                }
            ).ToList();
        }

        /// <summary>
        /// returns Model.Item item by referencing size id
        /// </summary>
        /// <param name="id">int id</param>
        /// <returns>Model.Item</returns>
        public Model.Item GetOneItemById(int id)
        {
            Entity.Item itemId = 
                _context.Items
                .Include(r => r.Sizes)
                .FirstOrDefault(r => r.Id == id);

            return new Model.Item() {
                Id = itemId.Id,
                Name = itemId.Name,
                Price = (decimal)itemId.Price,

                Size = itemId.Sizes.Select(r => new Model.Size() {
                    Id = r.Id,
                    ClothingSize = r.ClothingSize,
                    SizeQuantity = (int)r.SizeQuantity
                }).ToList()
            };
        }

        public Store GetOneStoreById(int id)
        {
            Entity.Store storeId =
                _context.Stores
                .Include(r => r.Items)
                .FirstOrDefault(r => r.Id == id);

            return new Model.Store() {
                Id = storeId.Id,
                Address = storeId.Address,
                City = storeId.City,
                State = storeId.State,
                
                Item = storeId.Items.Select(r => new Model.Item() {
                    Id = r.Id,
                    Name = r.Name,
                    Price = (decimal)r.Price
                }).ToList()
            };
        }

        public Customer GetOneCustById(int id)
        {
            Entity.Customer custId =
                _context.Customers
                .Include(r => r.Orders)
                .FirstOrDefault(r => r.Id == id);

            return new Model.Customer() {
                Id = custId.Id,
                Username = custId.Username,
                Email = custId.Email,
                Password = custId.Password,
                
                Orders = custId.Orders.Select(r => new Model.Order() {
                    Id = r.Id,
                    CustomerId = r.CustomerId,
                    StoreId = r.StoreId
                }).ToList()
            };
        }

        public Order AddOrder(Order order)
        {
            Entity.Order orderToAdd = new Entity.Order() {
                CustomerId = order.CustomerId,
                StoreId = order.StoreId
            };

            orderToAdd = _context.Add(orderToAdd).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return new Model.Order() {
                Id = orderToAdd.Id,
                CustomerId = orderToAdd.CustomerId,
                StoreId = orderToAdd.StoreId
            };
        }

        public Order GetOrderById(int id)
        {
            Entity.Order orderId = 
                _context.Orders
                .Include(r => r.Customer)
                .Include(r => r.Store)
                .FirstOrDefault(r => r.Id == id);
            
            return new Model.Order() {
                CustomerId = orderId.CustomerId,
                StoreId = orderId.StoreId,

                Customers = new Model.Customer() {
                    Id = orderId.Customer.Id,
                    Username = orderId.Customer.Username,
                    Email = orderId.Customer.Email
                },
            
                Stores = new Model.Store() {
                    Address = orderId.Store.Address,
                    City = orderId.Store.City,
                    State = orderId.Store.State
                },
            };
        }

        public List<Store> GetStores()
        {
            return _context.Stores.Select(
                r => new Model.Store() {
                    Id = r.Id,
                    Address = r.Address,
                    City = r.City,
                    State = r.State
                }
            ).ToList();
        }

        public Model.Size UpdateSize(Model.Size size) {     
            Entity.Size updatedSize = (
                from i in _context.Sizes
                where i.ItemId == size.ItemId && i.ClothingSize == size.ClothingSize
                select i)
                .FirstOrDefault();

            updatedSize.SizeQuantity = size.SizeQuantity;

            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Model.Size() {
                SizeQuantity = (int)updatedSize.SizeQuantity
            };
        }

        public List<Model.Customer> SearchCustomer(string search)
        {
            return _context.Customers.Where(
                r => r.Username.Contains(search) || r.Email.Contains(search)
                ).Select(
                r => new Model.Customer(){
                    Id = r.Id,
                    Username = r.Username,
                    Email = r.Email,
                    Password = r.Password
                }
            ).ToList();
        }

        // public List<Order> GetOrderById(int id)
        // {
        //     return
        //         _context.Orders
        //         .Include(r => r.Customer)
        //         .Include(r => r.Store)
        //         .Where(r => r.StoreId == id)
        //         .Select(orderId => new Model.Order() {
        //             CustomerId = orderId.CustomerId,
        //             StoreId = orderId.StoreId,
        //             Customers = new Model.Customer() {
        //             Id = orderId.Customer.Id,
        //             Username = orderId.Customer.Username,
        //             Email = orderId.Customer.Email
        //         },

        //         Stores = new Model.Store() {
        //             Address = orderId.Store.Address,
        //             City = orderId.Store.City,
        //             State = orderId.Store.State
        //         }
        //         }

        //         ).ToList();
        // }
    }
}