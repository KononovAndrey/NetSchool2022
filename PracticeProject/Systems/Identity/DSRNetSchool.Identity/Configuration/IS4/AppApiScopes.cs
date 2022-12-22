namespace DSRNetSchool.Identity.Configuration;

using DSRNetSchool.Common.Security;
using Duende.IdentityServer.Models;

public static class AppApiScopes
{
    public static IEnumerable<ApiScope> ApiScopes =>
        new List<ApiScope>
        {
            new ApiScope(AppScopes.BooksRead, "Access to books API - Read data"),
            new ApiScope(AppScopes.BooksWrite, "Access to books API - Write data")
        };
}