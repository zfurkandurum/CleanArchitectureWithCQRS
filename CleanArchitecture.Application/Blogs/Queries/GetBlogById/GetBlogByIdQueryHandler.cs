using AutoMapper;
using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogById;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogVM>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;
    
    public GetBlogByIdQueryHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }
    
    public async Task<BlogVM> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    { 
        var blog = await _blogRepository.GetByIdAsync(request.BlogId);
        return _mapper.Map<BlogVM>(blog);
    }
}