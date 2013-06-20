using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.LightSwitch;

namespace LightSwitchApplication
{
    public class BlogController : ApiController
    {
        public IEnumerable<BlogPosts> Get()
        {
            using (var serverContext = ServerApplicationContext.CreateContext())
            {
                var posts = serverContext.DataWorkspace.ApplicationData.BlogPostsSet.GetQuery().Execute();
                var result = (from p in posts
                              where p.IsDraft == false
                              select p).ToArray();

                return result;
            }
        }
    }
}