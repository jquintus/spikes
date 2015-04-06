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
        private Explorers explorers;

        public Dictionary<Inspector, InspectorWrapper> InspectorWrappers { get; private set; }
        public Dictionary<Explorer, ExplorerWrapper> ExplorerWrappers { get; private set; }

        private void NewInspector(Inspector Inspector)
        {
            if (Inspector.CurrentItem is MailItem)
            {
                InspectorWrappers.Add(Inspector, new InspectorWrapper(Inspector));
            }
        }

        private void NewExplorer(Explorer explorer)
        {
            ExplorerWrappers.Add(explorer, new ExplorerWrapper(explorer));
        }


        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
            inspectors.NewInspector -= NewInspector;
            inspectors = null;
            InspectorWrappers = null;

            explorers.NewExplorer -= NewExplorer;
            explorers = null;
            ExplorerWrappers = null;
        }

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            InspectorWrappers = new Dictionary<Inspector, InspectorWrapper>();
            ExplorerWrappers = new Dictionary<Explorer, ExplorerWrapper>();

            inspectors = Application.Inspectors;
            inspectors.NewInspector += NewInspector;

            foreach (Inspector inspector in inspectors)
            {
                NewInspector(inspector);
            }

            explorers = Application.Explorers;
            explorers.NewExplorer += NewExplorer;

            foreach (Explorer explorer in explorers)
            {
                NewExplorer(explorer);
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
