
namespace ConceptArchitect.Utils
{
    [Serializable]
    public  class InvalidIdException<I> : Exception
    {
        public I Id { get; set; }

        public InvalidIdException()
        {
        }

        public InvalidIdException(I? id)
        {
            Id = id;
        }

        public InvalidIdException(string? message) : base(message)
        {
        }

        public InvalidIdException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}