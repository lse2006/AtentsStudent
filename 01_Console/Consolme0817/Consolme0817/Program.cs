using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolme0817
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello Warld!");

            int level = 1;
            int hp = 10;
            float exp = 0.9f;
            string name = "너굴맨";

            Console.WriteLine(name + "의 " + "레벨은 " + level + "이고 HP는 " + hp + "이고 exp는" + exp + "이다."); 
            //1교시에 배운 내용을 토대로 아래 문장을 만들어라.
            //너굴맨의 레벨은 1이고, HP는 10이고, exp는 0.9이다.

            Console.ReadKey();
        }
    }
}
