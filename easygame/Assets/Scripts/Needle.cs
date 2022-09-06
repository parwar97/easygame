using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    private float tetherLength;
    private Vector2 tetherPoint;
    public bool isTethered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 getTetherPoint()
    {
        return tetherPoint;
    }

    public float getTetherLength()
    {
        return tetherLength;
    }


}
