using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPercentage.Normal
{
    public class SetPercentage : CodeActivity
    {
        [Category("Reference Options")]
        public InOutArgument<CustomForm> ModalPopup { set; get; }

        [Category("Input Options")]
        public InArgument<int> Percentage { set; get; }

        protected override void Execute(CodeActivityContext context)
        {
            CustomForm modalPopupSender = context.GetValue(ModalPopup);
            modalPopupSender.Percentage = context.GetValue(Percentage);
            modalPopupSender.Invalidate();
            modalPopupSender.BringToFront();

            context.SetValue(ModalPopup, modalPopupSender);
        }

    }
}
