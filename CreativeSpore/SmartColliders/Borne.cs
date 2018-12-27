using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000206 RID: 518
	public class Borne : MonoBehaviour
	{
		// Token: 0x06000E17 RID: 3607 RVA: 0x00099E00 File Offset: 0x00098000
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.atkCol2d = base.transform.Find("BodyDetect").GetComponent<BoxCollider2D>();
			this.atkBounceCol2d = base.transform.Find("BodyDetect2").GetComponent<BoxCollider2D>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06000E18 RID: 3608 RVA: 0x00099E64 File Offset: 0x00098064
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper")
			{
				if (!this.fall)
				{
					if (this.toLeft)
					{
						this.atkCol2d.enabled = false;
						this.atkBounceCol2d.enabled = true;
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, -4.5f);
						this.bounced = true;
					}
					else if (this.toRight)
					{
						this.atkCol2d.enabled = false;
						this.atkBounceCol2d.enabled = true;
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, -4.5f);
						this.bounced = true;
					}
				}
				else if (this.fall)
				{
					this.DestroyAnimation();
				}
			}
			if (this.bounced && other.tag == "EnemyBodyAttack")
			{
				this.hitedATK = false;
				if (!this.hitedATK)
				{
					if (other.transform.parent.GetComponent<EnemySkeleton>() != null)
					{
						EnemySkeleton component = other.transform.parent.GetComponent<EnemySkeleton>();
						component.hitBone = true;
					}
					this.hitedATK = true;
				}
			}
		}

		// Token: 0x06000E19 RID: 3609 RVA: 0x0009A130 File Offset: 0x00098330
		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.tag == "Road" || other.gameObject.tag == "PassThroughCollider" || other.gameObject.tag == "MoveRightObject" || other.gameObject.tag == "MoveLeftObject" || other.gameObject.tag == "DestroyObject")
			{
				this.atkCol2d.enabled = false;
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
				if (!this.destroyed)
				{
					base.Invoke("DestroyAnimation", 1f);
					this.destroyed = true;
				}
			}
		}

		// Token: 0x06000E1A RID: 3610 RVA: 0x0009A218 File Offset: 0x00098418
		private void Update()
		{
			if (!this.bounced && base.GetComponent<Rigidbody2D>().velocity.y < 0f)
			{
				this.fall = true;
			}
		}

		// Token: 0x06000E1B RID: 3611 RVA: 0x0009A254 File Offset: 0x00098454
		public void Action()
		{
			this.atkCol2d.enabled = true;
			this.atkBounceCol2d.enabled = false;
			this.destroyed = false;
			this.fall = false;
			this.bounced = false;
			this.hitedATK = false;
			this.animator.SetBool("Destroy", false);
			if (this.toLeft)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.5f, 4.5f);
			}
			else if (this.toRight)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(1.5f, 4.5f);
			}
		}

		// Token: 0x06000E1C RID: 3612 RVA: 0x0009A2F5 File Offset: 0x000984F5
		public void DestroyAnimation()
		{
			this.atkCol2d.enabled = false;
			this.animator.SetBool("Destroy", true);
		}

		// Token: 0x06000E1D RID: 3613 RVA: 0x0008FD35 File Offset: 0x0008DF35
		public void Destroy()
		{
			base.Invoke("GameObjectFalse", 0.2f);
		}

		// Token: 0x06000E1E RID: 3614 RVA: 0x0009A314 File Offset: 0x00098514
		public void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x040012F8 RID: 4856
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.SkeletonBorne_Idle");

		// Token: 0x040012F9 RID: 4857
		private Animator animator;

		// Token: 0x040012FA RID: 4858
		private EnemyBody enemyBody;

		// Token: 0x040012FB RID: 4859
		private BoxCollider2D atkCol2d;

		// Token: 0x040012FC RID: 4860
		private BoxCollider2D atkBounceCol2d;

		// Token: 0x040012FD RID: 4861
		private PlayerStatus playerStatus;

		// Token: 0x040012FE RID: 4862
		public bool toLeft;

		// Token: 0x040012FF RID: 4863
		public bool toRight;

		// Token: 0x04001300 RID: 4864
		public bool destroyed;

		// Token: 0x04001301 RID: 4865
		public bool fall;

		// Token: 0x04001302 RID: 4866
		public bool bounced;

		// Token: 0x04001303 RID: 4867
		public bool hitedATK;

		// Token: 0x04001304 RID: 4868
		public InstantiateManager instantiateManager;
	}
}
