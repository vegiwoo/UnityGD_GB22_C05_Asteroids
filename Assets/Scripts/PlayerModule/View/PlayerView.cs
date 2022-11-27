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
        public Rigidbody RigidBody { get; private set; }
        
        private Vector3 _moveVertical;
        private Vector3 _moveHorizontal;
        private Vector3 _rotateDirection;
        #endregion

        #region Properties

        #endregion

        #region Monobehavior methods

        private void Awake()
        {
            _moveVertical = _moveHorizontal = _rotateDirection = Vector3.zero;
            transform.Translate(0,Elevation,0);
        }

        private void Start()
        {
            RigidBody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_moveVertical != Vector3.zero)
            {
                RigidBody.AddForce(_moveVertical * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }

            if (_moveHorizontal != Vector3.zero)
            {
                RigidBody.AddForce(_moveHorizontal * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }

            if (_rotateDirection != Vector3.zero)
            {
                RigidBody.AddRelativeTorque(_rotateDirection * Time.fixedDeltaTime, ForceMode.VelocityChange);
            }
        }

        #endregion

        #region Functionality

        public void ChangeMovement(Vector3 horizontal, Vector3 vertical)
        {
            _moveHorizontal = horizontal;
            _moveVertical = vertical;
        }

        public void ChangeRotation(Vector3 rotate)
        {
            _rotateDirection = rotate;
        }

        #endregion
    }
}