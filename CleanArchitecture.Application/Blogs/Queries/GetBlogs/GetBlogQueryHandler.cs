using AutoMapper;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogs;

public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVM>>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;
    
    public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }
    public async Task<List<BlogVM>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _blogRepository.GetAllBlogsAsync();
        //var blogList = blogs.Select(b => new BlogVM { Author = b.Author, Name = b.Name, Description = b.Description, Id = b.Id }).ToList();

        var blogList = _mapper.Map<List<BlogVM>>(blogs);
        return blogList;
    }
}