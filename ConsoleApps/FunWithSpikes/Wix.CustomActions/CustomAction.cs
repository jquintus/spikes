using System;
using Microsoft.Deployment.WindowsInstaller;

namespace Wix.CustomActions
{
    using System.IO;

    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CloseIt(Session session)
        {
            try
            {
                const string fileFullPath = @"c:\KensCustomAction.txt";

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
