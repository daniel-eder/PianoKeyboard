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
    /// Class PianoKeyboardContext. Application context for PianoKeyboard.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ApplicationContext" />
    public class PianoKeyboardContext : ApplicationContext
    {
        /// <summary>
        /// The keyboard manager. Handles both MIDI listening and input simulation.
        /// </summary>
        private readonly KeyboardManager keyboardManager;
        /// <summary>
        /// The notify icon for the system try.
        /// </summary>
        private readonly NotifyIcon notifyIcon;
        /// <summary>
        /// The dialog that allows selecting a keyboard.
        /// </summary>
        private SelectDeviceDialog selectDeviceDialog;

        /// <summary>
        /// Initializes a new instance of the <see cref="PianoKeyboardContext"/> class.
        /// </summary>
        public PianoKeyboardContext()
        {
            this.keyboardManager = new KeyboardManager();
            this.keyboardManager.LoadConfigFile("config.json");

            this.notifyIcon = new NotifyIcon
            {
                Icon = Properties.Resources.Icon,
                ContextMenu = new ContextMenu(new[]
                {new MenuItem("Keyboard auswählen", this.ShowConfig), new MenuItem("Exit", this.Exit)}),
                Visible = true
            };

            this.ShowConfig(this, null);
        }

        /// <summary>
        /// Handles the Exit Menu Item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Exit(object sender, EventArgs e)
        {
            if (this.selectDeviceDialog != null)
                this.selectDeviceDialog.Close();
            this.notifyIcon.Visible = false;
            this.keyboardManager.Stop();
            Application.Exit();
        }

        /// <summary>
        /// Shows the select device dialog.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ShowConfig(object sender, EventArgs e)
        {
            if (this.selectDeviceDialog != null)
                return;

            this.selectDeviceDialog = new SelectDeviceDialog(this.keyboardManager);
            this.selectDeviceDialog.ShowDialog();

            if (this.selectDeviceDialog.SelectedDevice != -1)
            {
                this.keyboardManager.Initialize(this.selectDeviceDialog.SelectedDevice);
                this.keyboardManager.Start();
            }

            this.selectDeviceDialog.Close();
            this.selectDeviceDialog = null;
        }
    }
}