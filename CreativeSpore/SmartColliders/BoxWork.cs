using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020004FF RID: 1279
	public class BoxWork : MonoBehaviour
	{
		// Token: 0x0600311B RID: 12571 RVA: 0x005B754C File Offset: 0x005B574C
		private void Awake()
		{
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x0600311C RID: 12572 RVA: 0x005B7564 File Offset: 0x005B5764
		public void ActionReset()
		{
			this.box1.transform.position = new Vector2(this.pos1.position.x, this.pos1.position.y);
			this.box2.transform.position = new Vector2(this.pos2.position.x, this.pos2.position.y);
			this.box3.transform.position = new Vector2(this.pos3.position.x, this.pos3.position.y);
			this.box4.transform.position = new Vector2(this.pos4.position.x, this.pos4.position.y);
			this.box5.transform.position = new Vector2(this.pos5.position.x, this.pos5.position.y);
			this.box6.transform.position = new Vector2(this.pos6.position.x, this.pos6.position.y);
			foreach (IronMaiden ironMaiden in this.ironMaiden)
			{
				ironMaiden.onTheBox = false;
				int stageDifficult = this.playerStatus.stageDifficult;
				if (stageDifficult != 1)
				{
					if (stageDifficult != 2)
					{
						if (stageDifficult == 3)
						{
							ironMaiden.level = 2;
						}
					}
					else
					{
						ironMaiden.level = 2;
					}
				}
				else
				{
					ironMaiden.level = 1;
				}
			}
		}

		// Token: 0x040062BD RID: 25277
		public GameObject box1;

		// Token: 0x040062BE RID: 25278
		public GameObject box2;

		// Token: 0x040062BF RID: 25279
		public GameObject box3;

		// Token: 0x040062C0 RID: 25280
		public GameObject box4;

		// Token: 0x040062C1 RID: 25281
		public GameObject box5;

		// Token: 0x040062C2 RID: 25282
		public GameObject box6;

		// Token: 0x040062C3 RID: 25283
		public Transform pos1;

		// Token: 0x040062C4 RID: 25284
		public Transform pos2;

		// Token: 0x040062C5 RID: 25285
		public Transform pos3;

		// Token: 0x040062C6 RID: 25286
		public Transform pos4;

		// Token: 0x040062C7 RID: 25287
		public Transform pos5;

		// Token: 0x040062C8 RID: 25288
		public Transform pos6;

		// Token: 0x040062C9 RID: 25289
		public IronMaiden[] ironMaiden;

		// Token: 0x040062CA RID: 25290
		private PlayerStatus playerStatus;
	}
}
