using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020004E6 RID: 1254
	public class Bridge : MonoBehaviour
	{
		// Token: 0x0600309F RID: 12447 RVA: 0x005A9965 File Offset: 0x005A7B65
		public void Awake()
		{
			this.switchLever = base.transform.parent.GetComponent<SwitchLever>();
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x060030A0 RID: 12448 RVA: 0x005A998C File Offset: 0x005A7B8C
		public void FixedUpdate()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (currentAnimatorStateInfo.fullPathHash == Bridge.ANISTS_BridgeUp || currentAnimatorStateInfo.fullPathHash == Bridge.ANISTS_BridgeDown)
			{
				this.switchLever.leverFixed = true;
			}
			else if (currentAnimatorStateInfo.fullPathHash == Bridge.ANISTS_BridgeUpStay || currentAnimatorStateInfo.fullPathHash == Bridge.ANISTS_BridgeDownStay)
			{
				this.switchLever.leverFixed = false;
			}
		}

		// Token: 0x060030A1 RID: 12449 RVA: 0x005A9A08 File Offset: 0x005A7C08
		public void Update()
		{
			if (this.switchLever.leverOn)
			{
				this.animator.SetBool("Bridge", true);
			}
			else if (this.switchLever.leverOff)
			{
				this.animator.SetBool("Bridge", false);
			}
		}

		// Token: 0x040061AD RID: 25005
		public static readonly int ANISTS_BridgeUpStay = Animator.StringToHash("Base Layer.BridgeUp_Stay");

		// Token: 0x040061AE RID: 25006
		public static readonly int ANISTS_BridgeDownStay = Animator.StringToHash("Base Layer.BridgeDown_Stay");

		// Token: 0x040061AF RID: 25007
		public static readonly int ANISTS_BridgeUp = Animator.StringToHash("Base Layer.Bridge_Up");

		// Token: 0x040061B0 RID: 25008
		public static readonly int ANISTS_BridgeDown = Animator.StringToHash("Base Layer.Bridge_Down");

		// Token: 0x040061B1 RID: 25009
		[NonSerialized]
		public Animator animator;

		// Token: 0x040061B2 RID: 25010
		private SwitchLever switchLever;
	}
}
