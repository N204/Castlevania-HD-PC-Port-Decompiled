using System;
using System.Collections;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000323 RID: 803
	public class ChestBlue : MonoBehaviour
	{
		// Token: 0x06001981 RID: 6529 RVA: 0x00137647 File Offset: 0x00135847
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.myPV = base.GetComponent<PhotonView>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06001982 RID: 6530 RVA: 0x00137676 File Offset: 0x00135876
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent" && other.transform.parent.GetComponent<PhotonView>().isMine)
			{
				this.canOpen = true;
			}
		}

		// Token: 0x06001983 RID: 6531 RVA: 0x00137676 File Offset: 0x00135876
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent" && other.transform.parent.GetComponent<PhotonView>().isMine)
			{
				this.canOpen = true;
			}
		}

		// Token: 0x06001984 RID: 6532 RVA: 0x001376AE File Offset: 0x001358AE
		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent" && other.transform.parent.GetComponent<PhotonView>().isMine)
			{
				this.canOpen = false;
			}
		}

		// Token: 0x06001985 RID: 6533 RVA: 0x001376E8 File Offset: 0x001358E8
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			switch (this.playerStatus.charaNumber)
			{
			case 0:
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
				break;
			case 1:
				if (this.playerCtrl2 == null)
				{
					GameObject gameObject3 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl2 = gameObject3.GetComponent<PlayerController_Shanoa>();
				}
				if (this.playerMain2 == null)
				{
					GameObject gameObject4 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain2 = gameObject4.GetComponent<PlayerMain_Shanoa>();
				}
				break;
			case 2:
				if (this.playerCtrl3 == null)
				{
					GameObject gameObject5 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl3 = gameObject5.GetComponent<PlayerController_Jonathan>();
				}
				if (this.playerMain3 == null)
				{
					GameObject gameObject6 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain3 = gameObject6.GetComponent<PlayerMain_Jonathan>();
				}
				break;
			case 3:
				if (this.playerCtrl4 == null)
				{
					GameObject gameObject7 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl4 = gameObject7.GetComponent<PlayerController_Charotte>();
				}
				if (this.playerMain4 == null)
				{
					GameObject gameObject8 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain4 = gameObject8.GetComponent<PlayerMain_Charotte>();
				}
				break;
			case 4:
				if (this.playerCtrl5 == null)
				{
					GameObject gameObject9 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl5 = gameObject9.GetComponent<PlayerController_Albus>();
				}
				if (this.playerMain5 == null)
				{
					GameObject gameObject10 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain5 = gameObject10.GetComponent<PlayerMain_Albus>();
				}
				break;
			case 5:
				if (this.playerCtrl6 == null)
				{
					GameObject gameObject11 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl6 = gameObject11.GetComponent<PlayerController_Soma>();
				}
				if (this.playerMain6 == null)
				{
					GameObject gameObject12 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain6 = gameObject12.GetComponent<PlayerMain_Soma>();
				}
				break;
			case 6:
				if (this.playerCtrl7 == null)
				{
					GameObject gameObject13 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl7 = gameObject13.GetComponent<PlayerController_Alucard>();
				}
				if (this.playerMain7 == null)
				{
					GameObject gameObject14 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain7 = gameObject14.GetComponent<PlayerMain_Alucard>();
				}
				break;
			case 7:
				if (this.playerCtrl13 == null)
				{
					GameObject gameObject15 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl13 = gameObject15.GetComponent<PlayerController_Add1>();
				}
				if (this.playerMain13 == null)
				{
					GameObject gameObject16 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain13 = gameObject16.GetComponent<PlayerMain_Add1>();
				}
				break;
			case 8:
				if (this.playerCtrl8 == null)
				{
					GameObject gameObject17 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl8 = gameObject17.GetComponent<PlayerController_Julius>();
				}
				if (this.playerMain8 == null)
				{
					GameObject gameObject18 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain8 = gameObject18.GetComponent<PlayerMain_Julius>();
				}
				break;
			case 9:
				if (this.playerCtrl10 == null)
				{
					GameObject gameObject19 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl10 = gameObject19.GetComponent<PlayerController_Maria>();
				}
				if (this.playerMain10 == null)
				{
					GameObject gameObject20 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain10 = gameObject20.GetComponent<PlayerMain_Maria>();
				}
				break;
			case 10:
				if (this.playerCtrl9 == null)
				{
					GameObject gameObject21 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl9 = gameObject21.GetComponent<PlayerController_Yoko>();
				}
				if (this.playerMain9 == null)
				{
					GameObject gameObject22 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain9 = gameObject22.GetComponent<PlayerMain_Yoko>();
				}
				break;
			case 11:
				if (this.playerCtrl11 == null)
				{
					GameObject gameObject23 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl11 = gameObject23.GetComponent<PlayerController_Simon>();
				}
				if (this.playerMain11 == null)
				{
					GameObject gameObject24 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain11 = gameObject24.GetComponent<PlayerMain_Simon>();
				}
				break;
			case 12:
				if (this.playerCtrl12 == null)
				{
					GameObject gameObject25 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl12 = gameObject25.GetComponent<PlayerController_Fuma>();
				}
				if (this.playerMain12 == null)
				{
					GameObject gameObject26 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain12 = gameObject26.GetComponent<PlayerMain_Fuma>();
				}
				break;
			case 13:
				if (this.playerCtrl14 == null)
				{
					GameObject gameObject27 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl14 = gameObject27.GetComponent<PlayerController_Add2>();
				}
				if (this.playerMain14 == null)
				{
					GameObject gameObject28 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain14 = gameObject28.GetComponent<PlayerMain_Add2>();
				}
				break;
			case 14:
				if (this.playerCtrl15 == null)
				{
					GameObject gameObject29 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl15 = gameObject29.GetComponent<PlayerController_Add3>();
				}
				if (this.playerMain15 == null)
				{
					GameObject gameObject30 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain15 = gameObject30.GetComponent<PlayerMain_Add3>();
				}
				break;
			case 15:
				if (this.playerCtrl16 == null)
				{
					GameObject gameObject31 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl16 = gameObject31.GetComponent<PlayerController_Add4>();
				}
				if (this.playerMain16 == null)
				{
					GameObject gameObject32 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain16 = gameObject32.GetComponent<PlayerMain_Add4>();
				}
				break;
			case 16:
				if (this.playerCtrl17 == null)
				{
					GameObject gameObject33 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerCtrl17 = gameObject33.GetComponent<PlayerController_Add5>();
				}
				if (this.playerMain17 == null)
				{
					GameObject gameObject34 = GameObject.Find("Player" + PhotonNetwork.player.ID);
					this.playerMain17 = gameObject34.GetComponent<PlayerMain_Add5>();
				}
				break;
			}
			if (this.pSE == null)
			{
				GameObject gameObject35 = GameObject.Find("Player" + PhotonNetwork.player.ID);
				this.pSE = gameObject35.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
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
			if (this.canOpen && !this.Opened)
			{
				if (this.playerMain != null)
				{
					switch (this.playerMain.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain2 != null)
				{
					switch (this.playerMain2.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain2.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain3 != null)
				{
					switch (this.playerMain3.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain3.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain4 != null)
				{
					switch (this.playerMain4.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain4.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain5 != null)
				{
					switch (this.playerMain5.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain5.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain6 != null)
				{
					switch (this.playerMain6.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain6.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain7 != null)
				{
					switch (this.playerMain7.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain7.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain8 != null)
				{
					switch (this.playerMain8.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain8.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain9 != null)
				{
					switch (this.playerMain9.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain9.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain10 != null)
				{
					switch (this.playerMain10.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain10.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain11 != null)
				{
					switch (this.playerMain11.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain11.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain12 != null)
				{
					switch (this.playerMain12.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain12.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain13 != null)
				{
					switch (this.playerMain13.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain13.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain14 != null)
				{
					switch (this.playerMain14.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain14.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain15 != null)
				{
					switch (this.playerMain15.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain15.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain16 != null)
				{
					switch (this.playerMain16.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain16.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt2 = true;
						}
						if (!this.ltCheck2 && this.lt2)
						{
							this.lt2 = false;
						}
						break;
					}
				}
				else if (this.playerMain17 != null)
				{
					switch (this.playerMain17.padDecide)
					{
					case 0:
						if (this.ltCheck && !this.lt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck && !this.rt)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
							this.lt = true;
						}
						if (!this.ltCheck && this.lt)
						{
							this.lt = false;
						}
						break;
					}
					switch (this.playerMain17.keyDecide)
					{
					case 0:
						if (this.ltCheck2 && !this.lt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 2:
						if (Input.GetButtonDown("Cancel2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 3:
						if (Input.GetButtonDown("Fire1_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 4:
						if (Input.GetButtonDown("Fire2_2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 5:
						if (Input.GetButtonDown("Back2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 6:
						if (Input.GetButtonDown("RB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 7:
						if (Input.GetButtonDown("LB2"))
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
						}
						break;
					case 8:
						if (this.rtCheck2 && !this.rt2)
						{
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
							base.StartCoroutine(this.OpenChest(1.3f));
							this.animator.SetBool("Open", true);
							this.myPV.RPC("ReciveOpenChest", PhotonTargets.Others, new object[0]);
							this.Opened = true;
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
		}

		// Token: 0x06001986 RID: 6534 RVA: 0x00140D30 File Offset: 0x0013EF30
		public void Reset()
		{
			this.animator.Play("Chest_Blue_Idle", 0, 0f);
			this.canOpen = false;
			this.Opened = false;
			this.playerCtrl = null;
			this.playerCtrl2 = null;
			this.playerCtrl3 = null;
			this.playerCtrl4 = null;
			this.playerCtrl5 = null;
			this.playerCtrl6 = null;
			this.playerCtrl7 = null;
			this.playerCtrl8 = null;
			this.playerCtrl9 = null;
			this.playerCtrl10 = null;
			this.playerCtrl11 = null;
			this.playerCtrl12 = null;
			this.playerCtrl13 = null;
			this.playerCtrl14 = null;
			this.playerCtrl15 = null;
			this.playerCtrl16 = null;
			this.playerCtrl17 = null;
			this.playerMain = null;
			this.playerMain2 = null;
			this.playerMain3 = null;
			this.playerMain4 = null;
			this.playerMain5 = null;
			this.playerMain6 = null;
			this.playerMain7 = null;
			this.playerMain8 = null;
			this.playerMain9 = null;
			this.playerMain10 = null;
			this.playerMain11 = null;
			this.playerMain12 = null;
			this.playerMain13 = null;
			this.playerMain14 = null;
			this.playerMain15 = null;
			this.playerMain16 = null;
			this.playerMain17 = null;
		}

		// Token: 0x06001987 RID: 6535 RVA: 0x00140E50 File Offset: 0x0013F050
		private IEnumerator OpenChest(float delay)
		{
			yield return new WaitForSeconds(delay);
			if (this.playerCtrl != null)
			{
				this.playerCtrl.ItemFukidashi("生命の霊薬");
				this.playerCtrl.GetRevivalMedicine();
			}
			if (this.playerCtrl2 != null)
			{
				this.playerCtrl2.ItemFukidashi("生命の霊薬");
				this.playerCtrl2.GetRevivalMedicine();
			}
			if (this.playerCtrl3 != null)
			{
				this.playerCtrl3.ItemFukidashi("生命の霊薬");
				this.playerCtrl3.GetRevivalMedicine();
			}
			if (this.playerCtrl4 != null)
			{
				this.playerCtrl4.ItemFukidashi("生命の霊薬");
				this.playerCtrl4.GetRevivalMedicine();
			}
			if (this.playerCtrl5 != null)
			{
				this.playerCtrl5.ItemFukidashi("生命の霊薬");
				this.playerCtrl5.GetRevivalMedicine();
			}
			if (this.playerCtrl6 != null)
			{
				this.playerCtrl6.ItemFukidashi("生命の霊薬");
				this.playerCtrl6.GetRevivalMedicine();
			}
			if (this.playerCtrl7 != null)
			{
				this.playerCtrl7.ItemFukidashi("生命の霊薬");
				this.playerCtrl7.GetRevivalMedicine();
			}
			if (this.playerCtrl8 != null)
			{
				this.playerCtrl8.ItemFukidashi("生命の霊薬");
				this.playerCtrl8.GetRevivalMedicine();
			}
			if (this.playerCtrl9 != null)
			{
				this.playerCtrl9.ItemFukidashi("生命の霊薬");
				this.playerCtrl9.GetRevivalMedicine();
			}
			if (this.playerCtrl10 != null)
			{
				this.playerCtrl10.ItemFukidashi("生命の霊薬");
				this.playerCtrl10.GetRevivalMedicine();
			}
			if (this.playerCtrl11 != null)
			{
				this.playerCtrl11.ItemFukidashi("生命の霊薬");
				this.playerCtrl11.GetRevivalMedicine();
			}
			if (this.playerCtrl12 != null)
			{
				this.playerCtrl12.ItemFukidashi("生命の霊薬");
				this.playerCtrl12.GetRevivalMedicine();
			}
			if (this.playerCtrl13 != null)
			{
				this.playerCtrl13.ItemFukidashi("生命の霊薬");
				this.playerCtrl13.GetRevivalMedicine();
			}
			if (this.playerCtrl14 != null)
			{
				this.playerCtrl14.ItemFukidashi("生命の霊薬");
				this.playerCtrl14.GetRevivalMedicine();
			}
			if (this.playerCtrl15 != null)
			{
				this.playerCtrl15.ItemFukidashi("生命の霊薬");
				this.playerCtrl15.GetRevivalMedicine();
			}
			if (this.playerCtrl16 != null)
			{
				this.playerCtrl16.ItemFukidashi("生命の霊薬");
				this.playerCtrl16.GetRevivalMedicine();
			}
			if (this.playerCtrl17 != null)
			{
				this.playerCtrl17.ItemFukidashi("生命の霊薬");
				this.playerCtrl17.GetRevivalMedicine();
			}
			this.pSE.SoundEffectItemCommon(7);
			yield break;
		}

		// Token: 0x06001988 RID: 6536 RVA: 0x00140E72 File Offset: 0x0013F072
		[PunRPC]
		private void ReciveOpenChest()
		{
			this.Opened = true;
			this.animator.SetBool("Open", true);
		}

		// Token: 0x04002518 RID: 9496
		public static readonly int ANISTS_Open = Animator.StringToHash("Base Layer.Chest_Blue_Open");

		// Token: 0x04002519 RID: 9497
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Chest_Blue_Idle");

		// Token: 0x0400251A RID: 9498
		[NonSerialized]
		public Animator animator;

		// Token: 0x0400251B RID: 9499
		public bool canOpen;

		// Token: 0x0400251C RID: 9500
		public bool Opened;

		// Token: 0x0400251D RID: 9501
		private PlayerController playerCtrl;

		// Token: 0x0400251E RID: 9502
		private PlayerController_Shanoa playerCtrl2;

		// Token: 0x0400251F RID: 9503
		private PlayerController_Jonathan playerCtrl3;

		// Token: 0x04002520 RID: 9504
		private PlayerController_Charotte playerCtrl4;

		// Token: 0x04002521 RID: 9505
		private PlayerController_Albus playerCtrl5;

		// Token: 0x04002522 RID: 9506
		private PlayerController_Soma playerCtrl6;

		// Token: 0x04002523 RID: 9507
		private PlayerController_Alucard playerCtrl7;

		// Token: 0x04002524 RID: 9508
		private PlayerController_Julius playerCtrl8;

		// Token: 0x04002525 RID: 9509
		private PlayerController_Yoko playerCtrl9;

		// Token: 0x04002526 RID: 9510
		private PlayerController_Maria playerCtrl10;

		// Token: 0x04002527 RID: 9511
		private PlayerController_Simon playerCtrl11;

		// Token: 0x04002528 RID: 9512
		private PlayerController_Fuma playerCtrl12;

		// Token: 0x04002529 RID: 9513
		private PlayerController_Add1 playerCtrl13;

		// Token: 0x0400252A RID: 9514
		private PlayerController_Add2 playerCtrl14;

		// Token: 0x0400252B RID: 9515
		private PlayerController_Add3 playerCtrl15;

		// Token: 0x0400252C RID: 9516
		private PlayerController_Add4 playerCtrl16;

		// Token: 0x0400252D RID: 9517
		private PlayerController_Add5 playerCtrl17;

		// Token: 0x0400252E RID: 9518
		private PhotonView myPV;

		// Token: 0x0400252F RID: 9519
		private PlayerMain playerMain;

		// Token: 0x04002530 RID: 9520
		private PlayerMain_Shanoa playerMain2;

		// Token: 0x04002531 RID: 9521
		private PlayerMain_Jonathan playerMain3;

		// Token: 0x04002532 RID: 9522
		private PlayerMain_Charotte playerMain4;

		// Token: 0x04002533 RID: 9523
		private PlayerMain_Albus playerMain5;

		// Token: 0x04002534 RID: 9524
		private PlayerMain_Soma playerMain6;

		// Token: 0x04002535 RID: 9525
		private PlayerMain_Alucard playerMain7;

		// Token: 0x04002536 RID: 9526
		private PlayerMain_Julius playerMain8;

		// Token: 0x04002537 RID: 9527
		private PlayerMain_Yoko playerMain9;

		// Token: 0x04002538 RID: 9528
		private PlayerMain_Maria playerMain10;

		// Token: 0x04002539 RID: 9529
		private PlayerMain_Simon playerMain11;

		// Token: 0x0400253A RID: 9530
		private PlayerMain_Fuma playerMain12;

		// Token: 0x0400253B RID: 9531
		private PlayerMain_Add1 playerMain13;

		// Token: 0x0400253C RID: 9532
		private PlayerMain_Add2 playerMain14;

		// Token: 0x0400253D RID: 9533
		private PlayerMain_Add3 playerMain15;

		// Token: 0x0400253E RID: 9534
		private PlayerMain_Add4 playerMain16;

		// Token: 0x0400253F RID: 9535
		private PlayerMain_Add5 playerMain17;

		// Token: 0x04002540 RID: 9536
		private PlayerSoundEffect pSE;

		// Token: 0x04002541 RID: 9537
		private PlayerStatus playerStatus;

		// Token: 0x04002542 RID: 9538
		public bool rt;

		// Token: 0x04002543 RID: 9539
		public bool rtCheck;

		// Token: 0x04002544 RID: 9540
		public bool rt2;

		// Token: 0x04002545 RID: 9541
		public bool rtCheck2;

		// Token: 0x04002546 RID: 9542
		public bool lt;

		// Token: 0x04002547 RID: 9543
		public bool ltCheck;

		// Token: 0x04002548 RID: 9544
		public bool lt2;

		// Token: 0x04002549 RID: 9545
		public bool ltCheck2;
	}
}
