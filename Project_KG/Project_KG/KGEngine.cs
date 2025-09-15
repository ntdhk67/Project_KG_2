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
        public event Lifecycles Lifecycle;
        private GameManager _gameManager;
        public GameManager GM => _gameManager;
        private bool _ifAwake=false,_ifStart = false;
        public Random _rnd = new Random();
        public KGEngine()
        {
            _gameManager = new GameManager(this);
            _gameManager.Subscribe_Enable(); //Start,Update는 고리에 건 순서대로 작동함. 을 고려해서 몬스터랑 플레이어를 추가하면... 혹은 분리해야 하나...? X
            if(Lifecycle == null)
            {
                Lifecycle += _gameManager.Start;
                Lifecycle += _gameManager.Update;
            }
        }
        public void Run()
        {
            while(true)
            {
                if(_ifAwake==true)
                {
                    Awake();
                }//귀찮아서 넣어버림, 사이클에 적합하지 않아 나중에 뺄 예정
                if(_ifStart==true)
                {
                    Start();
                }
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
            Lifecycle?.Invoke();
        }
        public void OnIfAwake()
        {
            _ifAwake = true;
        }
        public void OnIfStart()
        {
            _ifStart = true;
        }
    }
}
