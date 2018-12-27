using System;
using System.Collections.Generic;
using UnityEngine;

namespace Anima2D
{
	// Token: 0x020000F3 RID: 243
	public class IkGroup : MonoBehaviour
	{
		// Token: 0x06000622 RID: 1570 RVA: 0x00064974 File Offset: 0x00062B74
		public void UpdateGroup()
		{
			for (int i = 0; i < this.m_IkComponents.Count; i++)
			{
				Ik2D ik2D = this.m_IkComponents[i];
				if (ik2D)
				{
					ik2D.enabled = false;
					ik2D.UpdateIK();
				}
			}
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x000649C2 File Offset: 0x00062BC2
		private void LateUpdate()
		{
			this.UpdateGroup();
		}

		// Token: 0x04000B00 RID: 2816
		[HideInInspector]
		[SerializeField]
		private List<Ik2D> m_IkComponents = new List<Ik2D>();
	}
}
