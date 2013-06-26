using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.LightSwitch;

namespace LightSwitchApplication
{
    public class BlogController : ApiController
    {
        public IEnumerable<BlogPost> Get()
        {
            return GetAllPosts();
        }
        
        public dynamic Get(string type)
        {
            var position = -1;
            if (Int32.TryParse(type, out position))
            {
                return GetBlogPostsAtPosition(position);
            }
            else
            {
                switch (type.ToUpperInvariant())
                {
                    case "COUNT":
                        {
                            return GetCount();
                        }
                    default:
                        {
                            return GetAllPosts();
                        }
                }
            }
        }

        private int GetCount()
        {
            using (var serverContext = ServerApplicationContext.CreateContext())
            {
                return serverContext.DataWorkspace.ApplicationData.PublishedBlogPosts().Execute().Count();
            }
        }

        private BlogPost GetBlogPostsAtPosition(int position)
        {
            using (var serverContext = ServerApplicationContext.CreateContext())
            {
                var posts = serverContext.DataWorkspace.ApplicationData.PublishedBlogPosts().Execute();
                if (position < posts.Count())
                {
                    var p = posts.Skip(position).First();
                    return new BlogPost()
                    {
                        Author = p.Author,
                        Body = p.Body,
                        Id = p.Id,
                        PublishedDateTime = p.PublishedDateTime,
                        Title = p.Title,
                    };
                }
                else
                {
                    throw new Exception("No such position");
                }
            }
        }

        private IEnumerable<BlogPost> GetAllPosts()
        {
            using (var serverContext = ServerApplicationContext.CreateContext())
            {
                var posts = serverContext.DataWorkspace.ApplicationData.PublishedBlogPosts().Execute();

                return posts.Select(_ => new BlogPost()
                {
                    Author = _.Author,
                    Body = _.Body,
                    Id = _.Id,
                    PublishedDateTime = _.PublishedDateTime,
                    Title = _.Title,
                });
            }
        }
    }
}