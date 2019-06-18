using System.Threading.Tasks;
using Parser.Services;

namespace Parser
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var parser = new ParseService();
            await parser.Run();

            //var model = new ProfileModel() { Id = "Ricardo_Delgado13", Link = "https://www.xing.com/profile/Giovanni_Marziale" };
            //parser.ParseProfile(model);
            //Console.WriteLine(model.ToString());
        }
    }
}
