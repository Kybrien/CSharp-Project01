using Display;
using SoundLoader;
using System;
using System.Threading;

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

    }
}
