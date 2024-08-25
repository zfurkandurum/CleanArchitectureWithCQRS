using System.Reflection.Metadata;
using AutoMapper;
using CleanArchitecture.Domain.Entity;
using CleanArchitecture.Domain.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Commands.UpdateBlog;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
{
    private readonly IBlogRepository _blogRepository;

    public UpdateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
    
    public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var updateBlogEntity = new Blog() 
            {
                Id = request.Id, 
                Description = request.Description, 
                Name = request.Name, 
                Author = request.Author
                
            };
        return await _blogRepository.UpdateAsync(request.Id, updateBlogEntity);

      
    }
}