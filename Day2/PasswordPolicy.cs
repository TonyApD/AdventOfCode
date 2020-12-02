using System.Linq;

namespace Day2
{
    class PasswordPolicy
    {
        int FirstNumber { get; }

        int SecondNumber { get; }

        char Character { get; }

        string Password { get; }

        public PasswordPolicy(int min, int max, char character, string password)
        {
            SecondNumber = max;
            FirstNumber = min;
            Character = character;
            Password = password;
        }

        public bool SatisfiesLengthConstraint()
        {
            var numberOfChar = Password.ToCharArray().Count(x => x == Character);
            return numberOfChar >= FirstNumber && numberOfChar <= SecondNumber;
        }

        public bool SatisfiesPositionConstraint()
        {
            return Password[FirstNumber - 1] == Character ^ Password[SecondNumber - 1] == Character;
        }
    }
}
