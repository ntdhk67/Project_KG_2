using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_KG
{
    public class GameManager:KGBehaviour
    {
        private int i = 0;
        public GameManager(KGEngine engine) : base(engine)
        {
        }
        protected override void Awake_KGB()
        {

        }
        protected override void Start_KGB()
        {

        }
        protected override void Update_KGB()
        {
            Console.WriteLine($"{i++}");
        }
    }
}
