
namespace Console
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            DockerManager.DockerInfo dockerInfo = new DockerManager.DockerInfo("prueba", "c:\\windows");
            DockerManager.DockerManager manager = new DockerManager.DockerManager(dockerInfo);
            var result = await manager.BuildContainerAsync();
            System.Console.WriteLine(result);
        }
    }
}
