using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Activities;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BotPercentage.Normal
{
    public class ShowModal : CodeActivity
    {
        [Category("Sizing Options")]
        public InArgument<int> Width { set; get; }
        [Category("Sizing Options")]
        public InArgument<int> Height { set; get; }

        [Category("Color Options")]
        public InArgument<Color> BackgroundColor { set; get; }
        [Category("Color Options")]
        public InArgument<Color> ForeColor { set; get; }

        [Category("Color Options")]
        public InArgument<Color> ProgressColor { set; get; }

        [Category("Color Options")]
        public InArgument<Color> ProgressForeColor { set; get; }


        [Category("Text Options")]
        public InArgument<string> Title { set; get; }

        [Category("Reference Options")]
        public InOutArgument<CustomForm> ModalPopup { set; get; }

        protected override void Execute(CodeActivityContext context)
        {
            CustomForm modalPopup = new CustomForm();
            modalPopup.FormBorderStyle = FormBorderStyle.None;
            modalPopup.StartPosition = FormStartPosition.CenterScreen;
            modalPopup.WindowState = FormWindowState.Normal;
            modalPopup.Width = context.GetValue(Width);
            modalPopup.Height = context.GetValue(Height);
            modalPopup.BackColor = context.GetValue(BackgroundColor);
            modalPopup.ForeColor = context.GetValue(ForeColor);
            modalPopup.ProgressBarColor = context.GetValue(ProgressColor);
            modalPopup.ProgressForeColor = context.GetValue(ProgressForeColor);
            modalPopup.Text = context.GetValue(Title);
            modalPopup.SetDefault();
            modalPopup.Show();

            context.SetValue(ModalPopup, modalPopup);
        }





    }

}
