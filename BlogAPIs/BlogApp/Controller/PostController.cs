using BlogApp.Models;
using BlogCrudApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{


    [Route("api/[controller]")]
    [ApiController]

    public class PostController : ControllerBase
    {
        private readonly ApiDbContext _context;
        PostManager postManager;

        public PostController(ApiDbContext context){
            _context = context;
            postManager = new PostManager(_context);
        }

        // Get all Posts
        [HttpGet]
        public async Task<IActionResult> GetAllPosts(){
            var posts = await postManager.GetAllPosts();
            return Ok(posts);
        }

        // Get Post by Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPostById(int id){
            try{
                var post = await postManager.GetPostById(id);
                return Ok(post);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
            
        }

        // Create Post]
        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post){
            var postId = await postManager.CreatePost(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreatePost), new {id = postId}, post);
        }

        // Edit post: Update title or content
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> EditPostById(int id, Post updatedPost){
            try{
                await postManager.EditPostById(id, updatedPost);
                return NoContent();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }


        // Delete Post
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePostById(int id){
            try{
                await postManager.DeletePostById(id);
                return NoContent();
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
            
        }
    }
}