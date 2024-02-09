using Display;
using SoundLoader;
using SaveEditor;

namespace StoryLoader
{
    internal class Story
    {
        public static void Introduction()
        {
            Console.WriteLine("{===============================================================================================================}");
            Sound.ChangeMusicBasedOnMap(6);
            TextDisplay.Sleeping("Dans un monde où les Pokémon règnent en maîtres, des objets mystérieux reposent, porteurs des secrets de l'univers.\n", 50);
            Menu.ShowLoadingScreen("{===============================================================================================================}\nDans un monde où les Pokémon règnent en maîtres, des objets mystérieux reposent, porteurs des secrets de l'univers.", 500);
            TextDisplay.Sleeping("Rassemblez-les tous pour déclencher la venue de celui qui sait, défiant le destin lui-même.\n", 50);
            Menu.ShowLoadingScreen("{===============================================================================================================}\nDans un monde où les Pokémon règnent en maîtres, des objets mystérieux reposent, porteurs des secrets de l'univers.\nRassemblez-les tous pour déclencher la venue de celui qui sait, défiant le destin lui-même.", 1000);
            TextDisplay.Sleeping("Préparez-vous à affronter $%#@(&# pour découvrir la vérité ultime.\n", 50);
            Menu.ShowLoadingScreen("{===============================================================================================================}\nDans un monde où les Pokémon règnent en maîtres, des objets mystérieux reposent, porteurs des secrets de l'univers.\nRassemblez-les tous pour déclencher la venue de celui qui sait, défiant le destin lui-même.\nPréparez-vous à affronter $%#@(&# pour découvrir la vérité ultime.", 1200);
            TextDisplay.Sleeping("L'aventure commence maintenant.\n", 50);
            Console.WriteLine("{===============================================================================================================}");
        }

        public static void EndEvent()
        {
        }


        public static void GameOver()
        {
            Console.Clear();
            Sound.ChangeMusicBasedOnMap(13);
            Console.WriteLine("                                   ╔══════════════════════════════════╗");
            Console.WriteLine("                                   ║             Game Over            ║");
            Console.WriteLine("                                   ╚══════════════════════════════════╝");
            TextDisplay.Sleeping("                Votre existence a été effacée de la mémoire stellaire de ce monde...\n", 15);
            TextDisplay.Sleeping("              Mais rien ne dit que vous etes le seul a essayer de connaitre la vérité...\n", 15);
            TextDisplay.Sleeping("                Votre histoire s'arrete ici, mais le monde continuera de tourner...\n\n", 15);
            TextDisplay.Sleeping("Ne perdez pas espoir, car quelqu'un d'autre suit deja sur vos trace dans l'espoir de découvrir l'ultime secret !\n", 20);
            Console.ReadKey();
            Save.DeleteSave();
            Sound.ChangeMusicBasedOnMap(0);
        }

    }
}
