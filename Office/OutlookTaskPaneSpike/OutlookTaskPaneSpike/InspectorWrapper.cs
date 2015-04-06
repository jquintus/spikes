using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools;
using System;

namespace OutlookTaskPaneSpike
{
    public class InspectorWrapper
    {
        private static int _count = 1;
        private Inspector inspector;
        private CustomTaskPane taskPane;

        public InspectorWrapper(Inspector Inspector)
        {
            inspector = Inspector;
            ((InspectorEvents_Event)inspector).Close += InspectorWrapper_Close;

            taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(new TaskPaneControl("Inspector", _count++), "My task pane", inspector);
            taskPane.VisibleChanged += TaskPane_VisibleChanged;
            taskPane.Visible = true;
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
            var ribbon = Globals.Ribbons[inspector].ManageTaskPaneRibbon;
            if (ribbon != null)
                ribbon.toggleButton1.Checked = taskPane.Visible;
        }
    }
}