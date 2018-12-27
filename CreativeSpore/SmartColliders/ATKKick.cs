using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000473 RID: 1139
	public class ATKKick : MonoBehaviour
	{
		// Token: 0x06002B2A RID: 11050 RVA: 0x0047A928 File Offset: 0x00478B28
		private void Awake()
		{
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.myPV = base.transform.parent.GetComponent<PhotonView>();
			if (base.transform.parent.GetComponent<PlayerController>() != null)
			{
				this.playerCtrl = base.transform.parent.GetComponent<PlayerController>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Shanoa>() != null)
			{
				this.playerCtrl_Shanoa = base.transform.parent.GetComponent<PlayerController_Shanoa>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Jonathan>() != null)
			{
				this.playerCtrl_Jonathan = base.transform.parent.GetComponent<PlayerController_Jonathan>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Charotte>() != null)
			{
				this.playerCtrl_Charotte = base.transform.parent.GetComponent<PlayerController_Charotte>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Albus>() != null)
			{
				this.playerCtrl_Albus = base.transform.parent.GetComponent<PlayerController_Albus>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Soma>() != null)
			{
				this.playerCtrl6 = base.transform.parent.GetComponent<PlayerController_Soma>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Alucard>() != null)
			{
				this.playerCtrl7 = base.transform.parent.GetComponent<PlayerController_Alucard>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Julius>() != null)
			{
				this.playerCtrl8 = base.transform.parent.GetComponent<PlayerController_Julius>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Yoko>() != null)
			{
				this.playerCtrl9 = base.transform.parent.GetComponent<PlayerController_Yoko>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Maria>() != null)
			{
				this.playerCtrl10 = base.transform.parent.GetComponent<PlayerController_Maria>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Simon>() != null)
			{
				this.playerCtrl11 = base.transform.parent.GetComponent<PlayerController_Simon>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Fuma>() != null)
			{
				this.playerCtrl12 = base.transform.parent.GetComponent<PlayerController_Fuma>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Add1>() != null)
			{
				this.playerCtrl13 = base.transform.parent.GetComponent<PlayerController_Add1>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Add2>() != null)
			{
				this.playerCtrl14 = base.transform.parent.GetComponent<PlayerController_Add2>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Add3>() != null)
			{
				this.playerCtrl15 = base.transform.parent.GetComponent<PlayerController_Add3>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Add4>() != null)
			{
				this.playerCtrl16 = base.transform.parent.GetComponent<PlayerController_Add4>();
			}
			if (base.transform.parent.GetComponent<PlayerController_Add5>() != null)
			{
				this.playerCtrl17 = base.transform.parent.GetComponent<PlayerController_Add5>();
			}
			this.col2d = base.GetComponent<CircleCollider2D>();
			if (base.gameObject.name == "Collider_Kick_Attack" && !this.myPV.isMine)
			{
				this.kickBound = true;
			}
		}

		// Token: 0x06002B2B RID: 11051 RVA: 0x0047ACE0 File Offset: 0x00478EE0
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!this.kickBound)
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
						this.ExpPlus(this.enemyBody.enemyLevel);
						Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x = vector.x;
						float y = vector.y;
						if (this.playerCtrl != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.comboCount, this.playerCtrl.dEX, x, y);
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.heroBoots * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.comboCount, this.playerCtrl_Shanoa.dEX, x, y);
						}
						else if (this.playerCtrl_Jonathan != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK, this.playerCtrl_Jonathan.comboCount, this.playerCtrl_Jonathan.dEX, x, y);
						}
						else if (this.playerCtrl_Charotte != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl_Charotte.aTK * this.playerCtrl_Charotte.heroBoots * this.playerCtrl_Charotte.berserkerMeiruATK, this.playerCtrl_Charotte.comboCount, this.playerCtrl_Charotte.dEX, x, y);
						}
						else if (this.playerCtrl_Albus != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl_Albus.aTK * this.playerCtrl_Albus.heroBoots * this.playerCtrl_Albus.berserkerMeiruATK, this.playerCtrl_Albus.comboCount, this.playerCtrl_Albus.dEX, x, y);
						}
						else if (this.playerCtrl6 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl6.aTK * this.playerCtrl6.heroBoots * this.playerCtrl6.berserkerMeiruATK, this.playerCtrl6.comboCount, this.playerCtrl6.dEX, x, y);
						}
						else if (this.playerCtrl7 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl7.aTK * this.playerCtrl7.heroBoots * this.playerCtrl7.berserkerMeiruATK, this.playerCtrl7.comboCount, this.playerCtrl7.dEX, x, y);
						}
						else if (this.playerCtrl8 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl8.aTK * this.playerCtrl8.heroBoots * this.playerCtrl8.berserkerMeiruATK, this.playerCtrl8.comboCount, this.playerCtrl8.dEX, x, y);
						}
						else if (this.playerCtrl9 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl9.aTK * this.playerCtrl9.heroBoots * this.playerCtrl9.berserkerMeiruATK, this.playerCtrl9.comboCount, this.playerCtrl9.dEX, x, y);
						}
						else if (this.playerCtrl10 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl10.aTK * this.playerCtrl10.heroBoots * this.playerCtrl10.berserkerMeiruATK, this.playerCtrl10.comboCount, this.playerCtrl10.dEX, x, y);
						}
						else if (this.playerCtrl11 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl11.aTK * this.playerCtrl11.heroBoots * this.playerCtrl11.berserkerMeiruATK, this.playerCtrl11.comboCount, this.playerCtrl11.dEX, x, y);
						}
						else if (this.playerCtrl12 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl12.aTK * this.playerCtrl12.heroBoots * this.playerCtrl12.berserkerMeiruATK, this.playerCtrl12.comboCount, this.playerCtrl12.dEX, x, y);
						}
						else if (this.playerCtrl13 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl13.aTK * this.playerCtrl13.heroBoots * this.playerCtrl13.berserkerMeiruATK, this.playerCtrl13.comboCount, this.playerCtrl13.dEX, x, y);
						}
						else if (this.playerCtrl14 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl14.aTK * this.playerCtrl14.heroBoots * this.playerCtrl14.berserkerMeiruATK, this.playerCtrl14.comboCount, this.playerCtrl14.dEX, x, y);
						}
						else if (this.playerCtrl15 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl15.aTK * this.playerCtrl15.heroBoots * this.playerCtrl15.berserkerMeiruATK, this.playerCtrl15.comboCount, this.playerCtrl15.dEX, x, y);
						}
						else if (this.playerCtrl16 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl16.aTK * this.playerCtrl16.heroBoots * this.playerCtrl16.berserkerMeiruATK, this.playerCtrl16.comboCount, this.playerCtrl16.dEX, x, y);
						}
						else if (this.playerCtrl17 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl17.aTK * this.playerCtrl17.heroBoots * this.playerCtrl17.berserkerMeiruATK, this.playerCtrl17.comboCount, this.playerCtrl17.dEX, x, y);
						}
						if (base.gameObject.name == "Collider_Kick_Attack2")
						{
							this.enemyBody.hitSlidingKickTimer = 0f;
							this.enemyBody.hitSlidingKick = true;
						}
						if (this.myPV.isMine)
						{
							float f = 0f;
							if (this.playerCtrl != null)
							{
								f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Shanoa != null)
							{
								f = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.heroBoots * this.playerCtrl_Shanoa.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Jonathan != null)
							{
								f = Mathf.Round(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Charotte != null)
							{
								f = Mathf.Round(this.playerCtrl_Charotte.aTK * this.playerCtrl_Charotte.heroBoots * this.playerCtrl_Charotte.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Albus != null)
							{
								f = Mathf.Round(this.playerCtrl_Albus.aTK * this.playerCtrl_Albus.heroBoots * this.playerCtrl_Albus.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl6 != null)
							{
								f = Mathf.Round(this.playerCtrl6.aTK * this.playerCtrl6.heroBoots * this.playerCtrl6.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl7 != null)
							{
								f = Mathf.Round(this.playerCtrl7.aTK * this.playerCtrl7.heroBoots * this.playerCtrl7.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl8 != null)
							{
								f = Mathf.Round(this.playerCtrl8.aTK * this.playerCtrl8.heroBoots * this.playerCtrl8.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl9 != null)
							{
								f = Mathf.Round(this.playerCtrl9.aTK * this.playerCtrl9.heroBoots * this.playerCtrl9.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl10 != null)
							{
								f = Mathf.Round(this.playerCtrl10.aTK * this.playerCtrl10.heroBoots * this.playerCtrl10.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl11 != null)
							{
								f = Mathf.Round(this.playerCtrl11.aTK * this.playerCtrl11.heroBoots * this.playerCtrl11.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl12 != null)
							{
								f = Mathf.Round(this.playerCtrl12.aTK * this.playerCtrl12.heroBoots * this.playerCtrl12.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl13 != null)
							{
								f = Mathf.Round(this.playerCtrl13.aTK * this.playerCtrl13.heroBoots * this.playerCtrl13.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl14 != null)
							{
								f = Mathf.Round(this.playerCtrl14.aTK * this.playerCtrl14.heroBoots * this.playerCtrl14.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl15 != null)
							{
								f = Mathf.Round(this.playerCtrl15.aTK * this.playerCtrl15.heroBoots * this.playerCtrl15.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl16 != null)
							{
								f = Mathf.Round(this.playerCtrl16.aTK * this.playerCtrl16.heroBoots * this.playerCtrl16.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl17 != null)
							{
								f = Mathf.Round(this.playerCtrl17.aTK * this.playerCtrl17.heroBoots * this.playerCtrl17.berserkerMeiruATK / 10f);
							}
							int num = Mathf.RoundToInt(f);
							if (num < 1)
							{
								num = 1;
							}
							this.playerStatus.damage += num;
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
						this.ExpPlus(this.enemyBody.enemyLevel);
						Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x2 = vector2.x;
						float y2 = vector2.y;
						if (this.playerCtrl != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.comboCount, this.playerCtrl.dEX, x2, y2);
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.heroBoots * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.comboCount, this.playerCtrl_Shanoa.dEX, x2, y2);
						}
						else if (this.playerCtrl_Jonathan != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK, this.playerCtrl_Jonathan.comboCount, this.playerCtrl_Jonathan.dEX, x2, y2);
						}
						else if (this.playerCtrl_Charotte != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl_Charotte.aTK * this.playerCtrl_Charotte.heroBoots * this.playerCtrl_Charotte.berserkerMeiruATK, this.playerCtrl_Charotte.comboCount, this.playerCtrl_Charotte.dEX, x2, y2);
						}
						else if (this.playerCtrl_Albus != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl_Albus.aTK * this.playerCtrl_Albus.heroBoots * this.playerCtrl_Albus.berserkerMeiruATK, this.playerCtrl_Albus.comboCount, this.playerCtrl_Albus.dEX, x2, y2);
						}
						else if (this.playerCtrl6 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl6.aTK * this.playerCtrl6.heroBoots * this.playerCtrl6.berserkerMeiruATK, this.playerCtrl6.comboCount, this.playerCtrl6.dEX, x2, y2);
						}
						else if (this.playerCtrl7 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl7.aTK * this.playerCtrl7.heroBoots * this.playerCtrl7.berserkerMeiruATK, this.playerCtrl7.comboCount, this.playerCtrl7.dEX, x2, y2);
						}
						else if (this.playerCtrl8 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl8.aTK * this.playerCtrl8.heroBoots * this.playerCtrl8.berserkerMeiruATK, this.playerCtrl8.comboCount, this.playerCtrl8.dEX, x2, y2);
						}
						else if (this.playerCtrl9 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl9.aTK * this.playerCtrl9.heroBoots * this.playerCtrl9.berserkerMeiruATK, this.playerCtrl9.comboCount, this.playerCtrl9.dEX, x2, y2);
						}
						else if (this.playerCtrl10 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl10.aTK * this.playerCtrl10.heroBoots * this.playerCtrl10.berserkerMeiruATK, this.playerCtrl10.comboCount, this.playerCtrl10.dEX, x2, y2);
						}
						else if (this.playerCtrl11 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl11.aTK * this.playerCtrl11.heroBoots * this.playerCtrl11.berserkerMeiruATK, this.playerCtrl11.comboCount, this.playerCtrl11.dEX, x2, y2);
						}
						else if (this.playerCtrl12 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl12.aTK * this.playerCtrl12.heroBoots * this.playerCtrl12.berserkerMeiruATK, this.playerCtrl12.comboCount, this.playerCtrl12.dEX, x2, y2);
						}
						else if (this.playerCtrl13 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl13.aTK * this.playerCtrl13.heroBoots * this.playerCtrl13.berserkerMeiruATK, this.playerCtrl13.comboCount, this.playerCtrl13.dEX, x2, y2);
						}
						else if (this.playerCtrl14 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl14.aTK * this.playerCtrl14.heroBoots * this.playerCtrl14.berserkerMeiruATK, this.playerCtrl14.comboCount, this.playerCtrl14.dEX, x2, y2);
						}
						else if (this.playerCtrl15 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl15.aTK * this.playerCtrl15.heroBoots * this.playerCtrl15.berserkerMeiruATK, this.playerCtrl15.comboCount, this.playerCtrl15.dEX, x2, y2);
						}
						else if (this.playerCtrl16 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl16.aTK * this.playerCtrl16.heroBoots * this.playerCtrl16.berserkerMeiruATK, this.playerCtrl16.comboCount, this.playerCtrl16.dEX, x2, y2);
						}
						else if (this.playerCtrl17 != null)
						{
							this.enemyBody.RPCActionDamageKick(this.playerCtrl17.aTK * this.playerCtrl17.heroBoots * this.playerCtrl17.berserkerMeiruATK, this.playerCtrl17.comboCount, this.playerCtrl17.dEX, x2, y2);
						}
						if (base.gameObject.name == "Collider_Kick_Attack2")
						{
							this.enemyBody.hitSlidingKickTimer = 0f;
							this.enemyBody.hitSlidingKick = true;
						}
						if (this.myPV.isMine)
						{
							float f2 = 0f;
							if (this.playerCtrl != null)
							{
								f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Shanoa != null)
							{
								f2 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.heroBoots * this.playerCtrl_Shanoa.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Jonathan != null)
							{
								f2 = Mathf.Round(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Charotte != null)
							{
								f2 = Mathf.Round(this.playerCtrl_Charotte.aTK * this.playerCtrl_Charotte.heroBoots * this.playerCtrl_Charotte.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Albus != null)
							{
								f2 = Mathf.Round(this.playerCtrl_Albus.aTK * this.playerCtrl_Albus.heroBoots * this.playerCtrl_Albus.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl6 != null)
							{
								f2 = Mathf.Round(this.playerCtrl6.aTK * this.playerCtrl6.heroBoots * this.playerCtrl6.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl7 != null)
							{
								f2 = Mathf.Round(this.playerCtrl7.aTK * this.playerCtrl7.heroBoots * this.playerCtrl7.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl8 != null)
							{
								f2 = Mathf.Round(this.playerCtrl8.aTK * this.playerCtrl8.heroBoots * this.playerCtrl8.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl9 != null)
							{
								f2 = Mathf.Round(this.playerCtrl9.aTK * this.playerCtrl9.heroBoots * this.playerCtrl9.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl10 != null)
							{
								f2 = Mathf.Round(this.playerCtrl10.aTK * this.playerCtrl10.heroBoots * this.playerCtrl10.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl11 != null)
							{
								f2 = Mathf.Round(this.playerCtrl11.aTK * this.playerCtrl11.heroBoots * this.playerCtrl11.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl12 != null)
							{
								f2 = Mathf.Round(this.playerCtrl12.aTK * this.playerCtrl12.heroBoots * this.playerCtrl12.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl13 != null)
							{
								f2 = Mathf.Round(this.playerCtrl13.aTK * this.playerCtrl13.heroBoots * this.playerCtrl13.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl14 != null)
							{
								f2 = Mathf.Round(this.playerCtrl14.aTK * this.playerCtrl14.heroBoots * this.playerCtrl14.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl15 != null)
							{
								f2 = Mathf.Round(this.playerCtrl15.aTK * this.playerCtrl15.heroBoots * this.playerCtrl15.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl16 != null)
							{
								f2 = Mathf.Round(this.playerCtrl16.aTK * this.playerCtrl16.heroBoots * this.playerCtrl16.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl17 != null)
							{
								f2 = Mathf.Round(this.playerCtrl17.aTK * this.playerCtrl17.heroBoots * this.playerCtrl17.berserkerMeiruATK / 10f);
							}
							int num2 = Mathf.RoundToInt(f2);
							if (num2 < 1)
							{
								num2 = 1;
							}
							this.playerStatus.damage += num2;
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
						this.ExpPlus(this.bB.enemyLevel);
						Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x3 = vector3.x;
						float y3 = vector3.y;
						if (this.playerCtrl != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.comboCount, this.playerCtrl.dEX, x3, y3);
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.heroBoots * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.comboCount, this.playerCtrl_Shanoa.dEX, x3, y3);
						}
						else if (this.playerCtrl_Jonathan != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK, this.playerCtrl_Jonathan.comboCount, this.playerCtrl_Jonathan.dEX, x3, y3);
						}
						else if (this.playerCtrl_Charotte != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl_Charotte.aTK * this.playerCtrl_Charotte.heroBoots * this.playerCtrl_Charotte.berserkerMeiruATK, this.playerCtrl_Charotte.comboCount, this.playerCtrl_Charotte.dEX, x3, y3);
						}
						else if (this.playerCtrl_Albus != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl_Albus.aTK * this.playerCtrl_Albus.heroBoots * this.playerCtrl_Albus.berserkerMeiruATK, this.playerCtrl_Albus.comboCount, this.playerCtrl_Albus.dEX, x3, y3);
						}
						else if (this.playerCtrl6 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl6.aTK * this.playerCtrl6.heroBoots * this.playerCtrl6.berserkerMeiruATK, this.playerCtrl6.comboCount, this.playerCtrl6.dEX, x3, y3);
						}
						else if (this.playerCtrl7 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl7.aTK * this.playerCtrl7.heroBoots * this.playerCtrl7.berserkerMeiruATK, this.playerCtrl7.comboCount, this.playerCtrl7.dEX, x3, y3);
						}
						else if (this.playerCtrl8 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl8.aTK * this.playerCtrl8.heroBoots * this.playerCtrl8.berserkerMeiruATK, this.playerCtrl8.comboCount, this.playerCtrl8.dEX, x3, y3);
						}
						else if (this.playerCtrl9 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl9.aTK * this.playerCtrl9.heroBoots * this.playerCtrl9.berserkerMeiruATK, this.playerCtrl9.comboCount, this.playerCtrl9.dEX, x3, y3);
						}
						else if (this.playerCtrl10 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl10.aTK * this.playerCtrl10.heroBoots * this.playerCtrl10.berserkerMeiruATK, this.playerCtrl10.comboCount, this.playerCtrl10.dEX, x3, y3);
						}
						else if (this.playerCtrl11 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl11.aTK * this.playerCtrl11.heroBoots * this.playerCtrl11.berserkerMeiruATK, this.playerCtrl11.comboCount, this.playerCtrl11.dEX, x3, y3);
						}
						else if (this.playerCtrl12 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl12.aTK * this.playerCtrl12.heroBoots * this.playerCtrl12.berserkerMeiruATK, this.playerCtrl12.comboCount, this.playerCtrl12.dEX, x3, y3);
						}
						else if (this.playerCtrl13 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl13.aTK * this.playerCtrl13.heroBoots * this.playerCtrl13.berserkerMeiruATK, this.playerCtrl13.comboCount, this.playerCtrl13.dEX, x3, y3);
						}
						else if (this.playerCtrl14 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl14.aTK * this.playerCtrl14.heroBoots * this.playerCtrl14.berserkerMeiruATK, this.playerCtrl14.comboCount, this.playerCtrl14.dEX, x3, y3);
						}
						else if (this.playerCtrl15 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl15.aTK * this.playerCtrl15.heroBoots * this.playerCtrl15.berserkerMeiruATK, this.playerCtrl15.comboCount, this.playerCtrl15.dEX, x3, y3);
						}
						else if (this.playerCtrl16 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl16.aTK * this.playerCtrl16.heroBoots * this.playerCtrl16.berserkerMeiruATK, this.playerCtrl16.comboCount, this.playerCtrl16.dEX, x3, y3);
						}
						else if (this.playerCtrl17 != null)
						{
							this.bB.ActionDamageKick(this.playerCtrl17.aTK * this.playerCtrl17.heroBoots * this.playerCtrl17.berserkerMeiruATK, this.playerCtrl17.comboCount, this.playerCtrl17.dEX, x3, y3);
						}
						if (base.gameObject.name == "Collider_Kick_Attack2")
						{
							this.enemyBody.hitSlidingKickTimer = 0f;
							this.enemyBody.hitSlidingKick = true;
						}
						if (this.myPV.isMine)
						{
							float f3 = 0f;
							if (this.playerCtrl != null)
							{
								f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.heroBoots * this.playerCtrl.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Shanoa != null)
							{
								f3 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.heroBoots * this.playerCtrl_Shanoa.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Jonathan != null)
							{
								f3 = Mathf.Round(this.playerCtrl_Jonathan.aTK * this.playerCtrl_Jonathan.heroBoots * this.playerCtrl_Jonathan.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Charotte != null)
							{
								f3 = Mathf.Round(this.playerCtrl_Charotte.aTK * this.playerCtrl_Charotte.heroBoots * this.playerCtrl_Charotte.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl_Albus != null)
							{
								f3 = Mathf.Round(this.playerCtrl_Albus.aTK * this.playerCtrl_Albus.heroBoots * this.playerCtrl_Albus.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl6 != null)
							{
								f3 = Mathf.Round(this.playerCtrl6.aTK * this.playerCtrl6.heroBoots * this.playerCtrl6.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl7 != null)
							{
								f3 = Mathf.Round(this.playerCtrl7.aTK * this.playerCtrl7.heroBoots * this.playerCtrl7.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl8 != null)
							{
								f3 = Mathf.Round(this.playerCtrl8.aTK * this.playerCtrl8.heroBoots * this.playerCtrl8.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl9 != null)
							{
								f3 = Mathf.Round(this.playerCtrl9.aTK * this.playerCtrl9.heroBoots * this.playerCtrl9.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl10 != null)
							{
								f3 = Mathf.Round(this.playerCtrl10.aTK * this.playerCtrl10.heroBoots * this.playerCtrl10.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl11 != null)
							{
								f3 = Mathf.Round(this.playerCtrl11.aTK * this.playerCtrl11.heroBoots * this.playerCtrl11.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl12 != null)
							{
								f3 = Mathf.Round(this.playerCtrl12.aTK * this.playerCtrl12.heroBoots * this.playerCtrl12.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl13 != null)
							{
								f3 = Mathf.Round(this.playerCtrl13.aTK * this.playerCtrl13.heroBoots * this.playerCtrl13.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl14 != null)
							{
								f3 = Mathf.Round(this.playerCtrl14.aTK * this.playerCtrl14.heroBoots * this.playerCtrl14.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl15 != null)
							{
								f3 = Mathf.Round(this.playerCtrl15.aTK * this.playerCtrl15.heroBoots * this.playerCtrl15.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl16 != null)
							{
								f3 = Mathf.Round(this.playerCtrl16.aTK * this.playerCtrl16.heroBoots * this.playerCtrl16.berserkerMeiruATK / 10f);
							}
							else if (this.playerCtrl17 != null)
							{
								f3 = Mathf.Round(this.playerCtrl17.aTK * this.playerCtrl17.heroBoots * this.playerCtrl17.berserkerMeiruATK / 10f);
							}
							int num3 = Mathf.RoundToInt(f3);
							if (num3 < 1)
							{
								num3 = 1;
							}
							this.playerStatus.damage += num3;
							if (!this.enemyBody.ownATKHitted)
							{
								this.enemyBody.ownATKHitted = true;
							}
						}
						this.hitedATK = true;
					}
				}
				else if (other.tag == "SkeltonKickBall")
				{
					if (this.playerCtrl != null)
					{
						if (this.playerCtrl.kick)
						{
							Rigidbody2D component = other.transform.parent.GetComponent<Rigidbody2D>();
							component.velocity = new Vector2(component.velocity.x, -6f);
						}
						if (this.playerCtrl.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component2 = other.transform.parent.GetComponent<Rigidbody2D>();
								component2.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component3 = other.transform.parent.GetComponent<Rigidbody2D>();
								component3.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl.kickNaname && !this.playerCtrl.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component4 = other.transform.parent.GetComponent<Rigidbody2D>();
								component4.velocity = new Vector2(3f, component4.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component5 = other.transform.parent.GetComponent<Rigidbody2D>();
								component5.velocity = new Vector2(-3f, component5.velocity.y);
							}
						}
					}
					if (this.playerCtrl_Shanoa != null)
					{
						if (this.playerCtrl_Shanoa.kick)
						{
							Rigidbody2D component6 = other.transform.parent.GetComponent<Rigidbody2D>();
							component6.velocity = new Vector2(component6.velocity.x, -6f);
						}
						if (this.playerCtrl_Shanoa.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component7 = other.transform.parent.GetComponent<Rigidbody2D>();
								component7.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component8 = other.transform.parent.GetComponent<Rigidbody2D>();
								component8.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl_Shanoa.kickNaname && !this.playerCtrl_Shanoa.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component9 = other.transform.parent.GetComponent<Rigidbody2D>();
								component9.velocity = new Vector2(3f, component9.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component10 = other.transform.parent.GetComponent<Rigidbody2D>();
								component10.velocity = new Vector2(-3f, component10.velocity.y);
							}
						}
					}
					if (this.playerCtrl_Jonathan != null)
					{
						if (this.playerCtrl_Jonathan.kick)
						{
							Rigidbody2D component11 = other.transform.parent.GetComponent<Rigidbody2D>();
							component11.velocity = new Vector2(component11.velocity.x, -6f);
						}
						if (this.playerCtrl_Jonathan.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component12 = other.transform.parent.GetComponent<Rigidbody2D>();
								component12.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component13 = other.transform.parent.GetComponent<Rigidbody2D>();
								component13.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl_Jonathan.kickNaname && !this.playerCtrl_Jonathan.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component14 = other.transform.parent.GetComponent<Rigidbody2D>();
								component14.velocity = new Vector2(3f, component14.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component15 = other.transform.parent.GetComponent<Rigidbody2D>();
								component15.velocity = new Vector2(-3f, component15.velocity.y);
							}
						}
					}
					if (this.playerCtrl_Charotte != null)
					{
						if (this.playerCtrl_Charotte.kick)
						{
							Rigidbody2D component16 = other.transform.parent.GetComponent<Rigidbody2D>();
							component16.velocity = new Vector2(component16.velocity.x, -6f);
						}
						if (this.playerCtrl_Charotte.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component17 = other.transform.parent.GetComponent<Rigidbody2D>();
								component17.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component18 = other.transform.parent.GetComponent<Rigidbody2D>();
								component18.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl_Charotte.kickNaname && !this.playerCtrl_Charotte.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component19 = other.transform.parent.GetComponent<Rigidbody2D>();
								component19.velocity = new Vector2(3f, component19.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component20 = other.transform.parent.GetComponent<Rigidbody2D>();
								component20.velocity = new Vector2(-3f, component20.velocity.y);
							}
						}
					}
					if (this.playerCtrl_Albus != null)
					{
						if (this.playerCtrl_Albus.kick)
						{
							Rigidbody2D component21 = other.transform.parent.GetComponent<Rigidbody2D>();
							component21.velocity = new Vector2(component21.velocity.x, -6f);
						}
						if (this.playerCtrl_Albus.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component22 = other.transform.parent.GetComponent<Rigidbody2D>();
								component22.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component23 = other.transform.parent.GetComponent<Rigidbody2D>();
								component23.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl_Albus.kickNaname && !this.playerCtrl_Albus.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component24 = other.transform.parent.GetComponent<Rigidbody2D>();
								component24.velocity = new Vector2(3f, component24.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component25 = other.transform.parent.GetComponent<Rigidbody2D>();
								component25.velocity = new Vector2(-3f, component25.velocity.y);
							}
						}
					}
					if (this.playerCtrl6 != null)
					{
						if (this.playerCtrl6.kick)
						{
							Rigidbody2D component26 = other.transform.parent.GetComponent<Rigidbody2D>();
							component26.velocity = new Vector2(component26.velocity.x, -6f);
						}
						if (this.playerCtrl6.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component27 = other.transform.parent.GetComponent<Rigidbody2D>();
								component27.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component28 = other.transform.parent.GetComponent<Rigidbody2D>();
								component28.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl6.kickNaname && !this.playerCtrl6.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component29 = other.transform.parent.GetComponent<Rigidbody2D>();
								component29.velocity = new Vector2(3f, component29.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component30 = other.transform.parent.GetComponent<Rigidbody2D>();
								component30.velocity = new Vector2(-3f, component30.velocity.y);
							}
						}
					}
					if (this.playerCtrl7 != null)
					{
						if (this.playerCtrl7.kick)
						{
							Rigidbody2D component31 = other.transform.parent.GetComponent<Rigidbody2D>();
							component31.velocity = new Vector2(component31.velocity.x, -6f);
						}
						if (this.playerCtrl7.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component32 = other.transform.parent.GetComponent<Rigidbody2D>();
								component32.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component33 = other.transform.parent.GetComponent<Rigidbody2D>();
								component33.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl7.kickNaname && !this.playerCtrl7.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component34 = other.transform.parent.GetComponent<Rigidbody2D>();
								component34.velocity = new Vector2(3f, component34.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component35 = other.transform.parent.GetComponent<Rigidbody2D>();
								component35.velocity = new Vector2(-3f, component35.velocity.y);
							}
						}
					}
					if (this.playerCtrl8 != null)
					{
						if (this.playerCtrl8.kick)
						{
							Rigidbody2D component36 = other.transform.parent.GetComponent<Rigidbody2D>();
							component36.velocity = new Vector2(component36.velocity.x, -6f);
						}
						if (this.playerCtrl8.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component37 = other.transform.parent.GetComponent<Rigidbody2D>();
								component37.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component38 = other.transform.parent.GetComponent<Rigidbody2D>();
								component38.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl8.kickNaname && !this.playerCtrl8.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component39 = other.transform.parent.GetComponent<Rigidbody2D>();
								component39.velocity = new Vector2(3f, component39.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component40 = other.transform.parent.GetComponent<Rigidbody2D>();
								component40.velocity = new Vector2(-3f, component40.velocity.y);
							}
						}
					}
					if (this.playerCtrl9 != null)
					{
						if (this.playerCtrl9.kick)
						{
							Rigidbody2D component41 = other.transform.parent.GetComponent<Rigidbody2D>();
							component41.velocity = new Vector2(component41.velocity.x, -6f);
						}
						if (this.playerCtrl9.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component42 = other.transform.parent.GetComponent<Rigidbody2D>();
								component42.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component43 = other.transform.parent.GetComponent<Rigidbody2D>();
								component43.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl9.kickNaname && !this.playerCtrl9.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component44 = other.transform.parent.GetComponent<Rigidbody2D>();
								component44.velocity = new Vector2(3f, component44.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component45 = other.transform.parent.GetComponent<Rigidbody2D>();
								component45.velocity = new Vector2(-3f, component45.velocity.y);
							}
						}
					}
					if (this.playerCtrl10 != null)
					{
						if (this.playerCtrl10.kick)
						{
							Rigidbody2D component46 = other.transform.parent.GetComponent<Rigidbody2D>();
							component46.velocity = new Vector2(component46.velocity.x, -6f);
						}
						if (this.playerCtrl10.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component47 = other.transform.parent.GetComponent<Rigidbody2D>();
								component47.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component48 = other.transform.parent.GetComponent<Rigidbody2D>();
								component48.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl10.kickNaname && !this.playerCtrl10.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component49 = other.transform.parent.GetComponent<Rigidbody2D>();
								component49.velocity = new Vector2(3f, component49.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component50 = other.transform.parent.GetComponent<Rigidbody2D>();
								component50.velocity = new Vector2(-3f, component50.velocity.y);
							}
						}
					}
					if (this.playerCtrl11 != null)
					{
						if (this.playerCtrl11.kick)
						{
							Rigidbody2D component51 = other.transform.parent.GetComponent<Rigidbody2D>();
							component51.velocity = new Vector2(component51.velocity.x, -6f);
						}
						if (this.playerCtrl11.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component52 = other.transform.parent.GetComponent<Rigidbody2D>();
								component52.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component53 = other.transform.parent.GetComponent<Rigidbody2D>();
								component53.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl11.kickNaname && !this.playerCtrl11.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component54 = other.transform.parent.GetComponent<Rigidbody2D>();
								component54.velocity = new Vector2(3f, component54.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component55 = other.transform.parent.GetComponent<Rigidbody2D>();
								component55.velocity = new Vector2(-3f, component55.velocity.y);
							}
						}
					}
					if (this.playerCtrl12 != null)
					{
						if (this.playerCtrl12.kick)
						{
							Rigidbody2D component56 = other.transform.parent.GetComponent<Rigidbody2D>();
							component56.velocity = new Vector2(component56.velocity.x, -6f);
						}
						if (this.playerCtrl12.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component57 = other.transform.parent.GetComponent<Rigidbody2D>();
								component57.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component58 = other.transform.parent.GetComponent<Rigidbody2D>();
								component58.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl12.kickNaname && !this.playerCtrl12.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component59 = other.transform.parent.GetComponent<Rigidbody2D>();
								component59.velocity = new Vector2(3f, component59.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component60 = other.transform.parent.GetComponent<Rigidbody2D>();
								component60.velocity = new Vector2(-3f, component60.velocity.y);
							}
						}
					}
					if (this.playerCtrl13 != null)
					{
						if (this.playerCtrl13.kick)
						{
							Rigidbody2D component61 = other.transform.parent.GetComponent<Rigidbody2D>();
							component61.velocity = new Vector2(component61.velocity.x, -6f);
						}
						if (this.playerCtrl13.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component62 = other.transform.parent.GetComponent<Rigidbody2D>();
								component62.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component63 = other.transform.parent.GetComponent<Rigidbody2D>();
								component63.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl13.kickNaname && !this.playerCtrl13.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component64 = other.transform.parent.GetComponent<Rigidbody2D>();
								component64.velocity = new Vector2(3f, component64.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component65 = other.transform.parent.GetComponent<Rigidbody2D>();
								component65.velocity = new Vector2(-3f, component65.velocity.y);
							}
						}
					}
					if (this.playerCtrl14 != null)
					{
						if (this.playerCtrl14.kick)
						{
							Rigidbody2D component66 = other.transform.parent.GetComponent<Rigidbody2D>();
							component66.velocity = new Vector2(component66.velocity.x, -6f);
						}
						if (this.playerCtrl14.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component67 = other.transform.parent.GetComponent<Rigidbody2D>();
								component67.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component68 = other.transform.parent.GetComponent<Rigidbody2D>();
								component68.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl14.kickNaname && !this.playerCtrl14.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component69 = other.transform.parent.GetComponent<Rigidbody2D>();
								component69.velocity = new Vector2(3f, component69.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component70 = other.transform.parent.GetComponent<Rigidbody2D>();
								component70.velocity = new Vector2(-3f, component70.velocity.y);
							}
						}
					}
					if (this.playerCtrl15 != null)
					{
						if (this.playerCtrl15.kick)
						{
							Rigidbody2D component71 = other.transform.parent.GetComponent<Rigidbody2D>();
							component71.velocity = new Vector2(component71.velocity.x, -6f);
						}
						if (this.playerCtrl15.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component72 = other.transform.parent.GetComponent<Rigidbody2D>();
								component72.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component73 = other.transform.parent.GetComponent<Rigidbody2D>();
								component73.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl15.kickNaname && !this.playerCtrl15.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component74 = other.transform.parent.GetComponent<Rigidbody2D>();
								component74.velocity = new Vector2(3f, component74.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component75 = other.transform.parent.GetComponent<Rigidbody2D>();
								component75.velocity = new Vector2(-3f, component75.velocity.y);
							}
						}
					}
					if (this.playerCtrl16 != null)
					{
						if (this.playerCtrl16.kick)
						{
							Rigidbody2D component76 = other.transform.parent.GetComponent<Rigidbody2D>();
							component76.velocity = new Vector2(component76.velocity.x, -6f);
						}
						if (this.playerCtrl16.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component77 = other.transform.parent.GetComponent<Rigidbody2D>();
								component77.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component78 = other.transform.parent.GetComponent<Rigidbody2D>();
								component78.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl16.kickNaname && !this.playerCtrl16.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component79 = other.transform.parent.GetComponent<Rigidbody2D>();
								component79.velocity = new Vector2(3f, component79.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component80 = other.transform.parent.GetComponent<Rigidbody2D>();
								component80.velocity = new Vector2(-3f, component80.velocity.y);
							}
						}
					}
					if (this.playerCtrl17 != null)
					{
						if (this.playerCtrl17.kick)
						{
							Rigidbody2D component81 = other.transform.parent.GetComponent<Rigidbody2D>();
							component81.velocity = new Vector2(component81.velocity.x, -6f);
						}
						if (this.playerCtrl17.kickNaname)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component82 = other.transform.parent.GetComponent<Rigidbody2D>();
								component82.velocity = new Vector2(3f, -2f);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component83 = other.transform.parent.GetComponent<Rigidbody2D>();
								component83.velocity = new Vector2(-3f, -2f);
							}
						}
						if (!this.playerCtrl17.kickNaname && !this.playerCtrl17.kick)
						{
							if (other.transform.parent.gameObject.transform.position.x > base.transform.position.x)
							{
								Rigidbody2D component84 = other.transform.parent.GetComponent<Rigidbody2D>();
								component84.velocity = new Vector2(3f, component84.velocity.y);
							}
							else if (other.transform.parent.gameObject.transform.position.x < base.transform.position.x)
							{
								Rigidbody2D component85 = other.transform.parent.GetComponent<Rigidbody2D>();
								component85.velocity = new Vector2(-3f, component85.velocity.y);
							}
						}
					}
				}
			}
		}

		// Token: 0x06002B2C RID: 11052 RVA: 0x0047F79C File Offset: 0x0047D99C
		private void Update()
		{
			if (this.playerStatus == null)
			{
				this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			}
			if (!this.col2d.enabled && this.hitedATK)
			{
				this.enemyBody = null;
				this.currentEnemyBody = null;
				this.bB = null;
				this.currentBB = null;
				this.hitedATK = false;
			}
		}

		// Token: 0x06002B2D RID: 11053 RVA: 0x0047F810 File Offset: 0x0047DA10
		private void ExpPlus(int lvl)
		{
			if ((this.playerCtrl != null || this.playerCtrl_Jonathan != null || this.playerCtrl8 != null || this.playerCtrl11 != null) && this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expMainWeapon01 += 0.1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expMainWeapon01 += 0.2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expMainWeapon01 += 0.3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expMainWeapon01 += 0.4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expMainWeapon01 += 0.5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expMainWeapon01 += 0.6f * this.playerStatus.masterRing;
					break;
				}
			}
			if (this.playerCtrl13 && this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expMainWeapon02 += 0.1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expMainWeapon02 += 0.2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expMainWeapon02 += 0.3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expMainWeapon02 += 0.4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expMainWeapon02 += 0.5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expMainWeapon02 += 0.6f * this.playerStatus.masterRing;
					break;
				}
			}
			if (this.playerCtrl10 && this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expHato += 0.1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expHato += 0.2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expHato += 0.3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expHato += 0.4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expHato += 0.5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expHato += 0.6f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x040051BC RID: 20924
		public bool hitedATK;

		// Token: 0x040051BD RID: 20925
		public bool kickBound;

		// Token: 0x040051BE RID: 20926
		private PlayerStatus playerStatus;

		// Token: 0x040051BF RID: 20927
		private CircleCollider2D col2d;

		// Token: 0x040051C0 RID: 20928
		private EnemyBody enemyBody;

		// Token: 0x040051C1 RID: 20929
		private EnemyBody currentEnemyBody;

		// Token: 0x040051C2 RID: 20930
		private Boss01BodyDetect bB;

		// Token: 0x040051C3 RID: 20931
		private Boss01BodyDetect currentBB;

		// Token: 0x040051C4 RID: 20932
		private PlayerController playerCtrl;

		// Token: 0x040051C5 RID: 20933
		private PlayerController_Shanoa playerCtrl_Shanoa;

		// Token: 0x040051C6 RID: 20934
		private PlayerController_Jonathan playerCtrl_Jonathan;

		// Token: 0x040051C7 RID: 20935
		private PlayerController_Charotte playerCtrl_Charotte;

		// Token: 0x040051C8 RID: 20936
		private PlayerController_Albus playerCtrl_Albus;

		// Token: 0x040051C9 RID: 20937
		private PlayerController_Soma playerCtrl6;

		// Token: 0x040051CA RID: 20938
		private PlayerController_Alucard playerCtrl7;

		// Token: 0x040051CB RID: 20939
		private PlayerController_Julius playerCtrl8;

		// Token: 0x040051CC RID: 20940
		private PlayerController_Yoko playerCtrl9;

		// Token: 0x040051CD RID: 20941
		private PlayerController_Maria playerCtrl10;

		// Token: 0x040051CE RID: 20942
		private PlayerController_Simon playerCtrl11;

		// Token: 0x040051CF RID: 20943
		private PlayerController_Fuma playerCtrl12;

		// Token: 0x040051D0 RID: 20944
		private PlayerController_Add1 playerCtrl13;

		// Token: 0x040051D1 RID: 20945
		private PlayerController_Add2 playerCtrl14;

		// Token: 0x040051D2 RID: 20946
		private PlayerController_Add3 playerCtrl15;

		// Token: 0x040051D3 RID: 20947
		private PlayerController_Add4 playerCtrl16;

		// Token: 0x040051D4 RID: 20948
		private PlayerController_Add5 playerCtrl17;

		// Token: 0x040051D5 RID: 20949
		private PhotonView myPV;
	}
}
