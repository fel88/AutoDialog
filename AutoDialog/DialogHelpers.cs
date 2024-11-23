using System.Windows.Forms;

namespace AutoDialog
{
    public static class DialogHelpers
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

        public static void AppendPropertiesToDialog(DialogForm d, object obj)
        {
            foreach (var item in obj.GetType().GetProperties())
            {
                if (item.SetMethod == null)
                    continue;

                if (item.PropertyType == typeof(bool))
                {
                    d.AddBoolField(item.Name, item.Name, (bool)item.GetValue(obj));
                }
                else if (item.PropertyType == typeof(string))
                {
                    d.AddStringField(item.Name, item.Name, (string)item.GetValue(obj));
                }
                else if (item.PropertyType == typeof(int))
                {
                    d.AddIntegerNumericField(item.Name, item.Name, (int)item.GetValue(obj), 100000000, -100000000);
                }
                else if (item.PropertyType == typeof(double))
                {
                    d.AddNumericField(item.Name, item.Name, (double)item.GetValue(obj), 100000000, -100000000);
                }
                else if (item.PropertyType == typeof(float))
                {
                    d.AddNumericField(item.Name, item.Name, (float)item.GetValue(obj), 100000000, -100000000);
                }
                else if (item.PropertyType.IsEnum)
                {
                    var val = Enum.GetName(item.PropertyType, item.GetValue(obj));
                    if (val != null)
                    {
                        d.AddOptionsField(item.Name, item.Name, Enum.GetNames(item.PropertyType), val);
                    }
                }
            }
        }

        public static bool EditWithAutoDialog(object obj, bool withProps = true, bool withFields = false)
        {
            var d = StartDialog();
            d.StartPosition = FormStartPosition.CenterScreen;

            if (withProps)
                AppendPropertiesToDialog(d, obj);

            if (!d.ShowDialog())
                return false;

            if (withProps)
                ExtractPropertiesToObject(d, obj);

            return true;
        }

        public static DialogForm StartEditWithAutoDialog(object obj, bool withProps = true, bool withFields = false)
        {
            var d = StartDialog();
            d.StartPosition = FormStartPosition.CenterScreen;

            if (withProps)
                AppendPropertiesToDialog(d, obj);

            return d;
        }

        public static void ExtractPropertiesToObject(DialogForm d, object obj)
        {
            foreach (var item in obj.GetType().GetProperties())
            {
                if (item.SetMethod == null)
                    continue;

                if (item.PropertyType == typeof(bool))
                {
                    item.SetValue(obj, d.GetBoolField(item.Name));
                }
                else if (item.PropertyType == typeof(string))
                {
                    item.SetValue(obj, d.GetStringField(item.Name));
                }
                else if (item.PropertyType == typeof(int))
                {
                    item.SetValue(obj, d.GetIntegerNumericField(item.Name));
                }
                else if (item.PropertyType == typeof(double))
                {
                    item.SetValue(obj, d.GetNumericField(item.Name));
                }
                else if (item.PropertyType == typeof(float))
                {
                    item.SetValue(obj, (float)d.GetNumericField(item.Name));
                }
                else if (item.PropertyType.IsEnum)
                {
                    var val = Enum.GetName(item.PropertyType, item.GetValue(obj));
                    if (val != null)
                    {
                        item.SetValue(obj, Enum.Parse(item.PropertyType, d.GetOptionsField(item.Name)));
                    }
                }
            }
        }
    }
}
