namespace BookLibrary.ExceptionMessages
{
    public class ExceptionMessages
    {
        public const string INVALID_BOOK_TITLE = "Incorrect book title!";
        public const string INVALID_AUTHOR_NAME = "Incorrectly entered author name!";
        public const string Invalid_Pages_Count = "Pages count cannot be equal ot less then zero";
        public const string Invalid_Count_Of_Characters = "The description mush be in the range of 0 - 200 characters! You have {0}.";
        public const string InvalidUsername = "Username is Invalid, must be more than 6 characters and symbols!";
        public const string InvalidPassword = "Password is Invalid, must be more than 7 characters and symbols!";
        public const string InvalidLogIn = "Invalid Username or Password or You dont have an account!";
    }
}
