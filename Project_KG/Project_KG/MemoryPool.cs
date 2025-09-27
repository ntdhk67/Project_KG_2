using System.Collections.Generic;
using System;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Project_KG.Interfaces;
using Project_KG.Scene;
namespace Project_KG
{
    public class MemoryPool
    {
        public KGEngine ThisEngine;
        //public KGQueue<EntityBase> ArcherPool = new KGQueue<EntityBase>();
        public Queue<EntityBase> ArcherPool=new Queue<EntityBase>();
        public int ArcherSize = 0;
        // public KGQueue<EntityBase> KnightPool = new KGQueue<EntityBase>();
        public Queue<EntityBase> KnightPool = new Queue<EntityBase>();
        public int KnightSize = 0;
        //public KGQueue<EntityBase> MagePool = new KGQueue<EntityBase>();
        public Queue<EntityBase> MagePool = new Queue<EntityBase>();
        public int MageSize = 0;
        //public KGQueue<EntityBase> SlimePool = new KGQueue<EntityBase>();
        public Queue<EntityBase> SlimePool = new Queue<EntityBase>();
        public int SlimeSize = 0;
        //public KGQueue<EntityBase> SkeletonPool = new KGQueue<EntityBase>();
        public Queue<EntityBase> SkeletonPool = new Queue<EntityBase>();
        public int SkeletonSize = 0;
        //public KGQueue<EntityBase> OrcPool = new KGQueue<EntityBase>();
        public Queue<EntityBase> OrcPool = new Queue<EntityBase>();
        public int OrcSize = 0;

        public MemoryPool(KGEngine engine)
        {
            ThisEngine = engine;
            for (int i = 0; i < 10; i++)
            {
                ArcherAdd();
                KnightAdd();
                MageAdd();
                SlimeAdd();
                SkeletonAdd();
                OrcAdd();
            }
        }
        public void ArcherAdd()
        {
            ArcherPool.Enqueue(new Archer(ThisEngine, 0));
            ArcherSize++;
        }
        public EntityBase ArcherGet(int n)
        {
            EntityBase obj;
            //Console.WriteLine(ArcherPool.Count());
            if (ArcherPool.Count() > 0)
            {
                obj = ArcherPool.Dequeue();
                //obj.SetActive(true);
            }
            else
            {
                obj = new Archer(ThisEngine, n);
            }
            obj.Reset(n);
            return obj;
        }
        public void ArcherReturn(EntityBase obj)
        {
            //obj.SetActive(false);
            if (ArcherPool.Count() < ArcherSize)
            {
                ArcherPool.Enqueue(obj);
            }
        }
        public void KnightAdd()
        {
            KnightPool.Enqueue(new Knight(ThisEngine, 0));
            KnightSize++;
        }
        public EntityBase KnightGet(int n)
        {
            EntityBase obj;
            //Console.WriteLine(KnightPool.Count());
            if (KnightPool.Count() > 0)
            {
                obj = KnightPool.Dequeue();
                //obj.SetActive(true);
            }
            else
            {
                obj = new Knight(ThisEngine, n);
            }
            obj.Reset(n);
            return obj;
        }
        public void KnightReturn(EntityBase obj)
        {
            //obj.SetActive(false);
            if (KnightPool.Count() < KnightSize)
            {
                KnightPool.Enqueue(obj);
            }
        }
        public void MageAdd()
        {
            MagePool.Enqueue(new Mage(ThisEngine, 0));
            MageSize++;
        }
        public EntityBase MageGet(int n)
        {
            EntityBase obj;
            //Console.WriteLine(MagePool.Count());
            if (MagePool.Count() > 0)
            {
                obj = MagePool.Dequeue();
                //obj.SetActive(true);
            }
            else
            {
                obj = new Mage(ThisEngine, n);
            }
            obj.Reset(n);
            return obj;
        }
        public void MageReturn(EntityBase obj)
        {
            //obj.SetActive(false);
            if (MagePool.Count() < MageSize)
            {
                MagePool.Enqueue(obj);
            }
        }
        public void SlimeAdd()
        {
            SlimePool.Enqueue(new Slime(ThisEngine, 0));
            SlimeSize++;
        }
        public EntityBase SlimeGet(int n)
        {
            EntityBase obj;
            //Console.WriteLine(SlimePool.Count());
            if (SlimePool.Count() > 0)
            {
                obj = SlimePool.Dequeue();
                //obj.SetActive(true);
            }
            else
            {
                obj = new Slime(ThisEngine, n);

            }
            obj.Reset(n);
            return obj;
        }
        public void SlimeReturn(EntityBase obj)
        {
            //obj.SetActive(false);
            if (SlimePool.Count() < SlimeSize)
            {
                SlimePool.Enqueue(obj);
            }
        }
        public void SkeletonAdd()
        {
            SkeletonPool.Enqueue(new Skeleton(ThisEngine, 0));
            SkeletonSize++;
        }
        public EntityBase SkeletonGet(int n)
        {
            EntityBase obj;
            //Console.WriteLine(SkeletonPool.Count());
            if (SkeletonPool.Count() > 0)
            {
                obj = SkeletonPool.Dequeue();
                //obj.SetActive(true);
            }
            else
            {
                obj = new Skeleton(ThisEngine, n);
            }
            obj.Reset(n);
            return obj;
        }
        public void SkeletonReturn(EntityBase obj)
        {
            //obj.SetActive(false);
            if (SkeletonPool.Count() < SkeletonSize)
            {
                SkeletonPool.Enqueue(obj);
            }
        }
        public void OrcAdd()
        {
            OrcPool.Enqueue(new Orc(ThisEngine, 0));
            OrcSize++;
        }
        public EntityBase OrcGet(int n)
        {
            EntityBase obj;
            //Console.WriteLine(OrcPool.Count());
            if (OrcPool.Count() >0)
            {
                obj = OrcPool.Dequeue();
                //obj.SetActive(true);
            }
            else
            {
                obj = new Orc(ThisEngine, n);
            }
            obj.Reset(n);
            return obj;
        }
        public void OrcReturn(EntityBase obj)
        {
            //obj.SetActive(false);
            if (OrcPool.Count() < OrcSize)
            {
                OrcPool.Enqueue(obj);
            }
        }
    }
}
