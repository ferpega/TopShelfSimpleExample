using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace WindowsServiceTopShelf
{
    class Program
    {

        // Command line reference:
        //    http://topshelf.readthedocs.org/en/latest/overview/commandline.html
        //
        // ..\WindowsServiceTopShelf.exe help

        static void Main(string[] args)
        {
            //HostFactory.Run(x =>            
            var host = HostFactory.New(x =>
                {
                    x.Service<ServiceImplementation>(s =>
                        {
                            s.ConstructUsing(name => new ServiceImplementation());
                            s.WhenStarted(si => si.Start());
                            s.WhenStopped(si => si.Stop());                                
                        });
                    x.RunAsLocalSystem();
                    x.SetDescription("AAAAA Service Description");
                    x.SetDisplayName("AAAAA Service Display Name");
                    x.SetServiceName("AAAAAServiceName");
                });
            host.Run();
        }
    }
}
