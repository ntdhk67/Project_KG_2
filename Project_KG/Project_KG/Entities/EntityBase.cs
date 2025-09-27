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
        public int num { get; protected set; }
        protected int HP { get; set; }
        public int HP_Check => HP;
        protected int AP { get; }
        protected readonly int MaxHp;
        public string Name { get; }
        //public int Tag { get; }
        public bool isDead = false;
        private Random _random => ThisEngine._rnd;
        protected EntityBase(KGEngine engine, int n, int hp, int ap, String name) : base(engine)
        {
            MaxHp = hp;
            HP = hp;
            AP = ap;
            Name = name; //와아 나도 나중에 파싱 써봐야지
            num = n;
            //나중에 옮길 예정(옮겨짐)
        }
        //라이프 사이클
        protected override void Awake_KGB()
        {

        }
        protected override void Start_KGB()
        {

        }
        public void Reset(int n)
        {
            HP = MaxHp;
            num = n;
            Started = false;
            isDead = false; //얘를 안 넣어놨구나 김대한 이 빡대가리
            Subscribe_Enable();
        }
        protected override void Update_KGB()
        {
            //Console.WriteLine((int)Tag); //잘 가져오는지 테스트
            if(isDead==false)
            {
                AttackDamage();
            }
        }
        //기타 처리 (Enable Disable OnDeath 등 처리 필요시 예약)

        public void TakeDamage(int dmg,int thisIndex)
        {
            HP -= dmg;
            //사망 bool만 해두기
            if (HP <= 0&&isDead==false)
            {
                if (this is IPlayer)
                {
                    ThisGameManager.players.SwapIndex(thisIndex, ThisGameManager.players.Top-1);
                }
                else if (this is IMonster)
                {
                    ThisGameManager.monsters.SwapIndex(thisIndex, ThisGameManager.monsters.Top-1);
                    ThisGameManager._killCount++;
                }
                else
                {
                }
                //isDead = true;
                ThisGameManager.dead.Add(this);
                ThisGameManager._isDestroy = true;
                Death();
            }
        }
        public void AttackDamage()
        {
            //Console.WriteLine(this.Name);
            EntityBase t;
            int index;
            if (TryGetTarget(out t,out index)==true &&t.isDead is false )
            {
                Console.WriteLine($"{num}번{Name}가 {t.num}번 {t.Name}을 공격! {t.HP}-{AP}={t.HP - AP}");
                t.TakeDamage(AP, index);
                //Console.WriteLine("YEE"); //대충 에러났나? 용도
            }
            //Console.WriteLine("YEE2");
            //e.TakeDamage(AP,i);
        }
        public bool TryGetTarget(out EntityBase? target,out int index)
        {
            if(this is IPlayer)
            {
                index = _random.Next(ThisGameManager.monsters.Top);
                target = ThisGameManager.monsters[index];
                if (ThisGameManager.monsters[index] == default(EntityBase))
                {
                    Console.WriteLine($"{num}{Name}{index}{target}문제다"); //if 파이프라인 비용 있지만 방어막으로서
                    return false;
                }
                return true;
            }
            else if(this is IMonster)
            {
                index = _random.Next(ThisGameManager.players.Top);
                target = ThisGameManager.players[index];
                if (ThisGameManager.players[index] is default(EntityBase))
                {
                    Console.WriteLine($"{num}{Name}{index}{target}문제다");
                    return false;
                }
                return true;
            }
            else
            {
                target = default(EntityBase);
                index = -1;
                return false;
            }
        }
        protected void Death_KGB()
        {
            isDead = true;
            UnSubscribe_Disable();
        }
        public void Death()
        {
            Death_KGB();
        }
    }
}
