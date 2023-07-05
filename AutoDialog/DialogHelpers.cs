using System.Windows.Forms;

namespace AutoDialog
{
    public class DialogHelpers
    {
        public static bool ShowQuestion(string text, string caption)
        {
            return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static DialogForm StartDialog()
        {
            DialogForm d = new DialogForm();          
            return d;
        }
    }
}
