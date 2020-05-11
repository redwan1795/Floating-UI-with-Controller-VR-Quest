using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerMovementScript : MonoBehaviour
{

    public GameObject camera;
    public const float WALK_SPEED = 2.5f;
    public const float RUN_SPEED = 6f;

    public GameObject leftController, rightController;

    public GameObject canvas;

    public Text myText;

    // Start is called before the first frame update
    void Start()
    {
        myText.text = "menu";
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector3 movement = camera.transform.TransformDirection(input.x, 0, input.y);

        movement.y = 0;
        movement = movement.magnitude == 0 ? Vector3.zero : movement / movement.magnitude;
        movement *= Time.deltaTime * (OVRInput.Get(OVRInput.Button.PrimaryThumbstick) ? RUN_SPEED: WALK_SPEED) * input.magnitude;
        this.transform.Translate(movement);

        //controller tracking

        leftController.transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
        leftController.transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);

        canvas.transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);

        /*
        canvas.transform.localPosition.x = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).x + 10.0;
        canvas.transform.localPosition.y = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).y + 10.0;
        canvas.transform.localPosition.z = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).z + 10.0;
        */

        canvas.transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);

        rightController.transform.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
        rightController.transform.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);

    }
}
