using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000288 RID: 648
	public class Blood_Range : MonoBehaviour
	{
		// Token: 0x06001334 RID: 4916 RVA: 0x000D6148 File Offset: 0x000D4348
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06001335 RID: 4917 RVA: 0x000D6158 File Offset: 0x000D4358
		private void OnTriggerEnter2D(Collider2D other)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if ((other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && !this.destroyCheck)
			{
				this.GameObjectFalse();
				this.destroyCheck = true;
			}
			if (other.tag == "PlayerBody" && !this.destroyCheck)
			{
				base.Invoke("GameObjectFalse", 0.1f);
			}
		}

		// Token: 0x06001336 RID: 4918 RVA: 0x000D6360 File Offset: 0x000D4560
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (currentAnimatorStateInfo.fullPathHash == Blood_Range.ANISTS_Idle && currentAnimatorStateInfo.normalizedTime > 1f && !this.destroyCheck)
			{
				this.GameObjectFalse();
				this.destroyCheck = true;
			}
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x000D63B4 File Offset: 0x000D45B4
		public void Action()
		{
			this.destroyCheck = false;
			this.animator.Play("Blood_Range_Idle", 0, 0f);
		}

		// Token: 0x06001338 RID: 4920 RVA: 0x000D63D3 File Offset: 0x000D45D3
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04001A8E RID: 6798
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Blood_Range_Idle");

		// Token: 0x04001A8F RID: 6799
		public bool destroyCheck;

		// Token: 0x04001A90 RID: 6800
		private Animator animator;

		// Token: 0x04001A91 RID: 6801
		public InstantiateManager instantiateManager;
	}
}
