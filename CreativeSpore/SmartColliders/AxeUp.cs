using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000205 RID: 517
	public class AxeUp : MonoBehaviour
	{
		// Token: 0x06000E0E RID: 3598 RVA: 0x00099A64 File Offset: 0x00097C64
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.cirCol2D = base.transform.Find("BodyCollider").GetComponent<CircleCollider2D>();
			this.cirCol2D2 = base.transform.Find("AxeSprite").GetComponent<CircleCollider2D>();
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x00099AB4 File Offset: 0x00097CB4
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
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 3f);
				}
				else if (this.toRight)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 3f);
				}
			}
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x00099CE7 File Offset: 0x00097EE7
		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.tag == "Road" || other.gameObject.tag == "DestroyObject")
			{
				this.DestroyAnimation();
			}
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x00099D24 File Offset: 0x00097F24
		public void Action()
		{
			this.cirCol2D.enabled = true;
			this.cirCol2D2.enabled = true;
			this.animator.SetBool("Destroy", false);
			if (this.toLeft)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, 3.5f);
			}
			else if (this.toRight)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 3.5f);
			}
		}

		// Token: 0x06000E12 RID: 3602 RVA: 0x00099DA9 File Offset: 0x00097FA9
		public void DestroyAnimation()
		{
			this.cirCol2D.enabled = false;
			this.cirCol2D2.enabled = false;
			this.animator.SetBool("Destroy", true);
			this.destroyCheck = true;
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x0008FD35 File Offset: 0x0008DF35
		public void Destroy()
		{
			base.Invoke("GameObjectFalse", 0.2f);
		}

		// Token: 0x06000E14 RID: 3604 RVA: 0x00099DDB File Offset: 0x00097FDB
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x040012EF RID: 4847
		public static readonly int ANISTS_Roll = Animator.StringToHash("Base Layer.Axe_Roll");

		// Token: 0x040012F0 RID: 4848
		private Animator animator;

		// Token: 0x040012F1 RID: 4849
		public GameObject ownerObj;

		// Token: 0x040012F2 RID: 4850
		public bool toLeft;

		// Token: 0x040012F3 RID: 4851
		public bool toRight;

		// Token: 0x040012F4 RID: 4852
		public bool destroyCheck;

		// Token: 0x040012F5 RID: 4853
		private CircleCollider2D cirCol2D;

		// Token: 0x040012F6 RID: 4854
		private CircleCollider2D cirCol2D2;

		// Token: 0x040012F7 RID: 4855
		public InstantiateManager instantiateManager;
	}
}
