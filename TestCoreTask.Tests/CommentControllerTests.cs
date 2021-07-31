using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCoreTask.BLL;
using TestCoreTask.WEB.Controllers;
using Xunit;

namespace TestCoreTask.Tests
{
    public class CommentControllerTests
    {
        [Fact]
        public async Task GetAllTestAsync()
        {
            // Arrange
            var mock1 = new Mock<ICommentService>();
            mock1.Setup(repo => repo.GetCommentsAsync()).Returns(Task.FromResult(GetTestComments()));
            var mock2 = new Mock<IMapper>();
            CommentController controller = new CommentController(mock1.Object, mock2.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        private IReadOnlyCollection<Comment> GetTestComments()
        {
            var comments = new List<Comment>
            {
                new Comment { Id=1, ParentId=0, Date=new DateTime(), Text="test", UserName="test"},
                new Comment { Id=2, ParentId=0, Date=new DateTime(), Text="test", UserName="test"},
                new Comment { Id=3, ParentId=0, Date=new DateTime(), Text="test", UserName="test"}
            };
            return comments;
        }
    }
}
