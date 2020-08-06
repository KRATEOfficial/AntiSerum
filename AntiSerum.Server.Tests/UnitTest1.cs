using System;
using Microsoft.AspNetCore.Hosting;
using Xunit;
using AntiSerum.Server.Services;

namespace AntiSerum.Server.Tests
{
    public class UnitTest1
    {   
        //The hashed word lists must be stored in this file for testing to work.
        //AntiSerum/AntiSerum.Shared.Tests/bin/x64/Debug/netcoreapp3.1/hashedWordLists
        public IWebHostEnvironment webHostEnvironment { get; }
        [Theory]
        [InlineData("test")]
        public void OneWordRetunIfFound(string searchWord)
        {
            bool findOne = true;
            WordSearchService test = new WordSearchService(webHostEnvironment);
            Assert.Equal(1, test.search(searchWord, findOne));
        }
        [Theory]
        [InlineData("test", 235)]
        public void OneWordRetunrHowManyFound(string searchWord, int returnValue)
        {
            bool findOne = false;
            WordSearchService test = new WordSearchService(webHostEnvironment);
            Assert.Equal(returnValue, test.search(searchWord, findOne));
        }
    }
}
