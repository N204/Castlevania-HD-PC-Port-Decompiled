using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000525 RID: 1317
	public class BloodEffect : MonoBehaviour
	{
		// Token: 0x060031F1 RID: 12785 RVA: 0x005CB20B File Offset: 0x005C940B
		private void Awake()
		{
			this.audioSorce = base.GetComponent<AudioSource>();
			this.pS = base.GetComponent<ParticleSystem>();
		}

		// Token: 0x060031F2 RID: 12786 RVA: 0x005CB225 File Offset: 0x005C9425
		private void Update()
		{
			if (this.pS.isStopped)
			{
				this.DestroyCall();
			}
		}

		// Token: 0x060031F3 RID: 12787 RVA: 0x005CB23D File Offset: 0x005C943D
		public void Action()
		{
			this.pS.Play();
			this.audioSorce.Play();
		}

		// Token: 0x060031F4 RID: 12788 RVA: 0x005CB255 File Offset: 0x005C9455
		private void DestroyCall()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x0400645B RID: 25691
		private AudioSource audioSorce;

		// Token: 0x0400645C RID: 25692
		public InstantiateManager instantiateManager;

		// Token: 0x0400645D RID: 25693
		private ParticleSystem pS;
	}
}
