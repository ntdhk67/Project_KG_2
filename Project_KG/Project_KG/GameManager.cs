using Project_KG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG
{
    public class GameManager:KGBehaviour
    {
        //private int i = 0; //순서 테스트
        protected KGList<EntityBase> _players = new KGList<EntityBase>();
        protected KGList<EntityBase> _monsters = new KGList<EntityBase>();
        public KGList<EntityBase> players =>_players;
        public KGList<EntityBase> monsters=>_monsters;

        public GameManager(KGEngine engine) : base(engine)
        {
        }
        protected override void Awake_KGB()
        {

        }
        protected override void Start_KGB()
        {
            players.Add(new Knight(ThisEngine));
        }
        protected override void Update_KGB()
        {
            //Console.WriteLine($"{i++}"); //순서 테스트
            
        }
    }
}
