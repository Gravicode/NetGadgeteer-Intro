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

namespace GadgeteerApp1
{
    public partial class Program
    {
        // This method is run when the mainboard is powered up or reset.   
        void ProgramStarted()
        {
            GT.Timer timer = new GT.Timer(200); // every second (1000ms)
            timer.Tick += timer_Tick;
            timer.Start();

            // Use Debug.Print to show messages in Visual Studio's "Output" window during debugging.
            Debug.Print("Program Started");
        }

        void timer_Tick(GT.Timer timer)
        {
            Debug.Print("light :" + lightSense.GetIlluminance());
            Debug.Print("posisi :" + joystick.GetPosition().X + "," + joystick.GetPosition().Y);
            Joystick.Position pos = joystick.GetPosition();
            double illuminance = lightSense.GetIlluminance();
            if (pos.X < -0.5 && System.Math.Abs(pos.Y) < 0.2)
            {
                //kiri                
                led7R.TurnLedOn(0);
            }
            else if (pos.X > 0.5 && System.Math.Abs(pos.Y) < 0.2)
            {
                //kanan
                led7R.TurnLedOn(3);
            }
            else if (pos.Y < -0.5 && System.Math.Abs(pos.X) < 0.2)
            {
                //atas
                led7R.TurnLedOn(4);
                led7R.TurnLedOn(5);
            }
            else if (pos.Y > 0.5 && System.Math.Abs(pos.X) < 0.2)
            {
                //bawah
                led7R.TurnLedOn(1);
                led7R.TurnLedOn(2);
            }
            else
            {
                double Cahaya = lightSense.ReadProportion();
                int rotasi = 50 + (int)(200 * Cahaya);
                led7R.Animate(rotasi, true, true, false);

            }

        }

    }
}
