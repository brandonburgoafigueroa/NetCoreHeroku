using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DockerManager
{
    public class ProcessManager
    {
        public static Task<Result> RunProcessAsync(string processPath, string arguments = "")
        {
            var tcs = new TaskCompletionSource<Result>();
            var process = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo(processPath, arguments)
                {
                    RedirectStandardError = true,
                    UseShellExecute = false
                }
            };
            process.Exited += (sender, args) =>
            {
                if (process.ExitCode != 0)
                {
                    tcs.SetResult(Result.Is_Failed);
                }
                else
                {
                    tcs.SetResult(Result.Is_Success);
                }
                process.Dispose();
            };
            process.Start();
            return tcs.Task;
        }
    }
}
