//using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

using System.Net.Http.Json;

namespace AnalyseText.Tests
{
    public class TextAnalysisApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TextAnalysisApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("Analyse Text", 2)]
        public async Task CountWords_ReturnsCorrectCount(string input, int expectedCount)
        {
            var response = await _client.GetAsync($"/count-words?input={input}");
            response.EnsureSuccessStatusCode();
            var count = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedCount.ToString(), count);
        }

        [Theory]
        [InlineData("Analyse Text", new[] { "Text" }, true)]
        [InlineData("Analyse Text", new[] { "test" }, false)]
        public async Task ContainsWords_ReturnsCorrectBoolean(string input, string[] words, bool expected)
        {
            var response = await _client.GetAsync($"/contains-words?input={input}&words={string.Join(",", words)}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected.ToString().ToLower(), result);
        }

        [Theory]
        [InlineData("Analyse Text", 11)]
        public async Task CountLetters_ReturnsCorrectCount(string input, int expectedCount)
        {
            var response = await _client.GetAsync($"/count-letters?input={input}");
            response.EnsureSuccessStatusCode();
            var count = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedCount.ToString(), count);
        }

        [Theory]
        [InlineData("Analyse Text", new[] { 'L', 'e' }, true)]
        [InlineData("Analyse Text", new[] { 'z', 'y' }, false)]
        public async Task ContainsLetters_ReturnsCorrectBoolean(string input, char[] letters, bool expected)
        {
            var response = await _client.GetAsync($"/contains-letters?input={input}&letters={string.Join(",", letters)}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected.ToString().ToLower(), result);
        }

        [Theory]
        [InlineData("SGVsbG8gV29ybGQ=", true)]
        [InlineData("NotBase64", false)]
        public async Task IsBase64_ReturnsCorrectBoolean(string input, bool expected)
        {
            var response = await _client.GetAsync($"/is-base64?input={input}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected.ToString().ToLower(), result);
        }

        [Theory]
        [InlineData("analyse@example.com", true)]
        [InlineData("invalid-email", false)]
        public async Task IsValidEmail_ReturnsCorrectBoolean(string email, bool expected)
        {
            var response = await _client.GetAsync($"/is-valid-email?email={email}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.Equal(expected.ToString().ToLower(), result);
        }
    }
}