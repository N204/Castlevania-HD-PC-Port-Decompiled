using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020003DB RID: 987
	public class ATKAlbus : MonoBehaviour
	{
		// Token: 0x0600235F RID: 9055 RVA: 0x002F9C7C File Offset: 0x002F7E7C
		private void Awake()
		{
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06002360 RID: 9056 RVA: 0x002F9C93 File Offset: 0x002F7E93
		private void Start()
		{
			if (this.playerCtrl != null)
			{
				this.playerNumber = this.playerCtrl.playerNumber;
			}
		}

		// Token: 0x06002361 RID: 9057 RVA: 0x002F9CB8 File Offset: 0x002F7EB8
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				EnemyBody component = other.transform.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component) == 1)
				{
					this.ExpPlus(component.enemyLevel);
					float x = base.transform.position.x;
					float y = base.transform.position.y;
					if (this.playerCtrl != null)
					{
						component.RPCActionDamageFire(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f, this.playerCtrl.dEX, x, y);
					}
					component.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f = 0f;
						if (this.playerCtrl != null)
						{
							f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f);
						}
						int num = Mathf.RoundToInt(f);
						if (num < 1)
						{
							num = 1;
						}
						this.playerStatus.damage += num;
						if (!component.ownATKHitted)
						{
							component.ownATKHitted = true;
						}
					}
				}
			}
			else if (other.tag == "EnemyBodyAttackSp")
			{
				EnemyBody component2 = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component2) == 1)
				{
					this.ExpPlus(component2.enemyLevel);
					float x2 = base.transform.position.x;
					float y2 = base.transform.position.y;
					if (this.playerCtrl != null)
					{
						component2.RPCActionDamageFire(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f, this.playerCtrl.dEX, x2, y2);
					}
					component2.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f2 = 0f;
						if (this.playerCtrl != null)
						{
							f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f);
						}
						int num2 = Mathf.RoundToInt(f2);
						if (num2 < 1)
						{
							num2 = 1;
						}
						this.playerStatus.damage += num2;
						if (!component2.ownATKHitted)
						{
							component2.ownATKHitted = true;
						}
					}
				}
			}
			else if (other.tag == "EnemyBodyAttackBoss01")
			{
				Boss01BodyDetect component3 = other.GetComponent<Boss01BodyDetect>();
				EnemyBody component4 = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component4) == 1)
				{
					this.ExpPlus(component3.enemyLevel);
					float x3 = base.transform.position.x;
					float y3 = base.transform.position.y;
					if (this.playerCtrl != null)
					{
						component3.ActionDamageFire(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f, this.playerCtrl.dEX, x3, y3);
					}
					component4.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f3 = 0f;
						if (this.playerCtrl != null)
						{
							f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f);
						}
						int num3 = Mathf.RoundToInt(f3);
						if (num3 < 1)
						{
							num3 = 1;
						}
						this.playerStatus.damage += num3;
						if (!component4.ownATKHitted)
						{
							component4.ownATKHitted = true;
						}
					}
				}
			}
		}

		// Token: 0x06002362 RID: 9058 RVA: 0x002FA0F4 File Offset: 0x002F82F4
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				EnemyBody component = other.transform.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component) == 1)
				{
					this.ExpPlus(component.enemyLevel);
					float x = base.transform.position.x;
					float y = base.transform.position.y;
					if (this.playerCtrl != null)
					{
						component.RPCActionDamageFire(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f, this.playerCtrl.dEX, x, y);
					}
					component.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f = 0f;
						if (this.playerCtrl != null)
						{
							f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f);
						}
						int num = Mathf.RoundToInt(f);
						if (num < 1)
						{
							num = 1;
						}
						this.playerStatus.damage += num;
						if (!component.ownATKHitted)
						{
							component.ownATKHitted = true;
						}
					}
				}
			}
			else if (other.tag == "EnemyBodyAttackSp")
			{
				EnemyBody component2 = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component2) == 1)
				{
					this.ExpPlus(component2.enemyLevel);
					float x2 = base.transform.position.x;
					float y2 = base.transform.position.y;
					if (this.playerCtrl != null)
					{
						component2.RPCActionDamageFire(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f, this.playerCtrl.dEX, x2, y2);
					}
					component2.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f2 = 0f;
						if (this.playerCtrl != null)
						{
							f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f);
						}
						int num2 = Mathf.RoundToInt(f2);
						if (num2 < 1)
						{
							num2 = 1;
						}
						this.playerStatus.damage += num2;
						if (!component2.ownATKHitted)
						{
							component2.ownATKHitted = true;
						}
					}
				}
			}
			else if (other.tag == "EnemyBodyAttackBoss01")
			{
				Boss01BodyDetect component3 = other.GetComponent<Boss01BodyDetect>();
				EnemyBody component4 = other.transform.parent.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component4) == 1)
				{
					this.ExpPlus(component3.enemyLevel);
					float x3 = base.transform.position.x;
					float y3 = base.transform.position.y;
					if (this.playerCtrl != null)
					{
						component3.ActionDamageFire(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f, this.playerCtrl.dEX, x3, y3);
					}
					component4.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f3 = 0f;
						if (this.playerCtrl != null)
						{
							f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK * 2.2f);
						}
						int num3 = Mathf.RoundToInt(f3);
						if (num3 < 1)
						{
							num3 = 1;
						}
						this.playerStatus.damage += num3;
						if (!component4.ownATKHitted)
						{
							component4.ownATKHitted = true;
						}
					}
				}
			}
		}

		// Token: 0x06002363 RID: 9059 RVA: 0x002FA530 File Offset: 0x002F8730
		private void Update()
		{
			if (this.playerStatus == null)
			{
				this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			}
			if (this.playerCtrl != null && this.playerNumber != this.playerCtrl.playerNumber)
			{
				this.playerNumber = this.playerCtrl.playerNumber;
			}
		}

		// Token: 0x06002364 RID: 9060 RVA: 0x002FA59C File Offset: 0x002F879C
		private int ReturnBool(int num, EnemyBody targetEnemyBody)
		{
			int num2 = 0;
			switch (num)
			{
			case 1:
				if (!targetEnemyBody.canRecive_ATK)
				{
					num2++;
				}
				break;
			case 2:
				if (!targetEnemyBody.canRecive_ATK1)
				{
					num2++;
				}
				break;
			case 3:
				if (!targetEnemyBody.canRecive_ATK2)
				{
					num2++;
				}
				break;
			case 4:
				if (!targetEnemyBody.canRecive_ATK3)
				{
					num2++;
				}
				break;
			case 5:
				if (!targetEnemyBody.canRecive_ATK4)
				{
					num2++;
				}
				break;
			case 6:
				if (!targetEnemyBody.canRecive_ATK5)
				{
					num2++;
				}
				break;
			case 7:
				if (!targetEnemyBody.canRecive_ATK6)
				{
					num2++;
				}
				break;
			case 8:
				if (!targetEnemyBody.canRecive_ATK7)
				{
					num2++;
				}
				break;
			case 9:
				if (!targetEnemyBody.canRecive_ATK8)
				{
					num2++;
				}
				break;
			case 10:
				if (!targetEnemyBody.canRecive_ATK9)
				{
					num2++;
				}
				break;
			}
			return num2;
		}

		// Token: 0x06002365 RID: 9061 RVA: 0x002FA6AC File Offset: 0x002F88AC
		private void ExpPlus(int lvl)
		{
			if (this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expAlbusGun += 0.3f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expAlbusGun += 0.6f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expAlbusGun += 0.9f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expAlbusGun += 1.2f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expAlbusGun += 1.5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expAlbusGun += 1.8f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x04003E34 RID: 15924
		private PlayerStatus playerStatus;

		// Token: 0x04003E35 RID: 15925
		public PhotonView myPV;

		// Token: 0x04003E36 RID: 15926
		public PlayerController_Albus playerCtrl;

		// Token: 0x04003E37 RID: 15927
		public int playerNumber;

		// Token: 0x04003E38 RID: 15928
		public float returnTime = 0.3f;
	}
}
