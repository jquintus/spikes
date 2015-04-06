using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools;
using Microsoft.Office.Tools.Ribbon;

namespace OutlookTaskPaneSpike
{
    public partial class ManageTaskPaneRibbon
    {
        private void ManageTaskPaneRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void toggleButton1_Click(object sender, RibbonControlEventArgs e)
        {
            ToggleInspector(sender as RibbonToggleButton, e.Control.Context as Inspector);
            ToggleExplorer(sender as RibbonToggleButton, e.Control.Context as Explorer);
        }

        private void ToggleExplorer(RibbonToggleButton button, Explorer explorer)
        {
            if (explorer == null) return;
            var inspectorWrapper = Globals.ThisAddIn.ExplorerWrappers[explorer];
            CustomTaskPane taskPane = inspectorWrapper.CustomTaskPane;
            if (taskPane != null)
            {
                taskPane.Visible = button.Checked;
            }
        }

        private void ToggleInspector(RibbonToggleButton button, Inspector inspector)
        {
            if (inspector == null) return;
            var inspectorWrapper = Globals.ThisAddIn.InspectorWrappers[inspector];
            CustomTaskPane taskPane = inspectorWrapper.CustomTaskPane;
            if (taskPane != null)
            {
                taskPane.Visible = button.Checked;
            }
        }
    }
}