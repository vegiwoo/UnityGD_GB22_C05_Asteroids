using System;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace Asteroids.PlayerModule
{
    //[RequireComponent(typeof(Rigidbody))]
    public class PlayerView : MonoBehaviour
    {
        #region Links

        #endregion

        #region Variables & constants

        private const float Elevation = 10f;
        private Rigidbody _rigidbody;


        private Vector3 _moveDirection = Vector3.zero;
        private float _moveSpeed = 0.00f;
        #endregion

        #region Properties

        #endregion

        #region Monobehavior methods

        private void Awake()
        {
            transform.Translate(0,Elevation,0);
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_moveDirection != Vector3.zero && _moveSpeed > 0.00f)
            {
                _rigidbody.MovePosition(_rigidbody.position + _moveDirection * _moveSpeed * Time.fixedDeltaTime);
            }

        }

        #endregion

        #region Functionality

        public void ChangeDirection(Vector3 moveDirection, float moveSpeed)
        {
            _moveDirection = moveDirection;
            _moveSpeed = moveSpeed;
        }

        #endregion
    }
}