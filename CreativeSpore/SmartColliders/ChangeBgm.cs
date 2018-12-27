using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200053F RID: 1343
	public class ChangeBgm : MonoBehaviour
	{
		// Token: 0x0600325F RID: 12895 RVA: 0x005D73F8 File Offset: 0x005D55F8
		private void Awake()
		{
			this.bgmWorks = GameObject.Find("BGM").GetComponent<BGMWorks>();
			this.targetFalse = base.transform.parent.parent.gameObject;
			this.targetFalse2 = base.transform.parent.gameObject;
			this.text1 = base.transform.Find("PekeSprite2").gameObject;
			this.text2 = base.transform.Find("PenSprite").gameObject;
			this.text3 = base.transform.Find("PekeSprite").gameObject;
			this.text1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-300f, this.text1.GetComponent<RectTransform>().anchoredPosition.y);
			this.text2.GetComponent<RectTransform>().anchoredPosition = new Vector2(-300f, this.text2.GetComponent<RectTransform>().anchoredPosition.y);
			this.text3.GetComponent<RectTransform>().anchoredPosition = new Vector2(-300f, this.text3.GetComponent<RectTransform>().anchoredPosition.y);
		}

		// Token: 0x06003260 RID: 12896 RVA: 0x005D7532 File Offset: 0x005D5732
		public void ChangeBGM()
		{
			this.bgmWorks.ChangeBGMCall(this.songNumber);
			this.targetFalse2.SetActive(false);
			this.targetFalse.SetActive(false);
		}

		// Token: 0x0400669E RID: 26270
		private GameObject targetFalse;

		// Token: 0x0400669F RID: 26271
		private GameObject targetFalse2;

		// Token: 0x040066A0 RID: 26272
		public int songNumber;

		// Token: 0x040066A1 RID: 26273
		private BGMWorks bgmWorks;

		// Token: 0x040066A2 RID: 26274
		private GameObject text1;

		// Token: 0x040066A3 RID: 26275
		private GameObject text2;

		// Token: 0x040066A4 RID: 26276
		private GameObject text3;
	}
}
