
namespace ConceptArchitect.Utils
{
    [Serializable]
    public  class InvalidIdException : Exception
    {
        public object Id { get; set; }



        public InvalidIdException(object id, string? message="Invalid Id")
         : this(id,message,null)
        {
        }

        public InvalidIdException(object id, string? message, Exception? innerException) : base(message, innerException)
        {
            this.Id=id;
        }
    }
}