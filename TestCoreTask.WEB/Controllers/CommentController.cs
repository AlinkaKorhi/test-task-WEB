using AutoMapper;
using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCoreTask.BLL;
using TestCoreTask.WEB.Controllers.Models;

namespace TestCoreTask.WEB.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentService.GetCommentsAsync();
            var models = comments.Select(_mapper.Map<CommentModel>);

            return Ok(models);
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<CommentModel>> Post([FromBody] CommentModel comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }

            var mapComment = _mapper.Map<Comment>(comment);
            var newComment = await _commentService.CreateCommentAsync(mapComment);

            return Ok(newComment);

        }

        [HttpGet("{id}")]
        [Route("{id}")]
        public async Task<ActionResult<CommentModel>> Get(int id)
        {
            var comment = _commentService.GetCommentById(id);
            var model = _mapper.Map<CommentModel>(comment);

            if (model == null)
                return NotFound();
            return new ObjectResult(model);
        }

        [HttpPut]
        [Route("")]
        public async Task<ActionResult<CommentModel>> Put(CommentModel comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }
            var model = _mapper.Map<Comment>(comment);
            var resultUpdate = _commentService.UpdateComment(model);

            return Ok(resultUpdate);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(CommentModel comment)
        {

            var model = _mapper.Map<Comment>(comment);
            await _commentService.DeleteComment(model);

            return Ok();

        }
    }
}
