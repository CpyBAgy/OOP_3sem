namespace Core.Services.Parser;

public abstract class Handler
{
    protected Handler? NextHandler { get; private set; }

    public void SetNext(Handler handler)
    {
        NextHandler = handler;
    }

    public abstract void Handle(string[] args, CommandLineArgs commandLineArgs, ref int position);
}
