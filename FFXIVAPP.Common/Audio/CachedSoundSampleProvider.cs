// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CachedSoundSampleProvider.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   CachedSoundSampleProvider.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Audio {
    using System;

    using NAudio.Wave;

    public class CachedSoundSampleProvider : ISampleProvider {
        private readonly CachedSound _cachedSound;

        private long _position;

        private float _volume;

        public CachedSoundSampleProvider(CachedSound cachedSound, float volume = 1.0f) {
            this._cachedSound = cachedSound;
            this._volume = volume;
        }

        public float Volume {
            get {
                return this._volume;
            }

            set {
                this._volume = value;
            }
        }

        public WaveFormat WaveFormat {
            get {
                return this._cachedSound.WaveFormat;
            }
        }

        public int Read(float[] buffer, int offset, int count) {
            var availableSamples = this._cachedSound.AudioData.Length - this._position;
            var samplesToCopy = Math.Min(availableSamples, count);
            Array.Copy(this._cachedSound.AudioData, this._position, buffer, offset, samplesToCopy);
            this._position += samplesToCopy;
            if (this._volume != 1f) {
                for (var n = 0; n < samplesToCopy; n++) {
                    buffer[offset + n] *= this._volume;
                }
            }

            return (int) samplesToCopy;
        }
    }
}