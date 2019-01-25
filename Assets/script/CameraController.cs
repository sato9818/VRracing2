using UnityEngine;
using UnityEngine.XR;
using System.Collections;

public class CameraController : MonoBehaviour {


	public Transform head;
void Update () {
    // TODO: ここで固定したい位置があれば指定しておく
    

    // VR.InputTracking から hmd の位置を取得
    Vector3 trackingPos =
            InputTracking.GetLocalPosition(XRNode.CenterEye);

    // CameraController 自体の rotation が
    // zero でなければ rotation を掛ける
    // trackingPosition = trackingPos * transform.rotation;

    // 固定したい位置から hmd の位置を
    // 差し引いて実質 hmd の移動を無効化する
    transform.position = head.position - trackingPos;
}

}