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
    public class Library
    {
        private HttpClient _httpsClient;
        private Book book;

        [SetUp]
        public void SetUp()
        {
            _httpsClient = new HttpClient();
            _httpsClient.BaseAddress = new Uri("http://localhost:3000");
            _httpsClient.DefaultRequestHeaders.Add("G-Token", "ROM831ESV");
        }

        [Test]
        public async Task ReceivedOKStatusCode_When_CreateNewBook()
        {
            book = new Book() { Title = "Test Book" };

            var json = book.ToJson();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpsClient.PostAsync("/books", content);

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            book = Book.FromJson(responseAsString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public async Task ReceivedInternalServerErrorStatusCode_When_CreateNewBookWithXML()
        {
            book = new Book() { Title = "Test Book" };

            var json = book.ToJson();
            var content = new StringContent(json, Encoding.UTF8, "application/xml");

            var response = await _httpsClient.PostAsync("/books", content);

            var responseAsString = await response.Content.ReadAsStringAsync();
            book = Book.FromJson(responseAsString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.InternalServerError);
        }

        [Test]
        public async Task ReceivedUnauthorizedStatusCode_When_CreateNewBookWithInvalidURL()
        {
            book = new Book() { Title = "Test Book" };

            var json = book.ToJson();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpsClient.PostAsync("/book", content);

            var responseAsString = await response.Content.ReadAsStringAsync();
            book = Book.FromJson(responseAsString);

            Assert.IsTrue(response.StatusCode == HttpStatusCode.Unauthorized);
        }

        [Test]
        public async Task ReceiveOKStatusCode_When_GetBooks()
        {
            var response = await _httpsClient.GetAsync("/books");

            response.EnsureSuccessStatusCode();

            var resonseAsString = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public async Task ReceivedNotFoundStatusCode_When_GetBooksWithInvalidURL()
        {
            var response = await _httpsClient.GetAsync("/book");

            var resonseAsString = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(response.StatusCode == HttpStatusCode.NotFound);
        }
    }
}



