using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AsyncAwaitSample.Helpers
{
    public class TextBoxTraceListener : TraceListener
    {
        private TextBox _txtBox;

        public TextBoxTraceListener(TextBox textBox)
        {
            this._txtBox = textBox;
        }

        public override void Write(string msg)
        {
            
            _txtBox.Dispatcher.Invoke(()=>
            {
                _txtBox.Text += msg;
            });
        }

        public override void WriteLine(string msg)
        {
            Write(msg + "\r\n");
        }
    }
}
