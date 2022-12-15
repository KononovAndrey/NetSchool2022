namespace DSRNetSchool.Common;

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

public static class StringExtension
{
    public static bool IsNullOrEmpty(this string data)
    {
        return string.IsNullOrEmpty(data);
    }

    public static bool IsNullOrWhiteSpace(this string data)
    {
        return string.IsNullOrWhiteSpace(data);
    }

    public static string ToTitleCase(this string text)
    {
        if (text == null)
            return null;

        var textInfo = new CultureInfo("en-US", false).TextInfo;
        text = textInfo.ToTitleCase(text.ToLower());
        return text;
    }

    public static string ToCamelCase(this string str)
    {
        return JsonNamingPolicy.CamelCase.ConvertName(str);
    }

    public static IEnumerable<string> ToSplit(this string str, int chunkSize)
    {
        if (string.IsNullOrEmpty(str))
            return new List<string>();

        if (str.Length < chunkSize)
            return new List<string>
            {
                str
            };

        return Enumerable.Range(0, str.Length / chunkSize)
            .Select(i => str.Substring(i * chunkSize, chunkSize));
    }

    public static string SquashWhiteSpaces(this string str)
    {
        str = str.Trim();
        return Regex.Replace(str, @"\s+", " ");
    }
}