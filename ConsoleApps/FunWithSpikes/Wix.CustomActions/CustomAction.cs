using System;
using Microsoft.Deployment.WindowsInstaller;

namespace Wix.CustomActions
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CloseIt(Session session)
        {
            try
            {
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
