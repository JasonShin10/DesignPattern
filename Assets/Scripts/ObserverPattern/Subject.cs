using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// namespace�� ������ �������� Ŭ���� �Լ� �������� ������ ���°�.
namespace Chapter.Observer
{
    public abstract class Subject : MonoBehaviour
    {
        private readonly ArrayList _observers = new ArrayList();
    // Attach()�� Detach()�� �� ������ ��Ͽ��� ������ ��ü�� �߰��ϰų� �����ϴ� ��Ȱ�� �Ѵ�. 
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }
    // NotifyObservers()�� ������ ��ü�� ����� �����ϸ鼭 public �޼����� Notify()�� ȣ���Ѵ�.
        public void NotifyObserver()
        {
            foreach (Observer observer in _observers)
            {
                observer.Notify(this);
            }
        }
    }
}
