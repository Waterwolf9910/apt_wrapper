// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Timers;

var run = () => {
    Console.WriteLine("Starting APT");
    using (var process = new Process()) {
        var info = new ProcessStartInfo("/bin/bash", "-c \"apt update -y >> /apt_wrapper.log && apt upgrade -y >> /apt_wrapper.log\"");
        info.UseShellExecute = false;
        // info.RedirectStandardError = true;
        // info.RedirectStandardInput = true;
        // info.WorkingDirectory="/";
        // process.OutputDataReceived
        process.StartInfo = info;
        process.Start();
        
        process.WaitForExit();
    }

    Console.WriteLine("Done");
};

File.WriteAllText("/apt_wrapper.pid", $"{Environment.ProcessId}");
run();

var stopper = new CancellationTokenSource();

Thread thread = new(() => {
    while (!stopper.Token.IsCancellationRequested) {

    }
});
thread.IsBackground = false;
thread.Start();

System.Timers.Timer timer = new();
timer.Elapsed += (a, b) => {
    run();
    // stopper.Cancel();
};
timer.AutoReset = true;
timer.Enabled = true;
// timer.Interval = 1000 * 30;
timer.Interval = 1000 * 60 * 60 * 12;
