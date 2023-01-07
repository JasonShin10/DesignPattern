using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    //BikeController는 직접 HUDController나 CameraController를 호출하지 않는다. 해야 할 동작을 알려주지 않고 바뀐 것이 있다는 것만 알린다.
    //관찰자가 알림을 받을 때 독립적으로 행동 방식을 정할 수 있어 중요하다. 어느 정도 주체와 분리됐다.
    public class BikeController : Subject
    {
        // 초기화 코드
       public bool IsTurboOn
        {
            get; private set;
        }

        public float CurrentHealth
        { 
            get { return health; }
        }

        private bool _isEngineOn;
        private HUDController _hudController;
        private CameraController _cameraController;

        [SerializeField]
        private float health = 100.0f;

        void Awake()
        {
         _hudController = gameObject.AddComponent<HUDController>();
         _cameraController = (CameraController)FindObjectOfType(typeof(CameraController));
        }

        private void Start()
        {
            StartEngine();
        }
        // BikeController가 활성화될 때 관찰자를 연결하고 비활성화될 때 연결을 끊는 부분
        void OnEnable()
        {
            if (_hudController)
                Attach(_hudController);
            if (_cameraController)
                Attach(_cameraController);        
        }
        void OnDisable()
        {
            if (_hudController)
                Detach(_hudController);

            if (_cameraController)
                Detach(_cameraController);
        }

        // 핵심 동작의 기본 구현을 몇 가지 다룬다. 오토바이가 망가지거나 터보 차저가 활성화될 때 자전거의 파라미터가 업데이트되면 관찰자에게 알린다.
        private void StartEngine()
        {
            _isEngineOn = true;
            NotifyObserver();
        }

        public void ToggleTurbo()
        {
            if (_isEngineOn)
                IsTurboOn = !IsTurboOn;

            NotifyObserver();
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            IsTurboOn = false;

            NotifyObserver();

            if (health < 0)
                Destroy(gameObject);
        }
    }
}
