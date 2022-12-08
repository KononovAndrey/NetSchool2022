namespace DSRNetSchool.Common;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

public static class ObjectJsonExtension
{
    public static JsonSerializerSettings SetDefaultSettings(this JsonSerializerSettings settings)
    {
        settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        settings.Converters.Add(new JsonTrimmingConverter());
        settings.Converters.Add(new StringEnumConverter(camelCaseText: true));

        return settings;
    }

    public static JsonSerializerSettings DefaultJsonSerializerSettings()
    {
        return new JsonSerializerSettings().SetDefaultSettings();
    }

    /// <summary>
    /// Serialize object to JSON string
    /// </summary>
    public static string ToJsonString(this object obj, JsonSerializerSettings? settings = null)
    {
        try
        {
            return JsonConvert.SerializeObject(obj, settings ?? DefaultJsonSerializerSettings());
        }
        catch (Exception ex)
        {
            throw new JsonException("Failed to convert to json string", ex);
        }
    }

    /// <summary>
    /// Deserialize object from JSON string
    /// </summary>
    public static T? FromJsonString<T>(this string obj, JsonSerializerSettings? settings = null)
    {
        return JsonConvert.DeserializeObject<T>(obj, settings ?? DefaultJsonSerializerSettings());
    }

    /// <summary>
    /// Deserialize object from JSON string
    /// </summary>
    public static object? FromJsonString(this string obj, JsonSerializerSettings? settings = null)
    {
        return JsonConvert.DeserializeObject(obj, typeof(object), settings ?? DefaultJsonSerializerSettings());
    }

    /// <summary>
    /// Try deserialize object from JSON string
    /// </summary>
    public static bool TryFromJsonString<T>(this string obj, out T? result)
    {
        try
        {
            result = JsonConvert.DeserializeObject<T>(obj);
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }
}
