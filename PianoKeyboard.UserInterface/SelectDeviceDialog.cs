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
using System.Windows.Forms;
using PianoKeyboard.Common;

namespace PianoKeyboard.UserInterface
{
    /// <summary>
    /// Class SelectDeviceDialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class SelectDeviceDialog : Form
    {
        /// <summary>
        /// The selected device index.
        /// </summary>
        public int SelectedDevice;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectDeviceDialog"/> class.
        /// </summary>
        /// <param name="keyboardManager">The keyboard manager.</param>
        public SelectDeviceDialog(KeyboardManager keyboardManager)
        {
            this.SelectedDevice = -1;
            this.InitializeComponent();
            this.deviceSelector.Items.AddRange(keyboardManager.GetDeviceList());
        }

        /// <summary>
        /// Handles the commit button click event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CommitButtonOnClick(object sender, EventArgs e)
        {
            this.SelectedDevice = this.deviceSelector.SelectedIndex;
            this.Close();
        }
    }
}