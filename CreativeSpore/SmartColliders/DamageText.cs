using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000524 RID: 1316
	public class DamageText : MonoBehaviour
	{
		// Token: 0x060031EE RID: 12782 RVA: 0x005CB160 File Offset: 0x005C9360
		private void Update()
		{
			this.count++;
			if (this.count < 30)
			{
				base.transform.position += Vector3.up * 0.01f;
			}
			else if (this.count >= 30)
			{
				base.transform.position += Vector3.down * 0.005f;
			}
			if (this.count > 40)
			{
				this.instantiateManager.releaseBall(base.gameObject);
			}
		}

		// Token: 0x060031EF RID: 12783 RVA: 0x005CB202 File Offset: 0x005C9402
		public void Action()
		{
			this.count = 0;
		}

		// Token: 0x04006459 RID: 25689
		private int count;

		// Token: 0x0400645A RID: 25690
		public InstantiateManager instantiateManager;
	}
}
