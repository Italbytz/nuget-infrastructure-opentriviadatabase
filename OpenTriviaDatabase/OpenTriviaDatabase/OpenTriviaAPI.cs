using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OpenTriviaDatabase
{
    public class OpenTriviaAPI
    {
        private const string MediaTypeJSON = "application/json";

        private static readonly HttpClient HttpClient;

        static OpenTriviaAPI()
        {
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://opentdb.com/")
            };
            var media = new MediaTypeWithQualityHeaderValue(MediaTypeJSON);
            HttpClient.DefaultRequestHeaders.Accept.Add(media);
        }

        public async Task<TokenResponse> RetrieveSessionToken()
        {
            return await HttpClient.GetFromJsonAsync<TokenResponse>("/api_token.php?command=request");
        }

        public async Task<List<Question>> RetrieveQuestions(int amount = 10,
            Category category = Category.Any,
            Difficulty difficulty = Difficulty.Any,
            TypeEnum type = TypeEnum.Any)
        {
            var categoryParameter = category == Category.Any ? "" : $"&category={Convert.ToInt32(category)}";
            var difficultyParameter = difficulty switch
            {
                Difficulty.Any => "",
                Difficulty.Easy => "&difficulty=easy",
                Difficulty.Medium => "&difficulty=medium",
                Difficulty.Hard => "&difficulty=hard",
                _ => "",
            };
            var typeParameter = type switch
            {
                TypeEnum.Any => "",
                TypeEnum.Boolean => "&type=boolean",
                TypeEnum.Multiple => "&type=multiple",
                _ => "",
            };
            var response = await HttpClient.GetFromJsonAsync<OpenTriviaResponse>($"/api.php?amount={amount}{categoryParameter}{difficultyParameter}{typeParameter}", Converter.Options);
            var questions = response.Results.Select(FormatQuestion).ToList();
            return questions;
        }

        private Question FormatQuestion(Question question)
        {
            question.CorrectAnswer = WebUtility.HtmlDecode(question.CorrectAnswer);
            question.Text = WebUtility.HtmlDecode(question.Text);
            question.IncorrectAnswers = question.IncorrectAnswers.Select(answer => WebUtility.HtmlDecode(answer)).ToList();
            return question;
        }

    }
}
