using System.Windows.Forms;

namespace OutlookTaskPaneSpike
{
    public partial class TaskPaneControl : UserControl
    {
        public TaskPaneControl(string name, int id)
        {
            InitializeComponent();
            label1.Text = string.Format("{0} -  {1} is awesome", name, id);
        }
    }
}