using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Anima2D
{
	// Token: 0x020000EF RID: 239
	public class Bone2D : MonoBehaviour
	{
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x000640FC File Offset: 0x000622FC
		// (set) Token: 0x060005EC RID: 1516 RVA: 0x00064104 File Offset: 0x00062304
		public Ik2D attachedIK
		{
			get
			{
				return this.m_AttachedIK;
			}
			set
			{
				this.m_AttachedIK = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060005ED RID: 1517 RVA: 0x0006410D File Offset: 0x0006230D
		// (set) Token: 0x060005EE RID: 1518 RVA: 0x00064115 File Offset: 0x00062315
		public Color color
		{
			get
			{
				return this.m_Color;
			}
			set
			{
				this.m_Color = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x00064120 File Offset: 0x00062320
		// (set) Token: 0x060005F0 RID: 1520 RVA: 0x000641FF File Offset: 0x000623FF
		public Bone2D child
		{
			get
			{
				if (this.m_Child)
				{
					this.child = this.m_Child;
				}
				if (this.m_CachedChild && this.m_ChildTransform != this.m_CachedChild.transform)
				{
					this.m_CachedChild = null;
				}
				if (this.m_ChildTransform && this.m_ChildTransform.parent != base.transform)
				{
					this.m_CachedChild = null;
				}
				if (!this.m_CachedChild && this.m_ChildTransform && this.m_ChildTransform.parent == base.transform)
				{
					this.m_CachedChild = this.m_ChildTransform.GetComponent<Bone2D>();
				}
				return this.m_CachedChild;
			}
			set
			{
				this.m_Child = null;
				this.m_CachedChild = value;
				this.m_ChildTransform = this.m_CachedChild.transform;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x00064220 File Offset: 0x00062420
		public Vector3 localEndPosition
		{
			get
			{
				return Vector3.right * this.localLength;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00064232 File Offset: 0x00062432
		public Vector3 endPosition
		{
			get
			{
				return base.transform.TransformPoint(this.localEndPosition);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060005F3 RID: 1523 RVA: 0x00064248 File Offset: 0x00062448
		// (set) Token: 0x060005F4 RID: 1524 RVA: 0x000642A5 File Offset: 0x000624A5
		public float localLength
		{
			get
			{
				if (this.child)
				{
					Vector3 vector = base.transform.InverseTransformPoint(this.child.transform.position);
					this.m_Length = Mathf.Clamp(vector.x, 0f, vector.x);
				}
				return this.m_Length;
			}
			set
			{
				if (!this.child)
				{
					this.m_Length = value;
				}
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x000642C0 File Offset: 0x000624C0
		public float length
		{
			get
			{
				return base.transform.TransformVector(this.localEndPosition).magnitude;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x000642E8 File Offset: 0x000624E8
		public Bone2D parentBone
		{
			get
			{
				Transform parent = base.transform.parent;
				if (!this.mParentBone)
				{
					if (parent)
					{
						this.mParentBone = parent.GetComponent<Bone2D>();
					}
				}
				else if (parent != this.mParentBone.transform)
				{
					if (parent)
					{
						this.mParentBone = parent.GetComponent<Bone2D>();
					}
					else
					{
						this.mParentBone = null;
					}
				}
				return this.mParentBone;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x0006436C File Offset: 0x0006256C
		public Bone2D linkedParentBone
		{
			get
			{
				if (this.parentBone && this.parentBone.child == this)
				{
					return this.parentBone;
				}
				return null;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060005F8 RID: 1528 RVA: 0x0006439C File Offset: 0x0006259C
		public Bone2D root
		{
			get
			{
				Bone2D bone2D = this;
				while (bone2D.parentBone)
				{
					bone2D = bone2D.parentBone;
				}
				return bone2D;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x000643C8 File Offset: 0x000625C8
		public Bone2D chainRoot
		{
			get
			{
				Bone2D bone2D = this;
				while (bone2D.parentBone && bone2D.parentBone.child == bone2D)
				{
					bone2D = bone2D.parentBone;
				}
				return bone2D;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060005FA RID: 1530 RVA: 0x0006440C File Offset: 0x0006260C
		public int chainLength
		{
			get
			{
				Bone2D bone2D = this;
				int num = 1;
				while (bone2D.parentBone && bone2D.parentBone.child == bone2D)
				{
					num++;
					bone2D = bone2D.parentBone;
				}
				return num;
			}
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x00064454 File Offset: 0x00062654
		public static Bone2D GetChainBoneByIndex(Bone2D chainTip, int index)
		{
			if (!chainTip)
			{
				return null;
			}
			Bone2D bone2D = chainTip;
			int chainLength = bone2D.chainLength;
			int num = 0;
			while (num < chainLength && bone2D)
			{
				if (num == index)
				{
					return bone2D;
				}
				if (!bone2D.linkedParentBone)
				{
					return null;
				}
				bone2D = bone2D.parentBone;
				num++;
			}
			return null;
		}

		// Token: 0x04000AEC RID: 2796
		[FormerlySerializedAs("color")]
		[SerializeField]
		private Color m_Color = Color.white;

		// Token: 0x04000AED RID: 2797
		[FormerlySerializedAs("mLength")]
		[SerializeField]
		private float m_Length = 1f;

		// Token: 0x04000AEE RID: 2798
		[FormerlySerializedAs("mChild")]
		[HideInInspector]
		[SerializeField]
		private Bone2D m_Child;

		// Token: 0x04000AEF RID: 2799
		[SerializeField]
		[HideInInspector]
		private Transform m_ChildTransform;

		// Token: 0x04000AF0 RID: 2800
		[SerializeField]
		private Ik2D m_AttachedIK;

		// Token: 0x04000AF1 RID: 2801
		private Bone2D m_CachedChild;

		// Token: 0x04000AF2 RID: 2802
		private Bone2D mParentBone;
	}
}
