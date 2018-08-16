using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Lesson8_BronashkoAV
{
    class Question
    {
        private string text;
        private bool trueFalse;

        public string Text { get => text; set => text = value; }
        public bool TrueFalse { get => trueFalse; set => trueFalse = value; }

        public Question()
        {
        }

        public Question(string text, bool trueFalse)
        {
            this.Text = text;
            this.TrueFalse = trueFalse;
        }
    }


}
