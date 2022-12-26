namespace DSRNetSchool.Common.Extensions;

using System;

public static class GuidExtension
{
    public static string Shrink(this Guid guid)
    {
        return guid.ToString().Replace("-", "").Replace(" ", "");
    }
}
