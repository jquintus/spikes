using System;
using Microsoft.Office.Tools;
using Microsoft.Office.Interop.Outlook;

namespace OutlookTaskPaneSpike
{
    public class InspectorWrapper
    {
        private Inspector inspector;
        private CustomTaskPane taskPane;

        public InspectorWrapper(Inspector Inspector)
        {
            inspector = Inspector;
            ((InspectorEvents_Event)inspector).Close += InspectorWrapper_Close;

            taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(new TaskPaneControl(), "My task pane", inspector);
            taskPane.VisibleChanged += TaskPane_VisibleChanged;
        }

        public CustomTaskPane CustomTaskPane { get { return taskPane; } }

        private void InspectorWrapper_Close()
        {
            if (taskPane != null)
            {
                Globals.ThisAddIn.CustomTaskPanes.Remove(taskPane);
            }

            taskPane = null;
            Globals.ThisAddIn.InspectorWrappers.Remove(inspector);

            ((InspectorEvents_Event)inspector).Close -= InspectorWrapper_Close;

            inspector = null;
        }

        private void TaskPane_VisibleChanged(object sender, EventArgs e)
        {
            Globals.Ribbons[inspector].ManageTaskPaneRibbon.toggleButton1.Checked = taskPane.Visible;
        }
    }
}