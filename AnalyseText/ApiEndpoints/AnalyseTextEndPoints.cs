using AnalyseText.Services;
using AnalyseText.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace AnalyseText.ApiEndpoints
{
    public static class AnalyseTextEndPoints
    {

        public static void MapAnalyseTextEndPoints(this WebApplication app)
        {
            TextAnalyseService _textAnalyseService = new TextAnalyseService();

            app.MapGet("/count-words", (string input) =>
            {
                input = input.ToLower();
                string error = ErrorServices.InputValid(input);
                if (!string.IsNullOrEmpty(error))
                    return Results.BadRequest(error);


                int count = _textAnalyseService.CountWords(input);
                return Results.Ok(count);
            });

            app.MapGet("/contains-words", (string input , string[] words) =>
            {
                input = input.ToLower();
                words = StringUtilities.Correction(words);
                string error = ErrorServices.InputAndWordsValid(input , words);
                if (!string.IsNullOrEmpty(error))
                    return Results.BadRequest(error);

                bool contains = _textAnalyseService.ContainWords(input , words);
                return Results.Ok(contains);
            });

            app.MapGet("/count-letters", (string input) =>
            {
                input = input.ToLower();
                string error = ErrorServices.InputValid(input);
                if (!string.IsNullOrEmpty(error))
                    return Results.BadRequest(error);

                int count = _textAnalyseService.CountLetters(input);
                return Results.Ok(count);
            });

            app.MapGet("/contains-letters", (string input , string[] letters) =>
            {
                input = input.ToLower();
                letters = StringUtilities.Correction(letters);
                string error = ErrorServices.InputAndLettersValid(input , letters);
                if (!string.IsNullOrEmpty(error))
                    return Results.BadRequest(error);

                bool contains = _textAnalyseService.ContainLetters(input , letters);
                return Results.Ok(contains);
            });

            app.MapGet("/is-base64", (string input) =>
            {
                string error = ErrorServices.InputValid(input);
                if (!string.IsNullOrEmpty(error))
                    return Results.BadRequest(error);

                return Results.Ok(_textAnalyseService.textIsBase64(input));
            });

            app.MapGet("/is-valid-email", (string email) =>
            {
                string error = ErrorServices.InputValid(email);
                if (!string.IsNullOrEmpty(error))
                    return Results.BadRequest(error);

                bool isValid = _textAnalyseService.validEmail(email);
                return Results.Ok(isValid);
            });
        }
    }
}
