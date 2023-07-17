using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public Transform activeRoom;
    public float dampSpeed;

    public static CameraController instance;
    [Range(-5,10)]
    public float minModX, maxModX, minModY, maxModY;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
        var maxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var minPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y + maxModX;

        Vector3 clampedPos = new Vector3(
           Mathf.Clamp(player.position.x, minPosX, maxPosX),
            Mathf.Clamp(player.position.y,minPosY, maxPosY),
            Mathf.Clamp(player.position.z, -10f, -10f)
            );

        Vector3 smothPos = Vector3.Lerp(transform.position, clampedPos, dampSpeed * Time.deltaTime);

        transform.position = smothPos;
       

        
    }
}
 