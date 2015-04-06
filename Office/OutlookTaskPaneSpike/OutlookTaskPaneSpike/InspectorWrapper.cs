using System;
using Microsoft.Office.Tools;

namespace OutlookTaskPaneSpike
{
    public class InspectorWrapper
    {
        private Microsoft.Office.Interop.Outlook.Inspector inspector;
        private CustomTaskPane taskPane;

        public InspectorWrapper(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {
            inspector = Inspector;
            ((Microsoft.Office.Interop.Outlook.InspectorEvents_Event)inspector).Close +=
                new Microsoft.Office.Interop.Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);

            taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(
                new TaskPaneControl(), "My task pane", inspector);
            taskPane.VisibleChanged += new EventHandler(TaskPane_VisibleChanged);
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

            ((Microsoft.Office.Interop.Outlook.InspectorEvents_Event)inspector).Close -=
                new Microsoft.Office.Interop.Outlook.InspectorEvents_CloseEventHandler(InspectorWrapper_Close);

            inspector = null;
        }

        private void TaskPane_VisibleChanged(object sender, EventArgs e)
        {
            Globals.Ribbons[inspector].ManageTaskPaneRibbon.toggleButton1.Checked =
                taskPane.Visible;
        }
    }
}