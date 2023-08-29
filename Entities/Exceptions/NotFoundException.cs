namespace Entities.Exceptions
{
    public abstract class NotFoundException :Exception
    {
        protected NotFoundException(string messsage):base(messsage)
        {
            
        }
    }
}
