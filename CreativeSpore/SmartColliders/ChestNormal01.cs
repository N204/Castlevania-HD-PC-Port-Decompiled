using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000328 RID: 808
	public class ChestNormal01 : MonoBehaviour
	{
		// Token: 0x060019AC RID: 6572 RVA: 0x00142232 File Offset: 0x00140432
		private void Awake()
		{
			this.myPV = base.GetComponent<PhotonView>();
			this.sprite = base.transform.Find("Sprite").GetComponent<SpriteRenderer>();
			this.itemBase = GameObject.Find("ItemBase").GetComponent<ItemBase>();
		}

		// Token: 0x060019AD RID: 6573 RVA: 0x00142270 File Offset: 0x00140470
		private void Start()
		{
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x060019AE RID: 6574 RVA: 0x0014227E File Offset: 0x0014047E
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "PlayerBody" && other.transform.parent.GetComponent<PhotonView>().isMine)
			{
				this.canOpen = true;
			}
		}

		// Token: 0x060019AF RID: 6575 RVA: 0x0014227E File Offset: 0x0014047E
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "PlayerBody" && other.transform.parent.GetComponent<PhotonView>().isMine)
			{
				this.canOpen = true;
			}
		}

		// Token: 0x060019B0 RID: 6576 RVA: 0x001422B6 File Offset: 0x001404B6
		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.tag == "PlayerBody" && other.transform.parent.GetComponent<PhotonView>().isMine)
			{
				this.canOpen = false;
			}
		}

		// Token: 0x060019B1 RID: 6577 RVA: 0x001422F0 File Offset: 0x001404F0
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
			if (this.ownPlayer == null)
			{
				this.ownPlayer = GameObject.Find("Player" + this.networkID.yourNetID);
			}
			if (this.playerCtrl == null)
			{
				this.playerCtrl = this.ownPlayer.GetComponent<PlayerController>();
			}
			if (currentAnimatorStateInfo.fullPathHash == ChestNormal01.ANISTS_Open)
			{
				this.Opened = true;
			}
			else if (currentAnimatorStateInfo.fullPathHash == ChestNormal01.ANISTS_Idle)
			{
				this.Opened = false;
			}
			if (this.canOpen && !this.Opened && Input.GetButtonDown("Decide"))
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
				if (randomItem < 35)
				{
					base.Invoke("InstantMimic", 1.5f);
				}
				else if (randomItem < 100 + num)
				{
					this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
					base.Invoke("OpenChest", 1.5f);
				}
			}
		}

		// Token: 0x060019B2 RID: 6578 RVA: 0x001424A6 File Offset: 0x001406A6
		public void InstantMimic()
		{
			this.sprite.enabled = false;
			PhotonNetwork.Instantiate("Enemy_Mimic", base.transform.position, Quaternion.identity, 0);
		}

		// Token: 0x060019B3 RID: 6579 RVA: 0x001424D0 File Offset: 0x001406D0
		public void OpenChest()
		{
			float f = this.playerStatus.LCK / 5f;
			float f2 = Mathf.Round(f);
			int num = Mathf.RoundToInt(f2);
			if (num < 1)
			{
			}
			int randomItem = this.GetRandomItem();
			Debug.Log(randomItem);
		}

		// Token: 0x060019B4 RID: 6580 RVA: 0x00142518 File Offset: 0x00140718
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

		// Token: 0x060019B5 RID: 6581 RVA: 0x00142558 File Offset: 0x00140758
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

		// Token: 0x060019B6 RID: 6582 RVA: 0x00142598 File Offset: 0x00140798
		[PunRPC]
		private void ReciveOpenChest()
		{
			this.animator.SetBool("Open", true);
			base.Invoke("OpenChest", 1.5f);
		}

		// Token: 0x04002580 RID: 9600
		public static readonly int ANISTS_Open = Animator.StringToHash("Base Layer.Chest_Normal_Open");

		// Token: 0x04002581 RID: 9601
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Chest_Normal_Idle");

		// Token: 0x04002582 RID: 9602
		[NonSerialized]
		public Animator animator;

		// Token: 0x04002583 RID: 9603
		public bool canOpen;

		// Token: 0x04002584 RID: 9604
		public bool Opened;

		// Token: 0x04002585 RID: 9605
		public PlayerStatus playerStatus;

		// Token: 0x04002586 RID: 9606
		public PlayerController playerCtrl;

		// Token: 0x04002587 RID: 9607
		public GameObject ownPlayer;

		// Token: 0x04002588 RID: 9608
		public NetworkID networkID;

		// Token: 0x04002589 RID: 9609
		private PhotonView myPV;

		// Token: 0x0400258A RID: 9610
		private SpriteRenderer sprite;

		// Token: 0x0400258B RID: 9611
		private ItemBase itemBase;
	}
}
