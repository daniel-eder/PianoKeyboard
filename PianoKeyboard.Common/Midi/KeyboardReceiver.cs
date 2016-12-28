// MIT License
// 
// Copyright (c) 2016 Daniel Eder
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using Sanford.Multimedia.Midi;

namespace PianoKeyboard.Common.Midi
{
    /// <summary>
    /// Class KeyboardReceiver.
    /// </summary>
    public class KeyboardReceiver
    {
        /// <summary>
        /// The midi input device.
        /// </summary>
        private InputDevice device;

        /// <summary>
        /// The ChannelMessageReceived event.
        /// </summary>
        public event Action<ChannelMessage> ChannelMessageReceived;

        /// <summary>
        /// Gets a list of available midi devices. Array idnex equals midi device index.
        /// </summary>
        /// <returns>System.String[].</returns>
        public string[] GetDeviceList()
        {
            var devices = new string[InputDevice.DeviceCount];
            for (var i = 0; i < InputDevice.DeviceCount; i++)
            {
                var deviceInfo = InputDevice.GetDeviceCapabilities(i);
                devices[i] = deviceInfo.name;
            }
            return devices;
        }

        /// <summary>
        /// Initializes the receiver for the specified device. Calling again disposes of the existing connection.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
        public bool Initialize(int deviceId)
        {
            try
            {
                if (this.device != null)
                {
                    this.device.StopRecording();
                    this.device.Close();
                    this.device.Dispose();
                    this.device = null;
                }
                this.device = new InputDevice(deviceId);
                this.device.ChannelMessageReceived += this.HandleChannelMessageReceived;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Starts listening for midi input.
        /// </summary>
        public void StartListening()
        {
            this.device.StartRecording();
        }

        /// <summary>
        /// Stops listening for midi input.
        /// </summary>
        public void StopListening()
        {
            this.device?.StopRecording();
        }

        /// <summary>
        /// Handles the channel message received event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ChannelMessageEventArgs"/> instance containing the event data.</param>
        private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            this.ChannelMessageReceived?.Invoke(e.Message);
        }
    }
}