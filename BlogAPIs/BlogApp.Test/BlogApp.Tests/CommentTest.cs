using BlogApp.Models;
using BlogApp.Controllers;

namespace BlogApp.Tests
{
    public class CommentTest
    {
        private readonly PostManager _postContext;
        private readonly CommentManager _commentContext;

        public CommentTest()
        {
            _postContext = new PostManager(ContextGenerator.Generator());
            _commentContext = new CommentManager(ContextGenerator.Generator());
        }

        [Fact]
        public async Task CreateCommentTest()
        {

            var post = Helper.GeneratePost();

            var postId = await _postContext.CreatePost(post);

            var text = "Text Comment";

            var comment = Helper.GenerateComment();

            await _commentContext.CreateComment(comment);

            Assert.Equal(comment.Text, text);

            await _commentContext.DeleteCommentById(comment.CommentId);
        }

        [Fact]
        public async Task EditCommentByIdTest()
        {
            var post = Helper.GeneratePost();

            var postId = await _postContext.CreatePost(post);

            var comment = Helper.GenerateComment();

            await _commentContext.CreateComment(comment);

            var updatedComment = new Comment
            {
                Text = "Updated comment",
                PostId = postId
            };

            await _commentContext.EditCommentById(comment.CommentId, updatedComment);

            Assert.Equal(comment.Text, updatedComment.Text);

            await _commentContext.DeleteCommentById(comment.CommentId);
        }

        [Fact]
        public async Task GetAllCommentTest()
        {
            var post1 = Helper.GeneratePost();
            var comment1 = Helper.GenerateComment();
            comment1.PostId = post1.PostId;


            await _postContext.CreatePost(post1);

            await _commentContext.CreateComment(comment1);

            var comments = await _commentContext.GetAllComment();

            Assert.NotEmpty(comments);
    }

    [Fact]
    public async Task DeleteCommentById()
    {
        var post = Helper.GeneratePost();
        var comment = Helper.GenerateComment();
        comment.PostId = post.PostId;

        await _postContext.CreatePost(post);
        await _commentContext.CreateComment(comment);

        await _postContext.DeletePostById(post.PostId);

        var comments = await _commentContext.GetAllComment();

        Assert.Empty(comments);

        await _commentContext.DeleteCommentById(comment.CommentId);
    }

    }
}