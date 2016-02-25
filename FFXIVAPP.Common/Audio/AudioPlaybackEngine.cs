// FFXIVAPP.Common ~ AudioPlaybackEngine.cs
// 
// Copyright © 2007 - 2016 Ryan Wilson - All Rights Reserved
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
using NAudio.Wave.SampleProviders;

namespace FFXIVAPP.Common.Audio
{
    public class AudioPlaybackEngine : IDisposable
    {
        private int ChannelCount = 2;
        private MixingSampleProvider Mixer;
        private IWavePlayer OutputDevice;
        private int SampleRate = 44100;

        public AudioPlaybackEngine(int sampleRate = 44100, int channelCount = 2)
        {
            SampleRate = sampleRate;
            ChannelCount = channelCount;
            SetupEngine();
        }

        private Guid LastAudioDevice { get; set; }

        public void Dispose()
        {
            OutputDevice.Dispose();
        }

        private void SetupEngine()
        {
            //OutputDevice = new WaveOutEvent();
            //OutputDevice = new DirectSoundOut(40);
            //OutputDevice = new WasapiOut(AudioClientShareMode.Shared, true, 40);
            if (Constants.DefaultAudioDevice == Guid.Empty)
            {
                OutputDevice = new DirectSoundOut(100);
            }
            else
            {
                LastAudioDevice = Constants.DefaultAudioDevice;
                OutputDevice = new DirectSoundOut(Constants.DefaultAudioDevice, 100);
            }
            Mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(SampleRate, ChannelCount))
            {
                ReadFully = true
            };
            OutputDevice.Init(Mixer);
            OutputDevice.Play();
        }

        public void PlaySound(CachedSound sound, int volume = 100)
        {
            if (LastAudioDevice != Constants.DefaultAudioDevice)
            {
                OutputDevice.Stop();
                SetupEngine();
            }
            Mixer.AddMixerInput(new CachedSoundSampleProvider(sound, (float) volume / 100));
        }

        #region Property Backings

        private static AudioPlaybackEngine _instance;

        public static AudioPlaybackEngine Instance
        {
            get { return _instance ?? (_instance = new AudioPlaybackEngine()); }
            set { _instance = value; }
        }

        #endregion
    }
}
