using System;
using UnityEngine;

namespace Anima2D
{
	// Token: 0x020000F4 RID: 244
	public class IkLimb2D : Ik2D
	{
		// Token: 0x06000625 RID: 1573 RVA: 0x000649DD File Offset: 0x00062BDD
		protected override IkSolver2D GetSolver()
		{
			return this.m_Solver;
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x000649E5 File Offset: 0x00062BE5
		protected override void Validate()
		{
			base.numBones = 2;
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x000649EE File Offset: 0x00062BEE
		protected override int ValidateNumBones(int numBones)
		{
			return 2;
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x000649F1 File Offset: 0x00062BF1
		protected override void OnIkUpdate()
		{
			base.OnIkUpdate();
			this.m_Solver.flip = this.flip;
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x000649E5 File Offset: 0x00062BE5
		private void OnValidate()
		{
			base.numBones = 2;
		}

		// Token: 0x04000B01 RID: 2817
		public bool flip;

		// Token: 0x04000B02 RID: 2818
		[SerializeField]
		private IkSolver2DLimb m_Solver = new IkSolver2DLimb();
	}
}
