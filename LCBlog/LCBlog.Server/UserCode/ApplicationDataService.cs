using System;
namespace LightSwitchApplication
{
    public partial class ApplicationDataService
    {
        partial void BlogPostsSet_Inserting(BlogPosts entity)
        {
            SetPublishedDate(entity);
        }

        private static void SetPublishedDate(BlogPosts entity)
        {
            if (!entity.IsDraft && !entity.PublishedDateTime.HasValue)
            {
                entity.PublishedDateTime = DateTime.UtcNow;
            }
        }

        partial void BlogPostsSet_Updating(BlogPosts entity)
        {
            SetPublishedDate(entity);
        }

        partial void CommentsSet_Inserting(Comments entity)
        {
            entity.CreatedDateTime = DateTime.UtcNow;
        }
    }
}
