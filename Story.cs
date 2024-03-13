using Display;
using SoundLoader;
using SaveEditor;
using System.Threading;

namespace StoryLoader
{
    internal class Story
    {
        public static void Introduction()
        {
            Console.WriteLine("{===============================================================================================================}");
            Sound.ChangeMusicBasedOnMap(12);
            TextDisplay.Sleeping("Dans un monde où les Pokémon règnent en maîtres, des objets mystérieux reposent, porteurs des secrets de l'univers.\n", 50);
            Menu.ShowLoadingScreen("{===============================================================================================================}\nDans un monde où les Pokémon règnent en maîtres, des objets mystérieux reposent, porteurs des secrets de l'univers.", 500);
            TextDisplay.Sleeping("Rassemblez-les tous pour déclencher la venue de celui qui sait, défiant le destin lui-même.\n", 50);
            Menu.ShowLoadingScreen("{===============================================================================================================}\nDans un monde où les Pokémon règnent en maîtres, des objets mystérieux reposent, porteurs des secrets de l'univers.\nRassemblez-les tous pour déclencher la venue de celui qui sait, défiant le destin lui-même.", 1000);
            TextDisplay.Sleeping("Préparez-vous à affronter $%#@(&# pour découvrir la vérité ultime.\n", 50);
            Menu.ShowLoadingScreen("{===============================================================================================================}\nDans un monde où les Pokémon règnent en maîtres, des objets mystérieux reposent, porteurs des secrets de l'univers.\nRassemblez-les tous pour déclencher la venue de celui qui sait, défiant le destin lui-même.\nPréparez-vous à affronter $%#@(&# pour découvrir la vérité ultime.", 1200);
            TextDisplay.Sleeping("L'aventure commence maintenant.\n", 50);
            Console.WriteLine("{===============================================================================================================}");
        }
        public static void EndGame()
        {
            Sound.ChangeMusicBasedOnMap(7);
            Thread.Sleep(3000);
            Console.Clear();
            TextDisplay.Sleeping("{===========================================}", 50);
            Sound.ChangeMusicBasedOnMap(14);
            TextDisplay.Sleeping("\nToi qui a décide de m'appeler", 50);
            Menu.ShowLoadingScreen("{===========================================}\nToi qui a décide de m'appeler", 500);
            TextDisplay.Sleeping("Ne te rends-tu pas compte de ce que tu viens de faire ?", 50);
            Menu.ShowLoadingScreen("{===========================================}\nToi qui a décide de m'appeler\nNe te rends-tu pas compte de ce que tu viens de faire ?", 500);
            TextDisplay.Sleeping("Tu as libéré une force que tu ne peux pas contrôler", 50);
            Menu.ShowLoadingScreen("{===========================================}\nToi qui a décide de m'appeler\tNe te rends-tu pas compte de ce que tu viens de faire ?\nTu as libéré une force que tu ne peux pas contrôler", 500);
            TextDisplay.Sleeping("Tu as réveillé un pouvoir que tu ne peux pas comprendre", 50);
            Menu.ShowLoadingScreen("{===========================================}\nToi qui a décide de m'appeler\nNe te rends-tu pas compte de ce que tu viens de faire ?\nTu as libéré une force que tu ne peux pas contrôler\nTu as réveillé un pouvoir que tu ne peux pas comprendre", 500);
            TextDisplay.Sleeping("Et pourtant tu te tiens devant moi...", 50);
            Menu.ShowLoadingScreen("{===========================================}\nToi qui a décide de m'appeler\nNe te rends-tu pas compte de ce que tu viens de faire ?\nTu as libéré une force que tu ne peux pas contrôler\nTu as réveillé un pouvoir que tu ne peux pas comprendre\nEt pourtant tu te tiens devant moi...", 500);
            TextDisplay.Sleeping("Moi, le grand Mewtwo t'invoque pour une confrontation qui decidera du destin de ta dimension", 50);
            Menu.ShowLoadingScreen("{===========================================}\nToi qui a décide de m'appeler\nNe te rends-tu pas compte de ce que tu viens de faire ?\nTu as libéré une force que tu ne peux pas contrôler\nTu as réveillé un pouvoir que tu ne peux pas comprendre\nEt pourtant tu te tiens devant moi...\nMoi, le grand Mewtwo t'invoque pour une confrontation qui decidera du destin de ta dimension", 500);
            TextDisplay.Sleeping("Si je te juge digne, tu deviendras le nouveau Raziel, gardien des secrets de ce monde", 50);
            Menu.ShowLoadingScreen("{===========================================}\nToi qui a décide de m'appeler\nNe te rends-tu pas compte de ce que tu viens de faire ?\nTu as libéré une force que tu ne peux pas contrôler\nTu as réveillé un pouvoir que tu ne peux pas comprendre\nEt pourtant tu te tiens devant moi...\nMoi, le grand Mewtwo t'invoque pour une confrontation qui decidera du destin de ta dimension\nSi je te juge digne, tu deviendras le nouveau Raziel, gardien des secrets de ce monde", 500);
            TextDisplay.Sleeping("Mais si echoues, ce sera la fin du monde tel que tu le connais", 80);
            Menu.ShowLoadingScreen("{===========================================}\nToi qui a décide de m'appeler\nNe te rends-tu pas compte de ce que tu viens de faire ?\nTu as libéré une force que tu ne peux pas contrôler\nTu as réveillé un pouvoir que tu ne peux pas comprendre\nEt pourtant tu te tiens devant moi...\nMoi, le grand Mewtwo t'invoque pour une confrontation qui decidera du destin de ta dimension\nSi je te juge digne, tu deviendras le nouveau Raziel, gardien des secrets de ce monde\nMais si echoues, ce sera la fin du monde tel que tu le connais", 500);
            TextDisplay.Sleeping("Maintenant viens, jeune homme...", 80);
            Menu.ShowLoadingScreen("{===========================================}\nToi qui a décide de m'appeler\nNe te rends-tu pas compte de ce que tu viens de faire ?\nTu as libéré une force que tu ne peux pas contrôler\nTu as réveillé un pouvoir que tu ne peux pas comprendre\nEt pourtant tu te tiens devant moi...\nMoi, le grand Mewtwo t'invoque pour une confrontation qui decidera du destin de ta dimension\nSi je te juge digne, tu deviendras le nouveau Raziel, gardien des secrets de ce monde\nMais si echoues, ce sera la fin du monde tel que tu le connais\nMaintenant viens, jeune homme...", 500);
            Console.WriteLine("{===========================================}");
            Console.ReadKey();
            Program.currentMapIndex = 6;
            Program.NumberOfItem = 0;
            Program.posX = 18;
            Program.posY = 9;
            Map.ChangeMap();
            Console.Clear();
            Sound.ChangeMusicBasedOnMap(6);
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
            Sound.ChangeMusicBasedOnMap(1);
        }

    }
}
