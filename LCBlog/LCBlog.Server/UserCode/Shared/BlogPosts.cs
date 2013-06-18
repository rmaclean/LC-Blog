using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LightSwitch;
namespace LightSwitchApplication
{
    public partial class BlogPosts
    {
        partial void BlogPosts_Created()
        {
            this.IsDraft = true;
        }
    }
}
