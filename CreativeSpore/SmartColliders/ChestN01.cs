using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000327 RID: 807
	public class ChestN01 : MonoBehaviour
	{
		// Token: 0x0600199C RID: 6556 RVA: 0x00141714 File Offset: 0x0013F914
		private void Start()
		{
			this.animator = base.GetComponent<Animator>();
			this.myPV = base.GetComponent<PhotonView>();
			this.sprite = base.transform.Find("Sprite").GetComponent<SpriteRenderer>();
			this.itemBase = GameObject.Find("ItemBase").GetComponent<ItemBase>();
		}

		// Token: 0x0600199D RID: 6557 RVA: 0x00141769 File Offset: 0x0013F969
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent" && other.transform.parent.GetComponent<PhotonView>().isMine)
			{
				this.canOpen = true;
			}
		}

		// Token: 0x0600199E RID: 6558 RVA: 0x00141769 File Offset: 0x0013F969
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent" && other.transform.parent.GetComponent<PhotonView>().isMine)
			{
				this.canOpen = true;
			}
		}

		// Token: 0x0600199F RID: 6559 RVA: 0x001417A1 File Offset: 0x0013F9A1
		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent" && other.transform.parent.GetComponent<PhotonView>().isMine)
			{
				this.canOpen = false;
			}
		}

		// Token: 0x060019A0 RID: 6560 RVA: 0x001417DC File Offset: 0x0013F9DC
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (this.playerStatus == null)
			{
				this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			}
			if (this.networkID == null)
			{
				this.networkID = GameObject.Find("NetworkID").GetComponent<NetworkID>();
			}
			if (this.playerCtrl == null)
			{
				GameObject gameObject = GameObject.Find("Player" + PhotonNetwork.player.ID);
				this.playerCtrl = gameObject.GetComponent<PlayerController>();
			}
			if (this.playerMain == null)
			{
				GameObject gameObject2 = GameObject.Find("Player" + PhotonNetwork.player.ID);
				this.playerMain = gameObject2.GetComponent<PlayerMain>();
			}
			float axisRaw = Input.GetAxisRaw("RTLT");
			float axisRaw2 = Input.GetAxisRaw("RTLT2");
			if (axisRaw == 0f)
			{
				this.ltCheck = false;
				this.rtCheck = false;
			}
			else if (axisRaw >= 0.01f)
			{
				this.ltCheck = false;
				this.rtCheck = true;
			}
			else if (axisRaw <= -0.01f)
			{
				this.rtCheck = false;
				this.ltCheck = true;
			}
			if (axisRaw2 == 0f)
			{
				this.ltCheck2 = false;
				this.rtCheck2 = false;
			}
			else if (axisRaw2 >= 0.01f)
			{
				this.ltCheck2 = false;
				this.rtCheck2 = true;
			}
			else if (axisRaw2 <= -0.01f)
			{
				this.rtCheck2 = false;
				this.ltCheck2 = true;
			}
			if (currentAnimatorStateInfo.fullPathHash == ChestN01.ANISTS_Open)
			{
				this.Opened = true;
			}
			else if (currentAnimatorStateInfo.fullPathHash == ChestN01.ANISTS_Idle)
			{
				this.Opened = false;
			}
			if (this.canOpen && !this.Opened)
			{
				switch (this.playerMain.padDecide)
				{
				case 0:
					if (this.ltCheck && !this.lt)
					{
						this.OpenAction();
						this.lt = true;
					}
					if (!this.ltCheck && this.lt)
					{
						this.lt = false;
					}
					break;
				case 1:
					if (Input.GetButtonDown("Jump"))
					{
						this.OpenAction();
					}
					break;
				case 2:
					if (Input.GetButtonDown("Cancel"))
					{
						this.OpenAction();
					}
					break;
				case 3:
					if (Input.GetButtonDown("Fire1"))
					{
						this.OpenAction();
					}
					break;
				case 4:
					if (Input.GetButtonDown("Fire2"))
					{
						this.OpenAction();
					}
					break;
				case 5:
					if (Input.GetButtonDown("Back"))
					{
						this.OpenAction();
					}
					break;
				case 6:
					if (Input.GetButtonDown("RB"))
					{
						this.OpenAction();
					}
					break;
				case 7:
					if (Input.GetButtonDown("LB"))
					{
						this.OpenAction();
					}
					break;
				case 8:
					if (this.rtCheck && !this.rt)
					{
						this.OpenAction();
						this.rt = true;
					}
					if (!this.rtCheck && this.rt)
					{
						this.rt = false;
					}
					break;
				case 9:
					if (this.ltCheck && !this.lt)
					{
						this.OpenAction();
						this.lt = true;
					}
					if (!this.ltCheck && this.lt)
					{
						this.lt = false;
					}
					break;
				}
				switch (this.playerMain.keyDecide)
				{
				case 0:
					if (this.ltCheck2 && !this.lt2)
					{
						this.OpenAction();
						this.lt2 = true;
					}
					if (!this.ltCheck2 && this.lt2)
					{
						this.lt2 = false;
					}
					break;
				case 1:
					if (Input.GetButtonDown("Jump2"))
					{
						this.OpenAction();
					}
					break;
				case 2:
					if (Input.GetButtonDown("Cancel2"))
					{
						this.OpenAction();
					}
					break;
				case 3:
					if (Input.GetButtonDown("Fire1_2"))
					{
						this.OpenAction();
					}
					break;
				case 4:
					if (Input.GetButtonDown("Fire2_2"))
					{
						this.OpenAction();
					}
					break;
				case 5:
					if (Input.GetButtonDown("Back2"))
					{
						this.OpenAction();
					}
					break;
				case 6:
					if (Input.GetButtonDown("RB2"))
					{
						this.OpenAction();
					}
					break;
				case 7:
					if (Input.GetButtonDown("LB2"))
					{
						this.OpenAction();
					}
					break;
				case 8:
					if (this.rtCheck2 && !this.rt2)
					{
						this.OpenAction();
						this.rt2 = true;
					}
					if (!this.rtCheck2 && this.rt2)
					{
						this.rt2 = false;
					}
					break;
				case 9:
					if (this.ltCheck2 && !this.lt)
					{
						this.OpenAction();
						this.lt2 = true;
					}
					if (!this.ltCheck2 && this.lt2)
					{
						this.lt2 = false;
					}
					break;
				}
			}
		}

		// Token: 0x060019A1 RID: 6561 RVA: 0x00141D58 File Offset: 0x0013FF58
		private void OpenAction()
		{
			float f = this.playerStatus.LCK / 3f;
			float f2 = Mathf.Round(f);
			int num = Mathf.RoundToInt(f2);
			if (num < 1)
			{
				num = 1;
			}
			int randomItem = this.GetRandomItem();
			Debug.Log(randomItem);
			this.animator.SetBool("Open", true);
			if (this.canPopMimic)
			{
				if (randomItem < 35)
				{
					this.myPV.RPC("AnimationSetBoolTrue", PhotonTargets.Others, new object[]
					{
						"Open"
					});
					base.Invoke("InstantMimic", 1.5f);
				}
				else if (randomItem < 100 + num)
				{
					this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
					base.Invoke("OpenChest", 1.5f);
				}
			}
			else if (!this.canPopMimic)
			{
				this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
				base.Invoke("OpenChest", 1.5f);
			}
		}

		// Token: 0x060019A2 RID: 6562 RVA: 0x00141E60 File Offset: 0x00140060
		public void InstantMimic()
		{
			this.sprite.enabled = false;
			PhotonNetwork.Instantiate("Enemy_Mimic", base.transform.position, Quaternion.identity, 0);
		}

		// Token: 0x060019A3 RID: 6563 RVA: 0x00141E8C File Offset: 0x0014008C
		public void OpenChest()
		{
			float f = this.playerStatus.LCK / 5f;
			float f2 = Mathf.Round(f);
			int num = Mathf.RoundToInt(f2);
			if (num < 1)
			{
				num = 1;
			}
			int randomItem = this.GetRandomItem();
			Debug.Log(randomItem);
			if (randomItem < 80)
			{
				switch (this.ReturnItemCommon())
				{
				case 1:
					this.itemBase.ItemPlus(this.itemCommon01);
					this.playerCtrl.ItemFukidashi(this.itemCommon01);
					break;
				case 2:
					this.itemBase.ItemPlus(this.itemCommon02);
					this.playerCtrl.ItemFukidashi(this.itemCommon02);
					break;
				case 3:
					this.itemBase.ItemPlus(this.itemCommon03);
					this.playerCtrl.ItemFukidashi(this.itemCommon03);
					break;
				case 4:
					this.itemBase.ItemPlus(this.itemCommon04);
					this.playerCtrl.ItemFukidashi(this.itemCommon04);
					break;
				case 5:
					this.itemBase.ItemPlus(this.itemCommon05);
					this.playerCtrl.ItemFukidashi(this.itemCommon05);
					break;
				case 6:
					this.itemBase.ItemPlus(this.itemCommon06);
					this.playerCtrl.ItemFukidashi(this.itemCommon06);
					break;
				case 7:
					this.itemBase.ItemPlus(this.itemCommon07);
					this.playerCtrl.ItemFukidashi(this.itemCommon07);
					break;
				case 8:
					this.itemBase.ItemPlus(this.itemCommon08);
					this.playerCtrl.ItemFukidashi(this.itemCommon08);
					break;
				case 9:
					this.itemBase.ItemPlus(this.itemCommon09);
					this.playerCtrl.ItemFukidashi(this.itemCommon09);
					break;
				case 10:
					this.itemBase.ItemPlus(this.itemCommon10);
					this.playerCtrl.ItemFukidashi(this.itemCommon10);
					break;
				}
			}
			else if (randomItem < 100 + num)
			{
				int num2 = this.ReturnItemRare();
				if (num2 != 1)
				{
					if (num2 != 2)
					{
						if (num2 == 3)
						{
							this.itemBase.ItemPlus(this.itemRare03);
							this.playerCtrl.ItemFukidashi(this.itemRare03);
						}
					}
					else
					{
						this.itemBase.ItemPlus(this.itemRare02);
						this.playerCtrl.ItemFukidashi(this.itemRare02);
					}
				}
				else
				{
					this.itemBase.ItemPlus(this.itemRare01);
					this.playerCtrl.ItemFukidashi(this.itemRare01);
				}
			}
		}

		// Token: 0x060019A4 RID: 6564 RVA: 0x0014214C File Offset: 0x0014034C
		public int GetRandom()
		{
			float f = this.playerStatus.LCK / 3f;
			float f2 = Mathf.Round(f);
			int num = Mathf.RoundToInt(f2);
			if (num < 1)
			{
				num = 1;
			}
			return UnityEngine.Random.Range(0, 100 + num);
		}

		// Token: 0x060019A5 RID: 6565 RVA: 0x0014218C File Offset: 0x0014038C
		public int ReturnItemCommon()
		{
			return UnityEngine.Random.Range(1, 10);
		}

		// Token: 0x060019A6 RID: 6566 RVA: 0x00142196 File Offset: 0x00140396
		public int ReturnItemRare()
		{
			return UnityEngine.Random.Range(1, 3);
		}

		// Token: 0x060019A7 RID: 6567 RVA: 0x001421A0 File Offset: 0x001403A0
		public int GetRandomItem()
		{
			float f = this.playerStatus.LCK / 5f;
			float f2 = Mathf.Round(f);
			int num = Mathf.RoundToInt(f2);
			if (num < 1)
			{
				num = 1;
			}
			return UnityEngine.Random.Range(0, 100 + num);
		}

		// Token: 0x060019A8 RID: 6568 RVA: 0x001421E0 File Offset: 0x001403E0
		[PunRPC]
		private void ReciveOpenChest()
		{
			this.animator.SetBool("Open", true);
			base.Invoke("OpenChest", 1.5f);
		}

		// Token: 0x060019A9 RID: 6569 RVA: 0x00142203 File Offset: 0x00140403
		[PunRPC]
		private void AnimationSetBoolTrue(string animationHash)
		{
			this.animator.SetBool(animationHash, true);
		}

		// Token: 0x0400255E RID: 9566
		public static readonly int ANISTS_Open = Animator.StringToHash("Base Layer.Chest_Normal_Open");

		// Token: 0x0400255F RID: 9567
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Chest_Normal_Idle");

		// Token: 0x04002560 RID: 9568
		[NonSerialized]
		public Animator animator;

		// Token: 0x04002561 RID: 9569
		public bool canOpen;

		// Token: 0x04002562 RID: 9570
		public bool Opened;

		// Token: 0x04002563 RID: 9571
		public bool canPopMimic;

		// Token: 0x04002564 RID: 9572
		public PlayerStatus playerStatus;

		// Token: 0x04002565 RID: 9573
		public PlayerController playerCtrl;

		// Token: 0x04002566 RID: 9574
		public NetworkID networkID;

		// Token: 0x04002567 RID: 9575
		public bool rt;

		// Token: 0x04002568 RID: 9576
		public bool rtCheck;

		// Token: 0x04002569 RID: 9577
		public bool rt2;

		// Token: 0x0400256A RID: 9578
		public bool rtCheck2;

		// Token: 0x0400256B RID: 9579
		public bool lt;

		// Token: 0x0400256C RID: 9580
		public bool ltCheck;

		// Token: 0x0400256D RID: 9581
		public bool lt2;

		// Token: 0x0400256E RID: 9582
		public bool ltCheck2;

		// Token: 0x0400256F RID: 9583
		public string itemCommon01;

		// Token: 0x04002570 RID: 9584
		public string itemCommon02;

		// Token: 0x04002571 RID: 9585
		public string itemCommon03;

		// Token: 0x04002572 RID: 9586
		public string itemCommon04;

		// Token: 0x04002573 RID: 9587
		public string itemCommon05;

		// Token: 0x04002574 RID: 9588
		public string itemCommon06;

		// Token: 0x04002575 RID: 9589
		public string itemCommon07;

		// Token: 0x04002576 RID: 9590
		public string itemCommon08;

		// Token: 0x04002577 RID: 9591
		public string itemCommon09;

		// Token: 0x04002578 RID: 9592
		public string itemCommon10;

		// Token: 0x04002579 RID: 9593
		public string itemRare01;

		// Token: 0x0400257A RID: 9594
		public string itemRare02;

		// Token: 0x0400257B RID: 9595
		public string itemRare03;

		// Token: 0x0400257C RID: 9596
		private PhotonView myPV;

		// Token: 0x0400257D RID: 9597
		private SpriteRenderer sprite;

		// Token: 0x0400257E RID: 9598
		private ItemBase itemBase;

		// Token: 0x0400257F RID: 9599
		private PlayerMain playerMain;
	}
}
