using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Soilder : MonoBehaviour
{
	public GameObject Bullet;//子彈物件
	public GameObject Grenade;//手雷物件
	private int Health = 100;
    private Hand hand;
	private Foot foot;
	private HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        hand = transform.GetChild(1).gameObject.GetComponent<Hand>();
		foot = transform.GetChild(2).gameObject.GetComponent<Foot>();
		healthBar = transform.GetChild(4).gameObject.GetComponent<HealthBar>();
    }
	
    // Update is called once per frame
    void Update()
    {
		hand.SetFilpX(hand.FaceLeft);
		foot.SetFilpX(hand.FaceLeft);
		
        ShootHandler();
		MoveHandler();
    }
	
	private void ShootHandler()
	{
		if (Input.GetMouseButtonDown(0) && hand.ShootAnim())
		{
			Instantiate(Bullet, hand.transform.position + new Vector3((hand.FaceLeft ? -0.05f : 0.05f), 0, 0), new Quaternion(0, 0, 0, 0))//clone
				.GetComponent<Bullet>()//get script class
				.Init(transform.position, hand.Angle, 4);//init bullet info
		}
		else if(Input.GetKey(KeyCode.Space) && hand.ThrowAnim())
		{
			GameObject throwGrenade = Instantiate(Grenade, hand.transform.position + new Vector3((hand.FaceLeft ? 0.1f : -0.1f), 0, 0), new Quaternion(0, 0, 0, 0));
			Rigidbody GrenadeBody = throwGrenade.AddComponent<Rigidbody>();
			GrenadeBody.AddForce(Quaternion.Euler(0, hand.Angle, 0) * new Vector3(5, 5f, 0), ForceMode.VelocityChange);
		}
	}
	
	
	private void MoveHandler()
	{
		bool isRun = false;
		bool isLeft = hand.FaceLeft;
		
        if (Input.GetKey(KeyCode.A))
		{
			isRun = true;
			transform.Translate(Vector2.left * Time.deltaTime); //往左
		}
		if (Input.GetKey(KeyCode.D))
		{
			isRun = true;
			isLeft = !isLeft;
			transform.Translate(Vector2.right * Time.deltaTime); //往右
		}
		foot.SetAnimStatus(isRun, isLeft);
	}
	
	public void ChangeHealth(int delta)
	{
		Health += delta;
		if(Health > 100)
		{
			Health = 100;
		}
		healthBar.SetHealthRate((float)Health/100f);
	}
}
