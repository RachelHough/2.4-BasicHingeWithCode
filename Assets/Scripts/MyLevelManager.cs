using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLevelManager : MonoBehaviour {


    public static MyLevelManager instance;

   


    public HingeJoint2D hingeOne;



    public JointMotor2D motorValues;


	// Use this for initialization
	void Start () {

        instance = this;
       motorValues = hingeOne.motor;

	}
	
	// Update is called once per frame
	void Update () {

        

	}


    public void UseHingeOne()
    {

        motorValues.motorSpeed = 100;
        hingeOne.motor = motorValues;


    }






}
