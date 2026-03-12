using UnityEngine;

public class DynamicBodyCollider : MonoBehaviour
{
    public CapsuleCollider bodyCollider;
    public Transform headCamera;

    void Update()
    {
        // 1. Get the current height of the VR headset
        float headHeight = headCamera.localPosition.y;

        // 2. Prevent the capsule from turning inside out if the headset tracks too low
        bodyCollider.height = Mathf.Clamp(headHeight, 0.2f, 2.5f);

        // 3. Keep the capsule centered under the player's head as they lean
        bodyCollider.center = new Vector3(headCamera.localPosition.x, bodyCollider.height / 2f, headCamera.localPosition.z);
    }
}