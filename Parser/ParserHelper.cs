using System.Runtime.CompilerServices;

namespace Parser
{
    public static class ParserHelper
    {
        public const string Url = "https://www.xing.com/";
        public const string Lang = "https://www.xing.com/en";
        public const string PeopleUrl = "https://www.xing.com/people/pages/";

        private static readonly char[] Letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static int _position;

        public static char GetNextChar()
        {
            if (_position + 1 >= Letters.Length)
            {
                _position = 0;
            }
            
            return Letters[_position++];
        }
    }
}