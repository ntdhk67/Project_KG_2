using System.Diagnostics;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
namespace Project_KG //string.Format(가져올 string, {0},{1},.... 등 거기에 넣어질 것들)
{
    public class MemoryPoolAuto
    {
        private Codes _codes=new Codes();
        public string MainStr;
        public string AddsStr;
        public string FunctionStr;
        public string InitStr;
        public string QueuesStr;
        public MemoryPoolAuto()
        {
            GetHeader();
            for(int i=0;i<6;i++)
            {
                GetFunction(i);
            }
            MainStr += string.Format(_codes.ClassHeader, "MemoryPool", QueuesStr, AddsStr, InitStr);
            using (StreamWriter writer = new StreamWriter("MemoryPool.cs"))
            {
             writer.Write(MainStr);
            }
        }
        private void GetHeader()
        {
            if (MainStr == null)
            {
                MainStr += _codes.CodeHeader;
            }
        }
        private void GetFunction(int i)
        {
            AddsStr += string.Format(_codes.Adds, _codes.EntityClasses[i]);
            QueuesStr += string.Format(_codes.Queues, _codes.EntityClasses[i]);
            InitStr += string.Format(_codes.Inits, _codes.EntityClasses[i]);
        }
    }
    public class Codes
    {
        public string[] EntityClasses = { "Archer" ,"Knight","Mage","Slime","Skeleton","Orc"};

        public string CodeHeader =
@"using System.Collections.Generic;
using System;
using System.Text;
using System.Threading.Tasks;
{0}
";
        //{0}은 혹시 더 넣을게 있을 경우? 뽑아내고 나서 해도 되긴 할 것 같지만
        public string ClassHeader =
@"namespace Project_KG
{{
    public class {0}
    {{
        private KGEngine ThisEngine;
        {1}
        public {0}(int maxSize=10,KGEngine engine)
        {{
            ThisEngine=engine;
            for(int i=0;i<maxSize;i++)
            {{
                {2}
            }}
        }}
        {3}

    }}
}}
";//그냥 네임스페이스도 여기 추가
        public string Queues =
@"public KGQueue<EntityBase> {0}Pool=new KGQueue<EntityBase>();
public int {0}Size=0;
";
        public string Adds =
@"{0}Add();
";
        public string Inits =
@"public void {0}Add()
{{
    {0}Pool.Enqueue(new {0}(ThisEngine,0));
    {0}Size++;
}}
public EntityBase {0}Get()
{{
    EntityBase obj;
    if({0}Pool.Count()<{0}Size)
    {{
        obj={0}Pool.Dequeue();
    }}
    else
    {{
        obj=new {0}();
    }}
    return obj;
}}
public void {0}Return(EntityBase obj)
{{
    obj.SetActive(false);
    if({0}Pool.Count()<{0}Size)
    {{
        {0}Pool.Enqueue(obj);
    }}
}}
";
    }
}