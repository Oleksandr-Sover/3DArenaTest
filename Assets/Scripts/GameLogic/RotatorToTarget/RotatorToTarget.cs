using UnityEngine;

namespace GameLogic
{
    public class RotatorToTarget : MonoBehaviour, IRotatorToTarget
    {
        public void Rotate(Transform target, float speed)
        {
            Vector3 targetPosition = target.position;
            targetPosition.y = transform.position.y;
            Vector3 targetDirection = targetPosition - transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}