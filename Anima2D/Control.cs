using System;
using UnityEngine;

namespace Anima2D
{
	// Token: 0x020000F0 RID: 240
	public class Control : MonoBehaviour
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x000644BC File Offset: 0x000626BC
		public Color color
		{
			get
			{
				if (this.m_CachedBone)
				{
					Color color = this.m_CachedBone.color;
					color.a = 1f;
					return color;
				}
				return Color.white;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060005FE RID: 1534 RVA: 0x000644F8 File Offset: 0x000626F8
		// (set) Token: 0x060005FF RID: 1535 RVA: 0x0006456E File Offset: 0x0006276E
		public Bone2D bone
		{
			get
			{
				if (this.m_CachedBone && this.m_BoneTransform != this.m_CachedBone.transform)
				{
					this.m_CachedBone = null;
				}
				if (!this.m_CachedBone && this.m_BoneTransform)
				{
					this.m_CachedBone = this.m_BoneTransform.GetComponent<Bone2D>();
				}
				return this.m_CachedBone;
			}
			set
			{
				this.m_BoneTransform = value.transform;
			}
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x00004F4D File Offset: 0x0000314D
		private void Start()
		{
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0006457C File Offset: 0x0006277C
		private void LateUpdate()
		{
			if (this.bone)
			{
				base.transform.position = this.bone.transform.position;
				base.transform.rotation = this.bone.transform.rotation;
			}
		}

		// Token: 0x04000AF3 RID: 2803
		[SerializeField]
		private Transform m_BoneTransform;

		// Token: 0x04000AF4 RID: 2804
		private Bone2D m_CachedBone;
	}
}
