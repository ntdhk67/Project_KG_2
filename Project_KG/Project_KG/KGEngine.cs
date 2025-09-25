using Project_KG.Scene;
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
        //public KGList<GameManager> GM=new KGList<GameManager>();
        public GameManager GM;
        private Lobby _lobby;
        private End _end;
        public int SceneNum = 0;
        private bool _ifStart = false,_notDungeon;
        public bool _ifA = false;
        public Random _rnd = new Random();
        //public KGList<Save> SaveData = new KGList<Save>(); 어우 저장 한번 해보렸는데 메모리 엄청 잡아먹는다 100만회를 메모리에 저장해버렸더니 1.2GB 뭐야이거
        public KGEngine()
        {
            _lobby = new Lobby(this);
            GM=new GameManager(this);
            //GM.Add(new GameManager(this));
            _end = new End(this);
            InLobby();
        }
        public void Run()
        {
            while (true)
            {
                if (_ifStart == true)
                {
                    Start(); //프레임 통일 및 Awake랑 달리 최초 활성화 시라는 점을 생각해서
                }
                Update();
                //Thread.Sleep((int)100); //A키 테스트할때는 꺼도 되겠죠?
                if (_notDungeon == false && GM._isDestroy == true)
                {
                    GM.Destroyer();
                    if (GM.EndCheck() == true) //어차피 처리하고 나서만 체크해도 될 것 같아서 호출횟수 줄이기
                    {
                        Ending();
                    }
                }
            }
        }
        public void InLobby()
        {
            Console.WriteLine($"{SceneNum + 1}번째 던전에 Spacebar로 입장 하시겠습니까? C로 결산을 조회할 수 있습니다. (경고 : A키 입력 시, 무한거던에 돌입합니다.)");
            if (_ifA==true)
            {
                InDungeon();
                return;
            }
            _notDungeon = true;
            ResetLifecycle();
            _lobby.Subscribe_Enable(); //Start,Update는 고리에 건 순서대로 작동함. 을 고려해서 몬스터랑 플레이어를 추가하면... 혹은 분리해야 하나...? X
        }
        public void InDungeon()
        {
            _notDungeon = false;
            ResetLifecycle();
            //GM.Add(new GameManager(this)); //scene니까 갈아끼울 수 있는 이벤트로
            //GM[SceneNum].Subscribe_Enable();
            GM.ReStart();
        }
        private void Ending()
        {
            //SaveData.Add(new Save(GM._killCount, GM.clear));
            Console.WriteLine($"{GM._killCount}마리를 잡고 클리어{GM.clear}");//결산
            _notDungeon = true;
            ResetLifecycle();
            _end.Subscribe_Enable();
        }
        private void ResetLifecycle()
        {
            Lifecycle = null;
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
