using ProofOfWork.Core.Solvers;
using System;

namespace ProofOfWork.Core
{
    class Program
    {
        static void Main()
        {
           // case number one(difficulty = 2) =================================
           //DifficultySolver.RunDifficultySolver(2);

           // // case number two (difficulty = 3) =================================
           // DifficultySolver.RunDifficultySolver(3);

           // // case number three (difficulty = 4) =================================
           // DifficultySolver.RunDifficultySolver(4);

           // // case number four (difficulty = 5) =================================
           // DifficultySolver.RunDifficultySolver(5);

            for (int i = 0; i < 10; i++)
            {
                SpecificStringSolver.RunSpecificStringSolver("000");
            }

            Console.ReadKey();
        }
    }
}
