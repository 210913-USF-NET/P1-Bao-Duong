using System;
using Xunit;
using Models;


namespace Tests
{
    public class ModelTests
    {
        [Fact]
        public void CustomerShouldCreate()
        {

            Customer test = new Customer();

            Assert.NotNull(test);
        }

        [Fact]
        public void CustomerShouldSetValidData()
        {

            Customer test = new Customer();
            string testName = "bduong";


            test.Username = testName;


            Assert.Equal(testName, test.Username);
        }

        [Theory]
        [InlineData("")]
        [InlineData("%$@^^")]
        [InlineData("a!")]
        public void CustomerShouldNotAllowInvalidName(string input)
        {
            //Arrange
            Customer test = new Customer();
            
            //Act & Assert
            //When I try to set the restaurant's name to an invalid data
            //We make sure that the program throws input invalid exception
            Assert.Throws<InputInvalidException>(() => test.Username = input);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("!@#$")]
        [InlineData("bduong@")]
        [InlineData("bduong@gmail")]
        [InlineData("bduong@gmail.")]
        [InlineData("bduong@gmail.c")]
        [InlineData("bduong@gmail.co")]
        public void ReviewShouldNotSetInvalidRating(string input)
        {
            Customer test = new Customer();

            Assert.Throws<InputInvalidException>(() => test.Email = input);
        }
    }
}