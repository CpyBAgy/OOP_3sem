namespace Core.Services.Parser;

public class IdHandler : Handler
{
    public override void Handle(string[] args, CommandLineArgs commandLineArgs, ref int position)
    {
        if (args[position] == "-id" && position + 1 < args.Length)
        {
            commandLineArgs.Id = args[++position].Trim('"');
        }
        else
        {
            NextHandler?.Handle(args, commandLineArgs, ref position);
        }
    }
}