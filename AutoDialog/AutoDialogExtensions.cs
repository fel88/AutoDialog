namespace AutoDialog.Extensions
{
    public static class AutoDialogExtensions
    {
        public static void ExtractPropertiesToObject(this DialogForm d, object obj)
        {
            DialogHelpers.ExtractPropertiesToObject(d, obj);
        }

        public static void AppendPropertiesToDialog(this DialogForm d, object obj)
        {
            DialogHelpers.AppendPropertiesToDialog(d, obj);
        }

        public static bool EditWithAutoDialog(this object obj, bool withProps = true, bool withFields = false)
        {
            var d = DialogHelpers.StartDialog();
            d.StartPosition = FormStartPosition.CenterScreen;

            if (withProps)
                DialogHelpers.AppendPropertiesToDialog(d, obj);

            d.Init();
            if (!d.ShowDialog())
                return false;

            if (withProps)
                ExtractPropertiesToObject(d, obj);

            return true;
        }

        public static DialogForm StartEditWithAutoDialog(this object obj, bool withProps = true, bool withFields = false)
        {
            var d = DialogHelpers.StartDialog();
            d.StartPosition = FormStartPosition.CenterScreen;

            if (withProps)
                DialogHelpers.AppendPropertiesToDialog(d, obj);

            return d;
        }
    }
}
