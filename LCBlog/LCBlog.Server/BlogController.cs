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