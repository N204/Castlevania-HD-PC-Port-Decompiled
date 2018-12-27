using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200036C RID: 876
	public class BiblePages : MonoBehaviour
	{
		// Token: 0x06001DBF RID: 7615 RVA: 0x00231A61 File Offset: 0x0022FC61
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06001DC0 RID: 7616 RVA: 0x00231A6F File Offset: 0x0022FC6F
		public void Velocity(float x, float y)
		{
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
		}

		// Token: 0x06001DC1 RID: 7617 RVA: 0x00231A83 File Offset: 0x0022FC83
		public void Action()
		{
			this.animator.Play("BiblePages_Idle");
		}

		// Token: 0x06001DC2 RID: 7618 RVA: 0x0008FD35 File Offset: 0x0008DF35
		public void DestroyCall()
		{
			base.Invoke("GameObjectFalse", 0.2f);
		}

		// Token: 0x06001DC3 RID: 7619 RVA: 0x00231A95 File Offset: 0x0022FC95
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x040031FD RID: 12797
		private Animator animator;

		// Token: 0x040031FE RID: 12798
		public InstantiateManager instantiateManager;
	}
}
