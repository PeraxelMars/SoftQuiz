using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SoftQuiz.Services
{
    public static class QuizDataService
    {
        public static string GetQuizData(string quizPath, string quizName)
        {
            string path = string.Format("{0}QuizFolder\\{1}.json", quizPath, quizName);
            return File.ReadAllText(path);
        }

        public static List<string> ListAvailableQuiz(string quizPath)
        {
            List<string> quizFiles = Directory.GetFiles(quizPath + "\\QuizFolder").ToList();

            quizFiles = quizFiles
                        .OrderBy(q => q)
                        .Select(q => q.Split("\\".ToCharArray())
                            .Last()
                            .Replace(".json", ""))
                        .ToList();

            return quizFiles;
        }
    }
}