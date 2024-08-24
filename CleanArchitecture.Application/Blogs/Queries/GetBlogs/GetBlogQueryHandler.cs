using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogs;

public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVM>>
{
    private readonly IBlogRepository _blogRepository;
    
    public GetBlogQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
    public async Task<List<BlogVM>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _blogRepository.GetAllBlogsAsync();
        var blogList = blogs.Select(b => new BlogVM { Author = b.Author, Name = b.Name, Description = b.Description, Id = b.Id })
            .ToList();
        return blogList;
    }
}