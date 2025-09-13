using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_KG
{
    public class KGEngine
    {
        public delegate void Lifecycles();
        public event Lifecycles Test;
        private GameManager gameManager;
        public KGEngine()
        {
            gameManager = new GameManager(this);
            gameManager.Subscribe_Enable(); //고리에 건 순서대로 작동함.
            if(Test==null)
            {
                Test += gameManager.Start;
                Test += gameManager.Update;
            }
        }
        public void Run()
        {
            while(true)
            {
                Update_KGB();
                Thread.Sleep((int)100);
            }
        }
        protected virtual void Awake()
        {

        }
        protected virtual void Start()
        {

        }
        protected virtual void Update_KGB()
        {
            Test?.Invoke();
        }
    }
}
