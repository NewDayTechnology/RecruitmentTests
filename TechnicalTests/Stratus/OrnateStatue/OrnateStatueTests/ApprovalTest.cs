using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text;

namespace OrnateStatueTests;

public class ApprovalTest
{
    [Fact]
    public Task ThirtyDays()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));

        Program.Main(["30"]);
        var output = fakeoutput.ToString();

        return Verify(output);
    }

    [Fact(Skip = "Not yet implemented")]
    public Task ThirtyDaysV2()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));

        Program.Main(["30"]);
        var output = fakeoutput.ToString();

        return Verify(output);
    }
}
