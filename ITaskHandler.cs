using System.IO;
using System.Threading.Tasks;

namespace consoleTest
{
    interface ITaskHandler 
    {
        Stream HandleTask(Task responseTask);
    }
}
