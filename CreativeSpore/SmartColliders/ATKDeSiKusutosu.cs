using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000470 RID: 1136
	public class ATKDeSiKusutosu : MonoBehaviour
	{
		// Token: 0x06002B1C RID: 11036 RVA: 0x00477BE4 File Offset: 0x00475DE4
		private void Awake()
		{
			if (base.transform.parent.parent.parent.parent.GetComponent<PlayerController_Shanoa>() != null)
			{
				this.playerCtrl_Shanoa = base.transform.parent.parent.parent.parent.GetComponent<PlayerController_Shanoa>();
				this.myPV = base.transform.parent.parent.parent.parent.GetComponent<PhotonView>();
			}
			this.col2d = base.GetComponent<BoxCollider2D>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06002B1D RID: 11037 RVA: 0x00477C88 File Offset: 0x00475E88
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody")
			{
				if (other.transform.parent.name == "Enemy_Kani" || other.transform.parent.name == "Enemy_FinalGuard")
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
					if (this.playerCtrl_Shanoa != null)
					{
						int num2 = this.switchDeSi;
						if (num2 != 0)
						{
							if (num2 == 1)
							{
								if (!this.subATK)
								{
									this.enemyBody.RPCActionDamageSiKusutosu(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y);
								}
								else if (this.subATK)
								{
									this.enemyBody.RPCActionDamageSiKusutosu(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y);
								}
							}
						}
						else if (!this.subATK)
						{
							this.enemyBody.RPCActionDamageDeKusutosu(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y);
						}
						else if (this.subATK)
						{
							this.enemyBody.RPCActionDamageDeKusutosu(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x, y);
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl_Shanoa != null)
						{
							float f = 0f;
							if (!this.subATK)
							{
								f = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							else if (this.subATK)
							{
								f = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							int num3 = Mathf.RoundToInt(f);
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
				if (other.transform.parent.parent.name == "Enemy_Kani")
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
					if (this.playerCtrl_Shanoa != null)
					{
						int num5 = this.switchDeSi;
						if (num5 != 0)
						{
							if (num5 == 1)
							{
								if (!this.subATK)
								{
									this.enemyBody.RPCActionDamageSiKusutosu(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2);
								}
								else if (this.subATK)
								{
									this.enemyBody.RPCActionDamageSiKusutosu(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2);
								}
							}
						}
						else if (!this.subATK)
						{
							this.enemyBody.RPCActionDamageDeKusutosu(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2);
						}
						else if (this.subATK)
						{
							this.enemyBody.RPCActionDamageDeKusutosu(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x2, y2);
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl_Shanoa != null)
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
							int num6 = Mathf.RoundToInt(f2);
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
					if (this.playerCtrl_Shanoa != null)
					{
						int num7 = this.switchDeSi;
						if (num7 != 0)
						{
							if (num7 == 1)
							{
								if (!this.subATK)
								{
									this.bB.ActionDamageSiKusutosu(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3);
								}
								else if (this.subATK)
								{
									this.bB.ActionDamageSiKusutosu(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3);
								}
							}
						}
						else if (!this.subATK)
						{
							this.bB.ActionDamageDeKusutosu(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3);
						}
						else if (this.subATK)
						{
							this.bB.ActionDamageDeKusutosu(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK, this.playerCtrl_Shanoa.dEX, x3, y3);
						}
					}
					if (this.myPV.isMine)
					{
						if (this.playerCtrl_Shanoa != null)
						{
							float f3 = 0f;
							if (!this.subATK)
							{
								f3 = Mathf.Round(this.playerCtrl_Shanoa.aTK * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							else if (this.subATK)
							{
								f3 = Mathf.Round(this.playerCtrl_Shanoa.aTK_Sub * this.playerCtrl_Shanoa.berserkerMeiruATK);
							}
							int num8 = Mathf.RoundToInt(f3);
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

		// Token: 0x06002B1E RID: 11038 RVA: 0x00478551 File Offset: 0x00476751
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

		// Token: 0x0400519B RID: 20891
		public bool hitedATK;

		// Token: 0x0400519C RID: 20892
		public int switchDeSi;

		// Token: 0x0400519D RID: 20893
		private PlayerStatus playerStatus;

		// Token: 0x0400519E RID: 20894
		private BoxCollider2D col2d;

		// Token: 0x0400519F RID: 20895
		private PhotonView myPV;

		// Token: 0x040051A0 RID: 20896
		private EnemyBody enemyBody;

		// Token: 0x040051A1 RID: 20897
		private EnemyBody currentEnemyBody;

		// Token: 0x040051A2 RID: 20898
		private Boss01BodyDetect bB;

		// Token: 0x040051A3 RID: 20899
		private Boss01BodyDetect currentBB;

		// Token: 0x040051A4 RID: 20900
		private PlayerController_Shanoa playerCtrl_Shanoa;

		// Token: 0x040051A5 RID: 20901
		public bool subATK;
	}
}
