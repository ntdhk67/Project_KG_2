using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_KG.Scene
{
    public class End:KGBehaviour
    {
        public End(KGEngine engine) : base(engine)
        {
        }
        protected override void Start_KGB()
        {
            AddComponent<KeyInputComponent>();
        }
        protected override void Update_KGB()
        {
            if(ThisEngine._ifA==true)
            {
                ThisEngine.SceneNum++;
                ThisEngine.InLobby();
            }
            else if (Console.KeyAvailable)
            {
                KeyInputComponent key = GetComponent<KeyInputComponent>();
                if (key.KeyInfo == ConsoleKey.Spacebar)
                {
                    ThisEngine.SceneNum++;
                    ThisEngine.InLobby();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
