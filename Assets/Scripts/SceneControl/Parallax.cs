using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform[] backgrounds;     //Array of all back and foregrounds to be Parallaxed
    private float[] parallaxScales;     //Proportion of the camera's movement to move the backgrounds by
    public float smoothing = 1f;        //How smooth the parralax is going to be. Make sure to set this above 0

    private Transform cam;              //Refrence to the main camera's transform
    private Vector3 previousCamPos;     //The postion of the camera in the previous frame

    //Called before start
    private void Awake()
    {
        //Set up camera refrence
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Store the frames position for later, get current camera postion on this frame
        previousCamPos = cam.position;

        //Assinging coresponding parallax scales
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //For each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            //Set the parallax is the opposite of the camera movement because the previous fram multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // Set a Target X postion which is the current postion plus the parallax 
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //Create a target position which is the background's current position with it's X position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //Fade between current postion and the target postion using a lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        // Set the previousCamPos to the camera's position at the end of the frame
        previousCamPos = cam.position;
    }
}
