using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Vercel.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class VercelOpenApiClientTests : FixturedUnitTest
{
    public VercelOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
