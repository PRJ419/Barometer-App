using System;
using System.Collections.Generic;
using System.Text;

namespace Barometer_App.Services
{
    public class InputValidator
    {
        private List<AbstractRule> Rules;

        public void AddRule(AbstractRule rule)
        {
            Rules.Add(rule);
        }

        public bool CheckRules()
        {
            foreach (var rule in Rules)
            {
                if (!rule.doCheck())
                    return false;
            }

            return true;
        }
    }
}
