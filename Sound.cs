using System;
using Display;
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
                    return "OST_End.wav";
                case 7:
                    return "Earthquake.wav";
                case 8:
                    return "Combat_12.wav";
                case 9:
                    return "Combat_34.wav";
                case 10:
                    return "Combat_56.wav";
                case 11:
                    return "Combat_Boss.wav";
                case 12:
                    return "Introduction.wav";
                case 13:
                    return "GameOver.wav";
                case 14:
                    return "EndTalk.wav";
                default:
                    return "";
            }
        }

        public static void AutoOST()
        {
            switch (Program.currentMapIndex)
            {
                case 0:
                    SoundLoader.Sound.ChangeMusicBasedOnMap(1);
                    break;
                case 1:
                    SoundLoader.Sound.ChangeMusicBasedOnMap(1);
                    break;
                case 2:
                    SoundLoader.Sound.ChangeMusicBasedOnMap(3);
                    break;
                case 3:
                    SoundLoader.Sound.ChangeMusicBasedOnMap(3);
                    break;
                case 4:
                    SoundLoader.Sound.ChangeMusicBasedOnMap(5);
                    break;
                case 5:
                    SoundLoader.Sound.ChangeMusicBasedOnMap(5);
                    break;
            }
        }
    }
}
