using UnityEngine;
using System.Collections;

public class RtsCamera : MonoBehaviour {

  public int LevelArea = 100;

    public int ScrollArea = 25;
    public int ScrollSpeed = 25;
    public int DragSpeed = 100;

    public int ZoomSpeed = 25;
    public int ZoomMin = 20;
    public int ZoomMax = 100;

    public int PanSpeed = 50;
    public int PanAngleMin = 25;
    public int PanAngleMax = 80;
	
	// Use this for initialization
	void Start () {
	 
	}
	
	// Update is called once per frame
	void Update () {
	
		// Init camera translation for this frame.
        var translation = Vector3.zero;

        // Zoom in or out
        var zoomDelta = Input.GetAxis("Mouse ScrollWheel")*ZoomSpeed*Time.deltaTime;
        if (zoomDelta!=0)
        {
            Camera.main.orthographicSize -=  ZoomSpeed * zoomDelta;
        }
		

		
        // Start panning camera if zooming in close to the ground or if just zooming out.
        //var pan = camera.transform.eulerAngles.x - zoomDelta;
        //pan = Mathf.Clamp(pan, PanAngleMin, PanAngleMax);
		
        //if (zoomDelta < 0 || camera.transform.position.y < (ZoomMax / 2))
        //{
            //camera.transform.eulerAngles = new Vector3(pan, 0, 0);
        //}

        // Move camera with arrow keys
        translation += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Move camera with mouse
       // if (Input.GetMouseButton(2)) // MMB
       // {
            // Hold button and drag camera around
       //     translation -= new Vector3(Input.GetAxis("Mouse X") * DragSpeed * Time.deltaTime, 0, 
       //                        Input.GetAxis("Mouse Y") * DragSpeed * Time.deltaTime);
       // }

        // Keep camera within level and zoom area
        //var desiredPosition = camera.transform.position + translation;
        //if (desiredPosition.x < -LevelArea || LevelArea < desiredPosition.x)
        //{
          //  translation.x = 0;
        //}
        //if (desiredPosition.y < ZoomMin || ZoomMax < desiredPosition.y)
        //{
        //    translation.y = 0;
        //}
        //if (desiredPosition.z < -LevelArea || LevelArea < desiredPosition.z)
        //{
          //  translation.z = 0;
        //}

        // Finally move camera parallel to world axis
        camera.transform.position += translation;
	}
}

