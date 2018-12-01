using ProofOfWork.Core.Entities;
using ProofOfWork.Core.Generators;
using System;
using System.Diagnostics;

namespace ProofOfWork.Core.Solvers
{
    public class SpecificStringSolver
    {
        public static void RunSpecificStringSolver(string specificString)
        {
            ChallengeResult result = 
                SolveTheChallenge(RandomStringGenerator.GenerateByLen(10), specificString);

            Console.WriteLine($"Found a hash for your string!");
            Console.WriteLine(result.SolveHash);
            Console.WriteLine($"It took {result.SolveSeconds.ToString()} seconds to find it.");
        }

        private static ChallengeResult SolveTheChallenge(string challengeString, string specificString)
        {
            var challengeResult = new ChallengeResult();
            string expectedResult = specificString;
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
                    //Md5Generator.GenerateMd5String(challengeResult.SolveString);
                Sha256Generator.GenerateSha256String(challengeResult.SolveString);

                // checking if we found a solution
                //Console.WriteLine(challengeResult.SolveHash);
            } while (!challengeResult.SolveHash.StartsWith(expectedResult));

            challengeResult.SolveSeconds = stopwatch.Elapsed.TotalSeconds;

            return challengeResult;
        }


    }
}
