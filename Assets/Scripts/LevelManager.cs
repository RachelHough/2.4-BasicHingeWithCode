using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    // The HingeJoint2D component on a GameObject is "powered"/implemented by a HingeJoint2D
    // object. I am going to create a variable that can store a HingeJoint2D object and
    // 'wire it up' via the inspector.
    public HingeJoint2D pivotHingeJoint;

    // Just for demonstration purposes I am going to set the spinningHingeJoint variable
    // below not by 'wiring it up' via the inspector but by using tags. If you have a look
    // at the SpinningHinge game object in the scene you will notice that I have tagged
    // it "Propeller"
    private HingeJoint2D spinningHingeJoint;

	// Use this for initialization
	void Start () {
        // Let's ask the Unity Engine to search for all Game Objects that are tagged "Propeller"
        // and to return us the 'first' one it finds. This is safe for us to do in this example
        // as we only have one Game Object tagged "Propeller".
        GameObject propellerGO = GameObject.FindGameObjectWithTag("Propeller");

        // Now let's get the HingeJoint2D component
        spinningHingeJoint = propellerGO.GetComponent<HingeJoint2D>();

        // Okay, we're ready to go
	}
	
	// Update is called once per frame
	void Update () {

        // Just to keep things tidy, I wrote a function that checks for keyboard
        // inputs
        CheckForKeyboardInputs();
    }

    private void CheckForKeyboardInputs()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            // The motor property of the HingeJoint2D component is represented by a
            // JointMotor2D object. How do I know all this? I searched for Hinge Joint 2D in the 
            // Scripting API section of the Unity documentation and found the documentation for
            // HingeJoint2D class/script, https://docs.unity3d.com/ScriptReference/HingeJoint2D.html.
            // I see that is has a motor property thatm when I click on it, is implemented using
            // a JointMotor2D class/script.
            // So I create a variable that can hold a JointMotor2D object and then I take a copy of
            // the JointMotor2D object that is on the HingeJoint2D object, i.e. the Hinge Joint 2D
            // component on the game object, and store it in a variable called theMotor
            JointMotor2D theMotor = pivotHingeJoint.motor;

            // I see that the JointMotor2D class has a motorSpeed ( https://docs.unity3d.com/ScriptReference/JointMotor2D.html )
            // which is a float. So I am going to set it to 100.
            // REMEMBER: I am changed the motor speed on theMotor object which is a COPY of the one 
            // that is on the HingeJoint2D component.
            theMotor.motorSpeed = 100f;

            // Finally I overwrite the JointMotor2D object on the HingeJoint2D component with the
            // copy that I have modified.
            pivotHingeJoint.motor = theMotor;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            // The code here is very similar to the code below except it changes the speed to -100
            JointMotor2D theMotor = pivotHingeJoint.motor;
            theMotor.motorSpeed = -100f;

            pivotHingeJoint.motor = theMotor;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            spinningHingeJoint.useMotor = true;
        }
    }
}
