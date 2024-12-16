using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class PostService : IPostService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PostService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PostDto> CreatePostAsync(PostCreateDto postDto)
    {
        var post = _mapper.Map<Post>(postDto);
        post.Id = Guid.NewGuid();
        post.IsPublished = false; // Novo post começa como não publicado

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return _mapper.Map<PostDto>(post);
    }

    public async Task<List<PostDto>> GetAllPostsAsync()
    {
        var posts = await _context.Posts.ToListAsync();
        return _mapper.Map<List<PostDto>>(posts);
    }

    public async Task<PostDto?> GetPostByIdAsync(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);
        return post == null ? null : _mapper.Map<PostDto>(post);
    }

    public async Task<PostDto> UpdatePostAsync(Guid id, PostCreateDto postDto)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post == null)
        {
            throw new Exception("Post not found");
        }

        post.Content = postDto.Content;
        post.ScheduledDate = postDto.ScheduledDate;
        post.MediaUrl = postDto.MediaUrl;
        post.CustomerId = postDto.CustomerId;

        await _context.SaveChangesAsync();

        return _mapper.Map<PostDto>(post);
    }

    public async Task<bool> DeletePostAsync(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post == null)
        {
            return false;
        }

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return true;
    }
}



