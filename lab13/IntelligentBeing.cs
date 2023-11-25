using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Laba_13
{
    [Serializable]
    public abstract class IntelligentBeing
    {
        [DataMember]
        public string Name;

        protected IntelligentBeing(string name, DateTime birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        [DataMember]
        public readonly DateTime Birthday;

        public double AgeInYears => (DateTime.Now - Birthday).TotalDays / 365.0;

        public override string ToString()
        {
            return $"this creature: {Name}\t live: {AgeInYears} years";
        }
    }
}
