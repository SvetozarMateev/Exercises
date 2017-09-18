using Academy.Core.Contracts;
using Academy.Ninject;
using Ninject;

namespace Academy
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var kernel = new StandardKernel(new AcademyModule());
            var engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
