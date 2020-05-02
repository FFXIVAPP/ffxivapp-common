// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AudioPlaybackEngine.cs" company="SyndicatedLife">
//   Copyright© 2007 - 2020 Ryan Wilson &amp;lt;syndicated.life@gmail.com&amp;gt; (https://syndicated.life/)
//   Licensed under the MIT license. See LICENSE.md in the solution root for full license information.
// </copyright>
// <summary>
//   AudioPlaybackEngine.cs Implementation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace FFXIVAPP.Common.Audio {
    using System;

    using NAudio.Wave;
    using NAudio.Wave.SampleProviders;

    public class AudioPlaybackEngine : IDisposable {
        private static Lazy<AudioPlaybackEngine> _instance = new Lazy<AudioPlaybackEngine>(() => new AudioPlaybackEngine());

        private int ChannelCount = 2;

        private MixingSampleProvider Mixer;

        private IWavePlayer OutputDevice;

        private int SampleRate = 44100;

        public AudioPlaybackEngine(int sampleRate = 44100, int channelCount = 2) {
            this.SampleRate = sampleRate;
            this.ChannelCount = channelCount;
            this.SetupEngine();
        }

        public static AudioPlaybackEngine Instance {
            get {
                return _instance.Value;
            }
        }

        private Guid LastAudioDevice { get; set; }

        public void Dispose() {
            this.OutputDevice.Dispose();
        }

        public void PlaySound(CachedSound sound, int volume = 100) {
            if (this.LastAudioDevice != Constants.DefaultAudioDevice) {
                this.OutputDevice.Stop();
                this.SetupEngine();
            }

            this.Mixer.AddMixerInput(new CachedSoundSampleProvider(sound, (float) volume / 100));
        }

        private void SetupEngine() {
            // OutputDevice = new WaveOutEvent();
            // OutputDevice = new DirectSoundOut(40);
            // OutputDevice = new WasapiOut(AudioClientShareMode.Shared, true, 40);
            if (Constants.DefaultAudioDevice == Guid.Empty) {
                this.OutputDevice = new DirectSoundOut(100);
            }
            else {
                this.LastAudioDevice = Constants.DefaultAudioDevice;
                this.OutputDevice = new DirectSoundOut(Constants.DefaultAudioDevice, 100);
            }

            this.Mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(this.SampleRate, this.ChannelCount)) {
                ReadFully = true,
            };
            this.OutputDevice.Init(this.Mixer);
            this.OutputDevice.Play();
        }
    }
}