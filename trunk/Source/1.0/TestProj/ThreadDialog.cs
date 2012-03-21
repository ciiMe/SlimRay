using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

using System.Windows.Forms;

namespace TestProj
{
  public static  class ThreadDialog
    {
      public static bool CloseFlag = false;

      public static void ShowForm(object sender)
      {
          Form2 frm = new Form2();

          frm.ShowDialog();
      }

      public static void NewThread()
      {
          Thread t = new Thread(new ParameterizedThreadStart(ShowForm));

          t.Start(); 
      }
    }
}
