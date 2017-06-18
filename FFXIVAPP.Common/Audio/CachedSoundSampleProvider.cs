// FFXIVAPP.Common ~ CachedSoundSampleProvider.cs
// 
// Copyright © 2007 - 2017 Ryan Wilson - All Rights Reserved
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

using System;
using NAudio.Wave;

namespace FFXIVAPP.Common.Audio
{
    public class CachedSoundSampleProvider : ISampleProvider
    {
        private readonly CachedSound _cachedSound;
        private long _position;
        private float _volume;

        public CachedSoundSampleProvider(CachedSound cachedSound, float volume = 1.0f)
        {
            _cachedSound = cachedSound;
            _volume = volume;
        }

        public float Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }

        public int Read(float[] buffer, int offset, int count)
        {
            var availableSamples = _cachedSound.AudioData.Length - _position;
            var samplesToCopy = Math.Min(availableSamples, count);
            Array.Copy(_cachedSound.AudioData, _position, buffer, offset, samplesToCopy);
            _position += samplesToCopy;
            if (_volume != 1f)
            {
                for (var n = 0; n < samplesToCopy; n++)
                {
                    buffer[offset + n] *= _volume;
                }
            }
            return (int) samplesToCopy;
        }

        public WaveFormat WaveFormat
        {
            get { return _cachedSound.WaveFormat; }
        }
    }
}
