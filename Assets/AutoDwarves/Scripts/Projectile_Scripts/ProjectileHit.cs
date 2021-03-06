﻿using UnityEngine;
using System.Collections;

public class ProjectileHit : MonoBehaviour {

    // Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            Debug.Log("Collided into ground");
            gameObject.SendMessage("TransformIntoLemming");
        }
        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided into enemy");
            gameObject.SendMessage("ApplyDamage", 10);
        }

    }

    void TransformIntoLemming()
    {
        Debug.Log("Transforming into lemming");
        GameObject lemming = (GameObject)Instantiate(
            Resources.Load("Prefabs/Lemming_Miner"),
            new Vector3(transform.position.x, transform.position.y), 
            Quaternion.Euler(0, 0, 0)
        );

        //AddComponentsToGameObject(lemming);
        SwitchCameraFocusOn(lemming);

        Destroy(gameObject); //kill off current projectile (only used for animation)

    }

    void AddComponentsToGameObject(GameObject gameObject)
    {
        var lemmingMoveScript = gameObject.AddComponent<LemmingMove>();
        lemmingMoveScript.Speed = 5;
    }

    void SwitchCameraFocusOn(GameObject gameObject) //switch camera follow to the new lemming object
    {
        var followScript = Camera.main.GetComponent<ProjectileFollow>();
        followScript.projectile = gameObject.transform;
    }

    void ApplyDamage(int damageDone)
    {
        Debug.Log("Apply Damage");
    }
}
