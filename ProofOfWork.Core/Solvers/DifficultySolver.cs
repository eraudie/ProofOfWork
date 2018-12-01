using ProofOfWork.Core.Entities;
using ProofOfWork.Core.Generators;
using System;
using System.Diagnostics;

namespace ProofOfWork.Core.Solvers
{
    public class DifficultySolver
    {
        public static void RunDifficultySolver(int difficulty)
        {
            var numberOfSolutionsFound = 0;
            var finishTime = CurrentTime + 15;

            do
            {
                ChallengeResult result = 
                    SolveTheChallenge(RandomStringGenerator.GenerateByLen(10), difficulty);
                numberOfSolutionsFound++;
            } while (CurrentTime < finishTime);
            
            Console.WriteLine($"Total number of solutions found for (difficulty = {difficulty.ToString()}): {numberOfSolutionsFound}");
        }

        private static int CurrentTime => 
            (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        
        private static ChallengeResult SolveTheChallenge(string challengeString, int difficulty)
        {
            var challengeResult = new ChallengeResult();
            string expectedResult = new string('0', difficulty);//if the difficulty=4 the expectedResult will be='0000'
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            do
            {
                // counting the number of iterations
                challengeResult.NumberOfIterations++;

                // generating random string to test it
                challengeResult.SolveString = 
                    challengeString + RandomStringGenerator.GenerateByLen(10);
                
                // generating sha-256 from the random string
                challengeResult.SolveHash = 
                    
                    Sha256Generator.GenerateSha256String(challengeResult.SolveString);
                
                // checking if we found a solution
            } while (!challengeResult.SolveHash.StartsWith(expectedResult));

            challengeResult.SolveSeconds = stopwatch.Elapsed.TotalSeconds;

            return challengeResult;
        }

    }
}
