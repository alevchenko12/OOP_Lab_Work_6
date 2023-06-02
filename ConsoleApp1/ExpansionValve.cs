using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Work_6
{
    public class ExpansionValve : BaseComponent
    {
        //Розширювальний клапан є регулюючим компонентом, який контролює потік холодоагенту між стороною високого тиску (конденсатор) і стороною низького тиску (випарник).
        //Він знижує тиск холодоагенту, дозволяючи йому розширюватися та швидко охолоджуватися, коли він потрапляє у випарник.

        public override string ReportComponent()
        {
            Console.WriteLine("ExpansionValve:");
            return base.ReportComponent();
        }

        public override string ReportBreackdown()
        {
            Console.WriteLine("ExpansionValve:");
            return base.ReportBreackdown();
        }
    }
}
