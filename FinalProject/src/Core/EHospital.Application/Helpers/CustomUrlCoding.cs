using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace EHospital.Application.Helpers;

public static class CustomUrlCoding
{
    public static string UrlEncoding(this string value)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        string encodeValue = WebEncoders.Base64UrlEncode(bytes);
        return encodeValue;
    }

    public static string UrlDecoding(this string value)
    {
        byte[] bytes = WebEncoders.Base64UrlDecode(value);
        string decodeValue = Encoding.UTF8.GetString(bytes);
        return decodeValue;
    }
}
