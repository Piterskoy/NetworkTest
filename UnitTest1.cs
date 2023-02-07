using System.Text;
using CliWrap;
using Xunit.Abstractions;

namespace Network.Test;

public class UnitTest1
{
    private readonly ITestOutputHelper output;

    public UnitTest1(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public async Task Test1()
    {
        var method = await GetIp4Method("Wired connection 1");
        output.WriteLine($"method={method}");
    }

    public async Task<string> GetIp4Method(string connection)
    {
        var stdOutBuffer = new StringBuilder();
        var result = await Cli.Wrap("sudo")
        .WithArguments($"nmcli -f ipv4.method con show '{connection}'")
        .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
        .ExecuteAsync();

        return stdOutBuffer.ToString();
    }
    
}