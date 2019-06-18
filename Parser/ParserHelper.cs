namespace Parser
{
    public static class ParserHelper
    {
        public const string Url = "https://www.xing.com/";
        public const string Lang = "https://www.xing.com/en";
        public const string PeopleUrl = "https://www.xing.com/people/pages/";
        public const string ProfileUrl = "https://www.xing.com/profile/";

        public const string InterestsId = "interests";
        public const string WantsId = "wants";
        public const string HavesId = "haves";

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