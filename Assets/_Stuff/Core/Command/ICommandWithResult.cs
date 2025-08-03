namespace IpegamaGames
{
    public interface ICommandWithResult<TReturn> : IBaseCommand
    {
        TReturn Execute();
    }
}