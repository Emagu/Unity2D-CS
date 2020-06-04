using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
	private float Speed = 5;
	public int Damage = 10;
	public bool IsPenetrate = false;
	private Vector2 StartPosition;
	private float StartAngle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2FromAngle(StartAngle) * Time.deltaTime * Speed);
		//每秒向上移動(Speed)單位的距離
		if(Math.Abs(StartPosition.x - transform.position.x) > 5 || Math.Abs(StartPosition.y - transform.position.y) > 5)
		{
		 　　Destroy(gameObject);
		}
    }
	
	void OnTriggerEnter2D(Collider2D Coll)
	{
		if(IsPenetrate)
		{
			IsPenetrate = false;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	public void Init(Vector2 StartPosition, float StartAngle, float Speed)
	{
		this.StartPosition = StartPosition;
		this.Speed = Speed;
		this.StartAngle = StartAngle;
	}
	
	private Vector2 Vector2FromAngle(float a)
	{
		a *= Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
	}
}
