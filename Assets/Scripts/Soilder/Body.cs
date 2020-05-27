using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D Coll)
	{
		switch(Coll.gameObject.tag)
		{
			case "Bullet":
				Bullet bullet = Coll.gameObject.GetComponent<Bullet>();//get script class
				Soilder selfBody = this.transform.parent.gameObject.GetComponent<Soilder>();
				selfBody.ChangeHealth(-bullet.Damage);
				break;
		}
	}
}
