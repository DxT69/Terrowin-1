using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_jumpAttack : MonoBehaviour
{

	[SerializeField] public int attackDamage;
	[SerializeField] Vector2 boxSize;
	public Vector3 attackOffset;
	public LayerMask attackMask;
	private int nat=0;
	public Animator animator;
	private bool run;
	void Update()
	{

		//Debug.Log(nat + "numero");

		run = animator.GetBool("IsRunning");
		if (run == true)
		{
			nat = 0;
		}

	}
	public void jAttack()
	{

		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapBox(pos, boxSize, 0, attackMask);
		if (colInfo != null)
		{
			if (nat==0)
			{
				colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
				nat = 1;
			}
		}
	}
	private void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;


		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(pos, boxSize);
	}
}
