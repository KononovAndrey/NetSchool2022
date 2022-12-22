namespace DSRNetSchool.Identity.Configuration;

using Duende.IdentityServer.Test;

public static class AppApiTestUsers
{
    public static List<TestUser> ApiUsers =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "alice@tst.com",
                Password = "password"
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "bob@tst.com",
                Password = "password"
            }
        };
}