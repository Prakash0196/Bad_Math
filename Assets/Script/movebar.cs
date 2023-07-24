using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebar : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position +=new Vector3(speed,0,0);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collided !");
        speed = speed* -1;
    }
}
