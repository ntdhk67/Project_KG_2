using Project_KG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG
{
    public class GameManager:KGBehaviour //대충 scene1
    {
        //private int i = 0; //순서 테스트
        protected KGList<EntityBase> _players = new KGList<EntityBase>();
        protected KGList<EntityBase> _monsters = new KGList<EntityBase>();
        protected KGList<EntityBase> _dead = new KGList<EntityBase>();
        public KGList<EntityBase> players =>_players;
        public KGList<EntityBase> monsters=>_monsters;
        public KGList<EntityBase> dead => _dead; //죽게 될 애들
        public bool _isDestroy = false;

        public GameManager(KGEngine engine) : base(engine)
        {
        }
        protected override void Awake_KGB()
        {

        }
        protected override void Start_KGB()
        {
            //Knight, Archer, Mage, Skeleton, Slime, Orc 횟수대로 숫자 붙이고 싶었어서
            int n = ThisEngine._rnd.Next(5, 10);
            for (int i= n; i>0 ;i--)
            {
                switch (ThisEngine._rnd.Next(0, 3))
                {
                    case 0:
                        players.Add(new Knight(ThisEngine,n-i+1));
                        break;
                    case 1:
                        players.Add(new Archer(ThisEngine,n-i+1));
                        break;
                    case 2:
                        players.Add(new Mage(ThisEngine,n - i + 1));
                        break;
                    default:
                        break;
                }
            } //플레이어 선, 몬스터 후 근데 이렇게 하면 나중에 더 업그레이드 막 해가지고 전투 도중에 소환된게 있거나 그러면 순서관리하기 용이하지 않음... 그래서 아예 Invoke할 곳을 분할해서 두면 낫겠다 싶긴 한데...
            n = ThisEngine._rnd.Next(5, 10);
            for (int i = n; i > 0; i--)
            {
                switch (ThisEngine._rnd.Next(0, 3))
                {
                    case 0:
                        monsters.Add(new Skeleton(ThisEngine, n-i + 1));
                        break;
                    case 1:
                        monsters.Add(new Slime(ThisEngine,n - i + 1));
                        break;
                    case 2:
                        monsters.Add(new Orc(ThisEngine,n - i + 1));
                        break;
                    default:
                        break;
                }
            }
        }
        protected override void Update_KGB()
        {
            //Console.WriteLine("Test");
        }
        public void Destroyer()
        {
            if(_isDestroy==true)
            {
                foreach(EntityBase e in dead)
                {
                    _monsters.Remove(e);
                    _players.Remove(e);
                }
                _dead.Clear();
                _isDestroy = false;
            }
        }
        public bool EndCheck()
        {
            if(_players.isEmpty()==true&&_monsters.isEmpty()==true)
            {
                _players.Clear();
                _monsters.Clear();
                return true;
            }
            return false;
        }
    }
}
