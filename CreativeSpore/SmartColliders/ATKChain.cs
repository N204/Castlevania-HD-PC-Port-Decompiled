using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200046B RID: 1131
	public class ATKChain : MonoBehaviour
	{
		// Token: 0x06002B00 RID: 11008 RVA: 0x004743B0 File Offset: 0x004725B0
		private void Awake()
		{
			if (this.myPV == null && base.transform.parent.parent.parent.GetComponent<PhotonView>() != null)
			{
				this.myPV = base.transform.parent.parent.parent.GetComponent<PhotonView>();
			}
			if (base.transform.parent.parent.GetComponent<PlayerController>() != null)
			{
				this.playerCtrl = base.transform.parent.parent.GetComponent<PlayerController>();
			}
			if (this.playerCtrl == null && this.playerCtrl3 == null && base.transform.parent.parent.parent.GetComponent<PlayerController_Jonathan>() != null)
			{
				this.playerCtrl2 = base.transform.parent.parent.parent.GetComponent<PlayerController_Jonathan>();
			}
		}

		// Token: 0x06002B01 RID: 11009 RVA: 0x004744B8 File Offset: 0x004726B8
		private void Start()
		{
			if (this.playerCtrl != null)
			{
				this.playerNumber = this.playerCtrl.playerNumber;
			}
			if (this.playerCtrl2 != null)
			{
				this.playerNumber = this.playerCtrl2.playerNumber;
			}
			if (this.playerCtrl3 != null)
			{
				this.playerNumber = this.playerCtrl3.playerNumber;
			}
		}

		// Token: 0x06002B02 RID: 11010 RVA: 0x0047452C File Offset: 0x0047272C
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				EnemyBody component = other.transform.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component) == 1)
				{
					this.ExpPlus(component.enemyLevel);
					Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x = vector.x;
					float y = vector.y;
					if (this.playerCtrl != null)
					{
						component.RPCActionDamageChain(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
					}
					if (this.playerCtrl2 != null)
					{
						component.RPCActionDamageChain(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK, this.playerCtrl2.dEX, x, y);
					}
					if (this.playerCtrl3 != null)
					{
						component.RPCActionDamageChain(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK, this.playerCtrl3.dEX, x, y);
					}
					component.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f = 0f;
						if (this.playerCtrl != null)
						{
							f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl2 != null)
						{
							f = Mathf.Round(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl3 != null)
						{
							f = Mathf.Round(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK / 7f);
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
					Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x2 = vector2.x;
					float y2 = vector2.y;
					if (this.playerCtrl != null)
					{
						component2.RPCActionDamageChain(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
					}
					if (this.playerCtrl2 != null)
					{
						component2.RPCActionDamageChain(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK, this.playerCtrl2.dEX, x2, y2);
					}
					if (this.playerCtrl3 != null)
					{
						component2.RPCActionDamageChain(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK, this.playerCtrl3.dEX, x2, y2);
					}
					component2.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f2 = 0f;
						if (this.playerCtrl != null)
						{
							f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl2 != null)
						{
							f2 = Mathf.Round(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl3 != null)
						{
							f2 = Mathf.Round(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK / 7f);
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
					Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x3 = vector3.x;
					float y3 = vector3.y;
					if (this.playerCtrl != null)
					{
						component3.ActionDamageChain(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
					}
					if (this.playerCtrl2 != null)
					{
						component3.ActionDamageChain(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK, this.playerCtrl2.dEX, x3, y3);
					}
					if (this.playerCtrl3 != null)
					{
						component3.ActionDamageChain(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK, this.playerCtrl3.dEX, x3, y3);
					}
					component4.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f3 = 0f;
						if (this.playerCtrl != null)
						{
							f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl2 != null)
						{
							f3 = Mathf.Round(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl3 != null)
						{
							f3 = Mathf.Round(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK / 7f);
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

		// Token: 0x06002B03 RID: 11011 RVA: 0x00474C18 File Offset: 0x00472E18
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				EnemyBody component = other.transform.parent.GetComponent<EnemyBody>();
				if (this.ReturnBool(this.playerNumber, component) == 1)
				{
					this.ExpPlus(component.enemyLevel);
					Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x = vector.x;
					float y = vector.y;
					if (this.playerCtrl != null)
					{
						component.RPCActionDamageChain(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
					}
					if (this.playerCtrl2 != null)
					{
						component.RPCActionDamageChain(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK, this.playerCtrl2.dEX, x, y);
					}
					if (this.playerCtrl3 != null)
					{
						component.RPCActionDamageChain(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK, this.playerCtrl3.dEX, x, y);
					}
					component.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f = 0f;
						if (this.playerCtrl != null)
						{
							f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl2 != null)
						{
							f = Mathf.Round(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl3 != null)
						{
							f = Mathf.Round(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK / 7f);
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
					Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x2 = vector2.x;
					float y2 = vector2.y;
					if (this.playerCtrl != null)
					{
						component2.RPCActionDamageChain(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
					}
					if (this.playerCtrl2 != null)
					{
						component2.RPCActionDamageChain(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK, this.playerCtrl2.dEX, x2, y2);
					}
					if (this.playerCtrl3 != null)
					{
						component2.RPCActionDamageChain(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK, this.playerCtrl3.dEX, x2, y2);
					}
					component2.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f2 = 0f;
						if (this.playerCtrl != null)
						{
							f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl2 != null)
						{
							f2 = Mathf.Round(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl3 != null)
						{
							f2 = Mathf.Round(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK / 7f);
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
					Vector3 vector3 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
					float x3 = vector3.x;
					float y3 = vector3.y;
					if (this.playerCtrl != null)
					{
						component3.ActionDamageChain(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
					}
					if (this.playerCtrl2 != null)
					{
						component3.ActionDamageChain(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK, this.playerCtrl2.dEX, x3, y3);
					}
					if (this.playerCtrl3 != null)
					{
						component3.ActionDamageChain(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK, this.playerCtrl3.dEX, x3, y3);
					}
					component4.ReciveBoolReturn(this.returnTime, "ATK", this.playerNumber);
					if (this.myPV.isMine)
					{
						float f3 = 0f;
						if (this.playerCtrl != null)
						{
							f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl2 != null)
						{
							f3 = Mathf.Round(this.playerCtrl2.aTK * this.playerCtrl2.berserkerMeiruATK / 7f);
						}
						if (this.playerCtrl3 != null)
						{
							f3 = Mathf.Round(this.playerCtrl3.aTK * this.playerCtrl3.berserkerMeiruATK / 7f);
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

		// Token: 0x06002B04 RID: 11012 RVA: 0x00475304 File Offset: 0x00473504
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
			if (this.playerCtrl2 != null && this.playerNumber != this.playerCtrl2.playerNumber)
			{
				this.playerNumber = this.playerCtrl2.playerNumber;
			}
			if (this.playerCtrl3 != null && this.playerNumber != this.playerCtrl3.playerNumber)
			{
				this.playerNumber = this.playerCtrl3.playerNumber;
			}
		}

		// Token: 0x06002B05 RID: 11013 RVA: 0x004753E0 File Offset: 0x004735E0
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

		// Token: 0x06002B06 RID: 11014 RVA: 0x004754F0 File Offset: 0x004736F0
		private void ExpPlus(int lvl)
		{
			if (this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expMainWeapon01 += 0.3f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expMainWeapon01 += 0.6f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expMainWeapon01 += 0.9f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expMainWeapon01 += 1.2f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expMainWeapon01 += 1.5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expMainWeapon01 += 1.8f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x0400516D RID: 20845
		private PlayerStatus playerStatus;

		// Token: 0x0400516E RID: 20846
		public PhotonView myPV;

		// Token: 0x0400516F RID: 20847
		private PlayerController playerCtrl;

		// Token: 0x04005170 RID: 20848
		private PlayerController_Jonathan playerCtrl2;

		// Token: 0x04005171 RID: 20849
		public PlayerController_Julius playerCtrl3;

		// Token: 0x04005172 RID: 20850
		public int playerNumber;

		// Token: 0x04005173 RID: 20851
		public float returnTime = 0.3f;
	}
}
