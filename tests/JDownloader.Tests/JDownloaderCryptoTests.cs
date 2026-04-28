using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace JDownloader.Tests;

public class JDownloaderCryptoTests
{
    [Fact]
    public async Task EncryptAndDecrypt_RoundTripPayload()
    {
        byte[] key = [.. Enumerable.Range(1, 32).Select(static value => (byte)value)];
        const string payload = "{\"message\":\"hello\"}";

        string encrypted = await JDownloaderCrypto.Encrypt(payload, key);
        string decrypted = await JDownloaderCrypto.Decrypt(encrypted, key);

        Assert.Equal(payload, decrypted);
    }

    [Fact]
    public void GetSecret_NormalizesEmailCase()
    {
        byte[] upper = JDownloaderCrypto.GetSecret("USER@EXAMPLE.COM", "password", "server");
        byte[] lower = JDownloaderCrypto.GetSecret("user@example.com", "password", "server");

        Assert.Equal(lower, upper);
    }

    [Fact]
    public void GetSignature_MatchesHmacSha256()
    {
        byte[] key = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        const string data = "/my/connect?email=user%40example.com&appkey=test";

        string signature = JDownloaderCrypto.GetSignature(data, key);

        using HMACSHA256 hmac = new(key);
        string expected = Convert.ToHexStringLower(hmac.ComputeHash(Encoding.UTF8.GetBytes(data)));

        Assert.Equal(expected, signature);
    }

    [Fact]
    public void GetEncryptionToken_DerivesStableHash()
    {
        byte[] secret = Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        byte[] token = JDownloaderCrypto.GetEncryptionToken(secret, "00112233445566778899aabbccddeeff");

        Assert.Equal(32, token.Length);
        Assert.Equal(token, JDownloaderCrypto.GetEncryptionToken(secret, "00112233445566778899aabbccddeeff"));
    }
}
