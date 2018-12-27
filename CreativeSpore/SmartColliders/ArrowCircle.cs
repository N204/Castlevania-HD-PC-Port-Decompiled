using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000202 RID: 514
	public class ArrowCircle : MagicMain
	{
		// Token: 0x06000DF4 RID: 3572 RVA: 0x00098D48 File Offset: 0x00096F48
		protected override void Awake()
		{
			base.Awake();
			this.animator = base.GetComponent<Animator>();
			this.col2D = base.GetComponent<BoxCollider2D>();
			this.eSE = base.GetComponent<EnemySoundEffect>();
		}

		// Token: 0x06000DF5 RID: 3573 RVA: 0x00098D74 File Offset: 0x00096F74
		private void OnTriggerEnter2D(Collider2D other)
		{
			if ((other.tag == "PlayerATKChain" || other.tag == "PlayerATKArm" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && !this.destroyed)
			{
				this.animator.SetBool("Destroy", true);
				this.Destroy();
				this.destroyed = true;
			}
		}

		// Token: 0x06000DF6 RID: 3574 RVA: 0x00098F50 File Offset: 0x00097150
		private void Update()
		{
			this.goVeloTimer += Time.deltaTime;
			if (this.goVeloTimer > this.goVeloTime)
			{
				if (!this.check)
				{
					this.eSE.SoundEffectPlay(0);
					this.check = true;
				}
				if (!this.destroyed)
				{
					this.timer += Time.deltaTime;
					this.col2D.enabled = true;
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
		}

		// Token: 0x06000DF7 RID: 3575 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x06000DF8 RID: 3576 RVA: 0x00099044 File Offset: 0x00097244
		public void Action()
		{
			this.check = false;
			this.grounded = false;
			this.destroyed = false;
			this.timer = 0f;
			this.goVeloTimer = 0f;
			this.animator.SetBool("Destroy", false);
			this.eSE.SoundEffectStop();
		}

		// Token: 0x06000DF9 RID: 3577 RVA: 0x00099098 File Offset: 0x00097298
		public void Destroy()
		{
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
			this.col2D.enabled = false;
			base.Invoke("GameObjectFalse", 1f);
		}

		// Token: 0x06000DFA RID: 3578 RVA: 0x000990D0 File Offset: 0x000972D0
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x040012CE RID: 4814
		[NonSerialized]
		public Animator animator;

		// Token: 0x040012CF RID: 4815
		public float velocityX;

		// Token: 0x040012D0 RID: 4816
		public float velocityY;

		// Token: 0x040012D1 RID: 4817
		public bool destroyed;

		// Token: 0x040012D2 RID: 4818
		public bool check;

		// Token: 0x040012D3 RID: 4819
		public float timer;

		// Token: 0x040012D4 RID: 4820
		private BoxCollider2D col2D;

		// Token: 0x040012D5 RID: 4821
		public float goVeloTimer;

		// Token: 0x040012D6 RID: 4822
		public float goVeloTime = 3f;

		// Token: 0x040012D7 RID: 4823
		public InstantiateManager instantiateManager;

		// Token: 0x040012D8 RID: 4824
		private EnemySoundEffect eSE;
	}
}
