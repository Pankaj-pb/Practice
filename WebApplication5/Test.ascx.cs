using System;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class Test1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Save_Click(object sender, EventArgs e)
        {
            if (CustomValidator_UserName.IsValid)
            {

            }
        }

        protected void CustomValidator_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var dateOfBirth = TextBox_UserName.Text;
            if (!string.IsNullOrEmpty(dateOfBirth))
            {
                try
                {
                    var dateTime = Convert.ToDateTime(dateOfBirth);
                    args.IsValid = true;
                }
                catch (Exception ex)
                {
                    args.IsValid = false;
                }
            }
        }
    }
}