using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// namespace란 누군가 만들어높은 클래스 함수 변수들을 가져다 쓰는것.
namespace Chapter.Observer
{
    public abstract class Subject : MonoBehaviour
    {
        private readonly ArrayList _observers = new ArrayList();
    // Attach()와 Detach()는 각 옵저버 목록에서 옵저버 객체를 추가하거나 제거하는 역활을 한다. 
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }
    // NotifyObservers()는 옵저버 객체의 목록을 루프하면서 public 메서드인 Notify()를 호출한다.
        public void NotifyObserver()
        {
            foreach (Observer observer in _observers)
            {
                observer.Notify(this);
            }
        }
    }
}
