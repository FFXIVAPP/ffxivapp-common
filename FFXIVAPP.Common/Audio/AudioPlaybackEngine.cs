// FFXIVAPP.Common
// AudioPlaybackEngine.cs
// 
// Copyright © 2007 - 2014 Ryan Wilson - All Rights Reserved
// 
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met: 
// 
//  * Redistributions of source code must retain the above copyright notice, 
//    this list of conditions and the following disclaimer. 
//  * Redistributions in binary form must reproduce the above copyright 
//    notice, this list of conditions and the following disclaimer in the 
//    documentation and/or other materials provided with the distribution. 
//  * Neither the name of SyndicatedLife nor the names of its contributors may 
//    be used to endorse or promote products derived from this software 
//    without specific prior written permission. 
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE. 

using System;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace FFXIVAPP.Common.Audio
{
    public class AudioPlaybackEngine : IDisposable
    {
        #region Property Backings

        private static AudioPlaybackEngine _instance;

        public static AudioPlaybackEngine Instance
        {
            get { return _instance ?? (_instance = new AudioPlaybackEngine()); }
            set { _instance = value; }
        }

        #endregion

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
    }
}
