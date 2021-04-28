// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoDisposeFileReader.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2021 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   AutoDisposeFileReader.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Audio {
    using NAudio.Wave;

    public class AutoDisposeFileReader : ISampleProvider {
        private readonly AudioFileReader _reader;

        private bool _isDisposed;

        public AutoDisposeFileReader(AudioFileReader reader) {
            this._reader = reader;
            this.WaveFormat = reader.WaveFormat;
        }

        public WaveFormat WaveFormat { get; }

        public int Read(float[] buffer, int offset, int count) {
            if (this._isDisposed) {
                return 0;
            }

            var read = this._reader.Read(buffer, offset, count);
            if (read == 0) {
                this._reader.Dispose();
                this._isDisposed = true;
            }

            return read;
        }
    }
}