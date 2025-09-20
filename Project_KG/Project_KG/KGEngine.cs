using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_KG
{
    public class KGEngine
    {
        public event Action Lifecycle;
        public KGList<GameManager> GM=new KGList<GameManager>();
        public int SceneNum = 0;
        private bool _ifAwake=false,_ifStart = false;
        public Random _rnd = new Random();
        private int _stage = 0;
        //private int _turn=0;
        public KGEngine()
        {
            GM.Add( new GameManager(this)); //scene니까 갈아끼울 수 있는 이벤트로
            GM[SceneNum].Subscribe_Enable(); //Start,Update는 고리에 건 순서대로 작동함. 을 고려해서 몬스터랑 플레이어를 추가하면... 혹은 분리해야 하나...? X
            if(Lifecycle == null)
            {
                Lifecycle += GM[SceneNum].Start;
                Lifecycle += GM[SceneNum].Update;
            }
        }
        public void Run()
        {
            while(true)
            {
                switch(_stage) //대충 씬 같은거
                {
                    case 0: //로비
                        _stage = 1;
                        break;
                    case 1: //던전 안
                        if (_ifStart == true)
                        {
                            Start(); //프레임 통일 및 Awake랑 달리 최초 활성화 시라는 점을 생각해서
                        }
                        Update();
                        Thread.Sleep((int)100);
                        GM[SceneNum].Destroyer();
                        if (GM[SceneNum].EndCheck() == true)
                        {
                            _stage = 2;
                        }
                        break;
                    case 2: //결산?
                        break;
                }
                //Console.WriteLine($"{_turn++}번째 턴");


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

        public void OnIfStart_KGB() //start 활성화해줄 bool변수
        {
            _ifStart = true;
        }
    }
}
