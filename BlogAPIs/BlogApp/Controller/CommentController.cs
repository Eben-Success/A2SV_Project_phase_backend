using BlogApp.Models;
using BlogCrudApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers;

[Route("api/[controller]")]
[ApiController]

    public class CommentController : ControllerBase
    {
        private readonly ApiDbContext _context;
        CommentManager commentManager;

        public CommentController(ApiDbContext context){
            _context = context;
            commentManager = new CommentManager(context);
        }

        // Get all Comments
        [HttpGet]
        public async Task<IActionResult> GetAllComment(){
            var posts = await _context.Comments.ToListAsync();
            return Ok(posts);
        }

        // Get comment by Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCommentById(int id){
            try{
                var comment = await commentManager.GetCommentById(id);
                return Ok(comment);
            } 
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        // Create Comment
        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment){
            try{
            await commentManager.CreateComment(comment);
            return NoContent();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        // Edit Comment: Update content of comment
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> EditCommentByIdd(int id, Comment updatedComment){
            try{
                await commentManager.EditCommentById(id, updatedComment);
                return NoContent();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        // Delete Comment By Id
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCommentById(int id){
            try{
                await commentManager.DeleteCommentById(id);
                return NoContent();
            } 
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

    }
