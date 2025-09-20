using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG.Entities
{
    public class Slime:EntityBase,IMonster
    {
        public Slime(KGEngine engine,int n) : base(engine,n,hp:50,ap:10,name:"Slime")
        {
        } //에잇 몰라 나중에 복붙해올꺼야
    }
}
