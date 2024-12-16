public interface IPostService
{
    Task<PostDto> CreatePostAsync(PostCreateDto postDto);
    Task<List<PostDto>> GetAllPostsAsync();
    Task<PostDto?> GetPostByIdAsync(Guid id);
    Task<PostDto> UpdatePostAsync(Guid id, PostCreateDto postDto);
    Task<bool> DeletePostAsync(Guid id);
}

