using System;
using UnityEngine;

namespace Anima2D
{
	// Token: 0x020000F1 RID: 241
	public abstract class Ik2D : MonoBehaviour
	{
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000603 RID: 1539 RVA: 0x000645F0 File Offset: 0x000627F0
		public IkSolver2D solver
		{
			get
			{
				return this.GetSolver();
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000604 RID: 1540 RVA: 0x000645F8 File Offset: 0x000627F8
		public bool record
		{
			get
			{
				return this.m_Record;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000605 RID: 1541 RVA: 0x00064600 File Offset: 0x00062800
		// (set) Token: 0x06000606 RID: 1542 RVA: 0x00064692 File Offset: 0x00062892
		public Bone2D target
		{
			get
			{
				if (this.m_Target)
				{
					this.target = this.m_Target;
				}
				if (this.m_CachedTarget && this.m_TargetTransform != this.m_CachedTarget.transform)
				{
					this.m_CachedTarget = null;
				}
				if (!this.m_CachedTarget && this.m_TargetTransform)
				{
					this.m_CachedTarget = this.m_TargetTransform.GetComponent<Bone2D>();
				}
				return this.m_CachedTarget;
			}
			set
			{
				this.m_CachedTarget = value;
				this.m_TargetTransform = value.transform;
				if (!this.m_Target)
				{
					this.InitializeSolver();
				}
				this.m_Target = null;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000607 RID: 1543 RVA: 0x000646C4 File Offset: 0x000628C4
		// (set) Token: 0x06000608 RID: 1544 RVA: 0x000646D4 File Offset: 0x000628D4
		public int numBones
		{
			get
			{
				return this.ValidateNumBones(this.m_NumBones);
			}
			set
			{
				int num = this.ValidateNumBones(value);
				if (num != this.m_NumBones)
				{
					this.m_NumBones = num;
					this.InitializeSolver();
				}
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000609 RID: 1545 RVA: 0x00064702 File Offset: 0x00062902
		// (set) Token: 0x0600060A RID: 1546 RVA: 0x0006470A File Offset: 0x0006290A
		public float weight
		{
			get
			{
				return this.m_Weight;
			}
			set
			{
				this.m_Weight = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x0600060B RID: 1547 RVA: 0x00064713 File Offset: 0x00062913
		// (set) Token: 0x0600060C RID: 1548 RVA: 0x0006471B File Offset: 0x0006291B
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

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x0600060D RID: 1549 RVA: 0x00064724 File Offset: 0x00062924
		// (set) Token: 0x0600060E RID: 1550 RVA: 0x0006472C File Offset: 0x0006292C
		public bool orientChild
		{
			get
			{
				return this.m_OrientChild;
			}
			set
			{
				this.m_OrientChild = value;
			}
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00064738 File Offset: 0x00062938
		private void OnDrawGizmos()
		{
			Gizmos.matrix = base.transform.localToWorldMatrix;
			if (base.enabled && this.target && this.numBones > 0)
			{
				Gizmos.DrawIcon(base.transform.position, "ikGoal");
			}
			else
			{
				Gizmos.DrawIcon(base.transform.position, "ikGoalDisabled");
			}
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x000647AB File Offset: 0x000629AB
		private void OnValidate()
		{
			this.Validate();
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x000647B3 File Offset: 0x000629B3
		private void Start()
		{
			this.OnStart();
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x000647BB File Offset: 0x000629BB
		private void Update()
		{
			this.SetAttachedIK(this);
			this.OnUpdate();
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x000647CA File Offset: 0x000629CA
		private void LateUpdate()
		{
			this.OnLateUpdate();
			this.UpdateIK();
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x000647D8 File Offset: 0x000629D8
		private void SetAttachedIK(Ik2D ik2D)
		{
			for (int i = 0; i < this.solver.solverPoses.Count; i++)
			{
				IkSolver2D.SolverPose solverPose = this.solver.solverPoses[i];
				if (solverPose.bone)
				{
					solverPose.bone.attachedIK = ik2D;
				}
			}
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x00064834 File Offset: 0x00062A34
		public void UpdateIK()
		{
			this.OnIkUpdate();
			this.solver.Update();
			if (this.orientChild && this.target.child)
			{
				this.target.child.transform.rotation = base.transform.rotation;
			}
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x00064892 File Offset: 0x00062A92
		protected virtual void OnIkUpdate()
		{
			this.solver.weight = this.weight;
			this.solver.targetPosition = base.transform.position;
			this.solver.restoreDefaultPose = this.restoreDefaultPose;
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x000648CC File Offset: 0x00062ACC
		private void InitializeSolver()
		{
			Bone2D chainBoneByIndex = Bone2D.GetChainBoneByIndex(this.target, this.numBones - 1);
			this.SetAttachedIK(null);
			this.solver.Initialize(chainBoneByIndex, this.numBones);
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x00064906 File Offset: 0x00062B06
		protected virtual int ValidateNumBones(int numBones)
		{
			return numBones;
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00004F4D File Offset: 0x0000314D
		protected virtual void Validate()
		{
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00004F4D File Offset: 0x0000314D
		protected virtual void OnStart()
		{
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00004F4D File Offset: 0x0000314D
		protected virtual void OnUpdate()
		{
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00004F4D File Offset: 0x0000314D
		protected virtual void OnLateUpdate()
		{
		}

		// Token: 0x0600061D RID: 1565
		protected abstract IkSolver2D GetSolver();

		// Token: 0x04000AF5 RID: 2805
		[HideInInspector]
		[SerializeField]
		private Bone2D m_Target;

		// Token: 0x04000AF6 RID: 2806
		[SerializeField]
		private bool m_Record;

		// Token: 0x04000AF7 RID: 2807
		[SerializeField]
		private Transform m_TargetTransform;

		// Token: 0x04000AF8 RID: 2808
		[SerializeField]
		private int m_NumBones;

		// Token: 0x04000AF9 RID: 2809
		[SerializeField]
		private float m_Weight = 1f;

		// Token: 0x04000AFA RID: 2810
		[SerializeField]
		private bool m_RestoreDefaultPose = true;

		// Token: 0x04000AFB RID: 2811
		[SerializeField]
		private bool m_OrientChild = true;

		// Token: 0x04000AFC RID: 2812
		private Bone2D m_CachedTarget;
	}
}
