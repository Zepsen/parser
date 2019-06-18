using System.Threading.Tasks;
using BLL.Services;

namespace Parser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var parser = new ParseService();
            await parser.Run();
        }
    }
}
