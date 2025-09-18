using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG.Entities
{
    public class Orc:EntityBase,IPlayer
    {
        public Orc(KGEngine engine, int n) : base(engine,n,hp:70,ap:15,name:"Orc")
        {
        } //에잇 몰라 나중에 복붙해올꺼야
    }
}
