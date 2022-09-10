using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public float tetherLength;
    private Vector2 tetherPoint;
    public bool isTethered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.K)))
        {
            isTethered = true;
        }
        else
        {
            isTethered = false;
        }
    }

    public Vector2 getTetherPoint()
    {
        tetherPoint = transform.position;
        return tetherPoint;
    }

    public float getTetherLength()
    {
        return tetherLength;
    }


}
