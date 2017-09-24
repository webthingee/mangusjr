using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class FlameAnimCtrl : MonoBehaviour {

    Animator anim;
	[SerializeField] float flameOffset;
	[SerializeField] float flameSpeed;
    
    void Awake () 
	{
        anim = GetComponent<Animator>();
		flameOffset = Random.Range(0f, 1.5f);
		flameSpeed = Random.Range(.5f, 1.5f);
    }
	
	void Update () 
	{
		anim.SetFloat("offsetFlame", flameOffset);
		anim.speed = flameSpeed;
	}
}
