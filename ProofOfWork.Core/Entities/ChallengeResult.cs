using System;
using System.Collections.Generic;
using System.Text;

namespace ProofOfWork.Core.Entities
{
    public class ChallengeResult
    {
        // Contain result string 
        public string SolveString { get; set; }

        // Contain the number of seconds was spend to solve the challenge
        public double SolveSeconds { get; set; }

        // Contain hash of 'SolveString'
        public string SolveHash { get; set; }

        // Contain the number of iterations done to solve the challenge
        public int NumberOfIterations { get; set; }
    }
}
