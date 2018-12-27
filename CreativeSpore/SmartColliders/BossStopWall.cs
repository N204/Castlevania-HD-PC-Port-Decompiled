using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000512 RID: 1298
	public class BossStopWall : MonoBehaviour
	{
		// Token: 0x06003196 RID: 12694 RVA: 0x005BD191 File Offset: 0x005BB391
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06003197 RID: 12695 RVA: 0x005BD1A0 File Offset: 0x005BB3A0
		public void Action(int val)
		{
			if (val != 1)
			{
				if (val != 2)
				{
					if (val == 3)
					{
						this.animator.SetTrigger("Break3");
					}
				}
				else
				{
					this.animator.SetTrigger("Break2");
				}
			}
			else
			{
				this.animator.SetTrigger("Break1");
			}
		}

		// Token: 0x06003198 RID: 12696 RVA: 0x005BD208 File Offset: 0x005BB408
		public void Reset()
		{
			this.animator.ResetTrigger("Break1");
			this.animator.ResetTrigger("Break2");
			this.animator.ResetTrigger("Break3");
			this.animator.Play("BossStopWall_Idle");
		}

		// Token: 0x04006396 RID: 25494
		private Animator animator;
	}
}
