using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000203 RID: 515
	public class ArrowSingle : MonoBehaviour
	{
		// Token: 0x06000DFC RID: 3580 RVA: 0x000990E4 File Offset: 0x000972E4
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.col2D = base.GetComponent<BoxCollider2D>();
			this.groundCheck_R = base.transform.Find("GroundCheck_R");
			this.groundCheck_C = base.transform.Find("GroundCheck_C");
			this.groundCheck_L = base.transform.Find("GroundCheck_L");
			this.eSE = base.GetComponent<EnemySoundEffect>();
		}

		// Token: 0x06000DFD RID: 3581 RVA: 0x00099158 File Offset: 0x00097358
		private void OnTriggerEnter2D(Collider2D other)
		{
			if ((other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && !this.destroyed)
			{
				this.animator.SetBool("Destroy", true);
				this.Destroy();
				this.destroyed = true;
			}
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x00099334 File Offset: 0x00097534
		private void Update()
		{
			if (!this.destroyed)
			{
				this.timer += Time.deltaTime;
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(this.velocityX, this.velocityY);
				if (this.grounded)
				{
					this.animator.SetBool("Destroy", true);
					this.Destroy();
					this.destroyed = true;
				}
				if (this.timer > 5f)
				{
					this.animator.SetBool("Destroy", true);
					this.Destroy();
					this.destroyed = true;
				}
			}
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x000993D4 File Offset: 0x000975D4
		private void FixedUpdate()
		{
			this.grounded = false;
			foreach (Collider2D array2 in new Collider2D[][]
			{
				Physics2D.OverlapPointAll(this.groundCheck_R.position),
				Physics2D.OverlapPointAll(this.groundCheck_C.position),
				Physics2D.OverlapPointAll(this.groundCheck_L.position)
			})
			{
				foreach (Collider2D collider2D in array2)
				{
					if (collider2D != null && !collider2D.isTrigger && (collider2D.tag == "Road" || collider2D.tag == "Slope" || collider2D.tag == "EventGround"))
					{
						this.grounded = true;
					}
				}
			}
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x000994D8 File Offset: 0x000976D8
		public void Action()
		{
			this.col2D.enabled = true;
			this.grounded = false;
			this.destroyed = false;
			this.timer = 0f;
			this.animator.SetBool("Destroy", false);
			this.eSE.SoundEffectPlay(0);
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x00099527 File Offset: 0x00097727
		public void Destroy()
		{
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
			this.col2D.enabled = false;
			base.Invoke("GameObjectFalse", 1f);
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x0009955F File Offset: 0x0009775F
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x040012D9 RID: 4825
		[NonSerialized]
		public Animator animator;

		// Token: 0x040012DA RID: 4826
		[NonSerialized]
		public bool grounded;

		// Token: 0x040012DB RID: 4827
		public float velocityX;

		// Token: 0x040012DC RID: 4828
		public float velocityY;

		// Token: 0x040012DD RID: 4829
		public bool destroyed;

		// Token: 0x040012DE RID: 4830
		public float timer;

		// Token: 0x040012DF RID: 4831
		private BoxCollider2D col2D;

		// Token: 0x040012E0 RID: 4832
		protected Transform groundCheck_R;

		// Token: 0x040012E1 RID: 4833
		protected Transform groundCheck_C;

		// Token: 0x040012E2 RID: 4834
		protected Transform groundCheck_L;

		// Token: 0x040012E3 RID: 4835
		public InstantiateManager instantiateManager;

		// Token: 0x040012E4 RID: 4836
		private EnemySoundEffect eSE;
	}
}
