using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSwinging : MonoBehaviour
{
    [SerializeField] public Needle needle;
    private Rigidbody2D rb;
    private float tetherLength;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tetherLength = needle.getTetherLength();
    }

    // Update is called once per frame
    void Update()
    {
        if(needle.isTethered = true)
        {
            Vector testPosition = transform.position + rb.velocity * Time.deltaTime;
            if (testPosition - needle.getTetherPoint()).Length() > tetherLength )
            {
                testPosition = (testPosition - needle.getTetherPoint()).Normalized() * tetherLength;
            }

        }

    }
}
