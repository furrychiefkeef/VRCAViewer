using Pastel;

if (args.Length > 0)
{
    string filepath = args[0];
    if (filepath.EndsWith(".vrca", StringComparison.OrdinalIgnoreCase))
    {
        Console.Title = filepath;
    begin:
        Console.Write($"Enter a command for {Path.GetFileName(filepath)}:  ");
        string? cmd = Console.ReadLine();
        switch (cmd)
        {

            case "%view":
                return 0;
            case "%tree":
                return 0;
            case "%help":
                Console.Write($"COMMANDS | PREFIX [{"%".Pastel(ConsoleColor.Cyan)}] " +
                    $"{"view".Pastel(ConsoleColor.Magenta)}, " +
                    $"{"tree".Pastel(ConsoleColor.Green)}, " +
                    $"{"help".Pastel(ConsoleColor.Red)}, " +
                    $"{"get_id".Pastel(ConsoleColor.Yellow)}");
                Console.ReadLine();
                Console.Clear();
                goto begin;
            case "%get_id":
                vrcaViewer.native.AvatarFile.GetAvatarID(filepath);
                return 0;
        }
    }
}
else Console.WriteLine("No commands provided. Use '%help' for commands!".Pastel(ConsoleColor.DarkRed)); Console.ReadLine(); return 1;
