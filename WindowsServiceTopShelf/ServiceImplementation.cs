using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace WindowsServiceTopShelf
{
    public class ServiceImplementation
    {
        readonly Timer _timer1;

        public ServiceImplementation()
        {
            _timer1 = new Timer(1000) 
                            { 
                                AutoReset = true 
                            };
            _timer1.Elapsed += ShowElapsedTime;
        }

        public void Start() 
        { 
            _timer1.Start(); 
        }
        public void Stop() 
        { 
            _timer1.Stop(); 
        }


        private void ShowElapsedTime(object sender, ElapsedEventArgs e)
        {
            var msg = string.Format("The service elapsed time: {0}", DateTime.Now);
            if (Environment.UserInteractive) {
                Console.WriteLine(msg);
            } else {
                System.Diagnostics.Trace.WriteLine(msg);
            }
        }

    }
}
