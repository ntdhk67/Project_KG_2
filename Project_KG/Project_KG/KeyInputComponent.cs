using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG
{
    public class KeyInputComponent : IComponent
    {
        public KGBehaviour Parent { get; set; }
        public ConsoleKey KeyInfo { get => Console.ReadKey(true).Key; } //어차피 아직 키 하나가지고 여러 동작 안해서 GetComponent로서에 집중해봄, 나중에 엔진의 루프에서 함수 호출 추가하면 한 프레임 통일 가능은 함.
    }
}