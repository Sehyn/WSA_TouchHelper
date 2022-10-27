using MouseKeyboardLibrary;
using System;

using System.Windows.Forms;

namespace WSA_TouchHelper
{
   
    public partial class Main : Form
    {
       

        private KeyboardHook _keyboardHook;
      
        public Main()
        {
            InitializeComponent();
            InitializeKeyboardHook(); //calls the method beneath to init the Hook

        }
        private void InitializeKeyboardHook()
        {
            _keyboardHook = new KeyboardHook(); //initialize
            _keyboardHook.KeyUp += new KeyEventHandler(HandleKeyUp); //assign event: when a key gets pressed, call this method
            _keyboardHook.Start();
        }

        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            //this gets called automatically by the KeyboardHook when ANY key is released
            // e contains the event information
            var pressedKey = e.KeyCode;

            /*
            It would be better practice to use a "switch statement" (https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/switch)
            instead of if and else here, but I kept it like that.
            */

            if (pressedKey == Keys.F9)
            {
                Utilities.LoggerInfo("F9 -> Showing Window");
        
                IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");

                ForegroundWindowBypass.Set(hWnd);

            }
            if (pressedKey == Keys.F2)
            {
                Utilities.LoggerInfo("F2 -> Clicking to");

                IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");

                ForegroundWindowBypass.Set(hWnd);
                Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X1.Text), Convert.ToInt32(Y1.Text)));
                Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X1.Text), Convert.ToInt32(Y1.Text)));


            }
            if (pressedKey == Keys.F3)
            {
                Utilities.LoggerInfo("F3 -> CursorPos:" );

                IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");

                ForegroundWindowBypass.Set(hWnd);
                Native.POINT lpPoint;
                Native.GetCursorPos(out lpPoint);
                Native.ScreenToClient(hWnd, ref lpPoint);
                Console.WriteLine("X : " + lpPoint.X);
                Console.WriteLine("Y : " + lpPoint.Y);

            }
            if (pressedKey == Keys.F4)
            {
                Utilities.LoggerInfo("F4 -> Clicking to:");
                Console.WriteLine("X : " + X2.Text);
                Console.WriteLine("Y : " + Y2.Text);

                IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");

                ForegroundWindowBypass.Set(hWnd);
                Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X1.Text), Convert.ToInt32(Y1.Text)));
                Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X1.Text), Convert.ToInt32(Y1.Text)));


            }

        }
    }
}
