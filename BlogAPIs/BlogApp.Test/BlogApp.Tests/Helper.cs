using BlogApp.Models;

namespace BlogApp.Tests
{
    public static class Helper

    // Generate new post and comment
    
    {
        public static Post GeneratePost()
        {
            var post = new Post
            {
                Title = "Post title",
                Content = "Post content"
            };

            return post;
        } 

        public static Comment GenerateComment()
        {
            var post = GenerateComment();

            var comment = new Comment
            {
                Text = "Comment Text",
                PostId = post.PostId
            };

            return comment;
        }
    }
}