using CnControls;
using UnityEngine;

namespace Examples.Scenes.TouchpadCamera
{
    public class RotateCamera : MonoBehaviour
    {
        public float RotationSpeed = 40f;
        public Transform OriginTransform;

        public void FixedUpdate()
        {
            var horizontalMovement = CnInputManager.GetAxis("Horizontal");
			var verticalMovement = CnInputManager.GetAxis("Vertical");
            OriginTransform.Rotate(Vector3.up, horizontalMovement * Time.deltaTime * RotationSpeed);
			OriginTransform.Rotate(Vector3.left, verticalMovement * Time.deltaTime * RotationSpeed);
			Quaternion q = transform.rotation;
			if (q.eulerAngles.y > 80 && q.eulerAngles.y < 90) {
				q.eulerAngles = new Vector3(q.eulerAngles.x, 80, 0);
			} else if (q.eulerAngles.y > 270 && q.eulerAngles.y < 280) {
				q.eulerAngles = new Vector3(q.eulerAngles.x, 280, 0);
			} else {
				q.eulerAngles = new Vector3(q.eulerAngles.x, q.eulerAngles.y, 0);
			}
			transform.rotation = q;
		}
    }
}