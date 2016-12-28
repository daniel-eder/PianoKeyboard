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
using System.Collections.Generic;
using PianoKeyboard.Common.Config;

namespace PianoKeyboard.Common.Translation
{
    /// <summary>
    /// Class NoteTranslation.
    /// </summary>
    public class NoteTranslation
    {
        /// <summary>
        /// The midi number to note translation dictionary.
        /// </summary>
        private readonly Dictionary<int, NoteEntry> midiNumberToNote;
        /// <summary>
        /// The notes in one octave.
        /// </summary>
        private readonly string[] octaveNotes = {"C", "CIS", "D", "DIS", "E", "F", "FIS", "G", "GIS", "A", "AIS", "B"};

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteTranslation"/> class.
        /// </summary>
        /// <param name="configFile">The configuration file to use.</param>
        public NoteTranslation(ConfigFile configFile)
        {
            this.midiNumberToNote = new Dictionary<int, NoteEntry>();

            foreach (var noteEntry in configFile.NoteEntries)
            {
                var noteValue = this.CalculateMidiValue(noteEntry.Note.ToUpper(), noteEntry.Octave);
                this.midiNumberToNote.Add(noteValue, noteEntry);
            }
        }

        /// <summary>
        /// Gets the note entry for the given midi number.
        /// </summary>
        /// <param name="midiNumber">The midi number.</param>
        /// <returns>NoteEntry.</returns>
        public NoteEntry GetNoteEntry(int midiNumber)
        {
            try
            {
                return this.midiNumberToNote[midiNumber];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Calculates the midi number for the given note and octave.
        /// Calculation based on: http://www.sengpielaudio.com/calculator-notenames.htm
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="octave">The octave.</param>
        /// <returns>System.Int32.</returns>
        private int CalculateMidiValue(string note, int octave)
        {
            var index = Array.FindIndex(this.octaveNotes, n => n == note);
            if (index == -1)
                return index;
            return 12*(octave + 1) + index;
        }
    }
}