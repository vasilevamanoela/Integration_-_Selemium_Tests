using ExamPreparation.IntegrationTests.Models;
using NUnit.Framework;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation.IntegrationTests
{
    [TestFixture]
    public class AuthorTests
    {
        private HttpClient _httpClient;
        private Author author;

        [SetUp]
        public void SetUp()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://libraryjuly.azurewebsites.net");
        }

        [Test]
        public async Task ReceivedOkStatusCode_When_CreatAuthor()
        {
            author = new Author();
            author.FirstName = "Gosho";
            author.LastName = "Goshov";
            author.Genre = "male";

            var json = author.ToJson();

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/authors", content);
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            var actualAuthor = Author.FromJson(responseAsString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Created);

            var expectedAuthor = new Author()
            {
                Name = $"{author.FirstName} {author.LastName}",
                Genre = author.Genre
            };

            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre);
        }

        [Test]
        public async Task ReceivedBadRequestStatusCode_When_CreateAuthorWithInvalidBody()
        {
            author = new Author();
            author.FirstName = "Goshoko";
            author.LastName = "Goshkov";
            author.DateOfBirth = "Invalid Date";
            author.Genre = "male";

            var json = author.ToJson();

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/authors", content);

            var responseAsString = await response.Content.ReadAsStringAsync();

            author = Author.FromJson(responseAsString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task ReceivedBadRequestStatusCode_When_CreateAuthorWithXML()
        {
            author = new Author();
            author.FirstName = "Goshoko";
            author.LastName = "Goshkov";
            author.Genre = "male";

            var json = author.ToJson();

            var content = new StringContent(json, Encoding.UTF8, "application/xml");

            var response = await _httpClient.PostAsync("/api/authors", content);

            var responseAsString = await response.Content.ReadAsStringAsync();

            author = Author.FromJson(responseAsString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task ReceivedNotFoundStatusCode_When_CreateAuthorWithInvalidURL()
        {
            author = new Author();
            author.FirstName = "Goshoko";
            author.LastName = "Goshkov";
            author.Genre = "male";

            var json = author.ToJson();

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/author", content);

            var responseAsString = await response.Content.ReadAsStringAsync();

            author = Author.FromJson(responseAsString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }

        [Test]
        public async Task ReceivedOkStatusCode_When_GetAuthor()
        {
            var authorId = "c9dcba08-4cbd-4abb-984b-57f984f16b28";

            var response = await _httpClient.GetAsync($"/api/authors/{authorId}");
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            var actualAuthor = Author.FromJson(responseAsString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);

            var expectedAuthor = new Author()
            {
                Name = "Gosho Goshov",
                Genre = "male"
            };

            Assert.AreEqual(expectedAuthor.Name, actualAuthor.Name);
            Assert.AreEqual(expectedAuthor.Genre, actualAuthor.Genre);
        }


        [Test]
        public async Task ReceivedNotFoundStatusCode_When_GetAuthorWithInvalidAuthorId()
        {
            var authorId = new Guid();

            var response = await _httpClient.GetAsync($"/api/authors/{authorId}");

            var responseAsString = await response.Content.ReadAsStringAsync();

            author = Author.FromJson(responseAsString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }

        [Test]
        public async Task ReceivedNotFoundStatusCode_When_GetAuthorWithInvalidURL()
        {
            var authorId = "d356016b-7d7e-48b0-aea4-5e19d86c3e7d";

            var response = await _httpClient.GetAsync($"/api/author/{authorId}");

            var responseAsString = await response.Content.ReadAsStringAsync();

            author = Author.FromJson(responseAsString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }
    }
}
