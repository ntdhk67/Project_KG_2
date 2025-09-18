using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG.Entities
{
    public class Mage:EntityBase,IPlayer
    {
        public Mage(KGEngine engine,int n) : base(engine,n, hp:50,ap:30,name:"Mage")
        {
        } //에잇 몰라 나중에 파싱써서 복붙해올꺼야
    }
}
