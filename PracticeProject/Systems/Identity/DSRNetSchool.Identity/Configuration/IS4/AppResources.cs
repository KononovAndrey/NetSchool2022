namespace DSRNetSchool.Identity.Configuration;

using Duende.IdentityServer.Models;

public static class AppResources
{
    public static IEnumerable<ApiResource> Resources => new List<ApiResource>
    {
        new ApiResource("api")
    };
}
