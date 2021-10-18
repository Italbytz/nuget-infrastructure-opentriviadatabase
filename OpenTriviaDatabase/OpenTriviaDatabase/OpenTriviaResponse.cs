using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenTriviaDatabase
{
    public partial class OpenTriviaResponse
    {
        [JsonPropertyName("response_code")]
        public long ResponseCode { get; set; }

        [JsonPropertyName("results")]
        public List<Question> Results { get; set; }
    }

    public partial class Question
    {
        [JsonPropertyName("category")]
        public Category Category { get; set; }

        [JsonPropertyName("type")]
        public TypeEnum Type { get; set; }

        [JsonPropertyName("difficulty")]
        public Difficulty Difficulty { get; set; }

        [JsonPropertyName("question")]
        public string Text { get; set; }

        [JsonPropertyName("correct_answer")]
        public string CorrectAnswer { get; set; }

        [JsonPropertyName("incorrect_answers")]
        public List<string> IncorrectAnswers { get; set; }
    }

    public enum Difficulty { Any, Easy, Hard, Medium };

    public enum TypeEnum { Any, Boolean, Multiple };

    public enum Category
    {
        Any = 0,
        [EnumMember(Value = "General Knowledge")]
        GeneralKnowledge = 9,
        [EnumMember(Value = "Entertainment: Books")]
        EntertainmentBooks = 10,
        [EnumMember(Value = "Entertainment: Film")]
        EntertainmentFilm = 11,
        [EnumMember(Value = "Entertainment: Music")]
        EntertainmentMusic = 12,
        [EnumMember(Value = "Entertainment: Musicals & Theatres")]
        EntertainmentMusicalsTheatres = 13,
        [EnumMember(Value = "Entertainment: Television")]
        EntertainmentTelevision = 14,
        [EnumMember(Value = "Entertainment: Video Games")]
        EntertainmentVideoGames = 15,
        [EnumMember(Value = "Entertainment: Board Games")]
        EntertainmentBoardGames = 16,
        [EnumMember(Value = "Science & Nature")]
        ScienceAndNature = 17,
        [EnumMember(Value = "Science: Computers")]
        ScienceComputers = 18,
        [EnumMember(Value = "Science: Mathematics")]
        ScienceMathematics = 19,
        [EnumMember(Value = "Mythology")]
        Mythology = 20,
        [EnumMember(Value = "Sports")]
        Sports = 21,
        [EnumMember(Value = "Geography")]
        Geography = 22,
        [EnumMember(Value = "History")]
        History = 23,
        [EnumMember(Value = "Politics")]
        Politics = 24,
        [EnumMember(Value = "Art")]
        Art = 25,
        [EnumMember(Value = "Celebrities")]
        Celebrities = 26,
        [EnumMember(Value = "Animals")]
        Animals = 27,
        [EnumMember(Value = "Vehicles")]
        Vehicles = 28,
        [EnumMember(Value = "Entertainment: Comics")]
        EntertainmentComics = 29,
        [EnumMember(Value = "Science: Gadgets")]
        ScienceGadgets = 30,
        [EnumMember(Value = "Entertainment: Japanese Anime & Manga")]
        EntertainmentJapaneseAnimeAndManga = 31,
        [EnumMember(Value = "Entertainment: Cartoon & Animations")]
        EntertainmentCartoonAndAnimations = 32,

    };

    internal static class Converter
    {
        public static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            Converters ={
        new JsonStringEnumMemberConverter()
    }
        };
    }

}
