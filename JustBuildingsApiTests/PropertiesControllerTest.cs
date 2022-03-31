using System.Threading.Tasks;
using JustBuildingsApi.Controllers;
using JustBuildingsApi.Interfaces;
using JustBuildingsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace JustBuildingsApiTests
{
    public class PropertiesControllerTest
    {
        private readonly PropertiesController controller;
        private readonly Mock<IUpdateProperties>? updateProperties;
        private readonly Mock<PropertiesContext>? propertiesContext;
        private readonly Mock<DbSet<Properties>> dbSet;

        public PropertiesControllerTest()
        {
            dbSet = new Mock<DbSet<Properties>>();
            propertiesContext = new Mock<PropertiesContext>();
            //FIXME: Fix setup with mock causing issues
            propertiesContext.Setup(c => c.Properties).Returns(dbSet.Object);

            updateProperties = new Mock<IUpdateProperties>();
            controller = new PropertiesController(propertiesContext.Object, updateProperties.Object);
        }

        [Fact]
        public async Task ShouldPost()
        {
            var properties = new Properties();
            properties.Name = "some random name";
            var result = Assert.IsAssignableFrom<CreatedAtActionResult>(await controller.PostProperties(false, properties));
            var resultContent = Assert.IsAssignableFrom<Properties>(result.Value);
            Assert.Equal("some random name", resultContent.Name);
            propertiesContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
            updateProperties.Verify(u => u.AddDemographicData(properties), Times.Never);
        }

        [Fact]
        public async Task ShouldPostWithAdditionalData()
        {
            var properties = new Properties();
            properties.Name = "some random name";
            var result = Assert.IsAssignableFrom<CreatedAtActionResult>(await controller.PostProperties(true, properties));
            var resultContent = Assert.IsAssignableFrom<Properties>(result.Value);
            Assert.Equal("some random name", resultContent.Name);
            propertiesContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
            updateProperties.Verify(u => u.AddDemographicData(properties), Times.Once);
        }
    }



}