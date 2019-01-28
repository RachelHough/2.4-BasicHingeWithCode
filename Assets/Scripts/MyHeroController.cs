using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHeroController : MonoBehaviour {


    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        MyLevelManager.instance.UseHingeOne();


    }

}
