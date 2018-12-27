using System;
using UnityEngine;

namespace Anima2D
{
	// Token: 0x020000F7 RID: 247
	[Serializable]
	public class IkSolver2DCCD : IkSolver2D
	{
		// Token: 0x0600063E RID: 1598 RVA: 0x00064E34 File Offset: 0x00063034
		protected override void DoSolverUpdate()
		{
			if (!base.rootBone)
			{
				return;
			}
			for (int i = 0; i < base.solverPoses.Count; i++)
			{
				IkSolver2D.SolverPose solverPose = base.solverPoses[i];
				if (solverPose != null && solverPose.bone)
				{
					solverPose.solverRotation = solverPose.bone.transform.localRotation;
					solverPose.solverPosition = base.rootBone.transform.InverseTransformPoint(solverPose.bone.transform.position);
				}
			}
			Vector3 vector = base.rootBone.transform.InverseTransformPoint(base.solverPoses[base.solverPoses.Count - 1].bone.endPosition);
			Vector3 a = base.rootBone.transform.InverseTransformPoint(this.targetPosition);
			this.damping = Mathf.Clamp01(this.damping);
			float num = 1f - Mathf.Lerp(0f, 0.99f, this.damping);
			for (int j = 0; j < this.iterations; j++)
			{
				for (int k = base.solverPoses.Count - 1; k >= 0; k--)
				{
					IkSolver2D.SolverPose solverPose2 = base.solverPoses[k];
					Vector3 b = a - solverPose2.solverPosition;
					Vector3 a2 = vector - solverPose2.solverPosition;
					b.z = 0f;
					a2.z = 0f;
					float num2 = MathUtils.SignedAngle(a2, b, Vector3.forward);
					num2 *= num;
					Quaternion quaternion = Quaternion.AngleAxis(num2, Vector3.forward);
					solverPose2.solverRotation *= quaternion;
					Vector3 solverPosition = solverPose2.solverPosition;
					vector = this.RotatePositionFrom(vector, solverPosition, quaternion);
					for (int l = base.solverPoses.Count - 1; l > k; l--)
					{
						IkSolver2D.SolverPose solverPose3 = base.solverPoses[l];
						solverPose3.solverPosition = this.RotatePositionFrom(solverPose3.solverPosition, solverPosition, quaternion);
					}
				}
			}
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x00065060 File Offset: 0x00063260
		private Vector3 RotatePositionFrom(Vector3 position, Vector3 pivot, Quaternion rotation)
		{
			Vector3 vector = position - pivot;
			vector = rotation * vector;
			return pivot + vector;
		}

		// Token: 0x04000B10 RID: 2832
		public int iterations = 10;

		// Token: 0x04000B11 RID: 2833
		public float damping = 0.8f;
	}
}
