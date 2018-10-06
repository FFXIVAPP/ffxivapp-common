// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CachedSound.cs" company="SyndicatedLife">
//   Copyright(c) 2018 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (http://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   CachedSound.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------
/* TODO: Audio
namespace FFXIVAPP.Common.Audio {
    using System.Collections.Generic;
    using System.Linq;

    using NAudio.Wave;

    public class CachedSound {
        public CachedSound(string audioFileName) {
            using (var audioFileReader = new AudioFileReader(audioFileName)) {
                this.WaveFormat = audioFileReader.WaveFormat;
                if (this.WaveFormat.SampleRate != 44100 || this.WaveFormat.Channels != 2) {
                    using (var resampled = new ResamplerDmoStream(audioFileReader, WaveFormat.CreateIeeeFloatWaveFormat(44100, 2))) {
                        ISampleProvider resampledSampleProvider = resampled.ToSampleProvider();
                        this.WaveFormat = resampledSampleProvider.WaveFormat;
                        List<float> wholeFile = new List<float>((int) resampled.Length);
                        float[] readBuffer = new float[resampled.WaveFormat.SampleRate * resampled.WaveFormat.Channels];
                        int samplesRead;
                        while ((samplesRead = resampledSampleProvider.Read(readBuffer, 0, readBuffer.Length)) > 0) {
                            wholeFile.AddRange(readBuffer.Take(samplesRead));
                        }

                        this.AudioData = wholeFile.ToArray();
                    }
                }
                else {
                    List<float> wholeFile = new List<float>((int) (audioFileReader.Length / 4));
                    float[] readBuffer = new float[audioFileReader.WaveFormat.SampleRate * audioFileReader.WaveFormat.Channels];
                    int samplesRead;
                    while ((samplesRead = audioFileReader.Read(readBuffer, 0, readBuffer.Length)) > 0) {
                        wholeFile.AddRange(readBuffer.Take(samplesRead));
                    }

                    this.AudioData = wholeFile.ToArray();
                }
            }
        }

        public float[] AudioData { get; private set; }

        public WaveFormat WaveFormat { get; }
    }
}
*/