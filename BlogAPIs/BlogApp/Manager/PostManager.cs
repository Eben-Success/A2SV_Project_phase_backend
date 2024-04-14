using BlogApp.Models;
using BlogCrudApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers;



    public class PostManager
    {
        private readonly ApiDbContext _context;

        public PostManager(ApiDbContext context){
            _context = context;
        }

        // Get all Posts
        public async Task<List<Post>> GetAllPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }

        // Get Post by Id
        public async Task<Post?> GetPostById(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            
            if (post == null)
            {
                throw new Exception("Invalid Post Id");
            }

            return post;
        }

        // Create Post
        public async Task<int> CreatePost(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            
            return post.PostId;
        }

        // Edit post: Update title or content
        public async Task EditPostById(int id, Post updatedPost){
                var post = await _context.Posts.FindAsync(id);

                if (post == null){
                    throw new Exception("Invalid Post Id");
                }

                post.Title = updatedPost.Title;
                post.Content = updatedPost.Content;

                await _context.SaveChangesAsync();
        }


        // Delete Post
        public async Task DeletePostById(int id){
                var post = await _context.Posts.FindAsync(id);

                if (post == null){
                    throw new Exception("Invalid Post Id");
                }

                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            
        }
    }
