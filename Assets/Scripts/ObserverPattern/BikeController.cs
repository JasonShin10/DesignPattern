using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Observer
{
    //BikeController�� ���� HUDController�� CameraController�� ȣ������ �ʴ´�. �ؾ� �� ������ �˷����� �ʰ� �ٲ� ���� �ִٴ� �͸� �˸���.
    //�����ڰ� �˸��� ���� �� ���������� �ൿ ����� ���� �� �־� �߿��ϴ�. ��� ���� ��ü�� �и��ƴ�.
    public class BikeController : Subject
    {
        // �ʱ�ȭ �ڵ�
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
        // BikeController�� Ȱ��ȭ�� �� �����ڸ� �����ϰ� ��Ȱ��ȭ�� �� ������ ���� �κ�
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

        // �ٽ� ������ �⺻ ������ �� ���� �ٷ��. ������̰� �������ų� �ͺ� ������ Ȱ��ȭ�� �� �������� �Ķ���Ͱ� ������Ʈ�Ǹ� �����ڿ��� �˸���.
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
