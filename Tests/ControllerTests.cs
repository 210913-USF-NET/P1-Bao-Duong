using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Controllers;
using Xunit;

namespace Tests
{
    public class ControllerTests
    {
        [Fact]
        public void ListOfStores()
        {
            var mockBL = new Mock<IBl>();
            mockBL.Setup(x => x.GetStoreList()).Returns(
                    new List<Store>()
                    {
                        new Store() {
                            Id = 1,
                            Address = "123",
                            City = "Denver",
                            State = "CO"
                        }
                    }
                );

            var controller = new StoreController(mockBL.Object);


            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Store>>(viewResult.ViewData.Model);

            Assert.Equal(1, model.Count());
        }

        [Fact]
        public void ListOfItem()
        {
            var mockBL = new Mock<IBl>();
            mockBL.Setup(x => x.GetItemList()).Returns(
                    new List<Item>()
                    {
                        new Item() {
                            Id = 1,
                            Name = "a",
                            Price = 1,
                        }
                    }
                );

            var controller = new ShopController(mockBL.Object);

            var result = controller.Index(false);

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Item>>(viewResult.ViewData.Model);

            Assert.Equal(1, model.Count());
        }

        [Fact]
        public void ListOfCustomer()
        {
            var mockBL = new Mock<IBl>();
            mockBL.Setup(x => x.GetCustomerList()).Returns(
                    new List<Customer>()
                    {
                        new Customer() {
                            Id = 1,
                            Username = "b",
                            Email = "b@gmail.com",
                            Password = "123"
                        }
                    }
                );

            var controller = new CustomerController(mockBL.Object);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<Customer>>(viewResult.ViewData.Model);

            Assert.Equal(1, model.Count());
        }
    }
}
