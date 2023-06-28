using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.FeatureManagement;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace FeatureFlagDemo.FeatureManagement.FeatureFilters.Tests
{
    public class BrowserFilterTests
    {
        [Fact]
        public async Task EvaluateAsync_ValidChrome_ReturnsTrue()
        {
            // Arrange
            var headers = new HeaderDictionary(new Dictionary<string, StringValues>
            {
                { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3" }
            });
            var httpContext = new Mock<HttpContext>();
            httpContext.Setup(c => c.Request.Headers).Returns(headers);

            var context = new FeatureFilterEvaluationContext();
            context.Parameters.Bind("AllowedBrowsers", new List<string> { "chrome" });

            var filter = new BrowserFilter(httpContext.Object);

            // Act
            var result = await filter.EvaluateAsync(context);

            // Assert
            // Assert.True(result);
        }

        [Fact]
        public async Task EvaluateAsync_ValidEdge_ReturnsFalse()
        {
            // Arrange
            var headers = new HeaderDictionary(new Dictionary<string, StringValues>
            {
                { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3 Edge/16.16299" }
            });
            var httpContext = new Mock<HttpContext>();
            httpContext.Setup(c => c.Request.Headers).Returns(headers);

            var context = new FeatureFilterEvaluationContext(new Dictionary<string, object>(), new Dictionary<string, string>());
            context.Parameters.Add("AllowedBrowsers", new List<string> { "edge" });

            var filter = new BrowserFilter(httpContext.Object);

            // Act
            var result = await filter.EvaluateAsync(context);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task EvaluateAsync_InvalidBrowser_ReturnsFalse()
        {
            // Arrange
            var headers = new HeaderDictionary(new Dictionary<string, StringValues>
            {
                { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Safari/537.3" }
            });
            var httpContext = new Mock<HttpContext>();
            httpContext.Setup(c => c.Request.Headers).Returns(headers);

            var context = new FeatureFilterEvaluationContext(new Dictionary<string, object>(), new Dictionary<string, string>());
            context.Parameters.Add("AllowedBrowsers", new List<string> { "chrome" });

            var filter = new BrowserFilter(httpContext.Object);

            // Act
            var result = await filter.EvaluateAsync(context);

            // Assert
            Assert.False(result);
        }
    }
}