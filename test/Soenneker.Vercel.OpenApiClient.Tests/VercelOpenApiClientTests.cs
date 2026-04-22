using Soenneker.Tests.HostedUnit;

namespace Soenneker.Vercel.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class VercelOpenApiClientTests : HostedUnitTest
{
    public VercelOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
