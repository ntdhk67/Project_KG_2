using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG.Entities
{
    public abstract class EntityBase:KGBehaviour
    {
        protected int HP { get; set; }
        public int HP_Check => HP;
        protected int AP { get; }
        public string Name { get; }
        public int Tag { get; }
        private Random _random => ThisEngine._rnd;
        protected EntityBase(KGEngine engine,int hp, int ap, String name) : base(engine)
        {
            HP = hp;
            AP = ap;
            Name = name;
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

        public void TakeDamage(int dmg)
        {
            HP -= dmg;
            //사망 bool만 해두기
        }
        public void AttackDamage()
        {

        }

        //Tag로 체크 어케하지???

        /*protected EntityBase GetTarget()
        {
            switch(Tag)
            {
                case 0: //0=플레이어일 때
                    int i = _random.Next(ThisGameManager.monsters.Top);
                    EntityBase e=ThisGameManager.monsters[i];
                    if(e.Enabled==false)
                    {
                        e=ThisGameManager.monsters[i+1];
                    }
                    return 
                case 1: //몬스터일 때
            }
        }*/
    }
}
