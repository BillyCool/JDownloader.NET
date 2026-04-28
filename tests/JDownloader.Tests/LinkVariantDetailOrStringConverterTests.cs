using System.Text.Json;
using JDownloader.Model;
using Xunit;

namespace JDownloader.Tests;

public class LinkVariantDetailOrStringConverterTests
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web);

    [Fact]
    public void Deserialize_StringValue_UsesRawString()
    {
        const string json = "{\"iconKey\":\"icon\",\"id\":\"variant-id\",\"name\":\"Variant\"}";

        LinkVariant? result = JsonSerializer.Deserialize<LinkVariant>(json, SerializerOptions);

        Assert.NotNull(result);
        Assert.True(result.Id.IsString);
        Assert.Equal("variant-id", result.Id.Raw);
        Assert.Equal("variant-id", result.Id.ToString());
    }

    [Fact]
    public void Deserialize_ObjectValue_UsesDetail()
    {
        const string json = "{\"iconKey\":\"icon\",\"id\":{\"id\":\"variant-id\",\"data\":{\"height\":1080}},\"name\":\"Variant\"}";

        LinkVariant? result = JsonSerializer.Deserialize<LinkVariant>(json, SerializerOptions);

        Assert.NotNull(result);
        Assert.True(result.Id.IsObject);
        Assert.Equal("variant-id", result.Id.Detail.Id);
        Assert.Equal(1080, result.Id.Detail.Data.Height);
    }

    [Fact]
    public void Deserialize_UnsupportedToken_FallsBackToRawJson()
    {
        const string json = "{\"iconKey\":\"icon\",\"id\":[1,2,3],\"name\":\"Variant\"}";

        LinkVariant? result = JsonSerializer.Deserialize<LinkVariant>(json, SerializerOptions);

        Assert.NotNull(result);
        Assert.True(result.Id.IsString);
        Assert.Equal("[1,2,3]", result.Id.Raw);
    }

    [Fact]
    public void Serialize_ObjectValue_WritesObjectPayload()
    {
        LinkVariant variant = new()
        {
            IconKey = "icon",
            Name = "Variant",
            Id = new LinkVariantDetailOrString(new LinkVariantDetail
            {
                Id = "variant-id",
                Data = new LinkVariantId
                {
                    Height = 720
                }
            })
        };

        string json = JsonSerializer.Serialize(variant, SerializerOptions);

        Assert.Contains("\"id\":{\"id\":\"variant-id\"", json);
        Assert.Contains("\"height\":720", json);
    }
}
