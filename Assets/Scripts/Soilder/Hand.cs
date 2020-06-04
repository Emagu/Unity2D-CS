using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Hand : MonoBehaviour
{
	private Animator Anim;
	public float Angle;
	public bool FaceLeft;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,-Camera.main.transform.position.z));
		Vector3 direction = worldPos - transform.position;
		direction.z=0f;
		direction.Normalize();
		Angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
		FaceLeft = Math.Abs(Angle) > 90;
		transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.Euler( 0, 0, (FaceLeft ? Angle - 180: Angle)), 5 * Time.deltaTime );
    }
	
	public bool ShootAnim()
	{
		return PlayAnim("Fire");
	}
	
	public bool ThrowAnim()
	{
		return PlayAnim("Throw");
	}
	
	public void SetFilpX(bool x)
	{
		SpriteRenderer m_SpriteRenderer = GetComponent<SpriteRenderer>();
		m_SpriteRenderer.flipX = x;
	}
	
	private bool PlayAnim(string animName)
	{
		if(Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
		{
			Anim.Play(animName);
			return true;
		}
		return false;
	}
}
