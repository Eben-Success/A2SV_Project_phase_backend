using BlogApp.Models;
using BlogCrudApp.Data;
using BlogApp.Controllers;

namespace BlogApp.Tests
{
    public class CommentTest
    {
        private readonly PostManager _postContext;
        private readonly CommentManager _commentContext;

        // Add missing  statement

        public CommentTest()
        {
            _postContext = new PostManager(ContextGenerator.Generator());
            _commentContext = new CommentManager(ContextGenerator.Generator());
        }

        [Fact]
        public async Task CreateCommentTest()
        {
           
            var post = new Post
            {
                Title = "Post Title",
                Content = "Post Content"
            };

            await _postContext.CreatePost(post);

            var text = "Text Comment";

            var comment = new Comment
            {
                Text = text,
                PostId = post.PostId
            };


            await _commentContext.CreateComment(comment);

            Assert.Equal(comment.Text, text);

        }

       


        [Fact]
        public async Task GetAllCommentsTest()
        {

            var post = new Post
            {
                Title = "Text Post",
                Content = "Text Content"
            };


            await _postContext.CreatePost(post);
            var text = "Post comment";

            var comment = new Comment
            {
                Text = text,
                PostId = post.PostId   
            };


            await _commentContext.CreateComment(comment);

            List<Comment> comments = await _commentContext.GetAllComment();
            
            Assert.NotEmpty(comments);
        }

        [Fact]
        public async Task PatchCommentTest()
        {
            

            var post = new Post
            {
                Title = "Text Post",
                Content = "Text Content"
            };

            await _postContext.CreatePost(post);

            var text = "Post comment";

            var comment = new Comment
            {
                Text = text,
                PostId = post.PostId
            };

            await _commentContext.CreateComment(comment);

            var patchedText = "Updated comment";

            var newComment = new Comment
            {
                Text = patchedText,
                PostId = post.PostId
            };

            await _commentContext.EditCommentById(comment.CommentId, newComment);

            Assert.Equal(comment.Text, patchedText);

        }

        [Fact]
        public async Task DeleteCommentTest()
        {
            var post = new Post
            {
                Title = "Text Post",
                Content = "Text Content"
            };

            await _postContext.CreatePost(post);

            string text = "Post comment";

            var comment = new Comment
            {
                Text = text,
                PostId = post.PostId
            };


            await _commentContext.CreateComment(comment);
            await _commentContext.DeleteCommentById(comment.CommentId);

            List<Comment> comments = await _commentContext.GetAllComment();
            Assert.Empty(comments);

        }
    }
}