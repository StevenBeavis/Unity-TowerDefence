﻿
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //personal
   

    public float panSpeed = 30f;

    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;

    public float minY;
    public float maxY;

    public float minX;
    public float maxX;

    public float minZ;
    public float maxZ;



    // Update is called once per frame
    void Update()
    {
        if (GameManager.GameHasEnded)
        {
            this.enabled = false;
            return;
        }

       
       



        if (Input.GetKey("w")|| Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll *  1000 * scrollSpeed * Time.deltaTime; 
        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, minX, maxX),Mathf.Clamp(transform.position.y, minY, maxY),
          Mathf.Clamp(transform.position.z, minZ, maxZ));

        
    }
}