using System;
using NAudio.Wave;

namespace SoundLoader
{
    public static class Sound
    {
        private static IWavePlayer waveOutDevice = new WaveOutEvent();
        private static AudioFileReader audioFileReader;

        public static void ChangeMusicBasedOnMap(int mapNumber)
        {
            string filePath = GetFilePathForMap(mapNumber);

            if (!string.IsNullOrEmpty(filePath))
            {
                StopMusic();

                audioFileReader = new AudioFileReader(filePath);
                waveOutDevice = new WaveOutEvent();
                waveOutDevice.Init(audioFileReader);
                waveOutDevice.Play();
            }
        }

        public static void StopMusic()
        {
            if (waveOutDevice != null && waveOutDevice.PlaybackState == PlaybackState.Playing)
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

        public static void SetVolume(float volume)
        {
            if (audioFileReader != null)
            {
                audioFileReader.Volume = volume; // Réglez le volume de l'AudioFileReader (entre 0.0 et 1.0)
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
                default:
                    return "";
            }
        }
    }
}
