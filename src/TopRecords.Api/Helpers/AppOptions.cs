namespace TopRecords.Api.Helpers;

public sealed class AppOptions
{
    public const string SectionName = "app";
    public string Url { get; init; } = default!;
}