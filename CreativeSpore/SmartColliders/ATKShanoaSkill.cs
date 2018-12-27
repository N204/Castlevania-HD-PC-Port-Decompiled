using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000475 RID: 1141
	public class ATKShanoaSkill : MonoBehaviour
	{
		// Token: 0x06002B34 RID: 11060 RVA: 0x00480788 File Offset: 0x0047E988
		private void Awake()
		{
			if (base.transform.parent.parent.GetComponent<PlayerController_Shanoa>() != null)
			{
				this.playerCtrl_Shanoa = base.transform.parent.parent.GetComponent<PlayerController_Shanoa>();
				this.myPV = base.transform.parent.parent.GetComponent<PhotonView>();
			}
			else if (base.transform.parent.parent.parent.parent.GetComponent<PlayerController_Shanoa>() != null)
			{
				this.playerCtrl_Shanoa = base.transform.parent.parent.parent.parent.GetComponent<PlayerController_Shanoa>();
				this.myPV = base.transform.parent.parent.parent.parent.GetComponent<PhotonView>();
			}
			if (base.GetComponent<BoxCollider2D>() != null)
			{
				this.col2d = base.GetComponent<BoxCollider2D>();
			}
			if (base.GetComponent<CircleCollider2D>() != null)
			{
				this.col2d2 = base.GetComponent<CircleCollider2D>();
			}
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06002B35 RID: 11061 RVA: 0x004808B4 File Offset: 0x0047EAB4
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				this.currentEnemyBody = other.transform.parent.GetComponent<EnemyBody>();
				if (this.hitedATK)
				{
					if (!(this.currentEnemyBody == this.enemyBody))
					{
						this.hitedATK = false;
					}
				}
				if (!this.hitedATK)
				{
					this.enemyBody = other.transform.parent.GetComponent<EnemyBody>();
					Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x = vector.x;
					float y = vector.y;
					if (this.playerCtrl_Shanoa != null)
					{
						switch (this.weaponSwitch)
						{
						case 1:
							if (!this.subATK)
							{
								this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x, y, 3);
							}
							else if (this.subATK)
							{
								this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x, y, 3);
							}
							break;
						case 2:
							if (!this.subATK)
							{
								this.enemyBody.RPCActionDamageHit(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x, y);
							}
							else if (this.subATK)
							{
								this.enemyBody.RPCActionDamageHit(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x, y);
							}
							break;
						case 3:
							if (!this.subATK)
							{
								this.enemyBody.RPCActionDamageConfodere(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x, y);
							}
							else if (this.subATK)
							{
								this.enemyBody.RPCActionDamageConfodere(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x, y);
							}
							break;
						case 4:
							if (!this.subATK)
							{
								this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f, this.playerCtrl_Shanoa.dEX, x, y, 3);
							}
							else if (this.subATK)
							{
								this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f, this.playerCtrl_Shanoa.dEX, x, y, 3);
							}
							break;
						case 5:
							if (!this.subATK)
							{
								this.enemyBody.RPCActionDamageDark(this.playerCtrl_Shanoa.aTK + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x, y);
							}
							else if (this.subATK)
							{
								this.enemyBody.RPCActionDamageDark(this.playerCtrl_Shanoa.aTK_Sub + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x, y);
							}
							break;
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl_Shanoa != null)
						{
							switch (this.weaponSwitch)
							{
							case 1:
							{
								float f = 0f;
								if (!this.subATK)
								{
									f = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num = Mathf.RoundToInt(f);
								if (num < 1)
								{
									num = 1;
								}
								this.playerStatus.damage += num;
								break;
							}
							case 2:
							{
								float f2 = 0f;
								if (!this.subATK)
								{
									f2 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f2 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num2 = Mathf.RoundToInt(f2);
								if (num2 < 1)
								{
									num2 = 1;
								}
								this.playerStatus.damage += num2;
								break;
							}
							case 3:
							{
								float f3 = 0f;
								if (!this.subATK)
								{
									f3 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f3 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num3 = Mathf.RoundToInt(f3);
								if (num3 < 1)
								{
									num3 = 1;
								}
								this.playerStatus.damage += num3;
								break;
							}
							case 4:
							{
								float f4 = 0f;
								if (!this.subATK)
								{
									f4 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f);
								}
								else if (this.subATK)
								{
									f4 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f);
								}
								int num4 = Mathf.RoundToInt(f4);
								if (num4 < 1)
								{
									num4 = 1;
								}
								this.playerStatus.damage += num4;
								break;
							}
							case 5:
							{
								float f5 = 0f;
								if (!this.subATK)
								{
									f5 = Mathf.Round(this.playerCtrl_Shanoa.aTK + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f5 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num5 = Mathf.RoundToInt(f5);
								if (num5 < 1)
								{
									num5 = 1;
								}
								this.playerStatus.damage += num5;
								break;
							}
							}
						}
						if (!this.enemyBody.ownATKHitted)
						{
							this.enemyBody.ownATKHitted = true;
						}
					}
					this.hitedATK = true;
				}
			}
			else if (other.tag == "EnemyBodyAttackSp")
			{
				this.currentEnemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.hitedATK)
				{
					if (!(this.currentEnemyBody == this.enemyBody))
					{
						this.hitedATK = false;
					}
				}
				if (!this.hitedATK)
				{
					this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
					Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x2 = vector2.x;
					float y2 = vector2.y;
					if (this.playerCtrl_Shanoa != null)
					{
						switch (this.weaponSwitch)
						{
						case 1:
							if (!this.subATK)
							{
								this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x2, y2, 3);
							}
							else if (this.subATK)
							{
								this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x2, y2, 3);
							}
							break;
						case 2:
							if (!this.subATK)
							{
								this.enemyBody.RPCActionDamageHit(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x2, y2);
							}
							else if (this.subATK)
							{
								this.enemyBody.RPCActionDamageHit(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x2, y2);
							}
							break;
						case 3:
							if (!this.subATK)
							{
								this.enemyBody.RPCActionDamageConfodere(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x2, y2);
							}
							else if (this.subATK)
							{
								this.enemyBody.RPCActionDamageConfodere(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x2, y2);
							}
							break;
						case 4:
							if (!this.subATK)
							{
								this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f, this.playerCtrl_Shanoa.dEX, x2, y2, 3);
							}
							else if (this.subATK)
							{
								this.enemyBody.RPCActionDamageCut(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f, this.playerCtrl_Shanoa.dEX, x2, y2, 3);
							}
							break;
						case 5:
							if (!this.subATK)
							{
								this.enemyBody.RPCActionDamageDark(this.playerCtrl_Shanoa.aTK + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x2, y2);
							}
							else if (this.subATK)
							{
								this.enemyBody.RPCActionDamageDark(this.playerCtrl_Shanoa.aTK_Sub + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x2, y2);
							}
							break;
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl_Shanoa != null)
						{
							switch (this.weaponSwitch)
							{
							case 1:
							{
								float f6 = 0f;
								if (!this.subATK)
								{
									f6 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f6 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num6 = Mathf.RoundToInt(f6);
								if (num6 < 1)
								{
									num6 = 1;
								}
								this.playerStatus.damage += num6;
								break;
							}
							case 2:
							{
								float f7 = 0f;
								if (!this.subATK)
								{
									f7 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f7 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num7 = Mathf.RoundToInt(f7);
								if (num7 < 1)
								{
									num7 = 1;
								}
								this.playerStatus.damage += num7;
								break;
							}
							case 3:
							{
								float f8 = 0f;
								if (!this.subATK)
								{
									f8 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f8 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num8 = Mathf.RoundToInt(f8);
								if (num8 < 1)
								{
									num8 = 1;
								}
								this.playerStatus.damage += num8;
								break;
							}
							case 4:
							{
								float f9 = 0f;
								if (!this.subATK)
								{
									f9 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f);
								}
								else if (this.subATK)
								{
									f9 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f);
								}
								int num9 = Mathf.RoundToInt(f9);
								if (num9 < 1)
								{
									num9 = 1;
								}
								this.playerStatus.damage += num9;
								break;
							}
							case 5:
							{
								float f10 = 0f;
								if (!this.subATK)
								{
									f10 = Mathf.Round(this.playerCtrl_Shanoa.aTK + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f10 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num10 = Mathf.RoundToInt(f10);
								if (num10 < 1)
								{
									num10 = 1;
								}
								this.playerStatus.damage += num10;
								break;
							}
							}
						}
						if (!this.enemyBody.ownATKHitted)
						{
							this.enemyBody.ownATKHitted = true;
						}
					}
					this.hitedATK = true;
				}
			}
			else if (other.tag == "EnemyBodyAttackBoss01")
			{
				this.currentBB = other.transform.GetComponent<Boss01BodyDetect>();
				if (this.hitedATK)
				{
					if (!(this.currentBB == this.bB))
					{
						this.hitedATK = false;
					}
				}
				if (!this.hitedATK)
				{
					this.bB = other.GetComponent<Boss01BodyDetect>();
					this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
					Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x3 = vector3.x;
					float y3 = vector3.y;
					if (this.playerCtrl_Shanoa != null)
					{
						switch (this.weaponSwitch)
						{
						case 1:
							if (!this.subATK)
							{
								this.bB.ActionDamageCut(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x3, y3, 3);
							}
							else if (this.subATK)
							{
								this.bB.ActionDamageCut(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x3, y3, 3);
							}
							break;
						case 2:
							if (!this.subATK)
							{
								this.bB.ActionDamageHit(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x3, y3);
							}
							else if (this.subATK)
							{
								this.bB.ActionDamageHit(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x3, y3);
							}
							break;
						case 3:
							if (!this.subATK)
							{
								this.bB.ActionDamageConfodere(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x3, y3);
							}
							else if (this.subATK)
							{
								this.bB.ActionDamageConfodere(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x3, y3);
							}
							break;
						case 4:
							if (!this.subATK)
							{
								this.bB.ActionDamageCut(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f, this.playerCtrl_Shanoa.dEX, x3, y3, 3);
							}
							else if (this.subATK)
							{
								this.bB.ActionDamageCut(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f, this.playerCtrl_Shanoa.dEX, x3, y3, 3);
							}
							break;
						case 5:
							if (!this.subATK)
							{
								this.bB.ActionDamageDark(this.playerCtrl_Shanoa.aTK + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x3, y3);
							}
							else if (this.subATK)
							{
								this.bB.ActionDamageDark(this.playerCtrl_Shanoa.aTK_Sub + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f, this.playerCtrl_Shanoa.dEX, x3, y3);
							}
							break;
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl_Shanoa != null)
						{
							switch (this.weaponSwitch)
							{
							case 1:
							{
								float f11 = 0f;
								if (!this.subATK)
								{
									f11 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f11 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num11 = Mathf.RoundToInt(f11);
								if (num11 < 1)
								{
									num11 = 1;
								}
								this.playerStatus.damage += num11;
								break;
							}
							case 2:
							{
								float f12 = 0f;
								if (!this.subATK)
								{
									f12 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f12 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num12 = Mathf.RoundToInt(f12);
								if (num12 < 1)
								{
									num12 = 1;
								}
								this.playerStatus.damage += num12;
								break;
							}
							case 3:
							{
								float f13 = 0f;
								if (!this.subATK)
								{
									f13 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f13 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num13 = Mathf.RoundToInt(f13);
								if (num13 < 1)
								{
									num13 = 1;
								}
								this.playerStatus.damage += num13;
								break;
							}
							case 4:
							{
								float f14 = 0f;
								if (!this.subATK)
								{
									f14 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f);
								}
								else if (this.subATK)
								{
									f14 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK / 3f);
								}
								int num14 = Mathf.RoundToInt(f14);
								if (num14 < 1)
								{
									num14 = 1;
								}
								this.playerStatus.damage += num14;
								break;
							}
							case 5:
							{
								float f15 = 0f;
								if (!this.subATK)
								{
									f15 = Mathf.Round(this.playerCtrl_Shanoa.aTK + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								else if (this.subATK)
								{
									f15 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub + this.playerCtrl_Shanoa.iNT * this.playerCtrl_Shanoa.berserkerMeiruATK * 3f);
								}
								int num15 = Mathf.RoundToInt(f15);
								if (num15 < 1)
								{
									num15 = 1;
								}
								this.playerStatus.damage += num15;
								break;
							}
							}
						}
						if (!this.enemyBody.ownATKHitted)
						{
							this.enemyBody.ownATKHitted = true;
						}
					}
					this.hitedATK = true;
				}
			}
		}

		// Token: 0x06002B36 RID: 11062 RVA: 0x00481EA8 File Offset: 0x004800A8
		private void Update()
		{
			if (this.col2d != null)
			{
				if (!this.col2d.enabled && this.hitedATK)
				{
					this.enemyBody = null;
					this.currentEnemyBody = null;
					this.bB = null;
					this.currentBB = null;
					this.hitedATK = false;
				}
			}
			else if (this.col2d2 != null && !this.col2d2.enabled && this.hitedATK)
			{
				this.currentBB = null;
				this.bB = null;
				this.hitedATK = false;
			}
		}

		// Token: 0x040051E1 RID: 20961
		public bool hitedATK;

		// Token: 0x040051E2 RID: 20962
		public int weaponSwitch;

		// Token: 0x040051E3 RID: 20963
		private PlayerStatus playerStatus;

		// Token: 0x040051E4 RID: 20964
		private BoxCollider2D col2d;

		// Token: 0x040051E5 RID: 20965
		private CircleCollider2D col2d2;

		// Token: 0x040051E6 RID: 20966
		private PhotonView myPV;

		// Token: 0x040051E7 RID: 20967
		private EnemyBody enemyBody;

		// Token: 0x040051E8 RID: 20968
		private EnemyBody currentEnemyBody;

		// Token: 0x040051E9 RID: 20969
		private Boss01BodyDetect bB;

		// Token: 0x040051EA RID: 20970
		private Boss01BodyDetect currentBB;

		// Token: 0x040051EB RID: 20971
		private PlayerController_Shanoa playerCtrl_Shanoa;

		// Token: 0x040051EC RID: 20972
		public bool subATK;
	}
}
