using System;
using UnityEngine;

namespace Anima2D
{
	// Token: 0x020000FE RID: 254
	[ExecuteInEditMode]
	[RequireComponent(typeof(SpriteMeshInstance))]
	public class SpriteMeshAnimation : MonoBehaviour
	{
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x000659D3 File Offset: 0x00063BD3
		// (set) Token: 0x0600065E RID: 1630 RVA: 0x000659DB File Offset: 0x00063BDB
		public SpriteMesh[] frames
		{
			get
			{
				return this.m_Frames;
			}
			set
			{
				this.m_Frames = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600065F RID: 1631 RVA: 0x000659E4 File Offset: 0x00063BE4
		public SpriteMeshInstance cachedSpriteMeshInstance
		{
			get
			{
				if (!this.m_SpriteMeshInstance)
				{
					this.m_SpriteMeshInstance = base.GetComponent<SpriteMeshInstance>();
				}
				return this.m_SpriteMeshInstance;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000660 RID: 1632 RVA: 0x00065A08 File Offset: 0x00063C08
		// (set) Token: 0x06000661 RID: 1633 RVA: 0x00065A11 File Offset: 0x00063C11
		public int frame
		{
			get
			{
				return (int)this.m_Frame;
			}
			set
			{
				this.m_Frame = (float)value;
			}
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x00065A1C File Offset: 0x00063C1C
		private void LateUpdate()
		{
			if (this.m_OldFrame != this.frame && this.m_Frames != null && this.m_Frames.Length > 0 && this.m_Frames.Length > this.frame && this.cachedSpriteMeshInstance)
			{
				this.m_OldFrame = this.frame;
				this.cachedSpriteMeshInstance.spriteMesh = this.m_Frames[this.frame];
			}
		}

		// Token: 0x04000B1D RID: 2845
		[SerializeField]
		private float m_Frame;

		// Token: 0x04000B1E RID: 2846
		[SerializeField]
		private SpriteMesh[] m_Frames;

		// Token: 0x04000B1F RID: 2847
		private int m_OldFrame;

		// Token: 0x04000B20 RID: 2848
		private SpriteMeshInstance m_SpriteMeshInstance;
	}
}
