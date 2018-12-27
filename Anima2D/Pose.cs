using System;
using System.Collections.Generic;
using UnityEngine;

namespace Anima2D
{
	// Token: 0x020000FA RID: 250
	public class Pose : ScriptableObject
	{
		// Token: 0x04000B13 RID: 2835
		[SerializeField]
		private List<Pose.PoseEntry> m_PoseEntries;

		// Token: 0x020000FB RID: 251
		[Serializable]
		public class PoseEntry
		{
			// Token: 0x04000B14 RID: 2836
			public string path;

			// Token: 0x04000B15 RID: 2837
			public Vector3 localPosition;

			// Token: 0x04000B16 RID: 2838
			public Quaternion localRotation;

			// Token: 0x04000B17 RID: 2839
			public Vector3 localScale;
		}
	}
}
