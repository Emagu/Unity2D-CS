using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foot : MonoBehaviour
{
	private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SetAnimStatus(bool isRun, bool isLeft)
	{
		Anim.SetFloat("Direction", isLeft ? 1 : -1);
		Anim.SetBool("Run", isRun);
	}
	
	public void SetFilpX(bool x)
	{
		SpriteRenderer m_SpriteRenderer = GetComponent<SpriteRenderer>();
		m_SpriteRenderer.flipX = x;
	}
}
