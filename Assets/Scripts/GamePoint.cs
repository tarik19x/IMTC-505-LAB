using Unity.VisualScripting;
using UnityEngine;

namespace IMTC505.starter.SampleGame
{
    [RequireComponent(typeof(Collider))]
    public class GamePoint : MonoBehaviour
    {
        [SerializeField]
        public bool pile_or_Single = true;

        [Tooltip("Points scored by touching this object.")]

        
        public float points = 10;
        public float rotationSpeed = 60.0f; // Adjust the rotation speed as needed.

        [Tooltip("Event to trigger when controller interacts with point object.")]
        public System.Action<GamePoint> OnTriggerEnterAction;

        void Start()
        {
            // Make sure non of the colliders in child objects are active
            foreach (Collider collider in GetComponentsInChildren<Collider>())
            {
                collider.enabled = false;
            }

            // Make sure the root collider is a trigger and enabled
            Collider rootCollider = GetComponent<Collider>();
            rootCollider.enabled = true;
            rootCollider.isTrigger = true;

            if (pile_or_Single == true)
            {
                points = 50;
               
                    // Rotate the GameObject around its Y-axis.

                rotationSpeed = 0;
                pile_or_Single = false;
            }
            
        }
        void Update()
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * 2);

        }

        void OnTriggerEnter(Collider collider)
        {
            OnTriggerEnterAction?.Invoke(this);
        }
    }
}
