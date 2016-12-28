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

using System.Collections.Generic;

namespace PianoKeyboard.Common.Config
{
    /// <summary>
    /// Class ConfigFile.
    /// </summary>
    public class ConfigFile
    {
        /// <summary>
        /// The note entries specified in the configuration file.
        /// </summary>
        public List<NoteEntry> NoteEntries;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigFile"/> class.
        /// </summary>
        public ConfigFile()
        {
            this.NoteEntries = new List<NoteEntry>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigFile"/> class.
        /// </summary>
        /// <param name="noteEntries">The note entries.</param>
        public ConfigFile(NoteEntry[] noteEntries)
        {
            this.NoteEntries = new List<NoteEntry>();
            this.NoteEntries.AddRange(noteEntries);
        }
    }
}