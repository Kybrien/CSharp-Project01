using Display;

namespace Anim
{
    public class Animation
    {
        public static void Fight_Anim()
        {
            string[] frames = new string[]
            {
@"
            ┌────────────────────────────────────────┐
            │                                        │
            │                                        │
            │                                        │
            │                                        │
            │                                        │
            │                                        │
            │                                        │
            └────────────────────────────────────────┘
            ",
            @"
            ┌────────────────────────────────────────┐
            │                  |                     │
            │                  |                     │
            │                  |                     │
            │                  |                     │
            │                  |                     │
            │                  |                     │
            │                  |                     │
            └────────────────────────────────────────┘
            ",
            @"
            ┌────────────────────────────────────────┐
            │              | | | | |                 │
            │              | | | | |                 │
            │              | | | | |                 │
            │              | | | | |                 │
            │              | | | | |                 │
            │              | | | | |                 │
            │              | | | | |                 │
            └────────────────────────────────────────┘
            ",
            @"
            ┌────────────────────────────────────────┐
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            │        | | | | | | | | | | | |         │
            └────────────────────────────────────────┘
            ",
            @"
            ┌────────────────────────────────────────┐
            │ | | | | | | | | | | | | | | | | | | | ││ 
            │ | | | | | | | | | | | | | | | | | | | ││ 
            │ | | | | | | | | | | | | | | | | | | | ││
            │ | | | | | | | | | | | | | | | | | | | ││
            │ | | | | | | | | | | | | | | | | | | | ││
            │ | | | | | | | | | | | | | | | | | | | ││
            │ | | | | | | | | | | | | | | | | | | | ││
            └────────────────────────────────────────┘
            ",
            @$"
                          ┌───────────────┐
                          │               │
                          │ WILD POKEMON  │
                          │   APPEARS!    │
                          └───────────────┘
            "
            };

            foreach (string frame in frames)
            {
                Console.Clear();
                Console.WriteLine(frame);
                Thread.Sleep(200); // Delay between frames
            }

        }

        public static void Mewtwo()
        {
            Console.Clear();
            Console.WriteLine("           #  #");
            Console.WriteLine("          <#####>");
            Console.WriteLine("        .  #o#o#");
            Console.WriteLine("      <:##:.####'");
            Console.WriteLine(".:#:. ⠈   '⠻###:.");
            Console.WriteLine("#  :#:      '##⡄ ^:.");
            Console.WriteLine("#;  ⠘#..   .####:.'#.");
            Console.WriteLine("^#;  :##:.:######: ;#;");
            Console.WriteLine(" ⠈##. ⠘##########'");
            Console.WriteLine("   :##⡄⠀:#######'");
            Console.WriteLine("     ^⠀⠀.#⠃    :#");
            Console.WriteLine("       .#:     :##:..");
            Console.WriteLine("      .###      ⠈^^");
            Console.WriteLine("       ^");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
