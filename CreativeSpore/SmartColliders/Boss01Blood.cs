using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020001FC RID: 508
	public class Boss01Blood : MonoBehaviour
	{
		// Token: 0x06000D7C RID: 3452 RVA: 0x0008FCAE File Offset: 0x0008DEAE
		private void Awake()
		{
			this.blood = base.transform.Find("Blood").GetComponent<SpriteRenderer>();
			this.bloodEnd = base.transform.Find("BloodEnd").GetComponent<SpriteRenderer>();
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x0008FCE6 File Offset: 0x0008DEE6
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "Road")
			{
				this.blood.enabled = false;
				this.bloodEnd.enabled = true;
				this.Destroy();
			}
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x0008FD1B File Offset: 0x0008DF1B
		public void Action()
		{
			this.blood.enabled = true;
			this.bloodEnd.enabled = false;
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x0008FD35 File Offset: 0x0008DF35
		public void Destroy()
		{
			base.Invoke("GameObjectFalse", 0.2f);
		}

		// Token: 0x06000D80 RID: 3456 RVA: 0x0008FD47 File Offset: 0x0008DF47
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x0400122F RID: 4655
		private SpriteRenderer blood;

		// Token: 0x04001230 RID: 4656
		private SpriteRenderer bloodEnd;

		// Token: 0x04001231 RID: 4657
		public InstantiateManager instantiateManager;
	}
}
