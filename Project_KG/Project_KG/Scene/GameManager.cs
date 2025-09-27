using Project_KG.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG.Scene
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
        public int _killCount = 0;
        public string clear;
        public MemoryPool _memoryPool;
        public GameManager(KGEngine engine) : base(engine)
        {

        }
        protected override void Awake_KGB()
        {

        }
        protected override void Start_KGB()
        {

        }
        public override void OnEnable()
        {

            base.OnEnable();
        }
        protected override void Update_KGB()
        {
            //Console.WriteLine("Test");
        }
        public void Destroyer()
        {
            foreach (EntityBase e in dead)
            {
                switch(e)
                {
                    case Archer:
                        _memoryPool.ArcherReturn(e);
                        _players.Remove(e);
                        break;
                    case Knight:
                        _memoryPool.KnightReturn(e);
                        _players.Remove(e);
                        break;
                    case Mage:
                        _memoryPool.MageReturn(e);
                        _players.Remove(e);
                        break;
                    case Slime:
                        _memoryPool.SlimeReturn(e);
                        _monsters.Remove(e);
                        break;
                    case Skeleton:
                        _memoryPool.SkeletonReturn(e);
                        _monsters.Remove(e);
                        break;
                    case Orc:
                        _memoryPool.OrcReturn(e);
                        _monsters.Remove(e);
                        break;
                    default:
                        break;
                }
            }
            _dead.Clear();
            _isDestroy = false;
        }
        public bool EndCheck()
        {
            if(_monsters.isEmpty()==true)
            {
                foreach(EntityBase e in _players)
                {
                    e.UnSubscribe_Disable();
                    switch (e)
                    {
                        case Archer:
                            _memoryPool.ArcherReturn(e);
                            break;
                        case Knight:
                            _memoryPool.KnightReturn(e);
                            break;
                        case Mage:
                            _memoryPool.MageReturn(e);
                            break;
                        default:
                            break;
                    }
                }
                foreach(EntityBase e in _monsters)
                {
                    e.UnSubscribe_Disable();
                    switch (e)
                    {
                        case Slime:
                            _memoryPool.SlimeReturn(e);
                            break;
                        case Skeleton:
                            _memoryPool.SkeletonReturn(e);
                            break;
                        case Orc:
                            _memoryPool.OrcReturn(e);
                            break;
                        default:
                            break;
                    }
                }
                _players.Clear();
                _monsters.Clear();
                clear = "했습니다.";
                return true;
            }
            else if(_players.isEmpty() == true)
            {
                foreach (EntityBase e in _players)
                {
                    e.UnSubscribe_Disable();
                    switch (e)
                    {
                        case Archer:
                            _memoryPool.ArcherReturn(e);
                            break;
                        case Knight:
                            _memoryPool.KnightReturn(e);
                            break;
                        case Mage:
                            _memoryPool.MageReturn(e);
                            break;
                        default:
                            break;
                    }

                }
                foreach (EntityBase e in _monsters)
                {
                    e.UnSubscribe_Disable();
                    switch (e)
                    {
                        case Slime:
                            _memoryPool.SlimeReturn(e);
                            break;
                        case Skeleton:
                            _memoryPool.SkeletonReturn(e);
                            break;
                        case Orc:
                            _memoryPool.OrcReturn(e);
                            break;
                        default:
                            break;
                    }
                }
                _players.Clear();
                _monsters.Clear();
                clear = "하지 못했습니다.";
                return true;
            }
            return false;
        }
        public void ReStart()
        {
            _players.Clear();
            _monsters.Clear();
            _dead.Clear();
            _isDestroy = false;
            _killCount = 0;
            clear = null;
            //Knight, Archer, Mage, Skeleton, Slime, Orc 횟수대로 숫자 붙이고 싶었어서
            int n = ThisEngine._rnd.Next(5, 10);
            for (int i = n; i > 0; i--)
            {
                switch (ThisEngine._rnd.Next(0, 3))
                {
                    case 0:
                        EntityBase k = _memoryPool.KnightGet(n - i + 1);
                        _players.Add(k);
                        break;
                    case 1:
                        EntityBase a = _memoryPool.ArcherGet(n - i + 1);
                        _players.Add(a);
                        break;
                    case 2:
                        EntityBase m = _memoryPool.MageGet(n - i + 1);
                        _players.Add(m);
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
                        _monsters.Add(_memoryPool.SkeletonGet(n - i + 1));
                        break;
                    case 1:
                        _monsters.Add(_memoryPool.SlimeGet(n - i + 1));
                        break;
                    case 2:
                        monsters.Add(_memoryPool.OrcGet(n - i + 1));
                        break;
                    default:
                        break;
                }
            }
            Subscribe_Enable();
        }
    }
}
