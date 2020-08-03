using System;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using AntiSerum.Server.Services;

namespace AntiSerum.Server.Tests
{
    public class UnitTest1
    {   
        public IWebHostEnvironment webHostEnvironment {get;}
        [Fact]
        public void Test1()
        {
            string searchWord = "testing";
            bool findOne = true;
            WordSearchService test = new WordSearchService(webHostEnvironment);
            int hold = test.search(searchWord, findOne);
            Assert.Equal(100, hold);
        }
        /*public static void Main()
        {
            string searchWord = "testing";
            WordSearchService test = new WordSearchService(webHostEnvironment);
            Console.WriteLine(test.search(searchWord, true)); 
        }*/
    }
}
