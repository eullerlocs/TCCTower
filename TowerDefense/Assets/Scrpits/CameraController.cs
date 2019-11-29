using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;

    public float panBoarderThickness = 10f;

    public float scrollSpeed = 5f;

    private float minY = 10f;
    private float maxY = 80f;
    

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }
        
       
        if(Input.mousePosition.y >=Screen.height-panBoarderThickness )
        {
            transform.Translate(Vector3.forward * panSpeed*Time.deltaTime,Space.World);
        }

        if (Input.mousePosition.y <= panBoarderThickness )
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.mousePosition.x >= Screen.width - (panBoarderThickness +50f))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (Input.mousePosition.x <= panBoarderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll *500* scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;


    }
}
