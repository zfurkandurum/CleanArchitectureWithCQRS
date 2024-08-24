using AutoMapper;
using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Commands.CreateBlog;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVM>
{
    private readonly IBlogRepository _blogRepository;
    private readonly IMapper _mapper;
    
    public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
    {
        _blogRepository = blogRepository;
        _mapper = mapper;
    }
    
    public async Task<BlogVM> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blogEntity = new Blog() { Name = request.Name, Author = request.Author, Description = request.Description };
        var result = await _blogRepository.CreateAsync(blogEntity);
        return _mapper.Map<BlogVM>(result);
    }
}