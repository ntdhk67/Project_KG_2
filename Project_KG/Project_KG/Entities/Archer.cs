using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG.Entities
{
    public class Archer:EntityBase,IPlayer
    {
        public Archer(KGEngine engine,int n) : base(engine,n, hp:70,ap:20,name:"Archer")
        {
        } //에잇 몰라 나중에 복붙해올꺼야
    }
}
