using Display;
using System;
using System.IO;
using System.Text;

namespace SaveEditor
{  
    //Sauvegarder la partie
    public class Save
    {
        public static bool IsIntroductionPlayed { get; set; } = false;
        public static void SaveGame()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "save.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(Program.posX);
                    writer.WriteLine(Program.posY);

                    // Sauvegarde de la carte
                    for (int i = 0; i < Program.currentMap.GetLength(0); i++)
                    {
                        for (int j = 0; j < Program.currentMap.GetLength(1); j++)
                        {
                            writer.Write(Program.currentMap[i, j]);
                        }
                        writer.WriteLine(); // Nouvelle ligne à la fin de chaque rangée de la carte
                    }
                }

                Console.WriteLine("Partie sauvegardée avec succès.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la sauvegarde : " + ex.Message);
            }
        }

        //Charger la sauvegarde
        public static void LoadGame()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "save.txt");

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string? posXLine = reader.ReadLine();
                        string? posYLine = reader.ReadLine();

                        if (posXLine != null && posYLine != null)
                        {
                            Program.posX = int.Parse(posXLine);
                            Program.posY = int.Parse(posYLine);
                        }

                        // Chargement de la carte
                        string? line;
                        List<string> mapLines = new List<string>();
                        while ((line = reader.ReadLine()) != null)
                        {
                            mapLines.Add(line);
                        }

                        Program.currentMap = new char[mapLines.Count, mapLines[0].Length];
                        for (int i = 0; i < mapLines.Count; i++)
                        {
                            for (int j = 0; j < mapLines[i].Length; j++)
                            {
                                Program.currentMap[i, j] = mapLines[i][j];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors du chargement : " + ex.Message);
            }
        }

        //Supprimer la sauvegarde
        public static void DeleteSave()
        {
            string filePath = Path.Combine(Environment.CurrentDirectory, "save.txt");

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Réinitialiser la position
                Program.posX = 8;
                Program.posY = 1;

                // Réinitialiser la carte
                Program.currentMap = Map.InitMap1();

                Console.WriteLine("Sauvegarde supprimée et jeu réinitialisé.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression de la sauvegarde : " + ex.Message);
            }
        }
    }  
}