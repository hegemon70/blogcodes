using System;
using System.Collections.Generic;

namespace CompositeEF_Sitemap
{
    public class AppSiteMap
    {
        public AppSiteMap()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public string Lang { get; set; }

        public string Href { get; set; }

        public string DisplayText { get; set; }

        public string Roles { get; set; }

        public int Order { get; set; }

        public virtual ICollection<AppSiteMap> Childs { get; set; }

        public virtual  AppSiteMap Parent { get; set; }
    }
}
