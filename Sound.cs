using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;


namespace SoundLoader
{
    public static class Sound
    {
        public static void ChangeMusicBasedOnMap(int mapNumber)
        {
            if (mapNumber >= 0 && mapNumber <= 2)
            {
                AudioManager.PlayMusic("Music/OST_13.mp3");
            }
            else if (mapNumber >= 3 && mapNumber <= 4)
            {
                AudioManager.PlayMusic("Music/OST_13.mp3");
            }
        }
    }
    public static class AudioManager
    {
        #pragma warning disable CA1416
        private static SoundPlayer soundPlayer = new SoundPlayer();
        #pragma warning disable CA1416

        public static void PlayMusic(string filePath)
        {
            try
            {
                #pragma warning disable CA1416
                soundPlayer.SoundLocation = filePath;
                soundPlayer.Load();
                soundPlayer.PlayLooping(); // Joue en boucle
                #pragma warning disable CA1416
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la lecture de la musique: " + ex.Message);
            }
        }

        public static void StopMusic()
        {
            soundPlayer.Stop();
        }
    }
}
