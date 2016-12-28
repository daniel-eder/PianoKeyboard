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

using System.IO;
using WindowsInput;
using PianoKeyboard.Common.Config;
using PianoKeyboard.Common.Midi;
using PianoKeyboard.Common.Translation;
using Sanford.Multimedia.Midi;

namespace PianoKeyboard.Common
{
    /// <summary>
    /// Class KeyboardManager.
    /// </summary>
    public class KeyboardManager
    {
        /// <summary>
        /// The keyboard receiver. Handles MIDI listening.
        /// </summary>
        private readonly KeyboardReceiver keyboardReceiver;
        /// <summary>
        /// The configuration file. Contains note translation settings.
        /// </summary>
        private ConfigFile configFile;
        /// <summary>
        /// The note translation. Translates midi values to notes.
        /// </summary>
        private NoteTranslation noteTranslation;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardManager"/> class.
        /// </summary>
        public KeyboardManager()
        {
            this.keyboardReceiver = new KeyboardReceiver();
            this.keyboardReceiver.ChannelMessageReceived += this.KeyboardReceiver_ChannelMessageReceived;
        }

        /// <summary>
        /// Gets a list of available keyboards. Array index is midi device index.
        /// </summary>
        /// <returns>System.String[].</returns>
        public string[] GetDeviceList()
        {
            return this.keyboardReceiver.GetDeviceList();
        }

        /// <summary>
        /// Starts listening for midi input.
        /// </summary>
        public void Start()
        {
            this.keyboardReceiver.StartListening();
        }

        /// <summary>
        /// Stops listening for midi input.
        /// </summary>
        public void Stop()
        {
            this.keyboardReceiver.StopListening();
        }

        /// <summary>
        /// Initializes the KeyboardManager for the specified device. If called again destroys the existing connection.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
        public bool Initialize(int deviceId)
        {
            return this.keyboardReceiver.Initialize(deviceId);
        }

        /// <summary>
        /// Loads the specified configuration file
        /// </summary>
        /// <param name="filePath">The configuration file path.</param>
        /// <exception cref="System.IO.FileNotFoundException">The configuration file was not found.</exception>
        public void LoadConfigFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The configuration file was not found.", filePath);

            this.configFile = ConfigParser.Parse(filePath);
            this.noteTranslation = new NoteTranslation(this.configFile);
        }

        /// <summary>
        /// Handles the ChannelMessageReceived event. Creates Input Events.
        /// </summary>
        /// <param name="message">The message.</param>
        private void KeyboardReceiver_ChannelMessageReceived(ChannelMessage message)
        {
            if (message.Command == ChannelCommand.NoteOn)
            {
                var noteEntry = this.noteTranslation.GetNoteEntry(message.Data1);
                if (noteEntry != null)
                {
                    if (noteEntry.IsCommand)
                        this.ExecuteCommand(noteEntry);
                    else
                        InputSimulator.SimulateTextEntry(noteEntry.Command);
                }
            }
        }


        /// <summary>
        /// Parses and executes commands translated from notes/midi values.
        /// </summary>
        /// <param name="noteEntry">The note entry.</param>
        private void ExecuteCommand(NoteEntry noteEntry)
        {
            var command = noteEntry.Command.ToLower().Trim('{', '}');
            switch (command)
            {
                case "return":
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN);
                    break;
                case "backspace":
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.BACK);
                    break;
                case "space":
                    InputSimulator.SimulateKeyPress(VirtualKeyCode.SPACE);
                    break;
            }
        }
    }
}