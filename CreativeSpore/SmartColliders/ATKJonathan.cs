using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000472 RID: 1138
	public class ATKJonathan : MonoBehaviour
	{
		// Token: 0x06002B25 RID: 11045 RVA: 0x004792B9 File Offset: 0x004774B9
		private void Awake()
		{
			this.col2d = base.GetComponent<BoxCollider2D>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06002B26 RID: 11046 RVA: 0x004792DC File Offset: 0x004774DC
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
					if (this.playerCtrl != null)
					{
						switch (this.weaponSwitch)
						{
						case 1:
							this.ExpPlus(this.enemyBody.enemyLevel);
							this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 2:
							this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 3:
							this.enemyBody.RPCActionDamageWeaponKnife(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 4:
							this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 2);
							break;
						case 5:
							this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y, 3);
							break;
						case 6:
							this.enemyBody.RPCActionDamageWeaponAxe(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 7:
							this.enemyBody.RPCActionDamageRoseWhip(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 8:
							this.enemyBody.RPCActionDamageMedusaWhip(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusStoneRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 9:
							this.enemyBody.RPCActionDamageHonooNoMuchi(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 10:
							this.enemyBody.RPCActionDamageSikkokuNoMuchi(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusPoisonRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 11:
							this.ExpPlus(this.enemyBody.enemyLevel);
							this.enemyBody.RPCActionDamageVampireKiller(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 12:
							this.enemyBody.RPCActionDamageMilican(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusStoneRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 13:
							this.enemyBody.RPCActionDamageRahab(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 14:
							this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 15:
							this.enemyBody.RPCActionDamageAssasinBlade(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusPoisonRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 16:
							this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						case 17:
							this.enemyBody.RPCActionDamageDragonSlayer(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusCurseRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 18:
							this.enemyBody.RPCActionDamageVoulvge(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
							break;
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num = Mathf.RoundToInt(f);
							if (num < 1)
							{
								num = 1;
							}
							this.playerStatus.damage += num;
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
					if (this.playerCtrl != null)
					{
						switch (this.weaponSwitch)
						{
						case 1:
							this.ExpPlus(this.enemyBody.enemyLevel);
							this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 2:
							this.enemyBody.RPCActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 3:
							this.enemyBody.RPCActionDamageWeaponKnife(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 4:
							this.enemyBody.RPCActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 2);
							break;
						case 5:
							this.enemyBody.RPCActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2, 3);
							break;
						case 6:
							this.enemyBody.RPCActionDamageWeaponAxe(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 7:
							this.enemyBody.RPCActionDamageRoseWhip(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 8:
							this.enemyBody.RPCActionDamageMedusaWhip(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusStoneRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 9:
							this.enemyBody.RPCActionDamageHonooNoMuchi(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 10:
							this.enemyBody.RPCActionDamageSikkokuNoMuchi(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusPoisonRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 11:
							this.ExpPlus(this.enemyBody.enemyLevel);
							this.enemyBody.RPCActionDamageVampireKiller(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 12:
							this.enemyBody.RPCActionDamageMilican(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusStoneRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 13:
							this.enemyBody.RPCActionDamageRahab(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 14:
							this.enemyBody.RPCActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 15:
							this.enemyBody.RPCActionDamageAssasinBlade(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusPoisonRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 16:
							this.enemyBody.RPCActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						case 17:
							this.enemyBody.RPCActionDamageDragonSlayer(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusCurseRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 18:
							this.enemyBody.RPCActionDamageVoulvge(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
							break;
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f2 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num2 = Mathf.RoundToInt(f2);
							if (num2 < 1)
							{
								num2 = 1;
							}
							this.playerStatus.damage += num2;
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
					if (this.playerCtrl != null)
					{
						switch (this.weaponSwitch)
						{
						case 1:
							this.ExpPlus(this.enemyBody.enemyLevel);
							this.bB.ActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 2:
							this.bB.ActionDamageHit(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 3:
							this.bB.ActionDamageWeaponKnife(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 4:
							this.bB.ActionDamageCut(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 2);
							break;
						case 5:
							this.bB.ActionDamagePoke(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3, 3);
							break;
						case 6:
							this.bB.ActionDamageWeaponAxe(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 7:
							this.bB.ActionDamageRoseWhip(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 8:
							this.bB.ActionDamageMedusaWhip(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusStoneRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 9:
							this.bB.ActionDamageHonooNoMuchi(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 10:
							this.bB.ActionDamageSikkokuNoMuchi(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusPoisonRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 11:
							this.ExpPlus(this.enemyBody.enemyLevel);
							this.bB.ActionDamageVampireKiller(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 12:
							this.bB.ActionDamageMilican(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusStoneRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 13:
							this.bB.ActionDamageRahab(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 14:
							this.bB.ActionDamageAgni(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 15:
							this.bB.ActionDamageAssasinBlade(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusPoisonRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 16:
							this.bB.ActionDamageStellaSword(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						case 17:
							this.bB.ActionDamageDragonSlayer(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							if (this.myPV.isMine)
							{
								this.enemyBody.StatusCurseRandom(base.transform.position.x, base.transform.position.y);
							}
							break;
						case 18:
							this.bB.ActionDamageVoulvge(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
							break;
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num3 = Mathf.RoundToInt(f3);
							if (num3 < 1)
							{
								num3 = 1;
							}
							this.playerStatus.damage += num3;
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

		// Token: 0x06002B27 RID: 11047 RVA: 0x0047A7A4 File Offset: 0x004789A4
		private void ExpPlus(int lvl)
		{
			if (this.playerCtrl != null && this.myPV.isMine)
			{
				switch (lvl)
				{
				case 0:
					this.playerStatus.expMainWeapon01 += 1f * this.playerStatus.masterRing;
					break;
				case 1:
					this.playerStatus.expMainWeapon01 += 2f * this.playerStatus.masterRing;
					break;
				case 2:
					this.playerStatus.expMainWeapon01 += 3f * this.playerStatus.masterRing;
					break;
				case 3:
					this.playerStatus.expMainWeapon01 += 4f * this.playerStatus.masterRing;
					break;
				case 4:
					this.playerStatus.expMainWeapon01 += 5f * this.playerStatus.masterRing;
					break;
				case 5:
					this.playerStatus.expMainWeapon01 += 6f * this.playerStatus.masterRing;
					break;
				}
			}
		}

		// Token: 0x06002B28 RID: 11048 RVA: 0x0047A8E5 File Offset: 0x00478AE5
		private void Update()
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

		// Token: 0x040051B2 RID: 20914
		public bool hitedATK;

		// Token: 0x040051B3 RID: 20915
		private PlayerStatus playerStatus;

		// Token: 0x040051B4 RID: 20916
		private BoxCollider2D col2d;

		// Token: 0x040051B5 RID: 20917
		public PhotonView myPV;

		// Token: 0x040051B6 RID: 20918
		private EnemyBody enemyBody;

		// Token: 0x040051B7 RID: 20919
		private EnemyBody currentEnemyBody;

		// Token: 0x040051B8 RID: 20920
		private Boss01BodyDetect bB;

		// Token: 0x040051B9 RID: 20921
		private Boss01BodyDetect currentBB;

		// Token: 0x040051BA RID: 20922
		public PlayerController_Jonathan playerCtrl;

		// Token: 0x040051BB RID: 20923
		public int weaponSwitch;
	}
}
