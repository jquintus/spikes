using System;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools;

namespace OutlookTaskPaneSpike
{
    public  class ExplorerWrapper
    {
        private static int _count = 1;
        private Explorer _explorer;
        private CustomTaskPane taskPane;

        public ExplorerWrapper(Explorer explorer)
        {
            _explorer = explorer;
            ((ExplorerEvents_Event)_explorer).Close += ExplorerWrapper_Close;

            taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(new TaskPaneControl("Explorer", _count++), "My task pane", _explorer);
            taskPane.VisibleChanged += TaskPane_VisibleChanged;
        }

        public CustomTaskPane CustomTaskPane { get { return taskPane; } }

        private void ExplorerWrapper_Close()
        {
            if (taskPane != null)
            {
                Globals.ThisAddIn.CustomTaskPanes.Remove(taskPane);
            }

            taskPane = null;
            Globals.ThisAddIn.ExplorerWrappers.Remove(_explorer);

            ((ExplorerEvents_Event)_explorer).Close -= ExplorerWrapper_Close;

            _explorer = null;
        }

        private void TaskPane_VisibleChanged(object sender, EventArgs e)
        {
            Globals.Ribbons[_explorer].ManageTaskPaneRibbon.toggleButton1.Checked = taskPane.Visible;
        }
    }
}
