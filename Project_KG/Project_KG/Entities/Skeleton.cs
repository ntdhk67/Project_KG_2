using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG.Entities
{
    public class Skeleton:EntityBase,IPlayer
    {
        public Skeleton(KGEngine engine,int n) : base(engine,n,hp:30,ap:10,name:"Skeleton")
        {
        } //에잇 몰라 나중에 복붙해올꺼야
    }
}
