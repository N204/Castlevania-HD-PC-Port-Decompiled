using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000337 RID: 823
	public class CandleNew : MonoBehaviour
	{
		// Token: 0x06001A2C RID: 6700 RVA: 0x0015DE28 File Offset: 0x0015C028
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.playerSpawn = GameObject.Find("StageNetwork").GetComponent<PlayerSpwan>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
		}

		// Token: 0x06001A2D RID: 6701 RVA: 0x0015DE80 File Offset: 0x0015C080
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper")
			{
				if (this.breakSprite != null)
				{
					if (other.transform.position.x > base.transform.position.x)
					{
						foreach (Sprite sprite in this.breakSprite)
						{
							this.instantiateManager.BreakStone(UnityEngine.Random.Range(this.instantPosLeft.transform.position.x, this.instantPosRight.transform.position.x), UnityEngine.Random.Range(this.instantPosDown.transform.position.y, this.instantPosUp.transform.position.y), 3, this.size, sprite, 2);
						}
					}
					else if (other.transform.position.x < base.transform.position.x)
					{
						foreach (Sprite sprite2 in this.breakSprite)
						{
							this.instantiateManager.BreakStone(UnityEngine.Random.Range(this.instantPosLeft.transform.position.x, this.instantPosRight.transform.position.x), UnityEngine.Random.Range(this.instantPosDown.transform.position.y, this.instantPosUp.transform.position.y), 2, this.size, sprite2, 2);
						}
					}
				}
				this.animator.SetTrigger("Destroy");
			}
		}

		// Token: 0x06001A2E RID: 6702 RVA: 0x0015E1FC File Offset: 0x0015C3FC
		private void Update()
		{
			if (this.playerSpawn.startLevel)
			{
				switch (this.playerStatus.charaNumber)
				{
				case 0:
					if (this.playerCtrl == null)
					{
						this.playerCtrl = GameObject.Find("Player" + PhotonNetwork.player.ID).GetComponent<PlayerController>();
					}
					break;
				case 1:
					if (this.playerCtrl2 == null)
					{
						this.playerCtrl2 = GameObject.Find("Player" + PhotonNetwork.player.ID).GetComponent<PlayerController_Shanoa>();
					}
					break;
				case 2:
					if (this.playerCtrl3 == null)
					{
						this.playerCtrl3 = GameObject.Find("Player" + PhotonNetwork.player.ID).GetComponent<PlayerController_Jonathan>();
					}
					break;
				case 3:
					if (this.playerCtrl4 == null)
					{
						this.playerCtrl4 = GameObject.Find("Player" + PhotonNetwork.player.ID).GetComponent<PlayerController_Charotte>();
					}
					break;
				case 4:
					if (this.playerCtrl5 == null)
					{
						this.playerCtrl5 = GameObject.Find("Player" + PhotonNetwork.player.ID).GetComponent<PlayerController_Albus>();
					}
					break;
				case 5:
					if (this.playerCtrl6 == null)
					{
						GameObject gameObject = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl6 = gameObject.GetComponent<PlayerController_Soma>();
					}
					break;
				case 6:
					if (this.playerCtrl7 == null)
					{
						GameObject gameObject2 = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl7 = gameObject2.GetComponent<PlayerController_Alucard>();
					}
					break;
				case 7:
					if (this.playerCtrl13 == null)
					{
						GameObject gameObject3 = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl13 = gameObject3.GetComponent<PlayerController_Add1>();
					}
					break;
				case 8:
					if (this.playerCtrl8 == null)
					{
						GameObject gameObject4 = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl8 = gameObject4.GetComponent<PlayerController_Julius>();
					}
					break;
				case 9:
					if (this.playerCtrl10 == null)
					{
						GameObject gameObject5 = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl10 = gameObject5.GetComponent<PlayerController_Maria>();
					}
					break;
				case 10:
					if (this.playerCtrl9 == null)
					{
						GameObject gameObject6 = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl9 = gameObject6.GetComponent<PlayerController_Yoko>();
					}
					break;
				case 11:
					if (this.playerCtrl11 == null)
					{
						GameObject gameObject7 = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl11 = gameObject7.GetComponent<PlayerController_Simon>();
					}
					break;
				case 12:
					if (this.playerCtrl12 == null)
					{
						GameObject gameObject8 = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl12 = gameObject8.GetComponent<PlayerController_Fuma>();
					}
					break;
				case 13:
					if (this.playerCtrl14 == null)
					{
						GameObject gameObject9 = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl14 = gameObject9.GetComponent<PlayerController_Add2>();
					}
					break;
				case 14:
					if (this.playerCtrl15 == null)
					{
						GameObject gameObject10 = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl15 = gameObject10.GetComponent<PlayerController_Add3>();
					}
					break;
				case 15:
					if (this.playerCtrl16 == null)
					{
						GameObject gameObject11 = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl16 = gameObject11.GetComponent<PlayerController_Add4>();
					}
					break;
				case 16:
					if (this.playerCtrl17 == null)
					{
						GameObject gameObject12 = GameObject.Find("Player" + PhotonNetwork.player.ID);
						this.playerCtrl17 = gameObject12.GetComponent<PlayerController_Add5>();
					}
					break;
				}
				if (this.playerStatus == null)
				{
					this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
				}
			}
		}

		// Token: 0x06001A2F RID: 6703 RVA: 0x0015E6F4 File Offset: 0x0015C8F4
		public void Destroy()
		{
			if (this.playerCtrl != null)
			{
				if (this.playerCtrl.mp < this.playerCtrl.mpMax)
				{
					int num = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl.mp >= this.playerCtrl.mpMax)
				{
					int num2 = this.ReturnRandom();
					float f = this.playerStatus.LCK / 10f;
					float f2 = Mathf.Round(f);
					int num3 = Mathf.RoundToInt(f2);
					if (num3 < 1)
					{
						num3 = 1;
					}
					if (num2 <= num3 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num2 <= num3 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num2 <= num3 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num2 > num3 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl2 != null)
			{
				if (this.playerCtrl2.mp < this.playerCtrl2.mpMax)
				{
					int num4 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num4 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num4 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl2.mp >= this.playerCtrl2.mpMax)
				{
					int num5 = this.ReturnRandom();
					float f3 = this.playerStatus.LCK / 10f;
					float f4 = Mathf.Round(f3);
					int num6 = Mathf.RoundToInt(f4);
					if (num6 < 1)
					{
						num6 = 1;
					}
					if (num5 <= num6 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num5 <= num6 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num5 <= num6 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num5 > num6 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl3 != null)
			{
				if (this.playerCtrl3.mp < this.playerCtrl3.mpMax)
				{
					int num7 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num7 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num7 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl3.mp >= this.playerCtrl3.mpMax)
				{
					int num8 = this.ReturnRandom();
					float f5 = this.playerStatus.LCK / 10f;
					float f6 = Mathf.Round(f5);
					int num9 = Mathf.RoundToInt(f6);
					if (num9 < 1)
					{
						num9 = 1;
					}
					if (num8 <= num9 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num8 <= num9 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num8 <= num9 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num8 > num9 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl4 != null)
			{
				if (this.playerCtrl4.mp < this.playerCtrl4.mpMax)
				{
					int num10 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num10 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num10 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl4.mp >= this.playerCtrl4.mpMax)
				{
					int num11 = this.ReturnRandom();
					float f7 = this.playerStatus.LCK / 10f;
					float f8 = Mathf.Round(f7);
					int num12 = Mathf.RoundToInt(f8);
					if (num12 < 1)
					{
						num12 = 1;
					}
					if (num11 <= num12 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num11 <= num12 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num11 <= num12 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num11 > num12 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl5 != null)
			{
				if (this.playerCtrl5.mp < this.playerCtrl5.mpMax)
				{
					int num13 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num13 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num13 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl5.mp >= this.playerCtrl5.mpMax)
				{
					int num14 = this.ReturnRandom();
					float f9 = this.playerStatus.LCK / 10f;
					float f10 = Mathf.Round(f9);
					int num15 = Mathf.RoundToInt(f10);
					if (num15 < 1)
					{
						num15 = 1;
					}
					if (num14 <= num15 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num14 <= num15 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num14 <= num15 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num14 > num15 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl6 != null)
			{
				if (this.playerCtrl6.mp < this.playerCtrl6.mpMax)
				{
					int num16 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num16 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num16 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl6.mp >= this.playerCtrl6.mpMax)
				{
					int num17 = this.ReturnRandom();
					float f11 = this.playerStatus.LCK / 10f;
					float f12 = Mathf.Round(f11);
					int num18 = Mathf.RoundToInt(f12);
					if (num18 < 1)
					{
						num18 = 1;
					}
					if (num17 <= num18 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num17 <= num18 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num17 <= num18 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num17 > num18 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl7 != null)
			{
				if (this.playerCtrl7.mp < this.playerCtrl7.mpMax)
				{
					int num19 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num19 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num19 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl7.mp >= this.playerCtrl7.mpMax)
				{
					int num20 = this.ReturnRandom();
					float f13 = this.playerStatus.LCK / 10f;
					float f14 = Mathf.Round(f13);
					int num21 = Mathf.RoundToInt(f14);
					if (num21 < 1)
					{
						num21 = 1;
					}
					if (num20 <= num21 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num20 <= num21 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num20 <= num21 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num20 > num21 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl8 != null)
			{
				if (this.playerCtrl8.mp < this.playerCtrl8.mpMax)
				{
					int num22 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num22 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num22 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl8.mp >= this.playerCtrl8.mpMax)
				{
					int num23 = this.ReturnRandom();
					float f15 = this.playerStatus.LCK / 10f;
					float f16 = Mathf.Round(f15);
					int num24 = Mathf.RoundToInt(f16);
					if (num24 < 1)
					{
						num24 = 1;
					}
					if (num23 <= num24 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num23 <= num24 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num23 <= num24 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num23 > num24 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl9 != null)
			{
				if (this.playerCtrl9.mp < this.playerCtrl9.mpMax)
				{
					int num25 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num25 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num25 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl9.mp >= this.playerCtrl9.mpMax)
				{
					int num26 = this.ReturnRandom();
					float f17 = this.playerStatus.LCK / 10f;
					float f18 = Mathf.Round(f17);
					int num27 = Mathf.RoundToInt(f18);
					if (num27 < 1)
					{
						num27 = 1;
					}
					if (num26 <= num27 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num26 <= num27 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num26 <= num27 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num26 > num27 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl10 != null)
			{
				if (this.playerCtrl10.mp < this.playerCtrl10.mpMax)
				{
					int num28 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num28 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num28 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl10.mp >= this.playerCtrl10.mpMax)
				{
					int num29 = this.ReturnRandom();
					float f19 = this.playerStatus.LCK / 10f;
					float f20 = Mathf.Round(f19);
					int num30 = Mathf.RoundToInt(f20);
					if (num30 < 1)
					{
						num30 = 1;
					}
					if (num29 <= num30 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num29 <= num30 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num29 <= num30 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num29 > num30 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl11 != null)
			{
				if (this.playerCtrl11.mp < this.playerCtrl11.mpMax)
				{
					int num31 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num31 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num31 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl11.mp >= this.playerCtrl11.mpMax)
				{
					int num32 = this.ReturnRandom();
					float f21 = this.playerStatus.LCK / 10f;
					float f22 = Mathf.Round(f21);
					int num33 = Mathf.RoundToInt(f22);
					if (num33 < 1)
					{
						num33 = 1;
					}
					if (num32 <= num33 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num32 <= num33 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num32 <= num33 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num32 > num33 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl12 != null)
			{
				if (this.playerCtrl12.mp < this.playerCtrl12.mpMax)
				{
					int num34 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num34 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num34 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl12.mp >= this.playerCtrl12.mpMax)
				{
					int num35 = this.ReturnRandom();
					float f23 = this.playerStatus.LCK / 10f;
					float f24 = Mathf.Round(f23);
					int num36 = Mathf.RoundToInt(f24);
					if (num36 < 1)
					{
						num36 = 1;
					}
					if (num35 <= num36 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num35 <= num36 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num35 <= num36 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num35 > num36 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl13 != null)
			{
				if (this.playerCtrl13.mp < this.playerCtrl13.mpMax)
				{
					int num37 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num37 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num37 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl13.mp >= this.playerCtrl13.mpMax)
				{
					int num38 = this.ReturnRandom();
					float f25 = this.playerStatus.LCK / 10f;
					float f26 = Mathf.Round(f25);
					int num39 = Mathf.RoundToInt(f26);
					if (num39 < 1)
					{
						num39 = 1;
					}
					if (num38 <= num39 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num38 <= num39 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num38 <= num39 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num38 > num39 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl14 != null)
			{
				if (this.playerCtrl14.mp < this.playerCtrl14.mpMax)
				{
					int num40 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num40 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num40 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl14.mp >= this.playerCtrl14.mpMax)
				{
					int num41 = this.ReturnRandom();
					float f27 = this.playerStatus.LCK / 10f;
					float f28 = Mathf.Round(f27);
					int num42 = Mathf.RoundToInt(f28);
					if (num42 < 1)
					{
						num42 = 1;
					}
					if (num41 <= num42 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num41 <= num42 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num41 <= num42 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num41 > num42 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl15 != null)
			{
				if (this.playerCtrl15.mp < this.playerCtrl15.mpMax)
				{
					int num43 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num43 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num43 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl15.mp >= this.playerCtrl15.mpMax)
				{
					int num44 = this.ReturnRandom();
					float f29 = this.playerStatus.LCK / 10f;
					float f30 = Mathf.Round(f29);
					int num45 = Mathf.RoundToInt(f30);
					if (num45 < 1)
					{
						num45 = 1;
					}
					if (num44 <= num45 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num44 <= num45 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num44 <= num45 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num44 > num45 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl16 != null)
			{
				if (this.playerCtrl16.mp < this.playerCtrl16.mpMax)
				{
					int num46 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num46 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num46 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl16.mp >= this.playerCtrl16.mpMax)
				{
					int num47 = this.ReturnRandom();
					float f31 = this.playerStatus.LCK / 10f;
					float f32 = Mathf.Round(f31);
					int num48 = Mathf.RoundToInt(f32);
					if (num48 < 1)
					{
						num48 = 1;
					}
					if (num47 <= num48 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num47 <= num48 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num47 <= num48 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num47 > num48 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
			else if (this.playerCtrl17 != null)
			{
				if (this.playerCtrl17.mp < this.playerCtrl17.mpMax)
				{
					int num49 = this.ReturnRandom();
					if (this.playerStatus.acce1Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if (this.playerStatus.acce2Armor == "ハートのブローチ")
					{
						this.heartNoBuroti += 20;
					}
					if ((float)num49 > this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
					else if ((float)num49 <= this.playerStatus.LCK + (float)this.heartNoBuroti)
					{
						this.instantiateManager.Heart2(base.transform.position.x, base.transform.position.y + this.instanceY);
					}
				}
				else if (this.playerCtrl17.mp >= this.playerCtrl17.mpMax)
				{
					int num50 = this.ReturnRandom();
					float f33 = this.playerStatus.LCK / 10f;
					float f34 = Mathf.Round(f33);
					int num51 = Mathf.RoundToInt(f34);
					if (num51 < 1)
					{
						num51 = 1;
					}
					if (num50 <= num51 * 3 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 500, 0);
					}
					else if (num50 <= num51 * 5 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 100, 0);
					}
					else if (num50 <= num51 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 10, 0);
					}
					else if (num50 > num51 * 10 * this.playerStatus.moneyLCK)
					{
						this.instantiateManager.Coin(base.transform.position.x, base.transform.position.y + this.instanceY, 1, 0);
					}
				}
			}
		}

		// Token: 0x06001A30 RID: 6704 RVA: 0x00161A48 File Offset: 0x0015FC48
		public void Reset()
		{
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
			if (base.gameObject.name == "Candle01")
			{
				this.animator.Play("Candle01_Idle", 0, 0f);
			}
			if (base.gameObject.name == "Candle02")
			{
				this.animator.Play("Candle02_Idle", 0, 0f);
			}
			if (base.gameObject.name == "Candle03")
			{
				this.animator.Play("Candle03_Idle", 0, 0f);
			}
			if (base.gameObject.name == "Candle04")
			{
				this.animator.Play("Candle04_Idle", 0, 0f);
			}
			if (base.gameObject.name == "Candle05")
			{
				this.animator.Play("Candle05_Idle", 0, 0f);
			}
			if (base.gameObject.name == "Stage05Clock")
			{
				this.animator.Play("  Stage05Clock_Idle", 0, 0f);
			}
			if (base.gameObject.name == "Stage06")
			{
				this.animator.Play("  Stage06_Idle", 0, 0f);
			}
			if (base.gameObject.name == "Stage07")
			{
				this.animator.Play("  Stage07_Idle", 0, 0f);
			}
			if (base.gameObject.name == "Stage08")
			{
				this.animator.Play("  Stage08_Idle", 0, 0f);
			}
		}

		// Token: 0x06001A31 RID: 6705 RVA: 0x00097E10 File Offset: 0x00096010
		public int ReturnRandom()
		{
			return UnityEngine.Random.Range(0, 100);
		}

		// Token: 0x0400279A RID: 10138
		private PlayerStatus playerStatus;

		// Token: 0x0400279B RID: 10139
		private PlayerController playerCtrl;

		// Token: 0x0400279C RID: 10140
		private PlayerController_Shanoa playerCtrl2;

		// Token: 0x0400279D RID: 10141
		private PlayerController_Jonathan playerCtrl3;

		// Token: 0x0400279E RID: 10142
		private PlayerController_Charotte playerCtrl4;

		// Token: 0x0400279F RID: 10143
		private PlayerController_Albus playerCtrl5;

		// Token: 0x040027A0 RID: 10144
		private PlayerController_Soma playerCtrl6;

		// Token: 0x040027A1 RID: 10145
		private PlayerController_Alucard playerCtrl7;

		// Token: 0x040027A2 RID: 10146
		private PlayerController_Julius playerCtrl8;

		// Token: 0x040027A3 RID: 10147
		private PlayerController_Yoko playerCtrl9;

		// Token: 0x040027A4 RID: 10148
		private PlayerController_Maria playerCtrl10;

		// Token: 0x040027A5 RID: 10149
		private PlayerController_Simon playerCtrl11;

		// Token: 0x040027A6 RID: 10150
		private PlayerController_Fuma playerCtrl12;

		// Token: 0x040027A7 RID: 10151
		private PlayerController_Add1 playerCtrl13;

		// Token: 0x040027A8 RID: 10152
		private PlayerController_Add2 playerCtrl14;

		// Token: 0x040027A9 RID: 10153
		private PlayerController_Add3 playerCtrl15;

		// Token: 0x040027AA RID: 10154
		private PlayerController_Add4 playerCtrl16;

		// Token: 0x040027AB RID: 10155
		private PlayerController_Add5 playerCtrl17;

		// Token: 0x040027AC RID: 10156
		private Animator animator;

		// Token: 0x040027AD RID: 10157
		public int heartNoBuroti;

		// Token: 0x040027AE RID: 10158
		public float instanceY;

		// Token: 0x040027AF RID: 10159
		private PlayerSpwan playerSpawn;

		// Token: 0x040027B0 RID: 10160
		private InstantiateManager instantiateManager;

		// Token: 0x040027B1 RID: 10161
		private Coin coin;

		// Token: 0x040027B2 RID: 10162
		public Sprite[] breakSprite;

		// Token: 0x040027B3 RID: 10163
		public float size = 2f;

		// Token: 0x040027B4 RID: 10164
		public GameObject instantPosUp;

		// Token: 0x040027B5 RID: 10165
		public GameObject instantPosDown;

		// Token: 0x040027B6 RID: 10166
		public GameObject instantPosRight;

		// Token: 0x040027B7 RID: 10167
		public GameObject instantPosLeft;
	}
}
