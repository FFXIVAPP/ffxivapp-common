// FFXIVAPP.Common ~ CachedSound.cs
// 
// Copyright © 2007 - 2015 Ryan Wilson - All Rights Reserved
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;

namespace FFXIVAPP.Common.Audio
{
    public class CachedSound
    {
        public CachedSound(string audioFileName)
        {
            using (var audioFileReader = new AudioFileReader(audioFileName))
            {
                WaveFormat = audioFileReader.WaveFormat;
                if (WaveFormat.SampleRate != 44100 || WaveFormat.Channels != 2)
                {
                    using (var resampled = new ResamplerDmoStream(audioFileReader, WaveFormat.CreateIeeeFloatWaveFormat(44100, 2)))
                    {
                        var resampledSampleProvider = resampled.ToSampleProvider();
                        WaveFormat = resampledSampleProvider.WaveFormat;
                        var wholeFile = new List<float>((int) (resampled.Length));
                        var readBuffer = new float[resampled.WaveFormat.SampleRate * resampled.WaveFormat.Channels];
                        int samplesRead;
                        while ((samplesRead = resampledSampleProvider.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        {
                            wholeFile.AddRange(readBuffer.Take(samplesRead));
                        }
                        AudioData = wholeFile.ToArray();
                    }
                }
                else
                {
                    var wholeFile = new List<float>((int) (audioFileReader.Length / 4));
                    var readBuffer = new float[audioFileReader.WaveFormat.SampleRate * audioFileReader.WaveFormat.Channels];
                    int samplesRead;
                    while ((samplesRead = audioFileReader.Read(readBuffer, 0, readBuffer.Length)) > 0)
                    {
                        wholeFile.AddRange(readBuffer.Take(samplesRead));
                    }
                    AudioData = wholeFile.ToArray();
                }
            }
        }

        public float[] AudioData { get; private set; }
        public WaveFormat WaveFormat { get; }
    }
}
