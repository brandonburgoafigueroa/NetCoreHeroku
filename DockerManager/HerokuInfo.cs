using System;
using System.Collections.Generic;
using System.Text;

namespace DockerManager
{
    class HerokuInfo
    {
        public string ApplicationName { get; set; }
        public string UserName { set; get; }
        private string RepositoryRoute { set; get; }
        public HerokuInfo(string ApplicationName)
        {
            this.ApplicationName = ApplicationName;
            RepositoryRoute= $"registry.heroku.com/{ApplicationName}/web";
        }
    }
}
