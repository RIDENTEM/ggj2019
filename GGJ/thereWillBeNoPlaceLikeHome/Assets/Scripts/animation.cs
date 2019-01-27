using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour {

    Rigidbody2D rigid;
    public GameObject legL;
    public GameObject legR;
    float timer = 0;
    int dir = 1;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (rigid.velocity.x < 0) dir = -1;
        else if (rigid.velocity.x > 0) dir = 1;
        else timer = 0;
        updateLegs();
	}

    void updateLegs()
    {
        print(timer);
        legL.transform.localScale = new Vector3(dir, 1, 1);
        legR.transform.localScale = new Vector3(dir, 1, 1);
        legL.transform.localEulerAngles = new Vector3(0, 0, Mathf.Sin(timer)*75);
        legR.transform.localEulerAngles = new Vector3(0, 0, -Mathf.Sin(timer) * 75);
        timer += Time.deltaTime * 10;
    }
}
