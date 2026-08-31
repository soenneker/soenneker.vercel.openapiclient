[![](https://img.shields.io/nuget/v/soenneker.vercel.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.vercel.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.vercel.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.vercel.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.vercel.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.vercel.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.vercel.openapiclient/codeql.yml?style=for-the-badge&label=CodeQL)](https://github.com/soenneker/soenneker.vercel.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Vercel.OpenApiClient

A Kiota-generated client for Vercel deployments, projects, domains, teams, storage, and other REST API resources.

## Installation

```bash
dotnet add package Soenneker.Vercel.OpenApiClient
```

## Usage

Create a Kiota adapter with a Vercel access token:

```csharp
using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Vercel.OpenApiClient;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://api.vercel.com/")
};

httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", accessToken);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new VercelOpenApiClient(adapter);
```

For example, retrieve the file tree for a deployment:

```csharp
var files = await client.V6
    .Deployments[deploymentId]
    .Files
    .GetAsync(
        request => request.QueryParameters.TeamId = teamId,
        cancellationToken);
```

Omit `TeamId` for resources in the token owner's personal account. For team resources, pass the owning team ID and use a token scoped to that team.

The caller owns the request adapter and `HttpClient`. API failures are thrown through Kiota's normal exception handling. For configuration-based authentication, caching, and service registration, use `Soenneker.Vercel.OpenApiClientUtil`.
