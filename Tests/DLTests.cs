using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;
using DL;
using Models;

namespace Tests
{
    public class DLTests
    {
        private readonly DbContextOptions<InvincibleDBContext> options;

        public DLTests()
        {
            options = new DbContextOptionsBuilder<InvincibleDBContext>()
                        .UseSqlite("Filename=Test.db").Options;
            Seed();
            Seed2();
            Seed3();
        }

        [Fact]
        public void GetAllCustomer()
        {
            using (var context = new InvincibleDBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                var customer = repo.GetCustomerList();

                //Assert
                Assert.Empty(customer);
            }
        }

        [Fact]
        public void AddCustomer()
        {
            using (var context = new InvincibleDBContext(options))
            {
                //Arrange with my repo and the item i'm going to add
                IRepo repo = new DBRepo(context);
                Customer customer = new Customer()
                {
                    Id = 3,
                    Username = "bduong",
                    Email = "bduong@gmail.com",
                    Password = "123"
                };

                //Act
                repo.AddCustomer(customer);
            }

            using (var context = new InvincibleDBContext(options))
            {
                //Assert
                Customer cust = context.Customers.FirstOrDefault(r => r.Id == 3);

                Assert.NotNull(cust);
                Assert.Equal("bduong", cust.Username);
                Assert.Equal("bduong@gmail.com", cust.Email);
                Assert.Equal("123", cust.Password);
            }
        }

        [Fact]
        public void GetAllItem()
        {
            using (var context = new InvincibleDBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                var item = repo.GetItemList();

                //Assert
                Assert.Equal(0, item.Count);
            }
        }

        [Fact]
        public void GetAllStore()
        {
            using (var context = new InvincibleDBContext(options))
            {
                //Arrange
                IRepo repo = new DBRepo(context);

                //Act
                var store = repo.GetStoreList();

                //Assert
                Assert.Equal(1, store.Count);
            }
        }

        [Fact]
        public void AddStore()
        {
            using (var context = new InvincibleDBContext(options))
            {
                //Arrange with my repo and the item i'm going to add
                IRepo repo = new DBRepo(context);
                Store store = new Store()
                {
                    Id = 2,
                    Address = "4567 E Burger St",
                    City = "Boulder",
                    State = "CO"
                };

                //Act
                repo.AddStore(store);
            }

            using (var context = new InvincibleDBContext(options))
            {
                //Assert
                Store sto = context.Stores.FirstOrDefault(r => r.Id == 2);

                Assert.NotNull(sto);
                Assert.Equal("4567 E Burger St", sto.Address);
                Assert.Equal("Boulder", sto.City);
                Assert.Equal("CO", sto.State);
            }
        }

        private void Seed()
        {
            using (var context = new InvincibleDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange(
                    new Customer()
                    {
                        Id = 1,
                        Username = "justinbieber",
                        Password = "belieber",
                        Email = "jb@gmail.com",
                    },
                    new Customer()
                    {
                        Id = 2,
                        Username = "hannahmontana",
                        Password = "camprock",
                        Email = "mlc@gmail.com",
                    }
                );

                context.SaveChanges();
            }
        }


        private void Seed2()
        {
            using (var context = new InvincibleDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Items.AddRange(
                    new Item()
                    {
                        Id = 1,
                        Name = "Classic Warmup Hoodie",
                        Price = 155    
                    },
                    new Item()
                    {
                        Id = 2,
                        Name = "Classic Warmup Pants",
                        Price = 125
                    }
                );

                context.SaveChanges();
            }
        }

        private void Seed3()
        {
            using (var context = new InvincibleDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Stores.AddRange(
                    new Store()
                    {
                        Id = 1,
                        Address = "1234 W Burrito Ave",
                        City = "Denver",
                        State = "CO"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}