using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG.Entities
{
    public class Knight:EntityBase,IPlayer
    {
        public Knight(KGEngine engine) : base(engine,hp:90,ap:10,name:"Knight")
        {
        } //에잇 몰라 나중에 복붙해올꺼야
    }
}
