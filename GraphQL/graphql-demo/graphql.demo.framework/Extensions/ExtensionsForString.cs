namespace graphql.demo.framework.Extensions;

public static class ExtensionsForString
{
    public static bool IsNullEmptyOrWhiteSpace(this string? value)
    {
        return string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value);
    }
}