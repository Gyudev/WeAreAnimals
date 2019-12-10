using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
	private Rigidbody2D characterRigid;
	private Animator characterAnimator;
	private SpriteRenderer characterSpriteRenderer;
	private CapsuleCollider2D charactorCollider;

	public int nextAction;
	public int nextWay;

	private void Awake()
	{
		characterRigid = GetComponent<Rigidbody2D>();
		characterAnimator = GetComponent<Animator>();
		characterSpriteRenderer = GetComponent<SpriteRenderer>();
		charactorCollider = GetComponent<CapsuleCollider2D>();

		Invoke("Think", 5f);
	}

	private void Start()
    {
        
    }


	private void FixedUpdate()
    {
		characterRigid.velocity = new Vector2(nextWay, characterRigid.velocity.y);

		Vector2 frontVec = new Vector2(characterRigid.position.x + (nextWay * 0.4f), characterRigid.position.y);

		Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
		RaycastHit2D characterRayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
		if (characterRayHit.collider == null)
		{
			Turn();
		}
	}

	private void Think()
	{
		nextWay = Random.Range(-1, 2);
		characterAnimator.SetInteger("WalkWay", nextWay);

		if (nextWay != 0)
		{
			characterSpriteRenderer.flipX = nextWay == -1;
		}
		else if(nextWay == 0)
		{
			nextAction = Random.Range(1, 4);
			switch (nextAction)
			{
				case 1:
					characterAnimator.SetTrigger("do_Jump");
					characterRigid.AddForce(new Vector2(0f, 500f));
					break;
				case 2:
					characterAnimator.SetTrigger("do_Die");
					break;
				case 3:
					characterAnimator.SetTrigger("do_Attack");
					break;
			}
		}

		float nextThinkTime = Random.Range(2f, 5f);
		Invoke("Think", nextThinkTime); //2~5초 뒤에 자신을 한번 더 호출함
	}

	private void Turn()
	{
		nextWay *= -1;
		characterSpriteRenderer.flipX = nextWay == -1;
		CancelInvoke(); // 현재 작동 중인 모든 Invoke 함수를 멈추는 함수
		Invoke("Think", 5);
	}
}
