using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{

    public class HUDController : Observer
    {
        private bool _isTurboOn;
        private float _currentHealth;
        private BikeController _bikeController;

        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(50, 50, 100, 200));
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Health: " + _currentHealth);
            GUILayout.EndHorizontal();

            if (_isTurboOn)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("Turbo Activated!");
                GUILayout.EndHorizontal();
            }

            if (_currentHealth <= 50.0f)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("WARNING: Low Health");
                GUILayout.EndHorizontal();
            }

            GUILayout.EndArea();
        }
        // Notify() 메서드는 신호를 보낸 서브젝트의 참조를 받는다. 속성에 접근하고 인터페이스에 표시할 속성을 선택할 수 있다.

        public override void Notify(Subject subject)
        {
            if (!_bikeController)
                _bikeController = subject.GetComponent<BikeController>();

            if (_bikeController)
            {
                _isTurboOn = _bikeController.IsTurboOn;
                _currentHealth = _bikeController.CurrentHealth;
            }
        }
    }
 
}