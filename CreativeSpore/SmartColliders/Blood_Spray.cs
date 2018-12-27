using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200028B RID: 651
	public class Blood_Spray : MagicMain
	{
		// Token: 0x06001347 RID: 4935 RVA: 0x000D6AE3 File Offset: 0x000D4CE3
		protected override void Awake()
		{
			base.Awake();
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06001348 RID: 4936 RVA: 0x000D6AF8 File Offset: 0x000D4CF8
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (this.animator.GetCurrentAnimatorStateInfo(0).fullPathHash == Blood_Spray.ANISTS_Idle && (other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && !this.destroyCheck)
			{
				base.GetComponent<Rigidbody2D>().simulated = false;
				this.animator.SetTrigger("Crush");
				base.Invoke("GameObjectFalse", 0.7f);
				this.destroyCheck = true;
			}
		}

		// Token: 0x06001349 RID: 4937 RVA: 0x000D6D08 File Offset: 0x000D4F08
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			this.timer += Time.deltaTime;
			if (currentAnimatorStateInfo.fullPathHash == Blood_Spray.ANISTS_Idle && !this.destroyCheck)
			{
				if (base.GetComponent<Rigidbody2D>().velocity.y < 0f && this.grounded)
				{
					base.GetComponent<Rigidbody2D>().simulated = false;
					this.animator.SetTrigger("Out");
					base.Invoke("GameObjectFalse", 0.7f);
					this.destroyCheck = true;
				}
				if (this.timer > 10f)
				{
					this.GameObjectFalse();
					this.destroyCheck = true;
				}
			}
		}

		// Token: 0x0600134A RID: 4938 RVA: 0x0009903A File Offset: 0x0009723A
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		// Token: 0x0600134B RID: 4939 RVA: 0x000D6DC8 File Offset: 0x000D4FC8
		public void Action()
		{
			base.GetComponent<Rigidbody2D>().simulated = true;
			this.grounded = false;
			this.destroyCheck = false;
			this.timer = 0f;
			this.animator.ResetTrigger("Out");
			this.animator.ResetTrigger("Crush");
			this.animator.Play("Blood_Spray_Idle");
		}

		// Token: 0x0600134C RID: 4940 RVA: 0x000D6E2A File Offset: 0x000D502A
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04001AA2 RID: 6818
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Blood_Spray_Idle");

		// Token: 0x04001AA3 RID: 6819
		public bool destroyCheck;

		// Token: 0x04001AA4 RID: 6820
		public float timer;

		// Token: 0x04001AA5 RID: 6821
		private Animator animator;

		// Token: 0x04001AA6 RID: 6822
		public InstantiateManager instantiateManager;
	}
}
