using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_KG
{
    public class KGQueue<T>
    {
        private T[] _queue;
        private int _countStart = 0, _countNow = 0, _max; //제거될 쪽 인덱스, 현재 인덱스, 크기
        public KGQueue(int s = 100)
        {
            if (s < 0)
            {
                s = 0;
            }
            _queue = new T[s]; // 사이즈
            _max = s - 1;
        }
        public T this[int i]
        {
            get { return _queue[i]; }
        }
        public void Enqueue(T t)
        {
            _queue[_countNow++ % _max] = t;
        }
        public T Dequeue()
        {
            //Down();
            return _queue[_countStart++ % _max];
        }
        private void Down()
        {
            if (_countStart > _max && _countNow > _max)
            {
                _countStart -= _max;
                _countNow -= _max;
            }
        }
        public void Clear()
        {
            _countStart = _countNow = 0;
        }
        public bool Contains(T t)
        {
            for (int i = _countStart; i < _countNow; i++)
            {
                if (EqualityComparer<T>.Default.Equals(t, _queue[i % _max]))
                {
                    return true;
                }
            }
            return false;
        }
        public int EnsureCapacity(int c) //RESIZE랑 비슷하나 있길래
        {
            if (c <= _countNow - _countStart + 1)
            {
                return _countNow - _countStart + 1;
            }
            else
            {
                RESIZE_KDH(c);
                return c;
            }
        }
        public void RESIZE(int l)
        {
            RESIZE_KDH(l);
        }
        private void RESIZE_KDH(int L)
        {
            T[] s = _queue;
            _queue = new T[L];
            if (_countNow - _countStart > L)
            {
                for (int i = 0; i < L; i++)
                {
                    _queue[i] = s[(i + (_countNow - _countStart) - L) % _max];
                }
                _countNow = L;
            }
            else
            {
                for (int i = 0; i < _countNow - _countStart; i++)
                {
                    _queue[i] = s[(i + _countStart) % _max];
                }
                _countNow -= _countStart;
            }
            _countStart = 0;
            _max = L - 1;
        }
        public T Peek()
        {
            return _queue[_countStart];
        }
        public int Count()
        {
            return _countNow-_countStart;
        }
    }
}
