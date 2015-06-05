using Microsoft.Deployment.WindowsInstaller;
using System;
using System.IO;

namespace Wix.CustomActions
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CloseIt(Session session)
        {
            try
            {
                string fileFullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CustomAction.txt");

                if (!File.Exists(fileFullPath))
                    File.Create(fileFullPath);

                File.AppendAllText(fileFullPath, string.Format("{0}Yes, we have a hit at {1}", Environment.NewLine, DateTime.Now));

                session.Log("Close DotTray!");
            }
            catch (Exception ex)
            {
                session.Log("ERROR in custom action CloseIt {0}", ex.ToString());
                return ActionResult.Failure;
            }

            return ActionResult.Success;
        }
    }
}