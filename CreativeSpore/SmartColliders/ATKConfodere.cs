using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200046E RID: 1134
	public class ATKConfodere : MonoBehaviour
	{
		// Token: 0x06002B11 RID: 11025 RVA: 0x00476099 File Offset: 0x00474299
		private void Awake()
		{
			this.col2d = base.GetComponent<BoxCollider2D>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06002B12 RID: 11026 RVA: 0x004760BC File Offset: 0x004742BC
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				if (this.playerCtrl_Shanoa != null && (other.transform.parent.name == "Enemy_Kani" || other.transform.parent.name == "Enemy_FinalGuard"))
				{
					int num = UnityEngine.Random.Range(0, 9);
					if (num == 5)
					{
						this.playerCtrl_Shanoa.CV_Anim();
					}
				}
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
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageConfodere(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x, y);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.enemyBody.RPCActionDamageConfodere(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y);
						}
						else if (this.subATK)
						{
							this.enemyBody.RPCActionDamageConfodere(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y);
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num2 = Mathf.RoundToInt(f);
							if (num2 < 1)
							{
								num2 = 1;
							}
							this.playerStatus.damage += num2;
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							float f2 = 0f;
							if (!this.subATK)
							{
								f2 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							else if (this.subATK)
							{
								f2 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							int num3 = Mathf.RoundToInt(f2);
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
			else if (other.tag == "EnemyBodyAttackSp")
			{
				if (this.playerCtrl_Shanoa != null && other.transform.parent.parent.name == "Enemy_Kani")
				{
					int num4 = UnityEngine.Random.Range(0, 9);
					if (num4 == 5)
					{
						this.playerCtrl_Shanoa.CV_Anim();
					}
				}
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
						this.ExpPlus(this.enemyBody.enemyLevel);
						this.enemyBody.RPCActionDamageConfodere(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x2, y2);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.enemyBody.RPCActionDamageConfodere(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2);
						}
						else if (this.subATK)
						{
							this.enemyBody.RPCActionDamageConfodere(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2);
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f3 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num5 = Mathf.RoundToInt(f3);
							if (num5 < 1)
							{
								num5 = 1;
							}
							this.playerStatus.damage += num5;
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							float f4 = 0f;
							if (!this.subATK)
							{
								f4 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							else if (this.subATK)
							{
								f4 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							int num6 = Mathf.RoundToInt(f4);
							if (num6 < 1)
							{
								num6 = 1;
							}
							this.playerStatus.damage += num6;
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
						this.ExpPlus(this.bB.enemyLevel);
						this.bB.ActionDamageConfodere(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK, this.playerCtrl.dEX, x3, y3);
					}
					else if (this.playerCtrl_Shanoa != null)
					{
						if (!this.subATK)
						{
							this.bB.ActionDamageConfodere(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3);
						}
						else if (this.subATK)
						{
							this.bB.ActionDamageConfodere(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3);
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl != null)
						{
							float f5 = Mathf.Round(this.playerCtrl.aTK * this.playerCtrl.berserkerMeiruATK);
							int num7 = Mathf.RoundToInt(f5);
							if (num7 < 1)
							{
								num7 = 1;
							}
							this.playerStatus.damage += num7;
						}
						else if (this.playerCtrl_Shanoa != null)
						{
							float f6 = 0f;
							if (!this.subATK)
							{
								f6 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							else if (this.subATK)
							{
								f6 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							int num8 = Mathf.RoundToInt(f6);
							if (num8 < 1)
							{
								num8 = 1;
							}
							this.playerStatus.damage += num8;
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

		// Token: 0x06002B13 RID: 11027 RVA: 0x004769DC File Offset: 0x00474BDC
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

		// Token: 0x06002B14 RID: 11028 RVA: 0x00476B1D File Offset: 0x00474D1D
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

		// Token: 0x04005183 RID: 20867
		public bool hitedATK;

		// Token: 0x04005184 RID: 20868
		private PlayerStatus playerStatus;

		// Token: 0x04005185 RID: 20869
		private BoxCollider2D col2d;

		// Token: 0x04005186 RID: 20870
		public PhotonView myPV;

		// Token: 0x04005187 RID: 20871
		private EnemyBody enemyBody;

		// Token: 0x04005188 RID: 20872
		private EnemyBody currentEnemyBody;

		// Token: 0x04005189 RID: 20873
		private Boss01BodyDetect bB;

		// Token: 0x0400518A RID: 20874
		private Boss01BodyDetect currentBB;

		// Token: 0x0400518B RID: 20875
		public PlayerController playerCtrl;

		// Token: 0x0400518C RID: 20876
		public PlayerController_Shanoa playerCtrl_Shanoa;

		// Token: 0x0400518D RID: 20877
		public bool subATK;
	}
}
