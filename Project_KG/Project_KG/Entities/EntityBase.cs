using Project_KG.Interfaces;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project_KG.Entities
{
    public abstract class EntityBase:KGBehaviour
    {
        public int num { get;}
        protected int HP { get; set; }
        public int HP_Check => HP;
        protected int AP { get; }
        public string Name { get; }
        public int Tag { get; }
        public bool isDead = false;
        private Random _random => ThisEngine._rnd;
        protected EntityBase(KGEngine engine, int n, int hp, int ap, String name) : base(engine)
        {
            HP = hp;
            AP = ap;
            Name = name; //와아 나도 나중에 파싱 써봐야지
            num = n;
            Subscribe_Enable();//나중에 옮길 예정
        }
        //라이프 사이클
        protected override void Awake_KGB()
        {

        }
        protected override void Start_KGB()
        {

        }
        protected override void Update_KGB()
        {
            //Console.WriteLine((int)Tag); //잘 가져오는지 테스트
            AttackDamage();
        }
        //기타 처리 (Enable Disable OnDeath 등 처리 필요시 예약)

        public void TakeDamage(int dmg,int thisIndex)
        {
            HP -= dmg;
            //사망 bool만 해두기
            if (HP <= 0)
            {
                isDead = true;
                //ThisGameManager.thisIndex
                switch (Tag)
                {
                    case 0: //0=플레이어일 때
                        ThisGameManager.players.SwapIndex(thisIndex, ThisGameManager.players.Top-1);
                        break;
                    case 1: //몬스터일 때
                        ThisGameManager.monsters.SwapIndex(thisIndex, ThisGameManager.monsters.Top-1);
                        break;
                    default:
                        break;

                }
                ThisGameManager.dead.Add(this);
                ThisGameManager._isDestroy = true;
            }
        }
        public void AttackDamage()
        {
            EntityBase t;
            int index;
            if (TryGetTarget(out t,out index)==true)
            {
                Console.WriteLine($"{num}번{Name}가 {t.num}번 {t.Name}을 공격! {t.HP}-{AP}={t.HP-AP}");
                t.TakeDamage(AP,index);
                //Console.WriteLine("YEE"); //대충 에러났나? 용도
            }
            //Console.WriteLine("YEE2");
            //e.TakeDamage(AP,i);
        }
        public bool TryGetTarget(out EntityBase? target,out int index)
        {
            switch (Tag)
            {
                case 0: //0=플레이어일 때
                    index = _random.Next(ThisGameManager.monsters.Top);
                    target = ThisGameManager.monsters[index];
                    if (ThisGameManager.monsters[index] == default(EntityBase))
                    {
                        return false;
                    }
                    return true;
                case 1: //몬스터일 때
                    index = _random.Next(ThisGameManager.players.Top);
                    target = ThisGameManager.players[index];
                    if (ThisGameManager.monsters[index] == default(EntityBase))
                    {
                        return false;
                    }
                    return true;
                default:
                    target = default(EntityBase);
                    index = -1;
                    return false;

            }
        }

    }
}
