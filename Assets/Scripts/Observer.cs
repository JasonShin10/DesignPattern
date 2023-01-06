using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    public abstract class Observer : MonoBehaviour
    {
        // �������� �ǰ��� �ϴ� Ŭ������ Observer Ŭ������ ��ӹ޾� ������Ʈ�� �Ķ���ͷ� �޴� Notify() �߻� �޼��带 �����ؾ��Ѵ�.
        public abstract void Notify(Subject subject);
    }
}


