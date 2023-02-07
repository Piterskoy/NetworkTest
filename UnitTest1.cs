using System.Text;
using CliWrap;

namespace Network.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {

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