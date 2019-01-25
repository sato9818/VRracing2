using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosController : MonoBehaviour
{

    public Transform Camera;
    public Transform Unitychan;
    public Transform Head;
    public Transform LeftFoot;
    public Transform RightFoot;
    public Transform Hip;
    public Transform BikeLeftFoot;
    public Transform BikeRightFoot;
    public Transform BikeHip;


    void Update()
    {
        //Unitychan.position = Camera.position - (Head.position - Unitychan.position);
        //Unitychan.position = BikeHip.position - (Hip.position - Unitychan.position);
        Camera.position = Head.position;

        //LeftFoot.position = BikeLeftFoot.position;
        //RightFoot.position = BikeRightFoot.position;
        //Hip.position = BikeHip.position;


    }
}