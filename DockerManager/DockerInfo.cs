using System;
using System.Collections.Generic;
using System.Text;

namespace DockerManager
{
    public class DockerInfo
    {
        public string ImageName { get; set; }
        public string Directory { set; get; }
        public DockerInfo(string ImageName, string Directory)
        {
            this.ImageName = ImageName;
            this.Directory = Directory;
        }
    }
}
