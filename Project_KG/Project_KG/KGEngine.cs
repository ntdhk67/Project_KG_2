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
            _gameManager = new GameManager(this); //scene니까 갈아끼울 수 있는 이벤트로
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
                if(_ifStart==true)
                {
                    Start(); //프레임 통일 및 Awake랑 달리 최초 활성화 시라는 점을 생각해서
                }
                Update();
                Thread.Sleep((int)100);
                _gameManager.Destroyer();
            }
        }
        protected virtual void Start()
        {
            Lifecycle?.Invoke();
        }
        protected virtual void Update()
        {
            Lifecycle?.Invoke();
        }

        public void OnIfStart_KGB()
        {
            _ifStart = true;
        }
    }
}
