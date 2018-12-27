using System;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200062C RID: 1580
	public class CountDown : MonoBehaviour
	{
		// Token: 0x060037F9 RID: 14329 RVA: 0x0068A668 File Offset: 0x00688868
		private void Start()
		{
			base.GetComponent<Text>().text = ((int)this.time).ToString();
		}

		// Token: 0x060037FA RID: 14330 RVA: 0x0068A698 File Offset: 0x00688898
		private void Update()
		{
			if (this.start && this.countDownMin.currentTime >= 0)
			{
				this.time -= Time.deltaTime;
			}
			if (this.time < 0f)
			{
				this.time = 60f;
				this.countDownMin.currentTime--;
			}
			if (this.countDownMin.over || !this.start)
			{
				base.GetComponent<Text>().text = "00";
			}
			if (!this.countDownMin.over)
			{
				if (this.time < 10f)
				{
					base.GetComponent<Text>().text = "0" + ((int)this.time).ToString();
				}
				else if (this.time >= 10f)
				{
					base.GetComponent<Text>().text = ((int)this.time).ToString();
				}
				else if (this.time > 59f)
				{
					base.GetComponent<Text>().text = "00";
				}
			}
		}

		// Token: 0x060037FB RID: 14331 RVA: 0x0068A7D0 File Offset: 0x006889D0
		public void GoStartTimer()
		{
			this.start = true;
			this.countDownMin.currentTime--;
		}

		// Token: 0x04007578 RID: 30072
		public float time = 60f;

		// Token: 0x04007579 RID: 30073
		public bool start;

		// Token: 0x0400757A RID: 30074
		public CountDownMin countDownMin;

		// Token: 0x0400757B RID: 30075
		private PlayerSpwan playerSpawn;
	}
}
