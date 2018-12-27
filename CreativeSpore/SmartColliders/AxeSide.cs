using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000204 RID: 516
	public class AxeSide : MonoBehaviour
	{
		// Token: 0x06000E04 RID: 3588 RVA: 0x00099574 File Offset: 0x00097774
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.cirCol2D = base.transform.Find("BodyCollider").GetComponent<CircleCollider2D>();
			this.cirCol2D2 = base.transform.Find("AxeSprite").GetComponent<CircleCollider2D>();
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x000995C4 File Offset: 0x000977C4
		private void OnTriggerEnter2D(Collider2D other)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (other.tag == "Road" || other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper")
			{
				if (!this.destroyCheck)
				{
					this.DestroyAnimation();
				}
				if (this.toLeft)
				{
					if (base.GetComponent<Rigidbody2D>().velocity.x < 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(2.5f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
				}
				else if (this.toRight && base.GetComponent<Rigidbody2D>().velocity.x > 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(-2.5f, base.GetComponent<Rigidbody2D>().velocity.y);
				}
			}
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x0009984E File Offset: 0x00097A4E
		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.tag == "Road" || other.gameObject.tag == "DestroyObject")
			{
				this.DestroyAnimation();
			}
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x0009988C File Offset: 0x00097A8C
		private void Update()
		{
			this.turnCount += Time.deltaTime;
			if (this.toLeft)
			{
				if (this.turnCount > 3f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(2.5f, base.GetComponent<Rigidbody2D>().velocity.y);
				}
			}
			else if (this.toRight && this.turnCount > 3f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(-2.5f, base.GetComponent<Rigidbody2D>().velocity.y);
			}
			if (!this.destroyCheck && this.turnCount >= 7f)
			{
				this.DestroyAnimation();
			}
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x00099958 File Offset: 0x00097B58
		public void Action()
		{
			this.destroyCheck = false;
			this.turnCount = 0f;
			this.cirCol2D2.enabled = true;
			this.cirCol2D.enabled = true;
			this.animator.SetBool("Destroy", false);
			if (this.toLeft)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(-2.5f, base.GetComponent<Rigidbody2D>().velocity.y);
			}
			else if (this.toRight)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(2.5f, base.GetComponent<Rigidbody2D>().velocity.y);
			}
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00099A0B File Offset: 0x00097C0B
		public void DestroyAnimation()
		{
			this.animator.SetBool("Destroy", true);
			this.cirCol2D.enabled = false;
			this.cirCol2D2.enabled = false;
			this.destroyCheck = true;
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x0008FD35 File Offset: 0x0008DF35
		public void Destroy()
		{
			base.Invoke("GameObjectFalse", 0.2f);
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x00099A3D File Offset: 0x00097C3D
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x040012E5 RID: 4837
		public static readonly int ANISTS_Roll = Animator.StringToHash("Base Layer.Axe_Roll");

		// Token: 0x040012E6 RID: 4838
		private Animator animator;

		// Token: 0x040012E7 RID: 4839
		public GameObject ownerObj;

		// Token: 0x040012E8 RID: 4840
		public bool toLeft;

		// Token: 0x040012E9 RID: 4841
		public bool toRight;

		// Token: 0x040012EA RID: 4842
		public bool destroyCheck;

		// Token: 0x040012EB RID: 4843
		public float turnCount;

		// Token: 0x040012EC RID: 4844
		private CircleCollider2D cirCol2D;

		// Token: 0x040012ED RID: 4845
		private CircleCollider2D cirCol2D2;

		// Token: 0x040012EE RID: 4846
		public InstantiateManager instantiateManager;
	}
}
