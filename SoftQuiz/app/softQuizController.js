(function () {
    var softQuizApp = angular
        .module('SoftQuizApplication', [])
        .controller("SoftQuizController", SoftQuizController);

    SoftQuizController.$inject = ['$scope', '$http'];

    function SoftQuizController($scope, $http) {
        var rootUrl = "";
        var questions = [];

        // Post data
        $scope.selectedAnswerId = -1;
        var quizReult = {};
        quizReult.zip = 12345;
        quizReult.answers = [];

        //Gui data
        var questionIndex = 0;
        $scope.lockedAnswer = false;
        var template = "/Templates/Quiz.html";
        $scope.selectedAnswerIndex = -1;

        $scope.getInclude = function () {
            return template;
        }

        // Break out get logic?
        $scope.loadQuiz = function (appRootUrl) {
            rootUrl = appRootUrl;

            var quizName = $("#selectedQuiz").val();

            $http.get(rootUrl + "api/Quiz/" + quizName).success(function (data) {
                questions = data;
                $scope.question = data[questionIndex];
            });
        }

        $scope.answerClicked = function (event, index) {
            $scope.selectedAnswerId = $scope.question.answers[index].id;
            $scope.selectedAnswerIndex = index;
        }

        $scope.lockAnswer = function () {

            var isCorrectAnswer = $scope.question.answers[$scope.selectedAnswerIndex].isCorrect;

            quizReult.answers.push(
                {
                    answerId: $scope.selectedAnswerId,
                    isCorrect: isCorrectAnswer
                });

            $("#answer" + $scope.selectedAnswerIndex).addClass(isCorrectAnswer ? "correctAnswer" : "wrongAnswer");

            $scope.lockedAnswer = true;
        };

        $scope.next = function () {
            // Reset
            $scope.selectedAnswerId = -1;
            $scope.selectedAnswerIndex = -1;
            $scope.lockedAnswer = false;

            if (questionIndex < (questions.length - 1)) {
                questionIndex += 1;
                $scope.question = questions[questionIndex];

                if (questionIndex === (questions.length - 1)) {
                    $("#btnNext").text("Show Result");
                }

            }
            else {
                $scope.save();
            }

        };

        $scope.save = function () {
            $http.post(rootUrl + "api/Quiz/", quizReult)
               .success(function (data) {
                   $scope.quizResult = data;
                   template = "/Templates/QuizResult.html";
               });
        }
    }

})();