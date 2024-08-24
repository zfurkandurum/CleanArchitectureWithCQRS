using MediatR;

namespace CleanArchitecture.Application.Blogs.Queries.GetBlogs;

public class GetBlogQuery : IRequest<List<BlogVM>>
{
    
};
