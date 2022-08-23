namespace BlogSample.Business;

public interface ICommandHandler<TCommand>
{
    System.Threading.Tasks.Task HandleAsync(TCommand command);
}