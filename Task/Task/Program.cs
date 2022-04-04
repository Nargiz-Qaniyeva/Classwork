using System;
using System.Threading.Tasks;

namespace Tasks
{
    internal class Program
    {
        static async void Main(string[] args)
        {
           await  Sum(); //main metod asinxron olmalidi v
        }
       public static  async Task<int> Sum()
        {
            int result = 0;
            var task = Task.Run(() => //action
              {
                  for (int i = 0; i < 100; i++)
                  {
                      result += i;
                  }   
              });
            await task;
            return result;
        }
    }
}
