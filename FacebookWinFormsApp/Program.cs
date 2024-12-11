using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <remarks>
        /// Submission Document Link:
        /// https://docs.google.com/document/d/1br6p_AzEXO-xRv8oDST8yZp-QIbCjZ4_0fmskwSslOg/edit?usp=sharing
        /// </remarks>
        [STAThread]
        static void Main()
        {
            Clipboard.SetText("design.patterns20cc");
            FacebookService.s_UseForamttedToStrings = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
