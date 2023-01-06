using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    // CameraController는 방금 받은 주체의 public Boolean 속성을 확인한다. 참이라면 BikeController에서 알림을 다시 받고 터보 토글이 꺼진 것을 확인할 때까지 카메라가 흔들리게 한다. 이때 중요한 것은 BikeController(주체)가 알림을 받은 후 HUD와 CameraController(관찰자)가 어떻게 작동할지 알지 못한다는 것이다. 주체가 변경된 사항을 알릴 때 어떻게 반응할지 선택하는 것은 관찰자의 재량이다.
    public class CameraController : Observer
    {
        private bool _isTurboOn;
        private Vector3 _initialPosition;
        private float _shakeMagnitude = 0.1f;
        private BikeController _bikeController;

        void OnEnable()
        {
            _initialPosition = gameObject.transform.localPosition;
        }

        void Update()
        {
            if (_isTurboOn)
            {
                gameObject.transform.localPosition = _initialPosition + (Random.insideUnitSphere * _shakeMagnitude);
            }
            else
            {
                gameObject.transform.localPosition = _initialPosition;
            }
        }

        public override void Notify(Subject subject)
        {
            if (!_bikeController)
                _bikeController = subject.GetComponent<BikeController>();

            if (_bikeController)
                _isTurboOn = _bikeController.IsTurboOn;
        }
    }
}
