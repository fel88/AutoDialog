using System.Reflection.Emit;

namespace AutoDialog
{
    public class Validator
    {
        public Func<Control, bool> Predicate;         
        public string Key;
    }

}
