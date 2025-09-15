using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_KG
{
    public class KGList<T>
    {
        private T[] _list;
        private int _num = 0, _max;
        public int Top => _num;
        public KGList(int s = 100)
        {
            if (s < 0)
            {
                s = 0;
            }
            _list = new T[s]; // 사이즈
            _max = s - 1;
        }

        public T this[int i]
        {
            get { return _list[i]; }
        }

        public void Add(T t)
        {
            if (_num == _max)
            {
                RESIZE_KDH(_list.Length * 2); //초과된 경우?
            }
            _list[_num++] = t;
        }
        public void Remove(T t)
        {
            int j = IndexOf(t);
            if (j < 0)
            {
                return;
            }
            RSet(j);
        }
        public void RemoveAt(int index)
        {
            RSet(index);
        }
        private void RSet(int n) //1칸 땡겨요
        {
            for (int i = n; i < _num; i++)
            {
                _list[i] = _list[i + 1];
            }
            _num--;

        }
        public int IndexOf(T t, int index = 0) //T비교 어케시키지;;;;
        {
            for (int i = index; i < _num; i++)
            {
                if (EqualityComparer<T>.Default.Equals(t, _list[i])) //마소 공식 사이트에서 보니까 List<T> 자료에서 T비교에 이거 쓰네
                {
                    return i;
                }
            }
            return -1;
        }
        public bool Contains(T t)
        {
            for (int i = 0; i < _num; i++)
            {
                if (EqualityComparer<T>.Default.Equals(t, _list[i])) //그냥 다이렉트로 반환 하려고 위에꺼 CTRL C+V
                {
                    return true;
                }
            }
            return false;
        }
        public void Reverse()
        {
            for (int i = 0; i < (_num / 2) + 1; i++) //9( 0-9 1-8 2-7 3-6 4-5) 10(0-10 1-9 2-8 3-7 4-6 5-5) //5(3) 5[0]-9[4] 6[1]-8[3] 7[2]-7[2]
            {
                T t = _list[i];
                _list[i] = _list[_num - 1 - i];
                _list[_num - 1 - i] = t;
            }
        }

        private void RESIZE_KDH(int L)
        {
            T[] s = _list;
            _list = new T[L];
            if (_num > L)
            {
                for (int i = 0; i < L; i++)
                {
                    _list[i] = s[i];
                }
                _num = L;
            }
            else
            {
                for (int i = 0; i < _num; i++)
                {
                    _list[i] = s[i];
                }
            }
            _max = L - 1;
        }
        public void RESIZE(int l)
        {
            RESIZE_KDH(l);
        }
        public void Clear()
        {
            _num = 0;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i=0;i<_num;i++)
            {
                yield return _list[i];
            }
        }
    }
}
