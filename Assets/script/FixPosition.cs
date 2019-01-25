using UnityEngine;
using UnityEngine.XR;

public class FixPosition : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 trackingPos = InputTracking.GetLocalPosition(XRNode.CenterEye);
        transform.parent.position = -trackingPos * 0.1f;
    }
}
