using UnityEngine;
using System.Collections;

public class buttonControl_scriptPlayer : MonoBehaviour 
{
	Animator anim;
	public AudioSource myFx;
    public AudioClip WalkSoundLeft;
	public AudioClip WalkSoundRight;

	private bool Left = false;

	void Awake ()
	{
		anim = GetComponentInChildren<Animator>();
	}

	public void Idle ()
	{
		anim.SetBool("isIdle", true);
		anim.SetBool("isWalking", false);
	}

	public void Walk ()
	{
		anim.SetBool("isWalking",!(anim.GetBool("isRun")));
		anim.SetBool("isIdle", false);
		if(!myFx.isPlaying)
		{
			if(Left)
			{
				myFx.PlayOneShot (WalkSoundLeft);
				Left = false;
			}
			else
			{
				myFx.PlayOneShot (WalkSoundRight);
				Left = true;
			}
		}
	}
	
	public void Run ()
	{
		anim.SetBool("isWalking",!(anim.GetBool("isRun")));
		anim.SetBool("isIdle", false);
	}
}
