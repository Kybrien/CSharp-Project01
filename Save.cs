using System;

namespace SaveEditor
{  
    //Sauvegarder la partie
    public class Save
    {
        public static void SaveGame()
        {
            string filePath = "save.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(Program.posX);
                    writer.WriteLine(Program.posY);
                }

                Console.WriteLine("Partie sauvegardée avec succès.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la sauvegarde de la : " + ex.Message);
            }
        }

        //Charger la sauvegarde
        public static void LoadGame()
        {
            string filePath = "save.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        if (int.TryParse(reader.ReadLine(), out Program.posX) && int.TryParse(reader.ReadLine(), out Program.posY))
                        {
                            Console.WriteLine("Partie chargée avec succès. Position actuelle : ({", Program.posX, "}, {", Program.posY, "})");
                        }
                        else
                        {
                            Console.WriteLine("Erreur lors de la lecture du fichier de sauvegarde.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Aucun fichier de sauvegarde trouvé.");
                    Console.WriteLine("Creation d'une nouvelle partie...");
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
            string filePath = "save.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("Sauvegarde supprimée avec succès.");
                }
                else
                {
                    Console.WriteLine("Aucune sauvegarde trouvée.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la suppression de la sauvegarde : " + ex.Message);
            }
        }
    }  
}