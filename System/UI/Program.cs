class Program
{
    static async Task Main()
    {

        Console.WriteLine("Bienvenue dans Spellcaster CLI !");
        Console.WriteLine("Que souhaitez-vous faire ?");
        Console.WriteLine("1. Corriger un texte en français");
        Console.WriteLine("2. Traduire un texte en français vers anglais");
        Console.WriteLine("3. Générer un fichier HTML");
        Console.WriteLine("4. Quitter");

        int userChoice = int.Parse(Console.ReadLine());

        switch (userChoice)
        {
            case 1:
                await Correction.TextCorrection();
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                return;
            default:
                return;
        }
    }
}
