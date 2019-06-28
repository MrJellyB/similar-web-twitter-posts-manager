using System;
namespace PostManager.Common.Exceptions
{
    public class MoreThanOneFeedForUserException : Exception, IBadRequestException
    {
    }
}
