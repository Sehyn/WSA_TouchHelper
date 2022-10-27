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
            MessageBox.Show("The hotkey to get the cursor position is: F3\nPut the X value into the X Text field\nPut the Y value into the Y Text field\nDo this for as much spells you'd like to add/use.", "Information");
            InitializeKeyboardHook(); //calls the method beneath to init the Hook
            X1.Text = Convert.ToString(Properties.Settings.Default.X1);
            X2.Text = Convert.ToString(Properties.Settings.Default.X2);
            X3.Text = Convert.ToString(Properties.Settings.Default.X3);
            X4.Text = Convert.ToString(Properties.Settings.Default.X4);
            X5.Text = Convert.ToString(Properties.Settings.Default.X5);
            X6.Text = Convert.ToString(Properties.Settings.Default.X6);
            Y1.Text = Convert.ToString(Properties.Settings.Default.Y1);
            Y2.Text = Convert.ToString(Properties.Settings.Default.Y2);
            Y3.Text = Convert.ToString(Properties.Settings.Default.Y3);
            Y4.Text = Convert.ToString(Properties.Settings.Default.Y4);
            Y5.Text = Convert.ToString(Properties.Settings.Default.Y5);
            Y6.Text = Convert.ToString(Properties.Settings.Default.Y6);


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

            if (pressedKey == Keys.F1)
            {
                Utilities.LoggerInfo("F1 -> Showing Window");        
                IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                ForegroundWindowBypass.Set(hWnd);

            }
            if (pressedKey == Keys.D1)
            {
                Utilities.LoggerInfo("F2 -> Clicking to");
                Console.WriteLine("X : " + X1.Text);
                Console.WriteLine("Y : " + Y1.Text);
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
                Utilities.LoggerInfo("F4 -> Clicking to");
                Console.WriteLine("X : " + X1.Text);
                Console.WriteLine("Y : " + Y1.Text);
                IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                ForegroundWindowBypass.Set(hWnd);
                Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X2.Text), Convert.ToInt32(Y2.Text)));
                Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X2.Text), Convert.ToInt32(Y2.Text)));


            }
            if (pressedKey == Keys.F5)
            {
                Utilities.LoggerInfo("F5 -> Clicking to");
                Console.WriteLine("X : " + X1.Text);
                Console.WriteLine("Y : " + Y1.Text);
                IntPtr hWnd = Native.FindWindow(null, "DOFUS Touch");
                ForegroundWindowBypass.Set(hWnd);
                Native.PostMessage(hWnd, Native.WM_LBUTTONDOWN, 1, Native.MakeLParam(Convert.ToInt32(X3.Text), Convert.ToInt32(Y3.Text)));
                Native.PostMessage(hWnd, Native.WM_LBUTTONUP, 0, Native.MakeLParam(Convert.ToInt32(X3.Text), Convert.ToInt32(Y3.Text)));


            }

        }

        private void BtnSaveCoordinates_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.X1 = Convert.ToInt32(X1.Text);
            Properties.Settings.Default.X2 = Convert.ToInt32(X2.Text);
            Properties.Settings.Default.X3 = Convert.ToInt32(X3.Text);
            Properties.Settings.Default.X4 = Convert.ToInt32(X4.Text);
            Properties.Settings.Default.X5 = Convert.ToInt32(X5.Text);
            Properties.Settings.Default.X6 = Convert.ToInt32(X6.Text);
            Properties.Settings.Default.Y1 = Convert.ToInt32(Y1.Text);
            Properties.Settings.Default.Y2 = Convert.ToInt32(Y2.Text);
            Properties.Settings.Default.Y3 = Convert.ToInt32(Y3.Text);
            Properties.Settings.Default.Y4 = Convert.ToInt32(Y4.Text);
            Properties.Settings.Default.Y5 = Convert.ToInt32(Y5.Text);
            Properties.Settings.Default.Y6 = Convert.ToInt32(Y6.Text);
            Properties.Settings.Default.Save();
        }
    }
}
