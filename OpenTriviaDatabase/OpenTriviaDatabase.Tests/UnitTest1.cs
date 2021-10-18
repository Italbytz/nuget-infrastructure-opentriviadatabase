using System.Threading.Tasks;
using NUnit.Framework;

namespace OpenTriviaDatabase.Tests
{
    public class Tests
    {
        OpenTriviaAPI api;

        [SetUp]
        public void Setup()
        {
            api = new OpenTriviaAPI();
        }

        [Test]
        public async Task TestRetrieveSessionToken()
        {
            var token = await api.RetrieveSessionToken();
            Assert.AreEqual(0, token.ResponseCode);
        }

        [Test]
        public async Task TestRetrieveQuestions()
        {
            var response = await api.RetrieveQuestions();
            Assert.AreEqual(10, response.Count);
        }

        [Test]
        public async Task TestRetrieveQuestionsFixedCategory()
        {
            var response = await api.RetrieveQuestions(category: Category.GeneralKnowledge);
            Assert.AreEqual(10, response.Count);
        }

    }
}
