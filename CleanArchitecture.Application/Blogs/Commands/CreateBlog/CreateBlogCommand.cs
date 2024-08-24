using CleanArchitecture.Application.Blogs.Queries.GetBlogs;
using MediatR;

namespace CleanArchitecture.Application.Blogs.Commands.CreateBlog;

public class CreateBlogCommand : IRequest<BlogVM>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
}