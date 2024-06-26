using BlogApp.Controllers;
using BlogApp.Models;

namespace BlogApp.Tests;

public class PostTest
{

    private readonly PostManager _context;
    
    public PostTest()
    {
        _context = new PostManager(ContextGenerator.Generator());
    }


    [Fact]
    public async Task GetAllPost_ReturnsAllPost()
    {
        
        var post1 = Helper.GeneratePost();
        var post2 = Helper.GeneratePost();

        await _context.CreatePost(post1);
        await _context.CreatePost(post2);

        List<Post> posts = await _context.GetAllPosts();
        
        Assert.NotEmpty(posts);

        await _context.DeletePostById(post1.PostId);
        await _context.DeletePostById(post2.PostId);

    }

    [Fact]
    public async Task GetPostById_ReturnsPost()
    {
        
        var post = Helper.GeneratePost();

        await _context.CreatePost(post);

        Post? newPost = await _context.GetPostById(post.PostId);

        Assert.NotNull(newPost);
        Assert.Equal(newPost.Title, post.Title);
        Assert.Equal(newPost.Content, post.Content);

        await _context.DeletePostById(post.PostId);
       
    }

    [Fact]
    public async Task CreatePostTest()
    {
    
        var postTitle = "Post Title";
        var postContent = "Post content";

        Post post = new() {Title = postTitle, Content = postContent};

        await _context.CreatePost(post);


        Assert.Equal(postTitle, post.Title);
        Assert.Equal(postContent, post.Content); 

        await _context.DeletePostById(post.PostId);

    }

    [Fact]
    public async Task EditPostByIdTest()
    {

        var post = Helper.GeneratePost();

        await _context.CreatePost(post);

        var updatedPost = new Post
        {
            Title = "Updated Title",
            Content = "Updated Content"
        };

        await _context.EditPostById(post.PostId, updatedPost);

        Assert.NotNull(post);
        Assert.Equal(post.Content, updatedPost.Content);
        
      await _context.DeletePostById(post.PostId);

    }

    [Fact]
    public async Task DeletePostByIdTest()
    {
        var post1 = Helper.GeneratePost();
        var post2 = Helper.GeneratePost();

        await _context.CreatePost(post1);
        await _context.CreatePost(post2);

        await _context.DeletePostById(post1.PostId);
        await _context.DeletePostById(post2.PostId);

        List<Post> posts = await _context.GetAllPosts();
        Assert.DoesNotContain(posts, p => p.PostId == post1.PostId);
        Assert.DoesNotContain(posts, p => p.PostId == post2.PostId);
    }
}