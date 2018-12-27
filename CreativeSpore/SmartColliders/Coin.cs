using System;
using Photon;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000338 RID: 824
	public class Coin : Photon.MonoBehaviour
	{
		// Token: 0x06001A33 RID: 6707 RVA: 0x00161C7C File Offset: 0x0015FE7C
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06001A34 RID: 6708 RVA: 0x00161CA0 File Offset: 0x0015FEA0
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent" && !this.check)
			{
				this.targetPV = other.transform.parent.GetComponent<PhotonView>();
				if (this.targetPV.isMine)
				{
					if (this.targetPV.GetComponent<PlayerController>() != null)
					{
						this.playerCtrl = other.transform.parent.GetComponent<PlayerController>();
						this.pSE = this.playerCtrl.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num = this.moneyPlusValue;
						if (num != 1)
						{
							if (num != 10)
							{
								if (num != 100)
								{
									if (num == 500)
									{
										this.playerCtrl.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Shanoa>() != null)
					{
						this.playerCtrl2 = other.transform.parent.GetComponent<PlayerController_Shanoa>();
						this.pSE = this.playerCtrl2.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num2 = this.moneyPlusValue;
						if (num2 != 1)
						{
							if (num2 != 10)
							{
								if (num2 != 100)
								{
									if (num2 == 500)
									{
										this.playerCtrl2.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl2.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl2.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl2.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Jonathan>() != null)
					{
						this.playerCtrl3 = other.transform.parent.GetComponent<PlayerController_Jonathan>();
						this.pSE = this.playerCtrl3.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num3 = this.moneyPlusValue;
						if (num3 != 1)
						{
							if (num3 != 10)
							{
								if (num3 != 100)
								{
									if (num3 == 500)
									{
										this.playerCtrl3.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl3.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl3.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl3.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Charotte>() != null)
					{
						this.playerCtrl4 = other.transform.parent.GetComponent<PlayerController_Charotte>();
						this.pSE = this.playerCtrl4.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num4 = this.moneyPlusValue;
						if (num4 != 1)
						{
							if (num4 != 10)
							{
								if (num4 != 100)
								{
									if (num4 == 500)
									{
										this.playerCtrl4.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl4.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl4.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl4.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Albus>() != null)
					{
						this.playerCtrl5 = other.transform.parent.GetComponent<PlayerController_Albus>();
						this.pSE = this.playerCtrl5.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num5 = this.moneyPlusValue;
						if (num5 != 1)
						{
							if (num5 != 10)
							{
								if (num5 != 100)
								{
									if (num5 == 500)
									{
										this.playerCtrl5.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl5.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl5.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl5.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Soma>() != null)
					{
						this.playerCtrl6 = other.transform.parent.GetComponent<PlayerController_Soma>();
						this.pSE = this.playerCtrl6.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num6 = this.moneyPlusValue;
						if (num6 != 1)
						{
							if (num6 != 10)
							{
								if (num6 != 100)
								{
									if (num6 == 500)
									{
										this.playerCtrl6.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl6.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl6.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl6.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Alucard>() != null)
					{
						this.playerCtrl7 = other.transform.parent.GetComponent<PlayerController_Alucard>();
						this.pSE = this.playerCtrl7.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num7 = this.moneyPlusValue;
						if (num7 != 1)
						{
							if (num7 != 10)
							{
								if (num7 != 100)
								{
									if (num7 == 500)
									{
										this.playerCtrl7.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl7.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl7.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl7.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Julius>() != null)
					{
						this.playerCtrl8 = other.transform.parent.GetComponent<PlayerController_Julius>();
						this.pSE = this.playerCtrl8.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num8 = this.moneyPlusValue;
						if (num8 != 1)
						{
							if (num8 != 10)
							{
								if (num8 != 100)
								{
									if (num8 == 500)
									{
										this.playerCtrl8.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl8.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl8.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl8.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Yoko>() != null)
					{
						this.playerCtrl9 = other.transform.parent.GetComponent<PlayerController_Yoko>();
						this.pSE = this.playerCtrl9.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num9 = this.moneyPlusValue;
						if (num9 != 1)
						{
							if (num9 != 10)
							{
								if (num9 != 100)
								{
									if (num9 == 500)
									{
										this.playerCtrl9.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl9.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl9.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl9.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Maria>() != null)
					{
						this.playerCtrl10 = other.transform.parent.GetComponent<PlayerController_Maria>();
						this.pSE = this.playerCtrl10.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num10 = this.moneyPlusValue;
						if (num10 != 1)
						{
							if (num10 != 10)
							{
								if (num10 != 100)
								{
									if (num10 == 500)
									{
										this.playerCtrl10.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl10.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl10.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl10.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Simon>() != null)
					{
						this.playerCtrl11 = other.transform.parent.GetComponent<PlayerController_Simon>();
						this.pSE = this.playerCtrl11.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num11 = this.moneyPlusValue;
						if (num11 != 1)
						{
							if (num11 != 10)
							{
								if (num11 != 100)
								{
									if (num11 == 500)
									{
										this.playerCtrl11.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl11.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl11.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl11.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Fuma>() != null)
					{
						this.playerCtrl12 = other.transform.parent.GetComponent<PlayerController_Fuma>();
						this.pSE = this.playerCtrl12.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num12 = this.moneyPlusValue;
						if (num12 != 1)
						{
							if (num12 != 10)
							{
								if (num12 != 100)
								{
									if (num12 == 500)
									{
										this.playerCtrl12.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl12.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl12.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl12.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Add1>() != null)
					{
						this.playerCtrl13 = other.transform.parent.GetComponent<PlayerController_Add1>();
						this.pSE = this.playerCtrl13.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num13 = this.moneyPlusValue;
						if (num13 != 1)
						{
							if (num13 != 10)
							{
								if (num13 != 100)
								{
									if (num13 == 500)
									{
										this.playerCtrl13.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl13.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl13.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl13.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Add2>() != null)
					{
						this.playerCtrl14 = other.transform.parent.GetComponent<PlayerController_Add2>();
						this.pSE = this.playerCtrl14.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num14 = this.moneyPlusValue;
						if (num14 != 1)
						{
							if (num14 != 10)
							{
								if (num14 != 100)
								{
									if (num14 == 500)
									{
										this.playerCtrl14.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl14.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl14.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl14.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Add3>() != null)
					{
						this.playerCtrl15 = other.transform.parent.GetComponent<PlayerController_Add3>();
						this.pSE = this.playerCtrl15.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num15 = this.moneyPlusValue;
						if (num15 != 1)
						{
							if (num15 != 10)
							{
								if (num15 != 100)
								{
									if (num15 == 500)
									{
										this.playerCtrl15.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl15.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl15.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl15.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Add4>() != null)
					{
						this.playerCtrl16 = other.transform.parent.GetComponent<PlayerController_Add4>();
						this.pSE = this.playerCtrl16.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num16 = this.moneyPlusValue;
						if (num16 != 1)
						{
							if (num16 != 10)
							{
								if (num16 != 100)
								{
									if (num16 == 500)
									{
										this.playerCtrl16.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl16.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl16.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl16.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Add5>() != null)
					{
						this.playerCtrl17 = other.transform.parent.GetComponent<PlayerController_Add5>();
						this.pSE = this.playerCtrl17.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num17 = this.moneyPlusValue;
						if (num17 != 1)
						{
							if (num17 != 10)
							{
								if (num17 != 100)
								{
									if (num17 == 500)
									{
										this.playerCtrl17.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl17.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl17.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl17.ItemFukidashi("1G");
						}
					}
					this.pSE.SoundEffectItemCommon(0);
					this.playerStatus.money += this.moneyPlusValue;
					this.GameObjectFalse();
					this.check = true;
				}
			}
		}

		// Token: 0x06001A35 RID: 6709 RVA: 0x00162B64 File Offset: 0x00160D64
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent" && !this.check)
			{
				this.targetPV = other.transform.parent.GetComponent<PhotonView>();
				if (this.targetPV.isMine)
				{
					if (this.targetPV.GetComponent<PlayerController>() != null)
					{
						this.playerCtrl = other.transform.parent.GetComponent<PlayerController>();
						this.pSE = this.playerCtrl.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num = this.moneyPlusValue;
						if (num != 1)
						{
							if (num != 10)
							{
								if (num != 100)
								{
									if (num == 500)
									{
										this.playerCtrl.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Shanoa>() != null)
					{
						this.playerCtrl2 = other.transform.parent.GetComponent<PlayerController_Shanoa>();
						this.pSE = this.playerCtrl2.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num2 = this.moneyPlusValue;
						if (num2 != 1)
						{
							if (num2 != 10)
							{
								if (num2 != 100)
								{
									if (num2 == 500)
									{
										this.playerCtrl2.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl2.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl2.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl2.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Jonathan>() != null)
					{
						this.playerCtrl3 = other.transform.parent.GetComponent<PlayerController_Jonathan>();
						this.pSE = this.playerCtrl3.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num3 = this.moneyPlusValue;
						if (num3 != 1)
						{
							if (num3 != 10)
							{
								if (num3 != 100)
								{
									if (num3 == 500)
									{
										this.playerCtrl3.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl3.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl3.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl3.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Charotte>() != null)
					{
						this.playerCtrl4 = other.transform.parent.GetComponent<PlayerController_Charotte>();
						this.pSE = this.playerCtrl4.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num4 = this.moneyPlusValue;
						if (num4 != 1)
						{
							if (num4 != 10)
							{
								if (num4 != 100)
								{
									if (num4 == 500)
									{
										this.playerCtrl4.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl4.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl4.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl4.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Albus>() != null)
					{
						this.playerCtrl5 = other.transform.parent.GetComponent<PlayerController_Albus>();
						this.pSE = this.playerCtrl5.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num5 = this.moneyPlusValue;
						if (num5 != 1)
						{
							if (num5 != 10)
							{
								if (num5 != 100)
								{
									if (num5 == 500)
									{
										this.playerCtrl5.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl5.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl5.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl5.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Soma>() != null)
					{
						this.playerCtrl6 = other.transform.parent.GetComponent<PlayerController_Soma>();
						this.pSE = this.playerCtrl6.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num6 = this.moneyPlusValue;
						if (num6 != 1)
						{
							if (num6 != 10)
							{
								if (num6 != 100)
								{
									if (num6 == 500)
									{
										this.playerCtrl6.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl6.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl6.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl6.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Alucard>() != null)
					{
						this.playerCtrl7 = other.transform.parent.GetComponent<PlayerController_Alucard>();
						this.pSE = this.playerCtrl7.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num7 = this.moneyPlusValue;
						if (num7 != 1)
						{
							if (num7 != 10)
							{
								if (num7 != 100)
								{
									if (num7 == 500)
									{
										this.playerCtrl7.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl7.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl7.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl7.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Julius>() != null)
					{
						this.playerCtrl8 = other.transform.parent.GetComponent<PlayerController_Julius>();
						this.pSE = this.playerCtrl8.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num8 = this.moneyPlusValue;
						if (num8 != 1)
						{
							if (num8 != 10)
							{
								if (num8 != 100)
								{
									if (num8 == 500)
									{
										this.playerCtrl8.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl8.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl8.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl8.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Yoko>() != null)
					{
						this.playerCtrl9 = other.transform.parent.GetComponent<PlayerController_Yoko>();
						this.pSE = this.playerCtrl9.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num9 = this.moneyPlusValue;
						if (num9 != 1)
						{
							if (num9 != 10)
							{
								if (num9 != 100)
								{
									if (num9 == 500)
									{
										this.playerCtrl9.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl9.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl9.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl9.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Maria>() != null)
					{
						this.playerCtrl10 = other.transform.parent.GetComponent<PlayerController_Maria>();
						this.pSE = this.playerCtrl10.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num10 = this.moneyPlusValue;
						if (num10 != 1)
						{
							if (num10 != 10)
							{
								if (num10 != 100)
								{
									if (num10 == 500)
									{
										this.playerCtrl10.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl10.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl10.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl10.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Simon>() != null)
					{
						this.playerCtrl11 = other.transform.parent.GetComponent<PlayerController_Simon>();
						this.pSE = this.playerCtrl11.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num11 = this.moneyPlusValue;
						if (num11 != 1)
						{
							if (num11 != 10)
							{
								if (num11 != 100)
								{
									if (num11 == 500)
									{
										this.playerCtrl11.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl11.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl11.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl11.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Fuma>() != null)
					{
						this.playerCtrl12 = other.transform.parent.GetComponent<PlayerController_Fuma>();
						this.pSE = this.playerCtrl12.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num12 = this.moneyPlusValue;
						if (num12 != 1)
						{
							if (num12 != 10)
							{
								if (num12 != 100)
								{
									if (num12 == 500)
									{
										this.playerCtrl12.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl12.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl12.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl12.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Add1>() != null)
					{
						this.playerCtrl13 = other.transform.parent.GetComponent<PlayerController_Add1>();
						this.pSE = this.playerCtrl13.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num13 = this.moneyPlusValue;
						if (num13 != 1)
						{
							if (num13 != 10)
							{
								if (num13 != 100)
								{
									if (num13 == 500)
									{
										this.playerCtrl13.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl13.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl13.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl13.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Add2>() != null)
					{
						this.playerCtrl14 = other.transform.parent.GetComponent<PlayerController_Add2>();
						this.pSE = this.playerCtrl14.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num14 = this.moneyPlusValue;
						if (num14 != 1)
						{
							if (num14 != 10)
							{
								if (num14 != 100)
								{
									if (num14 == 500)
									{
										this.playerCtrl14.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl14.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl14.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl14.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Add3>() != null)
					{
						this.playerCtrl15 = other.transform.parent.GetComponent<PlayerController_Add3>();
						this.pSE = this.playerCtrl15.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num15 = this.moneyPlusValue;
						if (num15 != 1)
						{
							if (num15 != 10)
							{
								if (num15 != 100)
								{
									if (num15 == 500)
									{
										this.playerCtrl15.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl15.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl15.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl15.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Add4>() != null)
					{
						this.playerCtrl16 = other.transform.parent.GetComponent<PlayerController_Add4>();
						this.pSE = this.playerCtrl16.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num16 = this.moneyPlusValue;
						if (num16 != 1)
						{
							if (num16 != 10)
							{
								if (num16 != 100)
								{
									if (num16 == 500)
									{
										this.playerCtrl16.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl16.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl16.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl16.ItemFukidashi("1G");
						}
					}
					else if (this.targetPV.GetComponent<PlayerController_Add5>() != null)
					{
						this.playerCtrl17 = other.transform.parent.GetComponent<PlayerController_Add5>();
						this.pSE = this.playerCtrl17.transform.Find("SoundEffect_2").GetComponent<PlayerSoundEffect>();
						int num17 = this.moneyPlusValue;
						if (num17 != 1)
						{
							if (num17 != 10)
							{
								if (num17 != 100)
								{
									if (num17 == 500)
									{
										this.playerCtrl17.ItemFukidashi("500G");
									}
								}
								else
								{
									this.playerCtrl17.ItemFukidashi("100G");
								}
							}
							else
							{
								this.playerCtrl17.ItemFukidashi("10G");
							}
						}
						else
						{
							this.playerCtrl17.ItemFukidashi("1G");
						}
					}
					this.pSE.SoundEffectItemCommon(0);
					this.playerStatus.money += this.moneyPlusValue;
					this.GameObjectFalse();
					this.check = true;
				}
			}
		}

		// Token: 0x06001A36 RID: 6710 RVA: 0x00163A28 File Offset: 0x00161C28
		private void Update()
		{
			if (base.GetComponent<Rigidbody2D>().velocity.y < -5f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, -5f);
			}
			if (this.playerStatus == null)
			{
				this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			}
			if (!this.check)
			{
				this.timer += Time.deltaTime;
				if (this.timer >= 10f)
				{
					this.GameObjectFalse();
					this.check = true;
				}
			}
		}

		// Token: 0x06001A37 RID: 6711 RVA: 0x00163ADC File Offset: 0x00161CDC
		public void Action()
		{
			this.timer = 0f;
			this.check = false;
			this.animator.ResetTrigger("Bronze");
			this.animator.ResetTrigger("Silver");
			this.animator.ResetTrigger("Gold");
			this.animator.Play("CoinBlue_Idle");
			int num = this.moneyPlusValue;
			if (num != 10)
			{
				if (num != 100)
				{
					if (num == 500)
					{
						this.animator.SetTrigger("Gold");
					}
				}
				else
				{
					this.animator.SetTrigger("Silver");
				}
			}
			else
			{
				this.animator.SetTrigger("Bronze");
			}
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x00163BA1 File Offset: 0x00161DA1
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x040027B8 RID: 10168
		public int moneyPlusValue;

		// Token: 0x040027B9 RID: 10169
		public bool check;

		// Token: 0x040027BA RID: 10170
		public float timer;

		// Token: 0x040027BB RID: 10171
		private PhotonView targetPV;

		// Token: 0x040027BC RID: 10172
		private PlayerStatus playerStatus;

		// Token: 0x040027BD RID: 10173
		private Animator animator;

		// Token: 0x040027BE RID: 10174
		private PlayerController playerCtrl;

		// Token: 0x040027BF RID: 10175
		private PlayerController_Shanoa playerCtrl2;

		// Token: 0x040027C0 RID: 10176
		private PlayerController_Jonathan playerCtrl3;

		// Token: 0x040027C1 RID: 10177
		private PlayerController_Charotte playerCtrl4;

		// Token: 0x040027C2 RID: 10178
		private PlayerController_Albus playerCtrl5;

		// Token: 0x040027C3 RID: 10179
		private PlayerController_Soma playerCtrl6;

		// Token: 0x040027C4 RID: 10180
		private PlayerController_Alucard playerCtrl7;

		// Token: 0x040027C5 RID: 10181
		private PlayerController_Julius playerCtrl8;

		// Token: 0x040027C6 RID: 10182
		private PlayerController_Yoko playerCtrl9;

		// Token: 0x040027C7 RID: 10183
		private PlayerController_Maria playerCtrl10;

		// Token: 0x040027C8 RID: 10184
		private PlayerController_Simon playerCtrl11;

		// Token: 0x040027C9 RID: 10185
		private PlayerController_Fuma playerCtrl12;

		// Token: 0x040027CA RID: 10186
		private PlayerController_Add1 playerCtrl13;

		// Token: 0x040027CB RID: 10187
		private PlayerController_Add2 playerCtrl14;

		// Token: 0x040027CC RID: 10188
		private PlayerController_Add3 playerCtrl15;

		// Token: 0x040027CD RID: 10189
		private PlayerController_Add4 playerCtrl16;

		// Token: 0x040027CE RID: 10190
		private PlayerController_Add5 playerCtrl17;

		// Token: 0x040027CF RID: 10191
		private PlayerSoundEffect pSE;

		// Token: 0x040027D0 RID: 10192
		public InstantiateManager instantiateManager;
	}
}
