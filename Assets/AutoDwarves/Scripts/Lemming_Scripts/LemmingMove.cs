using UnityEngine;
using System.Collections;

public class LemmingMove : MonoBehaviour {

    public Transform Target;
    public float Speed;

    //private Vector3 normalizeDirection;
    private Vector3 translation = new Vector3(0.1f, 0, 0);
    // Use this for initialization
    void Start()
    {
        Debug.Log("Lemming Move Start()");
        
        //normalizeDirection = (target.position - transform.position).normalized;
    }

    void Update()
    {   
        transform.position += translation;
        transform.Translate(translation * Time.deltaTime);
        //transform.position += transform.right * Time.deltaTime * Speed;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            Debug.Log("Collided into wall");
            translation.x = -0.1f;
        }
    }
}
