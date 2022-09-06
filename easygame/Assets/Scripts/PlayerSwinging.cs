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
        if(needle.isTethered == true)
        {
            Vector2 transform2D = transform.position;
            Vector2 testPosition = transform2D + rb.velocity * Time.deltaTime;
            if (testPosition.magnitude > tetherLength )
            {
                testPosition = (testPosition - needle.getTetherPoint()).normalized * tetherLength;
            }

        }

    }
}
