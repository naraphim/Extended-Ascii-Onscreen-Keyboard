using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace Keyboard_1
{
    public partial class Onscreen_Keyboard : Form
    {
        // splice 1 - to allow the form to be moved even though it has no window tab
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);


        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        
        // splice 2 - to prevent this form from ever getting focus - prevents a flickering artifact when typing caused by the focus shifting from the keyboard to the open window
        private const int WS_EX_NOACTIVATE = 0x08000000;
        //private const int WS_EX_APPWINDOW = 0x00040000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                //createParams.ExStyle |= WS_EX_APPWINDOW;// splice 3 //////////////////////////////////////////// 
                createParams.ExStyle |= WS_EX_NOACTIVATE;
                return createParams;
            }
        }
        
        //[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        //public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        Onscreen_Arrows Arrows1 = new Onscreen_Arrows();

        public Onscreen_Keyboard()
        {
            InitializeComponent();
        }

        private void Onscreen_Keyboard_Load(object sender, EventArgs e)
        {
            
            this.Icon = global::Keyboard_1.Properties.Resources.Memon;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height;
            this.Location = new Point(((Screen.PrimaryScreen.WorkingArea.Width) - BackEnd.WIDTH), ((Screen.PrimaryScreen.WorkingArea.Bottom) - BackEnd.ARROWSHEIGHT - BackEnd.HEIGHT));
            this.ShowInTaskbar = false;
            
            if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
            {
                BackEnd.capitalizationState = true;
            }
            else if (!Control.IsKeyLocked(Keys.CapsLock)) // lower case
            {
                BackEnd.capitalizationState = false;
            }

            Arrows1.Location = new Point(((Screen.PrimaryScreen.Bounds.Width) - BackEnd.ARROWSWIDTH), ((Screen.PrimaryScreen.WorkingArea.Height) - BackEnd.ARROWSHEIGHT));         
            Arrows1.TopMost = true;
            Arrows1.ShowInTaskbar = false;
            Arrows1.Show();
        }

        private void Onscreen_Keyboard_MouseDown(object sender, MouseEventArgs e)
        {
            this.TopMost = true;

            string colorHexString = ColorTranslator.ToHtml(BackEnd.mask.GetPixel(e.X, e.Y));
            

            if (e.Button == MouseButtons.Left)
            {
                if (colorHexString.Equals("#000000")) // IF your not "pressing a button" then you can move the form around the screen. (left mouse down is not detected in an x,y coordinate where a color is detected on the mask bitmap.)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                    Invalidate();
                }

                // 01
                else if (colorHexString.Equals("#FCFCFC")) // Button for (pholim/Open_Bracket)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Open_Bracket;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_4); //Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '[{' key
                        WindowsInput.InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.pholimDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_0);
                    }
                    

                }

                // 02
                else if (colorHexString.Equals("#F9F9F9")) // Button for jyam
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Jyam;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_J);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.jyamDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_J);
                    }
                }

                // 03
                else if (colorHexString.Equals("#F6F6F6")) // Button for jzhad
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Jzhad;
                        Refresh();
                        UInt16 scanCode = 194;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.jzhadDown;
                        Refresh();
                        UInt16 scanCode = 195;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }

                }

                // 04
                else if (colorHexString.Equals("#F3F3F3")) // Button for (nexus/Close_Bracket)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Closed_Bracket;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_6); //Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '[{' key
                        WindowsInput.InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.nexusDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_1);
                    }
                }

                // 05
                else if (colorHexString.Equals("#F0F0F0")) // Button for kehta
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Kehta;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_K);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.kehtaDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_K);
                    }
                }

                // 06
                else if (colorHexString.Equals("#EDEDED")) // Button for ader
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Ader;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_A);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.aderDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_A);
                    }
                }

                // 07
                else if (colorHexString.Equals("#EAEAEA")) // Button for alna
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Alna;
                        Refresh();
                        UInt16 scanCode = 196;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.alnaDown;
                        Refresh();
                        UInt16 scanCode = 197;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 08
                else if (colorHexString.Equals("#E7E7E7")) // Button for (thatus/Percent_Sign)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Percent_Sign;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_5); // num key + shift yields a region specific value - for North American keyboards shift+5 = %
                        WindowsInput.InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.thatusDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_2);
                    }
                }

                // 09
                else if (colorHexString.Equals("#E4E4E4")) // Button for amien
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Amien;
                        Refresh();
                        UInt16 scanCode = 198;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.amienDown;
                        Refresh();
                        UInt16 scanCode = 199;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 10
                else if (colorHexString.Equals("#E1E1E1")) // Button for athus
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Athus;
                        Refresh();
                        UInt16 scanCode = 200;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.athusDown;
                        Refresh();
                        UInt16 scanCode = 201;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 11
                else if (colorHexString.Equals("#DEDEDE")) // Button for haxt
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Haxt;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_H);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.haxtDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_H);
                    }
                }

                // 12
                else if (colorHexString.Equals("#DBDBDB")) // Button for (venik/Bar)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Bar;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_5); //Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '\|' key
                        WindowsInput.InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.venikDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_3);
                    }
                }

                // 13
                else if (colorHexString.Equals("#D8D8D8")) // Button for harux
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Harux;
                        Refresh();
                        UInt16 scanCode = 202;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.haruxDown;
                        Refresh();
                        UInt16 scanCode = 203;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 14
                else if (colorHexString.Equals("#D5D5D5")) // Button for ra
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Ra;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_R);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.raDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_R);
                    }
                }

                // 15
                else if (colorHexString.Equals("#D2D2D2")) // Button for ren
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Ren;
                        Refresh();
                        UInt16 scanCode = 204;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.renDown;
                        Refresh();
                        UInt16 scanCode = 205;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 16
                else if (colorHexString.Equals("#CFCFCF")) // Button for ris
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Ris;
                        Refresh();
                        UInt16 scanCode = 206;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.risDown;
                        Refresh();
                        UInt16 scanCode = 207;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 17
                else if (colorHexString.Equals("#CCCCCC")) // Button for (barim/Under_Score)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Under_Score;
                        Refresh();
                        UInt16 scanCode = 95; // this might be the best way of sending ALL characters but this also hasnt been determined for certain (using differen region's keyboard hardware and different Operating Systems)
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);  // this is not using the OEM specific code to render "_" because it is unclear what the appropriate VirtualKeyCode is for "_"
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.barimDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_4);
                    }
                }

                // 18
                else if (colorHexString.Equals("#C9C9C9")) // Button for barta
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Barta;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_B);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.bartaDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_B);
                    }
                }

                // 19
                else if (colorHexString.Equals("#C6C6C6")) // Button for seto
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Seto;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_C);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.setoDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_C);
                    }
                }

                // 20
                else if (colorHexString.Equals("#C3C3C3")) // Button for karthon
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Karthon;
                        Refresh();
                        UInt16 scanCode = 208;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.karthonDown;
                        Refresh();
                        UInt16 scanCode = 209;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 21
                else if (colorHexString.Equals("#C0C0C0")) // Button for dolus
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Dolus;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_D);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.dolusDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_D);
                    }
                }

                // 22
                else if (colorHexString.Equals("#BDBDBD")) // Button for (jensis/Tilda)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps 
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Tilda;
                        Refresh();
                        UInt16 scanCode = 126;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                        //WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_3); // Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '`~' key
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.jensisDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_5);
                    }
                }

                // 23
                else if (colorHexString.Equals("#BABABA")) // Button for gamin
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Gamin;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_G);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.gaminDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_G);
                    }
                }

                // 24
                else if (colorHexString.Equals("#B7B7B7")) // Button for payter
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Payter;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_P);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.payterDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_P);
                    }
                }

                // 25
                else if (colorHexString.Equals("#B4B4B4")) // Button for toma
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Toma;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_T);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.tomaDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_T);
                    }
                }

                // 26
                else if (colorHexString.Equals("#B1B1B1")) // Button for tris
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Tris;
                        Refresh();
                        UInt16 scanCode = 210;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.trisDown;
                        Refresh();
                        UInt16 scanCode = 211;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 27
                else if (colorHexString.Equals("#AEAEAE")) // Button for tyel
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Tyel;
                        Refresh();
                        UInt16 scanCode = 212;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.tyelDown;
                        Refresh();
                        UInt16 scanCode = 213;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 28
                else if (colorHexString.Equals("#ABABAB")) // Button for vex
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Vex;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_V);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.vexDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_V);
                    }
                }

                // 29
                else if (colorHexString.Equals("#A8A8A8")) // Button for azium
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Azium;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Z);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.aziumDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Z);
                    }
                }

                // 30
                else if (colorHexString.Equals("#A5A5A5")) // Button for efelid
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Efelid;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_E);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.efelidDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_E);
                    }
                }

                // 31
                else if (colorHexString.Equals("#A2A2A2")) // Button for esis
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Esis;
                        Refresh();
                        UInt16 scanCode = 214;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.esisDown;
                        Refresh();
                        UInt16 scanCode = 215;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    };
                }

                // 32
                else if (colorHexString.Equals("#9F9F9F")) // Button for fearon
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Fearon;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_F);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.fearonDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_F);
                    }
                }

                // 33
                else if (colorHexString.Equals("#9C9C9C")) // Button for lodus
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Lodus;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_L);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.lodusDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_L);
                    }
                }

                // 34
                else if (colorHexString.Equals("#999999")) // Button for memon
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Memon;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_M);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.memonDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_M);
                    }
                }

                // 35
                else if (colorHexString.Equals("#969696")) // Button for nefron
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Nefron;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_N);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.nefronDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_N);
                    }
                }

                // 36
                else if (colorHexString.Equals("#939393")) // Button for nonum
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Nonum;
                        Refresh();
                        UInt16 scanCode = 216;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.nonumDown;
                        Refresh();
                        UInt16 scanCode = 217;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 37
                else if (colorHexString.Equals("#909090")) // Button for sola
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Sola;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_S);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.solaDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_S);
                    }
                }

                // 38
                else if (colorHexString.Equals("#8D8D8D")) // Button for diamond (Spacebar)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Diamond;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.SPACE);
                    }
                    else // lowerBackEnd.keyDownCanvas
                    {
                        BackEnd.keyDownCanvas = BackEnd.diamondDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.SPACE);
                    }
                }

                // 39
                else if (colorHexString.Equals("#8A8A8A")) // Button for suden
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Suden;
                        Refresh();
                        UInt16 scanCode = 218;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.sudenDown;
                        Refresh();
                        UInt16 scanCode = 219;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 40
                else if (colorHexString.Equals("#878787")) // Button for exo
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Exo;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_X);
                    }
                    else // lower
                    {
                        BackEnd.keyDownCanvas = BackEnd.exoDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_X);
                    }
                }

                // 41
                else if (colorHexString.Equals("#848484")) // Button for ilunum
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Ilunum;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_I);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.ilunumDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_I);
                    }
                }

                // 42
                else if (colorHexString.Equals("#818181")) // Button for ixium
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Ixium;
                        Refresh();
                        UInt16 scanCode = 220;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.ixiumDown;
                        Refresh();
                        UInt16 scanCode = 221;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 43
                else if (colorHexString.Equals("#7E7E7E")) // Button for oberon
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Oberon;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_O);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.oberonDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_O);
                    }
                }

                // 44
                else if (colorHexString.Equals("#7B7B7B")) // Button for (odium/Equals) //OEM_PLUS
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Equals;
                        Refresh();
                        UInt16 scanCode = 61; // Cannot yet determine if there is a VirtualKeyCode for "Equals"
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.odiumDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_6);
                    }
                }

                // 45
                else if (colorHexString.Equals("#787878")) // Button for (comma/Open_Pointed_Bracket)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Open_Pointed_Bracket;
                        Refresh();
                        UInt16 scanCode = 60; // Cannot yet determine if there is a VirtualKeyCode for "Open_Pointed_Bracket"
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.commaDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_COMMA);
                    }
                }

                // 46
                else if (colorHexString.Equals("#757575")) // Button for ocillum
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Ocillum;
                        Refresh();
                        UInt16 scanCode = 222;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.ocillumDown;
                        Refresh();
                        UInt16 scanCode = 223;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 47
                else if (colorHexString.Equals("#727272")) // Button for ojium
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Ojium;
                        Refresh();
                        UInt16 scanCode = 224;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.ojiumDown;
                        Refresh();
                        UInt16 scanCode = 225;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 48
                else if (colorHexString.Equals("#6F6F6F")) // Button for opsen
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Opsen;
                        Refresh();
                        UInt16 scanCode = 226;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.opsenDown;
                        Refresh();
                        UInt16 scanCode = 227;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 49
                else if (colorHexString.Equals("#6C6C6C")) // Button for ortheks
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Ortheks;
                        Refresh();
                        UInt16 scanCode = 228;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.ortheksDown;
                        Refresh();
                        UInt16 scanCode = 229;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 50
                else if (colorHexString.Equals("#696969")) // Button for (parsus/Plus)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Plus;
                        Refresh();
                        UInt16 scanCode = 43;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.parsusDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_7);
                    }
                }

                // 51
                else if (colorHexString.Equals("#666666")) // Button for (period/>)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Close_Pointed_Bracket;
                        Refresh();
                        UInt16 scanCode = 62;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.periodDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_PERIOD);
                    }
                }

                // 52
                else if (colorHexString.Equals("#636363")) // Button for kanora
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Kanora;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Q);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.kanoraDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Q);
                    }
                }

                // 53
                else if (colorHexString.Equals("#606060")) // Button for wiron
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Wiron;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_W);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.wironDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_W);
                    }
                }

                // 54
                else if (colorHexString.Equals("#5D5D5D")) // Button for urna
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Urna;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.urnaDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U);
                    }
                }

                // 55
                else if (colorHexString.Equals("#5A5A5A")) // Button for (chrism/minus)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Minus;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_MINUS);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.chrismDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_8);
                    }
                }

                // 56
                else if (colorHexString.Equals("#575757")) // Button for (antagonisticClitic/Open_Parenthesis)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Open_Parenthesis;
                        Refresh();
                        UInt16 scanCode = 40;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.antagonisticCliticDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_2); // Question Mark Key
                        WindowsInput.InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
                    }
                }

                // 57
                else if (colorHexString.Equals("#545454")) // Button for usis
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Usis;
                        Refresh();
                        UInt16 scanCode = 230;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.usisDown;
                        Refresh();
                        UInt16 scanCode = 231;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 58
                else if (colorHexString.Equals("#515151")) // Button for uviel
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Uviel;
                        Refresh();
                        UInt16 scanCode = 232;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.uvielDown;
                        Refresh();
                        UInt16 scanCode = 233;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 59
                else if (colorHexString.Equals("#4E4E4E")) // Button for uzionDown
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Uzion;
                        Refresh();
                        UInt16 scanCode = 234;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else // Small
                    {
                        BackEnd.keyDownCanvas = BackEnd.uzionDown;
                        Refresh();
                        UInt16 scanCode = 235;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 60
                else if (colorHexString.Equals("#4B4B4B")) // Button for (dexin/Asterix)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Asterix;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.MULTIPLY); // check to see if this produces an asterix
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.dexinDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_9);
                    }
                }

                // 61
                else if (colorHexString.Equals("#484848")) // Button for (cooperativeClitic/Close_Parenthesis)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Close_Parenthesis;
                        Refresh();
                        UInt16 scanCode = 41;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.cooperativeCliticDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_1);
                        WindowsInput.InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
                    }
                }

                // 62
                else if (colorHexString.Equals("#454545")) // Button for yalta
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Yalta;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Y);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.yaltaDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Y);
                    }
                }

                // 63
                else if (colorHexString.Equals("#424242")) // Button for backspace
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Backspace;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.BACK);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.backspaceDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.BACK);
                    }
                }

                // 64
                else if (colorHexString.Equals("#3F3F3F")) // Button for (eshna/Forward_Slash)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Forward_Slash;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_2);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.eshnaDown;
                        Refresh();
                        UInt16 scanCode = 192;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 65
                else if (colorHexString.Equals("#3C3C3C")) // Button for (clitic/Open_Square_Bracket)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Open_Square_Bracket;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_4);  // Used for miscellaneous characters; it can vary by keyboard. Windows 2000/XP: For the US standard keyboard, the '[{' key
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.cliticDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_7); // For the US standard keyboard, the 'single-quote/double-quote' key
                    }
                }

                // 66
                else if (colorHexString.Equals("#393939")) // Button for circle
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Circle;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.CAPITAL);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.circleDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.CAPITAL);
                    }
                }

                // 67
                else if (colorHexString.Equals("#363636")) // Button for delete
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Delete;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.DELETE);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.deleteDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.DELETE);
                    }
                }

                // 68
                else if (colorHexString.Equals("#333333")) // Button for (yamen/Backward_Slash)
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Backward_Slash;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_5);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.yamenDown;
                        Refresh();
                        UInt16 scanCode = 193;
                        WindowsInput.InputSimulator.SimulateKeyPressViaScanCode(scanCode);
                    }
                }

                // 69
                else if (colorHexString.Equals("#303030")) // Button for dualClitic
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Close_Square_Bracket;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_6);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.dualCliticDown;
                        Refresh();
                        //quotation marks
                        WindowsInput.InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.OEM_7); // For the US standard keyboard, the 'single-quote/double-quote' key
                        WindowsInput.InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
                    }
                }

                // 70
                else if (colorHexString.Equals("#2D2D2D")) // Button for square
                {
                    if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
                    {
                        BackEnd.keyDownCanvas = BackEnd.capital_KeyDown_Square;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN);
                    }
                    else
                    {
                        BackEnd.keyDownCanvas = BackEnd.squareDown;
                        Refresh();
                        WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN);
                    }
                }
            }
        }

        private void Onscreen_Keyboard_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BackEnd.keyDownCanvas = BackEnd.blankCanvas;
                Refresh();

            } // if
        }

        private void Onscreen_Keyboard_Paint(object sender, PaintEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock)) // Caps
            {
                e.Graphics.DrawImage(BackEnd.capitalKeysUp, 0, 0, BackEnd.WIDTH, BackEnd.HEIGHT);
            }
            else 
            {
                e.Graphics.DrawImage(BackEnd.allKeysUp, 0, 0, BackEnd.WIDTH, BackEnd.HEIGHT);
            }
            e.Graphics.DrawImage(BackEnd.keyDownCanvas, 0, 0, BackEnd.WIDTH, BackEnd.HEIGHT);
            e.Graphics.DrawImage(BackEnd.keyHoverCanvas, 0, 0, BackEnd.WIDTH, BackEnd.HEIGHT);
        }

        private void Onscreen_Keyboard_MouseMove(object sender, MouseEventArgs e)
        {
            int move_X = e.X;
            int move_y = e.Y;
            if (0 < move_X && move_X < this.Width && 0 < move_y && move_y < this.Height) //??
            {
                //string sampledColorC1HexString = ColorTranslator.ToHtml(BackEnd.mask.GetPixel(move_X, move_y)); // make an exception handler for out of bounds value
                try
                {
                    Color c1 = BackEnd.mask.GetPixel(move_X, move_y);
                    string sampledColorC1HexString = ColorTranslator.ToHtml(c1);
                    //label1.Text = String.Format("{0}, {1}, {2}", move_X, move_y, sampledColorC1HexString);

                    if (!sampledColorC1HexString.Equals(BackEnd.currentHoverColor))
                    {
                        BackEnd.currentHoverColor = sampledColorC1HexString;

                        if (sampledColorC1HexString.Equals("#000000")) // IF you are not hovering over any button
                        {
                            BackEnd.keyHoverCanvas = BackEnd.blankCanvas;
                            Invalidate();
                        }

                        // 01
                        else if (sampledColorC1HexString.Equals("#FCFCFC")) // Button for pholim
                        {
                            BackEnd.keyHoverCanvas = BackEnd.pholimHover;
                            Refresh();
                        }

                        // 02
                        else if (sampledColorC1HexString.Equals("#F9F9F9")) // Button for jyam
                        {
                            BackEnd.keyHoverCanvas = BackEnd.jyamHover;
                            Refresh();
                        }

                        // 03
                        else if (sampledColorC1HexString.Equals("#F6F6F6")) // Button for jzhad
                        {
                            BackEnd.keyHoverCanvas = BackEnd.jzhadHover;
                            Refresh();

                        }

                        // 04
                        else if (sampledColorC1HexString.Equals("#F3F3F3")) // Button for nexus
                        {
                            BackEnd.keyHoverCanvas = BackEnd.nexusHover;
                            Refresh();
                        }

                        // 05
                        else if (sampledColorC1HexString.Equals("#F0F0F0")) // Button for kehta
                        {
                            BackEnd.keyHoverCanvas = BackEnd.kehtaHover;
                            Refresh();
                        }

                        // 06
                        else if (sampledColorC1HexString.Equals("#EDEDED")) // Button for ader
                        {
                            BackEnd.keyHoverCanvas = BackEnd.aderHover;
                            Refresh();
                        }

                        // 07
                        else if (sampledColorC1HexString.Equals("#EAEAEA")) // Button for alna
                        {
                            BackEnd.keyHoverCanvas = BackEnd.alnaHover;
                            Refresh();
                        }

                        // 08
                        else if (sampledColorC1HexString.Equals("#E7E7E7")) // Button for thatus
                        {
                            BackEnd.keyHoverCanvas = BackEnd.thatusHover;
                            Refresh();
                        }

                        // 09
                        else if (sampledColorC1HexString.Equals("#E4E4E4")) // Button for amien
                        {
                            BackEnd.keyHoverCanvas = BackEnd.amienHover;
                            Refresh();
                        }

                        // 10
                        else if (sampledColorC1HexString.Equals("#E1E1E1")) // Button for athus
                        {
                            BackEnd.keyHoverCanvas = BackEnd.athusHover;
                            Refresh();
                        }

                        // 11
                        else if (sampledColorC1HexString.Equals("#DEDEDE")) // Button for haxt
                        {
                            BackEnd.keyHoverCanvas = BackEnd.haxtHover;
                            Refresh();
                        }

                        // 12
                        else if (sampledColorC1HexString.Equals("#DBDBDB")) // Button for venik
                        {
                            BackEnd.keyHoverCanvas = BackEnd.venikHover;
                            Refresh();
                        }

                        // 13
                        else if (sampledColorC1HexString.Equals("#D8D8D8")) // Button for harux
                        {
                            BackEnd.keyHoverCanvas = BackEnd.haruxHover;
                            Refresh();
                        }

                        // 14
                        else if (sampledColorC1HexString.Equals("#D5D5D5")) // Button for ra
                        {
                            BackEnd.keyHoverCanvas = BackEnd.raHover;
                            Refresh();
                        }

                        // 15
                        else if (sampledColorC1HexString.Equals("#D2D2D2")) // Button for ren
                        {
                            BackEnd.keyHoverCanvas = BackEnd.renHover;
                            Refresh();
                        }

                        // 16
                        else if (sampledColorC1HexString.Equals("#CFCFCF")) // Button for ris
                        {
                            BackEnd.keyHoverCanvas = BackEnd.risHover;
                            Refresh();
                        }

                        // 17
                        else if (sampledColorC1HexString.Equals("#CCCCCC")) // Button for barim
                        {
                            BackEnd.keyHoverCanvas = BackEnd.barimHover;
                            Refresh();
                        }

                        // 18
                        else if (sampledColorC1HexString.Equals("#C9C9C9")) // Button for barta
                        {
                            BackEnd.keyHoverCanvas = BackEnd.bartaHover;
                            Refresh();
                        }

                        // 19
                        else if (sampledColorC1HexString.Equals("#C6C6C6")) // Button for seto
                        {
                            BackEnd.keyHoverCanvas = BackEnd.setoHover;
                            Refresh();
                        }

                        // 20
                        else if (sampledColorC1HexString.Equals("#C3C3C3")) // Button for karthon
                        {
                            BackEnd.keyHoverCanvas = BackEnd.karthonHover;
                            Refresh();
                        }

                        // 21
                        else if (sampledColorC1HexString.Equals("#C0C0C0")) // Button for dolus
                        {
                            BackEnd.keyHoverCanvas = BackEnd.dolusHover;
                            Refresh();
                        }

                        // 22
                        else if (sampledColorC1HexString.Equals("#BDBDBD")) // Button for jensis
                        {
                            BackEnd.keyHoverCanvas = BackEnd.jensisHover;
                            Refresh();
                        }

                        // 23
                        else if (sampledColorC1HexString.Equals("#BABABA")) // Button for gamin
                        {
                            BackEnd.keyHoverCanvas = BackEnd.gaminHover;
                            Refresh();
                        }

                        // 24
                        else if (sampledColorC1HexString.Equals("#B7B7B7")) // Button for payter
                        {
                            BackEnd.keyHoverCanvas = BackEnd.payterHover;
                            Refresh();
                        }

                        // 25
                        else if (sampledColorC1HexString.Equals("#B4B4B4")) // Button for toma
                        {
                            BackEnd.keyHoverCanvas = BackEnd.tomaHover;
                            Refresh();
                        }

                        // 26
                        else if (sampledColorC1HexString.Equals("#B1B1B1")) // Button for tris
                        {
                            BackEnd.keyHoverCanvas = BackEnd.trisHover;
                            Refresh();
                        }

                        // 27
                        else if (sampledColorC1HexString.Equals("#AEAEAE")) // Button for tyel
                        {
                            BackEnd.keyHoverCanvas = BackEnd.tyelHover;
                            Refresh();
                        }

                        // 28
                        else if (sampledColorC1HexString.Equals("#ABABAB")) // Button for vex
                        {
                            BackEnd.keyHoverCanvas = BackEnd.vexHover;
                            Refresh();
                        }

                        // 29
                        else if (sampledColorC1HexString.Equals("#A8A8A8")) // Button for azium
                        {
                            BackEnd.keyHoverCanvas = BackEnd.aziumHover;
                            Refresh();
                        }

                        // 30
                        else if (sampledColorC1HexString.Equals("#A5A5A5")) // Button for efelid
                        {
                            BackEnd.keyHoverCanvas = BackEnd.efelidHover;
                            Refresh();
                        }

                        // 31
                        else if (sampledColorC1HexString.Equals("#A2A2A2")) // Button for esis
                        {
                            BackEnd.keyHoverCanvas = BackEnd.esisHover;
                            Refresh();
                        }

                        // 32
                        else if (sampledColorC1HexString.Equals("#9F9F9F")) // Button for fearon
                        {
                            BackEnd.keyHoverCanvas = BackEnd.fearonHover;
                            Refresh();
                        }

                        // 33
                        else if (sampledColorC1HexString.Equals("#9C9C9C")) // Button for lodus
                        {
                            BackEnd.keyHoverCanvas = BackEnd.lodusHover;
                            Refresh();
                        }

                        // 34
                        else if (sampledColorC1HexString.Equals("#999999")) // Button for memon
                        {
                            BackEnd.keyHoverCanvas = BackEnd.memonHover;
                            Refresh();
                        }

                        // 35
                        else if (sampledColorC1HexString.Equals("#969696")) // Button for nefron
                        {
                            BackEnd.keyHoverCanvas = BackEnd.nefronHover;
                            Refresh();
                        }

                        // 36
                        else if (sampledColorC1HexString.Equals("#939393")) // Button for nonum
                        {
                            BackEnd.keyHoverCanvas = BackEnd.nonumHover;
                            Refresh();
                        }

                        // 37
                        else if (sampledColorC1HexString.Equals("#909090")) // Button for sola
                        {
                            BackEnd.keyHoverCanvas = BackEnd.solaHover;
                            Refresh();
                        }

                        // 38
                        else if (sampledColorC1HexString.Equals("#8D8D8D")) // Button for diamond (Spacebar)
                        {
                            BackEnd.keyHoverCanvas = BackEnd.diamondHover;
                            Refresh();
                        }

                        // 39
                        else if (sampledColorC1HexString.Equals("#8A8A8A")) // Button for suden
                        {
                            BackEnd.keyHoverCanvas = BackEnd.sudenHover;
                            Refresh();
                        }

                        // 40
                        else if (sampledColorC1HexString.Equals("#878787")) // Button for exo
                        {
                            BackEnd.keyHoverCanvas = BackEnd.exoHover;
                            Refresh();
                        }

                        // 41
                        else if (sampledColorC1HexString.Equals("#848484")) // Button for ilunum
                        {
                            BackEnd.keyHoverCanvas = BackEnd.ilunumHover;
                            Refresh();
                        }

                        // 42
                        else if (sampledColorC1HexString.Equals("#818181")) // Button for ixium
                        {
                            BackEnd.keyHoverCanvas = BackEnd.ixiumHover;
                            Refresh();
                        }

                        // 43
                        else if (sampledColorC1HexString.Equals("#7E7E7E")) // Button for oberon
                        {
                            BackEnd.keyHoverCanvas = BackEnd.oberonHover;
                            Refresh();
                        }

                        // 44
                        else if (sampledColorC1HexString.Equals("#7B7B7B")) // Button for odium
                        {
                            BackEnd.keyHoverCanvas = BackEnd.odiumHover;
                            Refresh();
                        }

                        // 45
                        else if (sampledColorC1HexString.Equals("#787878")) // Button for comma
                        {
                            BackEnd.keyHoverCanvas = BackEnd.commaHover;
                            Refresh();
                        }

                        // 46
                        else if (sampledColorC1HexString.Equals("#757575")) // Button for ocillum
                        {
                            BackEnd.keyHoverCanvas = BackEnd.ocillumHover;
                            Refresh();
                        }

                        // 47
                        else if (sampledColorC1HexString.Equals("#727272")) // Button for ojium
                        {
                            BackEnd.keyHoverCanvas = BackEnd.ojiumHover;
                            Refresh();
                        }

                        // 48
                        else if (sampledColorC1HexString.Equals("#6F6F6F")) // Button for opsen
                        {
                            BackEnd.keyHoverCanvas = BackEnd.opsenHover;
                            Refresh();
                        }

                        // 49
                        else if (sampledColorC1HexString.Equals("#6C6C6C")) // Button for ortheks
                        {
                            BackEnd.keyHoverCanvas = BackEnd.ortheksHover;
                            Refresh();
                        }

                        // 50
                        else if (sampledColorC1HexString.Equals("#696969")) // Button for parsus
                        {
                            BackEnd.keyHoverCanvas = BackEnd.parsusHover;
                            Refresh();
                        }

                        // 51
                        else if (sampledColorC1HexString.Equals("#666666")) // Button for period
                        {
                            BackEnd.keyHoverCanvas = BackEnd.periodHover;
                            Refresh();
                        }

                        // 52
                        else if (sampledColorC1HexString.Equals("#636363")) // Button for kanora
                        {
                            BackEnd.keyHoverCanvas = BackEnd.kanoraHover;
                            Refresh();
                        }

                        // 53
                        else if (sampledColorC1HexString.Equals("#606060")) // Button for wiron
                        {
                            BackEnd.keyHoverCanvas = BackEnd.wironHover;
                            Refresh();
                        }

                        // 54
                        else if (sampledColorC1HexString.Equals("#5D5D5D")) // Button for urna
                        {
                            BackEnd.keyHoverCanvas = BackEnd.urnaHover;
                            Refresh();
                        }

                        // 55
                        else if (sampledColorC1HexString.Equals("#5A5A5A")) // Button for chrism
                        {
                            BackEnd.keyHoverCanvas = BackEnd.chrismHover;
                            Refresh();
                        }

                        // 56
                        else if (sampledColorC1HexString.Equals("#575757")) // Button for antagonisticClitic
                        {
                            BackEnd.keyHoverCanvas = BackEnd.antagonisticCliticHover;
                            Refresh();
                        }

                        // 57
                        else if (sampledColorC1HexString.Equals("#545454")) // Button for usis
                        {
                            BackEnd.keyHoverCanvas = BackEnd.usisHover;
                            Refresh();
                        }

                        // 58
                        else if (sampledColorC1HexString.Equals("#515151")) // Button for uviel
                        {
                            BackEnd.keyHoverCanvas = BackEnd.uvielHover;
                            Refresh();
                        }

                        // 59
                        else if (sampledColorC1HexString.Equals("#4E4E4E")) // Button for uzionHover
                        {
                            BackEnd.keyHoverCanvas = BackEnd.uzionHover;
                            Refresh();
                        }

                        // 60
                        else if (sampledColorC1HexString.Equals("#4B4B4B")) // Button for dexin
                        {
                            BackEnd.keyHoverCanvas = BackEnd.dexinHover;
                            Refresh();
                        }

                        // 61
                        else if (sampledColorC1HexString.Equals("#484848")) // Button for cooperativeClitic
                        {
                            BackEnd.keyHoverCanvas = BackEnd.cooperativeCliticHover;
                            Refresh();
                        }

                        // 62
                        else if (sampledColorC1HexString.Equals("#454545")) // Button for yalta
                        {
                            BackEnd.keyHoverCanvas = BackEnd.yaltaHover;
                            Refresh();
                        }

                        // 63
                        else if (sampledColorC1HexString.Equals("#424242")) // Button for backspace
                        {
                            BackEnd.keyHoverCanvas = BackEnd.backspaceHover;
                            Refresh();
                        }

                        // 64
                        else if (sampledColorC1HexString.Equals("#3F3F3F")) // Button for eshna
                        {
                            BackEnd.keyHoverCanvas = BackEnd.eshnaHover;
                            Refresh();
                        }

                        // 65
                        else if (sampledColorC1HexString.Equals("#3C3C3C")) // Button for clitic
                        {
                            BackEnd.keyHoverCanvas = BackEnd.cliticHover;
                            Refresh();
                        }

                        // 66
                        else if (sampledColorC1HexString.Equals("#393939")) // Button for circle
                        {
                            BackEnd.keyHoverCanvas = BackEnd.circleHover;
                            Refresh();
                        }

                        // 67
                        else if (sampledColorC1HexString.Equals("#363636")) // Button for delete
                        {
                            BackEnd.keyHoverCanvas = BackEnd.deleteHover;
                            Refresh();
                        }

                        // 68
                        else if (sampledColorC1HexString.Equals("#333333")) // Button for yamen
                        {
                            BackEnd.keyHoverCanvas = BackEnd.yamenHover;
                            Refresh();
                        }

                        // 69
                        else if (sampledColorC1HexString.Equals("#303030")) // Button for dualClitic
                        {
                            BackEnd.keyHoverCanvas = BackEnd.dualCliticHover;
                            Refresh();
                        }

                        // 70
                        else if (sampledColorC1HexString.Equals("#2D2D2D")) // Button for square
                        {
                            BackEnd.keyHoverCanvas = BackEnd.squareHover;
                            Refresh();
                        }

                    }

                }
                catch
                {
                    //label1.Text = String.Format("{0}, {1}", move_X, move_y);
                }

                /*
                Color c1 = BackEnd.mask.GetPixel(move_X, move_y); // There is an exception thrown for parameter out of bounds

                string sampledColorC1HexString = ColorTranslator.ToHtml(c1);
                
                */
            }

        }

        private void timer1_Tick(object sender, EventArgs e) //State Machine
        {
            if (Control.IsKeyLocked(Keys.CapsLock) && BackEnd.capitalizationState == false)
            {
                BackEnd.capitalizationState = true;
                Refresh();
            }
            else if (!Control.IsKeyLocked(Keys.CapsLock) && BackEnd.capitalizationState == true)
            {
                BackEnd.capitalizationState = false;
                Refresh();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.Visible == false)
                {
                    this.Show();
                    Arrows1.Show();
                    notifyIcon1.Text = "Hide Onscreen Keyboard";
                }
                else
                {
                    this.Hide();
                    Arrows1.Hide();
                    notifyIcon1.Text = "Show Onscreen Keyboard";
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
