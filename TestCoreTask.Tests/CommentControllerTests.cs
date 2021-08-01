using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCoreTask.BLL;
using TestCoreTask.WEB.Controllers;
using TestCoreTask.WEB.Controllers.Models;
using Xunit;

namespace TestCoreTask.Tests
{
    public class CommentControllerTests
    {
        [Fact]
        public async Task GetAllTestAsync()
        {
            // Arrange
            var mockService = new Mock<ICommentService>();
            mockService.Setup(repo => repo.GetCommentsAsync()).Returns(Task.FromResult(GetTestComments()));
            var mockMapper = new Mock<IMapper>();
            CommentController controller = new CommentController(mockService.Object, mockMapper.Object);

            // Act
            var result = await controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CreateCommentTestAsync()
        {
            // Arrange
            var mockComment = new Comment { ParentId = 0, Date = new DateTime(), Text = "test", UserName = "test" };
            var mockCommentModel = new CommentModel { ParentId = 0, Date = new DateTime(), Text = "test", UserName = "test" };

            var mockService = new Mock<ICommentService>();
            mockService.Setup(repo => repo.CreateCommentAsync(mockComment)).Returns(Task.FromResult(CreateTestComment()));

            var mockMapper = new Mock<IMapper>();

            CommentController controller = new CommentController(mockService.Object, mockMapper.Object);

            // Act
            var result = await controller.Post(mockCommentModel);

            // Assert
            Assert.IsType<ActionResult<CommentModel>>(result);
        }

        [Fact]
        public async Task CreateCommentBadTestAsync()
        {
            // Arrange
            var mockService = new Mock<ICommentService>();
            var mockMapper = new Mock<IMapper>();

            CommentController controller = new CommentController(mockService.Object, mockMapper.Object);

            // Act
            var result = await controller.Post(null);

            // Assert
            Assert.IsType<BadRequestResult>(result.Result);
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

        private Comment CreateTestComment()
        {
            var comment = new Comment { Id = 1, ParentId = 0, Date = new DateTime(), Text = "test", UserName = "test" };
            return comment;
        }


    }
}
