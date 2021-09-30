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
        public void CustomerShouldNotAllowInvalidName(string input)
        {
            Customer test = new Customer();

            Assert.Throws<InputInvalidException>(() => test.Username = input);
        }

        [Theory]
        [InlineData("abc")]
        [InlineData("!@#$")]
        [InlineData("bduong@")]
        [InlineData("bduong@gmail")]
        [InlineData("bduong@gmail.")]
        [InlineData("bduong@gmail.c")]
        public void ReviewShouldNotSetInvalidRating(string input)
        {
            Customer test = new Customer();

            Assert.Throws<InputInvalidException>(() => test.Email = input);
        }
    }
}