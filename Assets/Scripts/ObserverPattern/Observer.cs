using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public abstract class Observer : MonoBehaviour
    {
        // 옵저버가 되고자 하는 클래스는 Observer 클래스를 상속받아 Subject를 파라미터로 받는 Notify() 추상 메서드를 구현해야한다.
        public abstract void Notify(Subject subject);
    }
}


