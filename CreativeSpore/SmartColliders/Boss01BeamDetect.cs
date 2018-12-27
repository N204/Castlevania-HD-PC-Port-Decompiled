using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020001FB RID: 507
	public class Boss01BeamDetect : MonoBehaviour
	{
		// Token: 0x06000D78 RID: 3448 RVA: 0x0008FA8C File Offset: 0x0008DC8C
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent")
			{
				if (this.leftDown)
				{
					this.bossStage01.targetLeftDownPos = true;
				}
				else if (this.rightDown)
				{
					this.bossStage01.targetRightDownPos = true;
				}
				else if (this.leftUp)
				{
					this.bossStage01.targetLeftUpPos = true;
				}
				else if (this.rightUp)
				{
					this.bossStage01.targetRightUpPos = true;
				}
				else if (this.bossWakeUp && !this.bossStage01.wakeUp)
				{
					this.bossStage01.wakeUp = true;
				}
			}
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x0008FB48 File Offset: 0x0008DD48
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent")
			{
				if (this.leftDown)
				{
					this.bossStage01.targetLeftDownPos = true;
				}
				else if (this.rightDown)
				{
					this.bossStage01.targetRightDownPos = true;
				}
				else if (this.leftUp)
				{
					this.bossStage01.targetLeftUpPos = true;
				}
				else if (this.rightUp)
				{
					this.bossStage01.targetRightUpPos = true;
				}
				else if (this.bossWakeUp && !this.bossStage01.wakeUp)
				{
					this.bossStage01.wakeUp = true;
				}
			}
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x0008FC04 File Offset: 0x0008DE04
		private void Update()
		{
			if (this.bossStage01.targetLeftDownPos || this.bossStage01.targetRightDownPos || this.bossStage01.targetLeftUpPos || this.bossStage01.targetRightUpPos)
			{
				this.falseTime += Time.deltaTime;
				if (this.falseTime > 6f)
				{
					this.bossStage01.targetLeftDownPos = false;
					this.bossStage01.targetRightDownPos = false;
					this.bossStage01.targetLeftUpPos = false;
					this.bossStage01.targetRightUpPos = false;
					this.falseTime = 0f;
				}
			}
		}

		// Token: 0x04001228 RID: 4648
		public BossStage01 bossStage01;

		// Token: 0x04001229 RID: 4649
		public bool bossWakeUp;

		// Token: 0x0400122A RID: 4650
		public bool leftDown;

		// Token: 0x0400122B RID: 4651
		public bool rightDown;

		// Token: 0x0400122C RID: 4652
		public bool leftUp;

		// Token: 0x0400122D RID: 4653
		public bool rightUp;

		// Token: 0x0400122E RID: 4654
		public float falseTime;
	}
}
