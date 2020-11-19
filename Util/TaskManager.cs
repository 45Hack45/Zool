using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Zool.Util
{
    enum TaskCompletion
    {
        none = 0,
        Canceled =  -2,
        Fault =     -1,
        Success =   1
    }
    class TaskManager
    {
        public static TaskCompletion CheckTask(string operation, Task task)
        {
            TaskCompletion completed = 0;

            if (task.IsCanceled)
            {
                completed = TaskCompletion.Canceled;
                DebugLog.shortMSG("ERROR: " + operation + " task Canceled");
            }
            else if (task.IsFaulted)
            {
                completed = TaskCompletion.Fault;
                DebugLog.shortMSG("ERROR: " + operation + " task Failed");
            }
            else if (task.IsCompletedSuccessfully)
            {
                completed = TaskCompletion.Success;
            }

            return completed;
        }
    }
}