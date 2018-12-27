using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020002EE RID: 750
	public class BalowGrandoIce : MonoBehaviour
	{
		// Token: 0x06001780 RID: 6016 RVA: 0x0011F941 File Offset: 0x0011DB41
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06001781 RID: 6017 RVA: 0x0011F950 File Offset: 0x0011DB50
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (currentAnimatorStateInfo.fullPathHash == BalowGrandoIce.ANISTS_Idle && currentAnimatorStateInfo.normalizedTime > 1f)
			{
				this.GameObjectFalse();
			}
		}

		// Token: 0x06001782 RID: 6018 RVA: 0x0011F992 File Offset: 0x0011DB92
		public void Action()
		{
			this.animator.Play("Balow_Grando_Idle");
		}

		// Token: 0x06001783 RID: 6019 RVA: 0x0011F9A4 File Offset: 0x0011DBA4
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04002228 RID: 8744
		public InstantiateManager instantiateManager;

		// Token: 0x04002229 RID: 8745
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Balow_Grando_Idle");

		// Token: 0x0400222A RID: 8746
		private Animator animator;
	}
}
