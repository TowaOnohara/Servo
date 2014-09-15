using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;

namespace Servo
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");

            // 7番ピンを使用します。
            //----------------------
            GT.Interfaces.PWMOutput servo = this.extender.SetupPWMOutput(GT.Socket.Pin.Seven);//must be pin 7,8,9

            // アクティブ化
            //----------------------
            servo.Active = true;

            // サーボ回転
            //----------------------
            while (1 == 1)
            {
                // 0°~60° の範囲で回転させます。
                for (UInt32 hightime = 500; hightime <= 2000; hightime += 72)
                {
                    //------------ 周期:20msec --- パルス幅:0.5msec～2msec -------
                    servo.SetPulse(20 * 1000 * 1000, hightime * 1000);      // パルス幅の変更（0°：500 ~ 60°：2000）
                    Debug.Print("High Time= " + hightime.ToString());
                    System.Threading.Thread.Sleep(100);
                }
            }
        }
    }
}
