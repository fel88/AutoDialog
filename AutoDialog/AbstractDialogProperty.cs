namespace AutoDialog
{
    public abstract class AbstractDialogProperty
    {
        public AbstractDialogProperty(Control[] controls)
        {
            Controls = controls;
        }

        public readonly Control[] Controls;
    }
}
