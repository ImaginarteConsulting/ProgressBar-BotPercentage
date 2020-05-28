using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPercentage.Normal
{
    public class CloseModal : CodeActivity
    {
        [Category("Reference Options")]
        public InOutArgument<CustomForm> ModalPopup { set; get; }

        protected override void Execute(CodeActivityContext context)
        {
            CustomForm modalPopupSender = context.GetValue(ModalPopup);
            modalPopupSender.Close();
            context.SetValue(ModalPopup, modalPopupSender);
        }

    }
}
