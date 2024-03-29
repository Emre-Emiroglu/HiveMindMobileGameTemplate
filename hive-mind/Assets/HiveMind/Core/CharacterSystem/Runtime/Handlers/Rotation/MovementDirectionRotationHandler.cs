using HiveMind.Core.CharacterSystem.Runtime.Datas.ValueObjects;
using HiveMind.Core.CharacterSystem.Runtime.Enums;
using HiveMind.Utilities.Extensions;
using UnityEngine;

namespace HiveMind.Core.CharacterSystem.Runtime.Handlers.Rotation
{
    public sealed class MovementDirectionRotationHandler : RotationHandler
    {
        #region ReadonlyFields
        private readonly Camera camera;
        #endregion

        #region Constructor
        public MovementDirectionRotationHandler(Camera camera, Transform transform, RotationData rotationData) : base(transform, rotationData)
        {
            this.camera = camera;
        }
        #endregion

        #region Dispose
        public override void Dispose() => base.Dispose();
        #endregion

        #region Set
        public override void SetEnableStatus(bool isEnable) => base.SetEnableStatus(isEnable);
        #endregion

        #region Executes
        public override void Execute(Vector2 inputValue) => base.Execute(inputValue);
        protected override void ExecuteProcess(Vector2 inputValue)
        {
            base.ExecuteProcess(inputValue);

            if (inputValue == Vector2.zero)
                return;

            Matrix4x4 matrix = Utilities.Utilities.IsoMatrix(Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f));

            Vector3 input = new(inputValue.x, 0f, inputValue.y);
            input = input.InputToIso(matrix);
            Vector3 direction = (transform.position + input) - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float speed = rotationData.RotationSpeed;
            float time = Time.deltaTime;

            switch (rotationData.RotationStyle)
            {
                case RotationStyles.Quaternion:
                    QuaternionRotate(angle, speed, time);
                    break;
                case RotationStyles.Euler:
                    EulerRotate(angle, speed, time);
                    break;
            }
        }
        private void QuaternionRotate(float angle, float speed, float time)
        {
            Quaternion startRotation = rotationData.RotationSpace == Space.World ? transform.rotation : transform.localRotation;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
            Quaternion lerpRotation = rotationData.IsSlerp ? Quaternion.Slerp(startRotation, targetRotation, speed * time) : Quaternion.Lerp(startRotation, targetRotation, speed * time);

            switch (rotationData.RotationSpace)
            {
                case Space.World:
                    transform.rotation = lerpRotation;
                    break;
                case Space.Self:
                    transform.localRotation = lerpRotation;
                    break;
            }
        }
        private void EulerRotate(float angle, float speed, float time)
        {
            Vector3 startRotation = rotationData.RotationSpace == Space.World ? transform.eulerAngles : transform.localEulerAngles;
            Vector3 targetRotation = new(0f, angle, 0f);
            Vector3 lerpRotation = rotationData.IsSlerp ? Vector3.Slerp(startRotation, targetRotation, speed * time) : Vector3.Lerp(startRotation, targetRotation, speed * time);

            switch (rotationData.RotationSpace)
            {
                case Space.World:
                    transform.eulerAngles = lerpRotation;
                    break;
                case Space.Self:
                    transform.localEulerAngles = lerpRotation;
                    break;
            }
        }
        #endregion
    }
}
