using BlogApp.Models;
using BlogCrudApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers;


    public class CommentManager
    {
        private readonly ApiDbContext _context;

        public CommentManager(ApiDbContext context){
            _context = context;
        }

        // Get all Comments
        public async Task<List<Comment>> GetAllComment(){
            var comments = await _context.Comments.ToListAsync();
            return comments;
        }

        public async Task<Comment> GetCommentById(int id){
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);

            if (comment == null){
                throw new Exception("Invalid comment Id");
            }

            return comment;
        }

        // Create Comment
        public async Task<int> CreateComment(Comment comment)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(x => x.PostId == comment.PostId);

            if (post == null)
                throw new Exception("Invalid Post Id");
            
            post.Comments.Add(comment);
            
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();

            return comment.CommentId;
        }


        // Edit Comment: Update content of comment
        public async Task EditCommentById(int id, Comment updatedComment){
                var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);

                if (comment == null){
                    throw new Exception("Invalid comment Id");
                }

                comment.Text = updatedComment.Text;
                await _context.SaveChangesAsync();

        }

        // Delete Comment By Id
        public async Task DeleteCommentById(int id){
                var comment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);

                if (comment == null){
                    throw new Exception("Invalid Id");
                }

                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();

        }

    }
