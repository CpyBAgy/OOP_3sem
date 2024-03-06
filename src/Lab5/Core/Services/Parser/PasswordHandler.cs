namespace Core.Services.Parser;

public class PasswordHandler : Handler
{
    public override void Handle(string[] args, CommandLineArgs commandLineArgs, ref int position)
    {
        if (args[position] == "-p" && position + 1 < args.Length)
        {
            commandLineArgs.Password = args[++position].Trim('"');
        }
        else
        {
            NextHandler?.Handle(args, commandLineArgs, ref position);
        }
    }
}