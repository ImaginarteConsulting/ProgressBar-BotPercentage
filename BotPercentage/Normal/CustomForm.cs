using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotPercentage.Normal
{
    public class CustomForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public new Color BackColor { set; get; }
        public new Color ForeColor { set; get; }
        public Color ProgressBarColor { set; get; }
        public Color ProgressForeColor { set; get; }
        public int Percentage { set; get; }

        public CustomForm()
        {
            SetDefault();
            this.Paint += ModalPopup_Paint;
            this.MouseDown += ModalPopup_MouseDown;
            this.DoubleBuffered = true;
        }
        public void SetDefault()
        {
            if (this.Width < 200)
                this.Width = 200;

            if (this.Height < 64)
                this.Height = 64;
        }
        private void ModalPopup_MouseDown(object sender, MouseEventArgs e)
        {
            CustomForm modalPopupSender = sender as CustomForm;
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(modalPopupSender.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void ModalPopup_Paint(object sender, PaintEventArgs e)
        {
            CustomForm modalPopupSender = sender as CustomForm;
            double progressWidth = modalPopupSender.Width * (modalPopupSender.Percentage / 100d);
            int progressHeight = modalPopupSender.Height;

            e.Graphics.Clear(modalPopupSender.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectTitle = new Rectangle(0, 0, modalPopupSender.Width, progressHeight / 2);
            e.Graphics.DrawString($"{modalPopupSender.Text}", new Font("Segoe UI Black", 14), new SolidBrush(modalPopupSender.ForeColor), rectTitle, new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.NoClip
            });


            Rectangle rect = new Rectangle(0, progressHeight / 2, Convert.ToInt32(progressWidth), progressHeight / 2);
            e.Graphics.FillRectangle(new SolidBrush(modalPopupSender.ProgressBarColor), rect);

            e.Graphics.DrawString($"{modalPopupSender.Percentage}%", new Font("Segoe UI SemiBold", 12), new SolidBrush(modalPopupSender.ProgressForeColor), rect, new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                FormatFlags = StringFormatFlags.NoClip
            });
        }
    }
}
