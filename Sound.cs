using System;
using NAudio.Wave;

namespace SoundLoader
{
    public static class Sound
    {
        private static IWavePlayer waveOutDevice;
        private static AudioFileReader audioFileReader;

        public static void ChangeMusicBasedOnMap(int mapNumber)
        {
            string filePath = GetFilePathForMap(mapNumber);

            if (!string.IsNullOrEmpty(filePath))
            {
                StopMusic(); // Arrête et libère les ressources de la musique précédente

                try
                {
                    audioFileReader = new AudioFileReader(filePath);
                    waveOutDevice = new WaveOutEvent();
                    waveOutDevice.Init(audioFileReader);
                    waveOutDevice.Play();
                }
                catch (Exception){}
            }
        }

        public static void StopMusic()
        {
            DisposeWave(); // Libère les ressources audio
        }

        /*public static void SetVolume(float volume)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Volume = volume; // Réglez le volume (entre 0.0 et 1.0)
            }
        }*/

        private static void DisposeWave()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }

            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
        }

        private static string GetFilePathForMap(int mapNumber)
        {
            switch (mapNumber)
            {
                case 0:
                case 1:
                    return "OST_12.wav";
                case 2:
                case 3:
                    return "OST_34.wav";
                case 4:
                case 5:
                    return "OST_56.wav";
                case 6:
                    return "Introduction.wav";
                default:
                    return "";
            }
        }
    }
}
