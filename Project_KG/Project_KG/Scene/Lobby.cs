using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_KG.Scene
{
    public class Lobby:KGBehaviour
    {
        public Lobby(KGEngine engine) : base(engine)
        {
        }
        protected override void Start_KGB()
        {
            AddComponent<KeyInputComponent>();
        }
        protected override void Update_KGB()
        {
            if(Console.KeyAvailable)
            {
                KeyInputComponent key = GetComponent<KeyInputComponent>();
                if (key.KeyInfo == ConsoleKey.Spacebar)
                {
                    ThisEngine.InDungeon();
                }
                else if (key.KeyInfo == ConsoleKey.A)
                {
                    ThisEngine._ifA=true;
                    ThisEngine.InDungeon();
                }
                /*else if(key.KeyInfo==ConsoleKey.C)
                {
                    Console.WriteLine("몇번 던전 결과를 조회하겠습니까?");
                    int number = Convert.ToInt32(Console.ReadLine())-1;
                    if(number>=0 && number<ThisEngine.SaveData.Top)
                    {
                        Console.WriteLine($"{ThisEngine.SaveData[number].KillCount}마리를 잡고 클리어{ThisEngine.SaveData[number].clear}");
                    }
                    else
                    {
                        Console.WriteLine("조회할 수 없습니다.");
                    } 어우 메모리 엄청 잡아먹네 이거
                }*/
                else
                {
                    return;
                }
            }
        }
    }
}
