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
    public partial class Onscreen_Arrows : Form
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_NOACTIVATE;
                return createParams;
            }
        }
        // NOTE** The transparency key has to be the *SAME* for both forms in order for click-through to work in the transparent areas of the form.

        public Onscreen_Arrows()
        {
            InitializeComponent();
        }

        private void Onscreen_Arrows_Load(object sender, EventArgs e)
        {
            this.Icon = global::Keyboard_1.Properties.Resources.Memon;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = this.BackgroundImage.Width;
            this.Height = this.BackgroundImage.Height;
        }

        private void Onscreen_Arrows_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(BackEnd.arrows_KeysUp, 0, 0, BackEnd.ARROWSWIDTH, BackEnd.ARROWSHEIGHT);
            e.Graphics.DrawImage(BackEnd.arrowsKeyDownCanvas, 0, 0, BackEnd.ARROWSWIDTH, BackEnd.ARROWSHEIGHT);
            e.Graphics.DrawImage(BackEnd.arrowsHoverCanvas, 0, 0, BackEnd.ARROWSWIDTH, BackEnd.ARROWSHEIGHT);
        }

        private void Onscreen_Arrows_MouseDown(object sender, MouseEventArgs e)
        {
            string colorHexString = ColorTranslator.ToHtml(BackEnd.arrows_Mask.GetPixel(e.X, e.Y));

            if (e.Button == MouseButtons.Left)
            {
                if (colorHexString.Equals("#000000")) // IF your not "pressing a button" then you can move the form around the screen. (left mose down is not detected in an x,y coordinate where a color is detected on the mask bitmap.)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                    Invalidate();
                }
                else if (colorHexString.Equals("#101010")) // Button for (Left)
                {
                    BackEnd.arrowsKeyDownCanvas = BackEnd.arrows_KeyDown_Left;
                    Refresh();
                    WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.LEFT);
                }
                else if (colorHexString.Equals("#121212")) // Button for (Up)
                {
                    BackEnd.arrowsKeyDownCanvas = BackEnd.arrows_KeyDown_Up;
                    Refresh();
                    WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.UP);
                }
                else if (colorHexString.Equals("#141414")) // Button for (Down)
                {
                    BackEnd.arrowsKeyDownCanvas = BackEnd.arrows_KeyDown_Down;
                    Refresh();
                    WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.DOWN);
                }
                else if (colorHexString.Equals("#161616")) // Button for (Right)
                {
                    BackEnd.arrowsKeyDownCanvas = BackEnd.arrows_KeyDown_Right;
                    Refresh();
                    WindowsInput.InputSimulator.SimulateKeyPress(VirtualKeyCode.RIGHT);
                }

            }
        }

        private void Onscreen_Arrows_MouseUp(object sender, MouseEventArgs e)
        {
            BackEnd.arrowsKeyDownCanvas = BackEnd.arrowsBlankCanvas;
            Refresh();
        }

        private void Onscreen_Arrows_MouseMove(object sender, MouseEventArgs e)
        {
            int arrow_move_X = e.X;
            int arrow_move_y = e.Y;
            //if (0 < arrow_move_X && arrow_move_X < BackEnd.screenWidth && 0 < arrow_move_y && arrow_move_y < BackEnd.screenHeight)
            if (0 < arrow_move_X && arrow_move_X < this.Width && 0 < arrow_move_y && arrow_move_y < this.Height)
            {
                try
                {
                    Color c = BackEnd.arrows_Mask.GetPixel(arrow_move_X, arrow_move_y); // There is an exception thrown for parameter out of bounds
                    string sampledColorHexString = ColorTranslator.ToHtml(c);
                    //label2.Text = String.Format("{0}, {1}, {2}", arrow_move_X, arrow_move_y, sampledColorHexString);

                    if (!sampledColorHexString.Equals(BackEnd.currentHoverColor))
                    {
                        BackEnd.currentHoverColorArrows = sampledColorHexString;

                        if (sampledColorHexString.Equals("#000000")) // IF you are not hovering over any button
                        {
                            BackEnd.arrowsHoverCanvas = BackEnd.arrowsBlankCanvas;
                            Invalidate();
                        }

                        // 01
                        else if (sampledColorHexString.Equals("#101010")) // Button for Left
                        {
                            BackEnd.arrowsHoverCanvas = BackEnd.arrows_Hover_Left;
                            Refresh();
                        }

                        // 02
                        else if (sampledColorHexString.Equals("#121212")) // Button for Up
                        {
                            BackEnd.arrowsHoverCanvas = BackEnd.arrows_Hover_Up;
                            Refresh();
                        }

                        // 03
                        else if (sampledColorHexString.Equals("#141414")) // Button for Right
                        {
                            BackEnd.arrowsHoverCanvas = BackEnd.arrows_Hover_Right;
                            Refresh();

                        }

                        // 04
                        else if (sampledColorHexString.Equals("#161616")) // Button for Down
                        {
                            BackEnd.arrowsHoverCanvas = BackEnd.arrows_Hover_Down;
                            Refresh();
                        }
                    }
                }
                catch 
                {
                    //label2.Text = String.Format("{0}, {1}", arrow_move_X, arrow_move_y);
                }
                
                /*
                Color c = BackEnd.arrows_Mask.GetPixel(arrow_move_X, arrow_move_y); // There is an exception thrown for parameter out of bounds
                string sampledColorHexString = ColorTranslator.ToHtml(c);

                 */
            }
        }
    }
}
