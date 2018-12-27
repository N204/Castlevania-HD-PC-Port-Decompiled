using System;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000564 RID: 1380
	public class CurrentStatus : MonoBehaviour
	{
		// Token: 0x06003351 RID: 13137 RVA: 0x006242C7 File Offset: 0x006224C7
		private void Awake()
		{
			this.text = base.GetComponent<Text>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06003352 RID: 13138 RVA: 0x006242EC File Offset: 0x006224EC
		private void Update()
		{
			if (this.playerStatus == null)
			{
				this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			}
			if (base.gameObject.name == "ATKText")
			{
				if (this.playerStatus.charaNumber == 1)
				{
					if (this.targetCheck.activeSelf)
					{
						this.text.text = string.Empty + this.playerStatus.ATK_Sub;
					}
					else
					{
						this.text.text = string.Empty + this.playerStatus.ATK;
					}
				}
				else
				{
					this.text.text = string.Empty + this.playerStatus.ATK;
				}
				if (this.playerStatus.statusLimit)
				{
					this.text.color = Color.yellow;
				}
			}
			else if (base.gameObject.name == "STRText")
			{
				this.text.text = string.Empty + this.playerStatus.STR;
			}
			else if (base.gameObject.name == "DEFText")
			{
				this.text.text = string.Empty + this.playerStatus.DEF;
				if (this.playerStatus.statusLimit)
				{
					this.text.color = Color.yellow;
				}
			}
			else if (base.gameObject.name == "CONText")
			{
				this.text.text = string.Empty + this.playerStatus.CON;
			}
			else if (base.gameObject.name == "INTText")
			{
				this.text.text = string.Empty + this.playerStatus.INT;
				if (this.playerStatus.statusLimit)
				{
					this.text.color = Color.yellow;
				}
			}
			else if (base.gameObject.name == "MNDText")
			{
				this.text.text = string.Empty + this.playerStatus.MND;
				if (this.playerStatus.statusLimit)
				{
					this.text.color = Color.yellow;
				}
			}
			else if (base.gameObject.name == "HitText")
			{
				this.text.text = string.Empty + this.playerStatus.playerHIT;
			}
			else if (base.gameObject.name == "PokeText")
			{
				this.text.text = string.Empty + this.playerStatus.playerPOKE;
			}
			else if (base.gameObject.name == "CutText")
			{
				this.text.text = string.Empty + this.playerStatus.playerCUT;
			}
			else if (base.gameObject.name == "FireText")
			{
				this.text.text = string.Empty + this.playerStatus.playerFIRE;
			}
			else if (base.gameObject.name == "IceText")
			{
				this.text.text = string.Empty + this.playerStatus.playerICE;
			}
			else if (base.gameObject.name == "ThunText")
			{
				this.text.text = string.Empty + this.playerStatus.playerTHUN;
			}
			else if (base.gameObject.name == "StoneText")
			{
				this.text.text = string.Empty + this.playerStatus.playerSTON;
			}
			else if (base.gameObject.name == "LightningText")
			{
				this.text.text = string.Empty + this.playerStatus.playerLIGH;
			}
			else if (base.gameObject.name == "DarkText")
			{
				this.text.text = string.Empty + this.playerStatus.playerDARK;
			}
			else if (base.gameObject.name == "PoisonText")
			{
				this.text.text = string.Empty + this.playerStatus.playerPOIS;
			}
			else if (base.gameObject.name == "CurseText")
			{
				this.text.text = string.Empty + this.playerStatus.playerCURS;
			}
		}

		// Token: 0x040069CD RID: 27085
		private Text text;

		// Token: 0x040069CE RID: 27086
		private PlayerStatus playerStatus;

		// Token: 0x040069CF RID: 27087
		private PlayerSpwan playerSpawn;

		// Token: 0x040069D0 RID: 27088
		public GameObject targetCheck;
	}
}
