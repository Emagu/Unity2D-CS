using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
	public Vector3 StartPoistion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.GetComponent<Rigidbody>() != null)
        {
            // 如果箭矢正再飛行
            if (GetComponent<Rigidbody>().velocity != Vector3.zero)
            {
                // 取得箭矢作用向量
                Vector3 vel = GetComponent<Rigidbody>().velocity;
				
                // 計算向量角度
                float angleZ = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, 0, angleZ-90);
                
            }
        }
		
		if(StartPoistion != null && (StartPoistion - transform.position).magnitude > 200)
		{
			Destroy(gameObject);
		}
    }
}
