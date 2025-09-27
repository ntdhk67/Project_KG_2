using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_KG.Interfaces;
using Project_KG.Scene;

namespace Project_KG
{
    public abstract class KGBehaviour
    {
        public bool Enabled, Started = false;
        private KGList<IComponent> components = new KGList<IComponent>();
        public KGEngine ThisEngine { get;} 
        public GameManager ThisGameManager { get; set; }//일종의 scene 느낌으로 만드는 중
        public KGBehaviour(KGEngine kgEngine)
        {
            ThisEngine = kgEngine;
            //ThisGameManager = ThisEngine.GM[ThisEngine.SceneNum];
            ThisGameManager = kgEngine.GM;
            Awake();
        }
        public void Subscribe_Enable()
        {
            ThisEngine.OnIfOnEnable();
            ThisEngine.LifecycleOnEnable += OnEnable; //인터페이스로 따로 두고 구현했는지 체크해서 if로 빼는게 무조건 구독보단 싸겠다
            if(Started==false)
            {
                ThisEngine.OnIfStart();
                ThisEngine.LifecycleStart += Start; //중복 방지
            }
            ThisEngine.LifecycleUpdate += Update;
        }
        public void UnSubscribe_Disable()
        {
            ThisEngine.LifecycleOnEnable -= OnEnable;
            ThisEngine.LifecycleStart -= Start; //구독한적 없어도 if 없이 -=해도 됨 (List와 같은 이유)
            ThisEngine.LifecycleStart -= Update;
            //ThisEngine.OnIfOnDisable();
            //ThisEngine.LifecycleOnDisable += OnDisable;
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

        protected void Enable_KGB()
        {
            if(Enabled==false)
            {
                Subscribe_Enable();
                Enabled = true;
            }
        }
        protected void Disable_KGB()
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
                ThisEngine.LifecycleStart -= Start;
                return;
            }
            Start_KGB();
            Started = true;
            ThisEngine.LifecycleStart -= Start;
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
        public virtual void OnEnable()
        {
            ThisEngine.LifecycleOnEnable -= OnEnable;
        }
        public virtual void OnDisable()
        {

        }
    }
}
