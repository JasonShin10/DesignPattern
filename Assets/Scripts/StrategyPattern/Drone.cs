using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.Strategy
{
    public class Drone : MonoBehaviour
    {

        // Ray parameters
        private RaycastHit _hit;
        private Vector3 _rayDirection;
        private float _rayAngle = -45.0f;
        private float _rayDistance = 15.0f;

        // Movement parameters
        public float speed = 1.0f;
        public float maxHeight = 5.0f;
        public float weavingDistance = 1.5f;
        public float fallbackDistance = 20.0f;

        void Start()
        {
            _rayDirection =
                transform.TransformDirection(Vector3.back)
                * _rayDistance;

            _rayDirection =
                Quaternion.Euler(_rayAngle, 0.0f, 0f)
                * _rayDirection;
        }

        // ApplyStrategy() 메서드에는 전략 패턴의 핵심 메커니즘이 포함됐다.
        // ApplyStrategy() 메서드가 구체적으로 파라미터를 통해 IManeuverBehaviour류의 전략 지시를 받는다.
        // 전략을 실행할 때 런타임에 Maneuver()를 호출하기만 하면 된다. 따라서 Drone 객체는 어떻게 전략의 행동 및 알고리즘이 실행되는지 알지 못해도 된다. 인터페이스만 인식하면 된다.
        public void ApplyStrategy(IManeuverBehaviour strategy)
        {
            strategy.Maneuver(this);
        }

        void Update()
        {
            Debug.DrawRay(transform.position,
                _rayDirection, Color.blue);

            if (Physics.Raycast(
                transform.position,
                _rayDirection, out _hit, _rayDistance))
            {

                if (_hit.collider)
                {
                    Debug.DrawRay(
                        transform.position,
                        _rayDirection, Color.green);
                }
            }
        }
    }
}