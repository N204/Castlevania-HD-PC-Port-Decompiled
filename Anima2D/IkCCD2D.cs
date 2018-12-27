using System;
using UnityEngine;

namespace Anima2D
{
	// Token: 0x020000F2 RID: 242
	public class IkCCD2D : Ik2D
	{
		// Token: 0x0600061F RID: 1567 RVA: 0x0006492F File Offset: 0x00062B2F
		protected override IkSolver2D GetSolver()
		{
			return this.m_Solver;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00064937 File Offset: 0x00062B37
		protected override void OnIkUpdate()
		{
			base.OnIkUpdate();
			this.m_Solver.iterations = this.iterations;
			this.m_Solver.damping = this.damping;
		}

		// Token: 0x04000AFD RID: 2813
		public int iterations = 10;

		// Token: 0x04000AFE RID: 2814
		[Range(0f, 1f)]
		public float damping = 0.8f;

		// Token: 0x04000AFF RID: 2815
		[SerializeField]
		private IkSolver2DCCD m_Solver = new IkSolver2DCCD();
	}
}
