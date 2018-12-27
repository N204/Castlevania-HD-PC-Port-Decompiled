using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Anima2D
{
	// Token: 0x020000F5 RID: 245
	[Serializable]
	public abstract class IkSolver2D
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x00064A30 File Offset: 0x00062C30
		// (set) Token: 0x0600062C RID: 1580 RVA: 0x00064AC2 File Offset: 0x00062CC2
		public Bone2D rootBone
		{
			get
			{
				if (this.m_RootBone)
				{
					this.rootBone = this.m_RootBone;
				}
				if (this.m_CachedRootBone && this.m_RootBoneTransform != this.m_CachedRootBone.transform)
				{
					this.m_CachedRootBone = null;
				}
				if (!this.m_CachedRootBone && this.m_RootBoneTransform)
				{
					this.m_CachedRootBone = this.m_RootBoneTransform.GetComponent<Bone2D>();
				}
				return this.m_CachedRootBone;
			}
			private set
			{
				this.m_RootBone = null;
				this.m_CachedRootBone = value;
				this.m_RootBoneTransform = null;
				if (value)
				{
					this.m_RootBoneTransform = value.transform;
				}
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600062D RID: 1581 RVA: 0x00064AF0 File Offset: 0x00062CF0
		public List<IkSolver2D.SolverPose> solverPoses
		{
			get
			{
				return this.m_SolverPoses;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600062E RID: 1582 RVA: 0x00064AF8 File Offset: 0x00062CF8
		// (set) Token: 0x0600062F RID: 1583 RVA: 0x00064B00 File Offset: 0x00062D00
		public float weight
		{
			get
			{
				return this.m_Weight;
			}
			set
			{
				this.m_Weight = Mathf.Clamp01(value);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000630 RID: 1584 RVA: 0x00064B0E File Offset: 0x00062D0E
		// (set) Token: 0x06000631 RID: 1585 RVA: 0x00064B16 File Offset: 0x00062D16
		public bool restoreDefaultPose
		{
			get
			{
				return this.m_RestoreDefaultPose;
			}
			set
			{
				this.m_RestoreDefaultPose = value;
			}
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00064B20 File Offset: 0x00062D20
		public void Initialize(Bone2D _rootBone, int numChilds)
		{
			this.rootBone = _rootBone;
			Bone2D bone2D = this.rootBone;
			this.solverPoses.Clear();
			for (int i = 0; i < numChilds; i++)
			{
				if (bone2D)
				{
					IkSolver2D.SolverPose solverPose = new IkSolver2D.SolverPose();
					solverPose.bone = bone2D;
					this.solverPoses.Add(solverPose);
					bone2D = bone2D.child;
				}
			}
			this.StoreDefaultPoses();
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00064B89 File Offset: 0x00062D89
		public void Update()
		{
			if (this.weight > 0f)
			{
				if (this.restoreDefaultPose)
				{
					this.RestoreDefaultPoses();
				}
				this.DoSolverUpdate();
				this.UpdateBones();
			}
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00064BB8 File Offset: 0x00062DB8
		public void StoreDefaultPoses()
		{
			for (int i = 0; i < this.solverPoses.Count; i++)
			{
				IkSolver2D.SolverPose solverPose = this.solverPoses[i];
				if (solverPose != null)
				{
					solverPose.StoreDefaultPose();
				}
			}
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x00064BFC File Offset: 0x00062DFC
		public void RestoreDefaultPoses()
		{
			for (int i = 0; i < this.solverPoses.Count; i++)
			{
				IkSolver2D.SolverPose solverPose = this.solverPoses[i];
				if (solverPose != null)
				{
					solverPose.RestoreDefaultPose();
				}
			}
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x00064C40 File Offset: 0x00062E40
		private void UpdateBones()
		{
			for (int i = 0; i < this.solverPoses.Count; i++)
			{
				IkSolver2D.SolverPose solverPose = this.solverPoses[i];
				if (solverPose != null && solverPose.bone)
				{
					if (this.weight == 1f)
					{
						solverPose.bone.transform.localRotation = solverPose.solverRotation;
					}
					else
					{
						solverPose.bone.transform.localRotation = Quaternion.Slerp(solverPose.bone.transform.localRotation, solverPose.solverRotation, this.weight);
					}
				}
			}
		}

		// Token: 0x06000637 RID: 1591
		protected abstract void DoSolverUpdate();

		// Token: 0x04000B03 RID: 2819
		[SerializeField]
		[HideInInspector]
		private Bone2D m_RootBone;

		// Token: 0x04000B04 RID: 2820
		[SerializeField]
		private Transform m_RootBoneTransform;

		// Token: 0x04000B05 RID: 2821
		[SerializeField]
		private List<IkSolver2D.SolverPose> m_SolverPoses = new List<IkSolver2D.SolverPose>();

		// Token: 0x04000B06 RID: 2822
		[SerializeField]
		private float m_Weight = 1f;

		// Token: 0x04000B07 RID: 2823
		[SerializeField]
		private bool m_RestoreDefaultPose = true;

		// Token: 0x04000B08 RID: 2824
		private Bone2D m_CachedRootBone;

		// Token: 0x04000B09 RID: 2825
		public Vector3 targetPosition;

		// Token: 0x020000F6 RID: 246
		[Serializable]
		public class SolverPose
		{
			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000639 RID: 1593 RVA: 0x00064D14 File Offset: 0x00062F14
			// (set) Token: 0x0600063A RID: 1594 RVA: 0x00064DA6 File Offset: 0x00062FA6
			public Bone2D bone
			{
				get
				{
					if (this.m_Bone)
					{
						this.bone = this.m_Bone;
					}
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
					this.m_Bone = null;
					this.m_CachedBone = value;
					this.m_BoneTransform = null;
					if (value)
					{
						this.m_BoneTransform = this.m_CachedBone.transform;
					}
				}
			}

			// Token: 0x0600063B RID: 1595 RVA: 0x00064DD9 File Offset: 0x00062FD9
			public void StoreDefaultPose()
			{
				this.defaultLocalRotation = this.bone.transform.localRotation;
			}

			// Token: 0x0600063C RID: 1596 RVA: 0x00064DF1 File Offset: 0x00062FF1
			public void RestoreDefaultPose()
			{
				if (this.bone)
				{
					this.bone.transform.localRotation = this.defaultLocalRotation;
				}
			}

			// Token: 0x04000B0A RID: 2826
			[HideInInspector]
			[SerializeField]
			[FormerlySerializedAs("bone")]
			private Bone2D m_Bone;

			// Token: 0x04000B0B RID: 2827
			[SerializeField]
			private Transform m_BoneTransform;

			// Token: 0x04000B0C RID: 2828
			private Bone2D m_CachedBone;

			// Token: 0x04000B0D RID: 2829
			public Vector3 solverPosition = Vector3.zero;

			// Token: 0x04000B0E RID: 2830
			public Quaternion solverRotation = Quaternion.identity;

			// Token: 0x04000B0F RID: 2831
			public Quaternion defaultLocalRotation = Quaternion.identity;
		}
	}
}
