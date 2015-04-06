using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;

namespace OutlookTaskPaneSpike
{
    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/bb296010.aspx
    /// </summary>
    public partial class ThisAddIn
    {
        private Inspectors inspectors;

        public Dictionary<Inspector, InspectorWrapper> InspectorWrappers { get; private set; }

        private void Inspectors_NewInspector(Inspector Inspector)
        {
            if (Inspector.CurrentItem is MailItem)
            {
                InspectorWrappers.Add(Inspector, new InspectorWrapper(Inspector));
            }
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
            inspectors.NewInspector -= Inspectors_NewInspector;
            inspectors = null;
            InspectorWrappers = null;
        }

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            InspectorWrappers = new Dictionary<Inspector, InspectorWrapper>();

            inspectors = Application.Inspectors;
            inspectors.NewInspector += Inspectors_NewInspector;

            foreach (Inspector inspector in inspectors)
            {
                Inspectors_NewInspector(inspector);
            }
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            Startup += ThisAddIn_Startup;
            Shutdown += ThisAddIn_Shutdown;
        }

        #endregion VSTO generated code
    }
}