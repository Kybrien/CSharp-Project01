using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Runtime.InteropServices;
using NAudio.Wave;


namespace SoundLoader
{
    public static class Sound
    {
        /*private static IWavePlayer waveOutDevice;
        private static AudioFileReader audioFileReader;*/

        public static void ChangeMusicBasedOnMap(int mapNumber)
        {
            if (mapNumber >= 0 && mapNumber <= 1)
            {
                AudioManager.PlayMusic("OST_12.wav");
            }
            else if (mapNumber >= 2 && mapNumber <= 3)
            {
                AudioManager.PlayMusic("OST_34.wav");
            }
            else if (mapNumber >= 3 && mapNumber <= 4)
            {
                AudioManager.PlayMusic("OST_56.wav");
            }
        }
    }

    public static class AudioManager
    {
        #pragma warning disable CA1416
        public static SoundPlayer soundPlayer = new SoundPlayer();

        public static void PlayMusic(string filePath)
        {
            try
            {
                #pragma warning disable CA1416
                soundPlayer.Stop(); // Arrêter la musique précédente
                soundPlayer.SoundLocation = filePath;
                soundPlayer.Load();
                soundPlayer.PlayLooping();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la lecture du fichier audio : " + ex.Message);
            }
        }
        /*public static void SetVolume(int volume)
        {
            // Le volume est un entier de 0 (muet) à 100 (volume maximal)
            // Convertir en valeur appropriée pour waveOutSetVolume (0x0000 à 0xFFFF)
            uint vol = (uint)(volume * 65535 / 100);
            waveOutSetVolume(IntPtr.Zero, vol | (vol << 16));
        }
        [DllImport("winmm.dll")]
        private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);*/
    }
}