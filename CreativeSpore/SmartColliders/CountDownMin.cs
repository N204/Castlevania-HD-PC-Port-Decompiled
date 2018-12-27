using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200062D RID: 1581
	public class CountDownMin : MonoBehaviour
	{
		// Token: 0x060037FD RID: 14333 RVA: 0x0068A7FC File Offset: 0x006889FC
		private void Awake()
		{
			this.menuOnOff = base.transform.parent.parent.GetComponent<MenuOnOff>();
			this.bgmWorks = GameObject.Find("BGM").GetComponent<BGMWorks>();
			this.myPV = base.GetComponent<PhotonView>();
		}

		// Token: 0x060037FE RID: 14334 RVA: 0x0068A83A File Offset: 0x00688A3A
		private void Start()
		{
			base.GetComponent<Text>().text = this.currentTime.ToString();
		}

		// Token: 0x060037FF RID: 14335 RVA: 0x0068A858 File Offset: 0x00688A58
		private void Update()
		{
			if (this.playerSpawn == null)
			{
				this.playerSpawn = GameObject.Find("StageNetwork").GetComponent<PlayerSpwan>();
			}
			if (this.currentTime < 0)
			{
				this.over = true;
			}
			if (this.over && !this.timeUp && PhotonNetwork.isMasterClient)
			{
				base.StartCoroutine(this.FailedCall(2f));
				this.playerSpawn.SaveDateAddScore();
				this.myPV.RPC("ReciveTimeUp", PhotonTargets.Others, new object[0]);
				this.timeUp = true;
			}
			if (this.over && !this.doubleCheck)
			{
				this.doubleCheck = true;
			}
			if (this.currentTime >= 10)
			{
				base.GetComponent<Text>().text = this.currentTime.ToString();
			}
			else if (this.currentTime < 10 && this.currentTime >= 0)
			{
				base.GetComponent<Text>().text = "0" + this.currentTime.ToString();
			}
			else if (this.currentTime <= 0)
			{
				base.GetComponent<Text>().text = "00";
			}
		}

		// Token: 0x06003800 RID: 14336 RVA: 0x0068A9A4 File Offset: 0x00688BA4
		private IEnumerator FailedCall(float delay)
		{
			yield return new WaitForSeconds(delay);
			this.menuOnOff.Faild();
			this.bgmWorks.SystemBGMCall(37);
			yield break;
		}

		// Token: 0x06003801 RID: 14337 RVA: 0x0068A9C6 File Offset: 0x00688BC6
		[PunRPC]
		private void ReciveTimeUp()
		{
			base.StartCoroutine(this.FailedCall(2f));
			this.playerSpawn.SaveDateAddScore();
		}

		// Token: 0x0400757C RID: 30076
		public int currentTime = 30;

		// Token: 0x0400757D RID: 30077
		public bool over;

		// Token: 0x0400757E RID: 30078
		public bool timeUp;

		// Token: 0x0400757F RID: 30079
		public bool doubleCheck;

		// Token: 0x04007580 RID: 30080
		public PlayerSpwan playerSpawn;

		// Token: 0x04007581 RID: 30081
		private MenuOnOff menuOnOff;

		// Token: 0x04007582 RID: 30082
		private BGMWorks bgmWorks;

		// Token: 0x04007583 RID: 30083
		private PhotonView myPV;
	}
}
