using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000513 RID: 1299
	public class BreakableStep : MonoBehaviour
	{
		// Token: 0x0600319A RID: 12698 RVA: 0x005BD255 File Offset: 0x005BB455
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x0600319B RID: 12699 RVA: 0x005BD263 File Offset: 0x005BB463
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!this.canBreak && other.name == "ElevetorKill")
			{
				this.animator.SetTrigger("Break");
				this.canBreak = true;
			}
		}

		// Token: 0x0600319C RID: 12700 RVA: 0x005BD29C File Offset: 0x005BB49C
		public void Reset()
		{
			this.canBreak = false;
			this.animator.ResetTrigger("Break");
			this.animator.Play("BossStep_Idle");
		}

		// Token: 0x04006397 RID: 25495
		private Animator animator;

		// Token: 0x04006398 RID: 25496
		private bool canBreak;
	}
}
