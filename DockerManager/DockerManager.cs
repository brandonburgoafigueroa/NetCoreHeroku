using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DockerManager
{
    public class DockerManager
    {
        public DockerInfo DockerInfo { get; set; }
        public DockerManager(DockerInfo dockerInfo)
        {
            DockerInfo = dockerInfo;
        }
        public async Task<string> BuildContainerAsync()
        {
            return await Task.Run(async () => {
                var respond = "";
                var result = await ProcessManager.RunProcessAsync("docker", $"build -t {DockerInfo.ImageName} {DockerInfo.Directory}");
                if (result == Result.Is_Success) { 
                    result = await ProcessManager.RunProcessAsync("docker", $"tag {DockerInfo.ImageName} registry.heroku.com/{DockerInfo.ImageName}/web");
                    if (result == Result.Is_Success)
                    {
                        respond = "Listo";
                    }
                    else
                    {
                        respond = "No se pudo crear el tag.";
                    }
                }
                else
                {
                    respond = "No se pudo compilar la imagen. \nVerifique la ruta o el nombre de la imagen";
                }
                return respond;
            });
        }
        
    }
    public enum Result
    {
        Is_Success, Is_Failed,
    }
}
