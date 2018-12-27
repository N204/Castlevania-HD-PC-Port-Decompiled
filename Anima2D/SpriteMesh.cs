using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Anima2D
{
	// Token: 0x020000FD RID: 253
	public class SpriteMesh : ScriptableObject
	{
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600065A RID: 1626 RVA: 0x000659C3 File Offset: 0x00063BC3
		public Sprite sprite
		{
			get
			{
				return this.m_Sprite;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600065B RID: 1627 RVA: 0x000659CB File Offset: 0x00063BCB
		public Mesh sharedMesh
		{
			get
			{
				return this.m_SharedMesh;
			}
		}

		// Token: 0x04000B19 RID: 2841
		public const int api_version = 4;

		// Token: 0x04000B1A RID: 2842
		[HideInInspector]
		[SerializeField]
		private int m_ApiVersion;

		// Token: 0x04000B1B RID: 2843
		[FormerlySerializedAs("sprite")]
		[SerializeField]
		private Sprite m_Sprite;

		// Token: 0x04000B1C RID: 2844
		[SerializeField]
		private Mesh m_SharedMesh;
	}
}
