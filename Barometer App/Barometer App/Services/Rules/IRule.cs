using System;
using System.Collections.Generic;
using System.Text;

namespace Barometer_App
{
    public interface AbstractRule
    {
        bool doCheck();
    }
    public abstract class AbstractRule<T> : AbstractRule
    {
        protected T Input;

        public abstract bool doCheck();
    }
}
