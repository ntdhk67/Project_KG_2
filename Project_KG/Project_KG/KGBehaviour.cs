using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;

namespace Project_KG
{
    public abstract class KGBehaviour:IGameControll
    {
        public bool Enabled, Started = false;
        private KGList<IComponent> components = new KGList<IComponent>();
        protected KGEngine ThisEngine { get; set; } //일종의 scene 느낌으로 만드는 중
        public KGBehaviour(KGEngine kgEngine)
        {
            ThisEngine = kgEngine;
        }
        public void Subscribe_Enable()
        {
            ThisEngine.Test += Start;
            ThisEngine.Test += Update;
        }
        public void UnSubscribe_Disable()
        {
            ThisEngine.Test -= Start;
            ThisEngine.Test -= Update;
        }
        public T AddComponent<T>() where T : IComponent,new()
        {
            T component = new T();
            component.Parent = this;
            components.Add(component);
            return component;
        }
        public T GetComponent<T>() where T : IComponent,new()
        {
            foreach (var component in components)
            {
                if (component is T)
                {
                    return (T)component;
                }
            }
            return default(T);
        }
        protected virtual void Awake_KGB()
        {

        }
        protected virtual void Start_KGB()
        {

        }
        protected virtual void Update_KGB()
        {

        }
        protected void Death_KGB()
        {

        }
        protected void Enable_KGB()
        {
            if(Enabled==false)
            {
                Subscribe_Enable();
                Enabled = true;
            }
        }
        protected  void Disable_KGB()
        {
            if(Enabled==true)
            {
                UnSubscribe_Disable();
                Enabled = false;
            }
        }
        //받기
        public void Awake()
        {
            Awake_KGB();
        }
        public void Start()
        {
            if (Started == true)
            {
                return;
            }
            Start_KGB();
            Started = true;
        }
        public void Update()
        {
            Update_KGB();
        }
        public void SetActive(bool b)
        {
            if(b==true)
            {
                Enable_KGB();
            }
            else
            {
                Disable_KGB();
            }
        }
        public void Death()
        {
            Death_KGB();
        }
    }
}
