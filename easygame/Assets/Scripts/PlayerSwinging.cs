using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerSwinging : MonoBehaviour
{
    [SerializeField] public Needle needle;
    private Rigidbody2D rb;
    private float tetherLength;
    public float max_speed_y;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tetherLength = needle.getTetherLength();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(needle.getTetherPoint());
        if (needle.isTethered == true)
        {
            Vector2 transform2D = transform.position;
            Vector2 testPosition = transform2D + rb.velocity * Time.deltaTime;
            //Debug.Log(rb.velocity);
            if ((testPosition - needle.getTetherPoint()).magnitude > tetherLength )
            {
                 testPosition = (testPosition - needle.getTetherPoint()).normalized * tetherLength;
                //rb.velocity = (testPosition - trasform.position) / Time.deltaTime;
                transform.position = (Vector3)needle.getTetherPoint() + (Vector3)testPosition;
                if (Mathf.Abs(rb.velocity.y) > max_speed_y)
                    rb.velocity = new Vector2(rb.velocity.x, 0f);
                    //   rb.velocity = max_speed;*/
            }

        }

    }
}
