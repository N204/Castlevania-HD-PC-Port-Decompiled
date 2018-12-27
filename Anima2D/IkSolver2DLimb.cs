using System;
using UnityEngine;

namespace Anima2D
{
	// Token: 0x020000F8 RID: 248
	[Serializable]
	public class IkSolver2DLimb : IkSolver2D
	{
		// Token: 0x06000641 RID: 1601 RVA: 0x0006508C File Offset: 0x0006328C
		protected override void DoSolverUpdate()
		{
			if (!base.rootBone || base.solverPoses.Count != 2)
			{
				return;
			}
			IkSolver2D.SolverPose solverPose = base.solverPoses[0];
			IkSolver2D.SolverPose solverPose2 = base.solverPoses[1];
			Vector3 vector = this.targetPosition - base.rootBone.transform.position;
			vector.z = 0f;
			float magnitude = vector.magnitude;
			float num = 0f;
			float num2 = 0f;
			float sqrMagnitude = vector.sqrMagnitude;
			float num3 = solverPose.bone.length * solverPose.bone.length;
			float num4 = solverPose2.bone.length * solverPose2.bone.length;
			float num5 = (sqrMagnitude + num3 - num4) / (2f * solverPose.bone.length * magnitude);
			float num6 = (sqrMagnitude - num3 - num4) / (2f * solverPose.bone.length * solverPose2.bone.length);
			if (num5 >= -1f && num5 <= 1f && num6 >= -1f && num6 <= 1f)
			{
				num = Mathf.Acos(num5) * 57.29578f;
				num2 = Mathf.Acos(num6) * 57.29578f;
			}
			float num7 = (!this.flip) ? 1f : -1f;
			Vector3 direction = Vector3.ProjectOnPlane(this.targetPosition - base.rootBone.transform.position, base.rootBone.transform.forward);
			if (base.rootBone.transform.parent)
			{
				direction = base.rootBone.transform.parent.InverseTransformDirection(direction);
			}
			float num8 = Mathf.Atan2(direction.y, direction.x) * 57.29578f;
			solverPose.solverRotation = Quaternion.Euler(0f, 0f, num8 - num7 * num);
			solverPose2.solverRotation = Quaternion.Euler(0f, 0f, num7 * num2);
		}

		// Token: 0x04000B12 RID: 2834
		public bool flip;
	}
}
