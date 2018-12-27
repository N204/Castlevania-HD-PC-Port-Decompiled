using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020003ED RID: 1005
	public class AlucardRange : MonoBehaviour
	{
		// Token: 0x06002460 RID: 9312 RVA: 0x0031B0A0 File Offset: 0x003192A0
		private void Awake()
		{
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			if (base.GetComponent<Animator>() != null)
			{
				this.animator = base.GetComponent<Animator>();
			}
			if (base.GetComponent<EnemySoundEffect>() != null)
			{
				this.eSE = base.GetComponent<EnemySoundEffect>();
			}
			if (base.transform.Find("GroundCheck_C") != null)
			{
				this.groundCheck_R = base.transform.Find("GroundCheck_R");
				this.groundCheck_C = base.transform.Find("GroundCheck_C");
				this.groundCheck_L = base.transform.Find("GroundCheck_L");
			}
			this.groundCheckCollider[0] = new Collider2D[16];
			this.groundCheckCollider[1] = new Collider2D[16];
			this.groundCheckCollider[2] = new Collider2D[16];
		}

		// Token: 0x06002461 RID: 9313 RVA: 0x0031B188 File Offset: 0x00319388
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (this.magicNumber == 2 && other.transform.parent.gameObject == this.ownerObj && this.timer >= 1f)
			{
				this.GameObjectFalse();
			}
			if (this.magicNumber == 11 && (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody" || other.tag == "EnemyBodyAttackSp" || other.tag == "EnemyBodyAttackBoss01") && !this.action)
			{
				this.targetPos = other.gameObject.transform.position;
				this.action = true;
			}
			if (this.magicNumber == 21 && (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody" || other.tag == "EnemyBodyAttackSp" || other.tag == "EnemyBodyAttackBoss01") && this.animator.GetCurrentAnimatorStateInfo(0).fullPathHash == AlucardRange.ANISTS_ShieldRod_AxeArmor_Idle && !this.action)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
				this.targetATKCol1.enabled = false;
				this.animator.SetTrigger("ATK");
				this.action = true;
			}
			if ((this.magicNumber == 23 || this.magicNumber == 33) && (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody" || other.tag == "EnemyBodyAttackSp" || other.tag == "EnemyBodyAttackBoss01") && !this.action)
			{
				this.targetPos = other.gameObject.transform.position;
				this.targetPos2 = other.gameObject.transform.position;
				this.targetPos3 = other.gameObject.transform.position;
				this.action = true;
			}
			if (this.magicNumber == 28 && other.transform.parent.gameObject == this.ownerObj && this.timer >= 1f)
			{
				AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo.fullPathHash == AlucardRange.ANISTS_TsukaimaNoKen_Idle && currentAnimatorStateInfo.normalizedTime > 1f && !this.destroyCheck)
				{
					this.animator.SetTrigger("Out");
					base.Invoke("GameObjectFalse", 2f);
					this.destroyCheck = true;
				}
			}
			if (this.magicNumber == 38 && other.transform.parent.gameObject == this.ownerObj && this.action)
			{
				AnimatorStateInfo currentAnimatorStateInfo2 = this.animator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo2.fullPathHash == AlucardRange.RuneSword_Idle && currentAnimatorStateInfo2.normalizedTime > 1f && !this.destroyCheck)
				{
					this.animator.SetTrigger("Out");
					base.Invoke("GameObjectFalse", 1f);
					this.destroyCheck = true;
				}
			}
			if (this.magicNumber == 43 && (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody" || other.tag == "EnemyBodyAttackSp" || other.tag == "EnemyBodyAttackBoss01") && this.getTarget)
			{
				this.startPos = base.transform.position;
				this.posHokan = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
				this.targetPos = other.gameObject.transform.position;
				this.targetATKCol3.enabled = false;
				this.action = true;
				this.getTarget = false;
			}
			if (this.enemySW)
			{
				if (other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper" || other.tag == "PlayerBody")
				{
					this.hitedATK = true;
				}
			}
			else if (!this.enemySW)
			{
				if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody" || other.tag == "EnemyBodyAttackSp")
				{
					if (other.transform.parent.GetComponent<EnemyBody>() != null)
					{
						this.currentEnemyBody = other.transform.parent.GetComponent<EnemyBody>();
					}
					else if (other.transform.parent.parent.GetComponent<EnemyBody>() != null)
					{
						this.currentEnemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
					}
					if (this.hitedATK)
					{
						if (!(this.currentEnemyBody == this.enemyBody))
						{
							this.hitedATK = false;
						}
					}
					if (!this.hitedATK)
					{
						if (other.transform.parent.GetComponent<EnemyBody>() != null)
						{
							this.enemyBody = other.transform.parent.GetComponent<EnemyBody>();
						}
						else if (other.transform.parent.parent.GetComponent<EnemyBody>() != null)
						{
							this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
						}
						Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x = vector.x;
						float y = vector.y;
						float f = 0f;
						if (this.magicNumber == 2 || this.magicNumber == 9 || this.magicNumber == 19 || this.magicNumber == 20 || this.magicNumber == 35 || this.magicNumber == 37 || this.magicNumber == 38)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageCut(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.05f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.05f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.1f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.1f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.15f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.15f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.25f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.25f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.3f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.3f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.35f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.35f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 21 && this.canDamage)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageCut(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.05f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.05f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.1f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.1f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.15f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.15f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.25f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.25f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.3f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.3f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.35f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.35f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 4 || this.magicNumber == 7)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageAgni(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageAgni(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageAgni(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageAgni(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageAgni(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageAgni(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageAgni(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageAgni(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageAgni(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 5)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageRahab(this.iNT * 1.5f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.5f * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageRahab(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageRahab(this.iNT * 3f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 3f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageRahab(this.iNT * 4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 4f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageRahab(this.iNT * 5f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 5f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageRahab(this.iNT * 6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 6f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageRahab(this.iNT * 7f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 7f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageRahab(this.iNT * 8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 8f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageRahab(this.iNT * 9f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 9f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 6)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageIndra(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageIndra(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageIndra(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageIndra(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageIndra(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageIndra(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageIndra(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageIndra(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageIndra(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 12)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageStone(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageStone(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageStone(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageStone(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageStone(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageStone(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageStone(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageStone(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageStone(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							if (this.mineSW)
							{
								this.enemyBody.StatusStoneRandom(x, y);
							}
						}
						if (this.magicNumber == 9)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageHit(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageHit(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageHit(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageHit(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageHit(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageHit(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageHit(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageHit(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageHit(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 24)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageFire(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageFire(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageFire(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageFire(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageFire(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageFire(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageFire(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageFire(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageFire(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 34)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamagePoke(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamagePoke(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamagePoke(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamagePoke(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamagePoke(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamagePoke(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamagePoke(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamagePoke(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamagePoke(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y, 1);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 36)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageDragonSlayer(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageDragonSlayer(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageDragonSlayer(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageDragonSlayer(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageDragonSlayer(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageDragonSlayer(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageDragonSlayer(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageDragonSlayer(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageDragonSlayer(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							if (this.mineSW)
							{
								this.enemyBody.StatusCurseRandom(x, y);
							}
						}
						if (this.magicNumber == 40 || this.magicNumber == 41 || this.magicNumber == 42)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageMagic(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.mineSW)
						{
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
						if (other.transform.parent.GetComponent<EnemyBody>() != null)
						{
							this.enemyBody = other.transform.parent.GetComponent<EnemyBody>();
						}
						else if (other.transform.parent.parent.GetComponent<EnemyBody>() != null)
						{
							this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
						}
						Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
						float x2 = vector2.x;
						float y2 = vector2.y;
						float f2 = 0f;
						if (this.magicNumber == 2 || this.magicNumber == 9 || this.magicNumber == 19 || this.magicNumber == 20 || this.magicNumber == 35 || this.magicNumber == 37 || this.magicNumber == 38)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageCut(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageCut(this.iNT * 1.05f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.05f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageCut(this.iNT * 1.1f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.1f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageCut(this.iNT * 1.15f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.15f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageCut(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageCut(this.iNT * 1.25f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.25f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageCut(this.iNT * 1.3f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.3f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageCut(this.iNT * 1.35f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.35f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageCut(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 21 && this.canDamage)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageCut(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageCut(this.iNT * 1.05f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.05f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageCut(this.iNT * 1.1f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.1f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageCut(this.iNT * 1.15f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.15f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageCut(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageCut(this.iNT * 1.25f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.25f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageCut(this.iNT * 1.3f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.3f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageCut(this.iNT * 1.35f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.35f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageCut(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 4 || this.magicNumber == 7)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageAgni(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageAgni(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageAgni(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageAgni(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageAgni(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageAgni(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageAgni(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageAgni(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageAgni(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 5)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageRahab(this.iNT * 1.5f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.5f * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageRahab(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageRahab(this.iNT * 3f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 3f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageRahab(this.iNT * 4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 4f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageRahab(this.iNT * 5f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 5f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageRahab(this.iNT * 6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 6f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageRahab(this.iNT * 7f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 7f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageRahab(this.iNT * 8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 8f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageRahab(this.iNT * 9f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 9f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 6)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageIndra(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageIndra(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageIndra(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageIndra(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageIndra(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageIndra(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageIndra(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageIndra(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageIndra(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 12)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageStone(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageStone(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageStone(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageStone(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageStone(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageStone(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageStone(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageStone(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageStone(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							if (this.mineSW)
							{
								this.enemyBody.StatusStoneRandom(x2, y2);
							}
						}
						if (this.magicNumber == 9)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageHit(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageHit(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageHit(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageHit(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageHit(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageHit(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageHit(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageHit(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageHit(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 24)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageFire(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageFire(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageFire(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageFire(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageFire(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageFire(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageFire(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageFire(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageFire(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 34)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamagePoke(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamagePoke(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamagePoke(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamagePoke(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamagePoke(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamagePoke(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamagePoke(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamagePoke(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamagePoke(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2, 1);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.magicNumber == 36)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageDragonSlayer(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageDragonSlayer(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageDragonSlayer(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageDragonSlayer(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageDragonSlayer(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageDragonSlayer(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageDragonSlayer(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageDragonSlayer(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageDragonSlayer(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							if (this.mineSW)
							{
								this.enemyBody.StatusCurseRandom(x2, y2);
							}
						}
						if (this.magicNumber == 40 || this.magicNumber == 41 || this.magicNumber == 42)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageMagic(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageMagic(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageMagic(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageMagic(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageMagic(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageMagic(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageMagic(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageMagic(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageMagic(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
						}
						if (this.mineSW)
						{
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
			}
		}

		// Token: 0x06002462 RID: 9314 RVA: 0x0031FFD8 File Offset: 0x0031E1D8
		private void OnTriggerStay2D(Collider2D other)
		{
			if (other.tag == "EnemyBodyAttack" || other.tag == "BonePillarBody" || other.tag == "EnemyBodyAttackSp")
			{
				if (other.transform.parent.GetComponent<EnemyBody>() != null)
				{
					this.enemyBody = other.transform.parent.GetComponent<EnemyBody>();
				}
				else if (other.transform.parent.parent.GetComponent<EnemyBody>() != null)
				{
					this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
				}
				Vector3 vector = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
				float x = vector.x;
				float y = vector.y;
				float f = 0f;
				if (this.magicNumber == 22 || this.magicNumber == 27 || this.magicNumber == 28 || this.magicNumber == 1 || this.magicNumber == 31 || this.magicNumber == 39)
				{
					if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
					{
						if (this.magicNumber == 22)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageDark(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageDark(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageDark(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageDark(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageDark(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageDark(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageDark(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageDark(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageDark(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.magicNumber == 27)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageVampireKiller(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageVampireKiller(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageVampireKiller(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageVampireKiller(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageVampireKiller(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageVampireKiller(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageVampireKiller(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageVampireKiller(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageVampireKiller(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.magicNumber == 28)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageCut(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageCut(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageCut(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageCut(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageCut(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.ExpPlus(this.enemyBody.enemyLevel);
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.magicNumber == 1)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageCut(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageCut(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageCut(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageCut(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageCut(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageCut(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y, 2);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.magicNumber == 31)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageHit(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageHit(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageHit(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageHit(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageHit(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageHit(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageHit(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageHit(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageHit(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.magicNumber == 39)
						{
							switch (this.lvl)
							{
							case 1:
								this.enemyBody.RPCActionDamageMagic(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.enemyBody.RPCActionDamageMagic(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
								f = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.mineSW)
						{
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
					}
				}
				else if ((this.magicNumber == 43 || this.magicNumber == 44) && this.ReturnBool2(this.playerNumber, this.skillNumber, this.enemyBody) == 1)
				{
					if (this.magicNumber == 43 && this.canDamage)
					{
						switch (this.lvl)
						{
						case 1:
							this.enemyBody.RPCActionDamageMagic(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * this.sWDamage * this.berserk;
							break;
						case 2:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 1.2f * this.sWDamage * this.berserk;
							break;
						case 3:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 1.4f * this.sWDamage * this.berserk;
							break;
						case 4:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 1.6f * this.sWDamage * this.berserk;
							break;
						case 5:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 1.8f * this.sWDamage * this.berserk;
							break;
						case 6:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 2f * this.sWDamage * this.berserk;
							break;
						case 7:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 2.2f * this.sWDamage * this.berserk;
							break;
						case 8:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 2.4f * this.sWDamage * this.berserk;
							break;
						case 9:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 2.6f * this.sWDamage * this.berserk;
							break;
						}
						this.enemyBody.ReciveBoolReturn(0.5f, "Skill" + this.skillNumber, this.playerNumber);
					}
					if (this.magicNumber == 44)
					{
						switch (this.lvl)
						{
						case 1:
							this.enemyBody.RPCActionDamageMagic(this.iNT * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * this.sWDamage * this.berserk;
							break;
						case 2:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 1.2f * this.sWDamage * this.berserk;
							break;
						case 3:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 1.4f * this.sWDamage * this.berserk;
							break;
						case 4:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 1.6f * this.sWDamage * this.berserk;
							break;
						case 5:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 1.8f * this.sWDamage * this.berserk;
							break;
						case 6:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 2f * this.sWDamage * this.berserk;
							break;
						case 7:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 2.2f * this.sWDamage * this.berserk;
							break;
						case 8:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 2.4f * this.sWDamage * this.berserk;
							break;
						case 9:
							this.enemyBody.RPCActionDamageMagic(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x, y);
							f = this.iNT * 2.6f * this.sWDamage * this.berserk;
							break;
						}
						this.enemyBody.ReciveBoolReturn(0.5f, "Skill" + this.skillNumber, this.playerNumber);
						this.InstantiateHealBall(x, y);
					}
					if (this.mineSW)
					{
						int num2 = Mathf.RoundToInt(f);
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
				}
			}
			else if (other.tag == "EnemyBodyAttackBoss01")
			{
				this.bB = other.GetComponent<Boss01BodyDetect>();
				if (other.transform.parent.GetComponent<EnemyBody>() != null)
				{
					this.enemyBody = other.transform.parent.GetComponent<EnemyBody>();
				}
				else if (other.transform.parent.parent.GetComponent<EnemyBody>() != null)
				{
					this.enemyBody = other.transform.parent.parent.GetComponent<EnemyBody>();
				}
				Vector3 vector2 = Vector3.Lerp(base.transform.position, other.transform.position, 0.5f);
				float x2 = vector2.x;
				float y2 = vector2.y;
				float f2 = 0f;
				if (this.magicNumber == 22 || this.magicNumber == 27 || this.magicNumber == 28 || this.magicNumber == 1 || this.magicNumber == 31 || this.magicNumber == 39)
				{
					if (this.ReturnBool(this.playerNumber, this.enemyBody) == 1)
					{
						if (this.magicNumber == 22)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageDark(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageDark(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageDark(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageDark(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageDark(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageDark(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageDark(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageDark(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageDark(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.magicNumber == 27)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageVampireKiller(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageVampireKiller(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageVampireKiller(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageVampireKiller(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageVampireKiller(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageVampireKiller(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageVampireKiller(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageVampireKiller(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageVampireKiller(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.magicNumber == 28)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageCut(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageCut(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageCut(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageCut(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageCut(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageCut(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageCut(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageCut(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageCut(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.ExpPlus(this.enemyBody.enemyLevel);
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.magicNumber == 1)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageCut(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageCut(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageCut(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageCut(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageCut(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageCut(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageCut(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageCut(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageCut(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2, 2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.magicNumber == 31)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageHit(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageHit(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageHit(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageHit(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageHit(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageHit(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageHit(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageHit(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageHit(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.magicNumber == 39)
						{
							switch (this.lvl)
							{
							case 1:
								this.bB.ActionDamageMagic(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * this.sWDamage * this.berserk;
								break;
							case 2:
								this.bB.ActionDamageMagic(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
								break;
							case 3:
								this.bB.ActionDamageMagic(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
								break;
							case 4:
								this.bB.ActionDamageMagic(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
								break;
							case 5:
								this.bB.ActionDamageMagic(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
								break;
							case 6:
								this.bB.ActionDamageMagic(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2f * this.sWDamage * this.berserk;
								break;
							case 7:
								this.bB.ActionDamageMagic(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
								break;
							case 8:
								this.bB.ActionDamageMagic(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
								break;
							case 9:
								this.bB.ActionDamageMagic(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
								f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
								break;
							}
							this.enemyBody.ReciveBoolReturn(0.3f, "ATK", this.playerNumber);
						}
						if (this.mineSW)
						{
							int num3 = Mathf.RoundToInt(f2);
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
					}
				}
				else if ((this.magicNumber == 43 || this.magicNumber == 44) && this.ReturnBool2(this.playerNumber, this.skillNumber, this.enemyBody) == 1)
				{
					if (this.magicNumber == 43 && this.canDamage)
					{
						switch (this.lvl)
						{
						case 1:
							this.bB.ActionDamageMagic(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * this.sWDamage * this.berserk;
							break;
						case 2:
							this.bB.ActionDamageMagic(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
							break;
						case 3:
							this.bB.ActionDamageMagic(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
							break;
						case 4:
							this.bB.ActionDamageMagic(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
							break;
						case 5:
							this.bB.ActionDamageMagic(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
							break;
						case 6:
							this.bB.ActionDamageMagic(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 2f * this.sWDamage * this.berserk;
							break;
						case 7:
							this.bB.ActionDamageMagic(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
							break;
						case 8:
							this.bB.ActionDamageMagic(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
							break;
						case 9:
							this.bB.ActionDamageMagic(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
							break;
						}
						this.enemyBody.ReciveBoolReturn(0.5f, "Skill" + this.skillNumber, this.playerNumber);
					}
					if (this.magicNumber == 44)
					{
						switch (this.lvl)
						{
						case 1:
							this.bB.ActionDamageMagic(this.iNT * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * this.sWDamage * this.berserk;
							break;
						case 2:
							this.bB.ActionDamageMagic(this.iNT * 1.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 1.2f * this.sWDamage * this.berserk;
							break;
						case 3:
							this.bB.ActionDamageMagic(this.iNT * 1.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 1.4f * this.sWDamage * this.berserk;
							break;
						case 4:
							this.bB.ActionDamageMagic(this.iNT * 1.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 1.6f * this.sWDamage * this.berserk;
							break;
						case 5:
							this.bB.ActionDamageMagic(this.iNT * 1.8f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 1.8f * this.sWDamage * this.berserk;
							break;
						case 6:
							this.bB.ActionDamageMagic(this.iNT * 2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 2f * this.sWDamage * this.berserk;
							break;
						case 7:
							this.bB.ActionDamageMagic(this.iNT * 2.2f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 2.2f * this.sWDamage * this.berserk;
							break;
						case 8:
							this.bB.ActionDamageMagic(this.iNT * 2.4f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 2.4f * this.sWDamage * this.berserk;
							break;
						case 9:
							this.bB.ActionDamageMagic(this.iNT * 2.6f * this.sWDamage * this.berserk, this.dEX, x2, y2);
							f2 = this.iNT * 2.6f * this.sWDamage * this.berserk;
							break;
						}
						this.enemyBody.ReciveBoolReturn(0.5f, "Skill" + this.skillNumber, this.playerNumber);
						this.InstantiateHealBall(x2, y2);
					}
					if (this.mineSW)
					{
						int num4 = Mathf.RoundToInt(f2);
						if (num4 < 1)
						{
							num4 = 1;
						}
						this.playerStatus.damage += num4;
						if (!this.enemyBody.ownATKHitted)
						{
							this.enemyBody.ownATKHitted = true;
						}
					}
				}
			}
		}

		// Token: 0x06002463 RID: 9315 RVA: 0x00323650 File Offset: 0x00321850
		private void Update()
		{
			switch (this.magicNumber)
			{
			case 1:
				if (this.ownerObj != null)
				{
					if (base.transform.position != this.ownerObj.transform.position)
					{
						base.transform.position = this.ownerObj.transform.position;
					}
				}
				else if (this.ownerObj == null)
				{
					this.GameObjectFalse();
				}
				if (this.right)
				{
					if (this.ownerObj.transform.parent.localScale.x < 0f)
					{
						this.targetATKCol1.enabled = false;
						this.GameObjectFalse();
					}
					if (!this.particle1.isPlaying)
					{
						this.targetATKCol1.enabled = false;
						this.GameObjectFalse();
					}
				}
				if (this.left)
				{
					if (this.ownerObj.transform.parent.localScale.x > 0f)
					{
						this.targetATKCol2.enabled = false;
						this.GameObjectFalse();
					}
					if (!this.particle2.isPlaying)
					{
						this.targetATKCol2.enabled = false;
						this.GameObjectFalse();
					}
				}
				break;
			case 2:
				this.timer += Time.deltaTime;
				if (!this.grounded)
				{
					if (base.transform.localScale.x > 0f)
					{
						if (this.timer < 1f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
						else if (this.timer >= 1f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
					}
					else if (base.transform.localScale.x < 0f)
					{
						if (this.timer < 1f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
						else if (this.timer >= 1f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
					}
					if (this.timer > 3f && !this.destroyCheck)
					{
						this.animator.SetTrigger("Out");
						base.Invoke("GameObjectFalse", 2f);
						this.destroyCheck = true;
					}
				}
				else if (this.grounded && !this.destroyCheck)
				{
					this.instantiateManager.HitEffectEnemy(base.transform.position.x, base.transform.position.y);
					this.GameObjectFalse();
				}
				break;
			case 3:
				if (this.time > 1f && !this.destroyCheck)
				{
					this.particle1.Stop();
					this.particle2.Stop();
					this.particle3.Stop();
					this.particle4.Stop();
					this.particle5.Stop();
					this.particle6.Stop();
					this.particle7.Stop();
					this.particle8.Stop();
					base.Invoke("GameObjectFalse", 1f);
					this.destroyCheck = true;
				}
				this.particle1.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
				this.particle2.transform.position = this.BezierCurve(this.startPos2, this.targetPos, this.posHokan2, this.time);
				this.particle3.transform.position = this.BezierCurve(this.startPos3, this.targetPos, this.posHokan3, this.time);
				this.particle4.transform.position = this.BezierCurve(this.startPos4, this.targetPos, this.posHokan4, this.time);
				this.particle5.transform.position = this.BezierCurve(this.startPos5, this.targetPos, this.posHokan5, this.time);
				this.particle6.transform.position = this.BezierCurve(this.startPos6, this.targetPos, this.posHokan6, this.time);
				this.particle7.transform.position = this.BezierCurve(this.startPos7, this.targetPos, this.posHokan7, this.time);
				this.particle8.transform.position = this.BezierCurve(this.startPos8, this.targetPos, this.posHokan8, this.time);
				this.time += Time.deltaTime * 2f;
				break;
			case 4:
			{
				AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo.fullPathHash == AlucardRange.ANISTS_AgniSwordEffect_Idle && currentAnimatorStateInfo.normalizedTime > 1f)
				{
					this.targetATKCol1.enabled = false;
					this.GameObjectFalse();
				}
				break;
			}
			case 5:
				if (this.particle1.isStopped)
				{
					this.targetATKCol1.enabled = false;
					this.GameObjectFalse();
				}
				break;
			case 6:
				if (this.particle1.isStopped)
				{
					this.targetATKCol1.enabled = false;
					this.GameObjectFalse();
				}
				break;
			case 7:
			{
				AnimatorStateInfo currentAnimatorStateInfo2 = this.animator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo2.fullPathHash == AlucardRange.ANISTS_LevateinSwordEffect_Idle && currentAnimatorStateInfo2.normalizedTime > 1f)
				{
					this.targetATKCol1.enabled = false;
					this.GameObjectFalse();
				}
				break;
			}
			case 8:
				if (this.particle1.isStopped)
				{
					this.GameObjectFalse();
				}
				break;
			case 9:
			{
				AnimatorStateInfo currentAnimatorStateInfo3 = this.animator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo3.fullPathHash == AlucardRange.ANISTS_SonicBlade_Idle && currentAnimatorStateInfo3.normalizedTime > 1f)
				{
					this.GameObjectFalse();
				}
				break;
			}
			case 10:
				this.timer += Time.deltaTime;
				if (this.timer > 3f)
				{
					this.GameObjectFalse();
				}
				break;
			case 11:
				this.timer += Time.deltaTime;
				if (this.timer > 1.5f && !this.destroyCheck)
				{
					if (!this.mineSW)
					{
						this.instantiateManager.PlayerMedusaHeadBullet(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, this.posHokan, this.targetPos);
					}
					else if (this.mineSW)
					{
						this.instantiateManager.PlayerMedusaHeadBullet(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, this.posHokan, this.targetPos);
					}
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 12:
				if (this.time > 1f && !this.destroyCheck)
				{
					this.targetATKCol3.enabled = false;
					this.particle1.Stop();
					this.particle2.Stop();
					this.particle3.Stop();
					base.Invoke("GameObjectFalse", 1f);
					this.destroyCheck = true;
				}
				base.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
				this.time += Time.deltaTime * 1.2f;
				break;
			case 13:
				this.timer += Time.deltaTime;
				if (this.timer > 2f && !this.destroyCheck)
				{
					if (this.playerCtrl != null)
					{
						switch (this.lvl)
						{
						case 1:
							this.playerCtrl.StatusUpCON(10f);
							break;
						case 2:
							this.playerCtrl.StatusUpCON(15f);
							break;
						case 3:
							this.playerCtrl.StatusUpCON(20f);
							break;
						case 4:
							this.playerCtrl.StatusUpCON(25f);
							break;
						case 5:
							this.playerCtrl.StatusUpCON(30f);
							break;
						case 6:
							this.playerCtrl.StatusUpCON(35f);
							break;
						case 7:
							this.playerCtrl.StatusUpCON(40f);
							break;
						case 8:
							this.playerCtrl.StatusUpCON(45f);
							break;
						case 9:
							this.playerCtrl.StatusUpCON(50f);
							break;
						}
					}
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 14:
				this.timer += Time.deltaTime;
				if (this.timer > 2f && !this.destroyCheck)
				{
					if (this.playerCtrl != null)
					{
						switch (this.lvl)
						{
						case 1:
							this.playerCtrl.StatusUpSTR(10f);
							break;
						case 2:
							this.playerCtrl.StatusUpSTR(15f);
							break;
						case 3:
							this.playerCtrl.StatusUpSTR(20f);
							break;
						case 4:
							this.playerCtrl.StatusUpSTR(25f);
							break;
						case 5:
							this.playerCtrl.StatusUpSTR(30f);
							break;
						case 6:
							this.playerCtrl.StatusUpSTR(35f);
							break;
						case 7:
							this.playerCtrl.StatusUpSTR(40f);
							break;
						case 8:
							this.playerCtrl.StatusUpSTR(45f);
							break;
						case 9:
							this.playerCtrl.StatusUpSTR(50f);
							break;
						}
					}
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 15:
				this.timer += Time.deltaTime;
				if (this.timer > 2f && !this.destroyCheck)
				{
					if (this.playerCtrl != null)
					{
						switch (this.lvl)
						{
						case 1:
							this.playerCtrl.StatusUpINT(10f);
							break;
						case 2:
							this.playerCtrl.StatusUpINT(15f);
							break;
						case 3:
							this.playerCtrl.StatusUpINT(20f);
							break;
						case 4:
							this.playerCtrl.StatusUpINT(25f);
							break;
						case 5:
							this.playerCtrl.StatusUpINT(30f);
							break;
						case 6:
							this.playerCtrl.StatusUpINT(35f);
							break;
						case 7:
							this.playerCtrl.StatusUpINT(40f);
							break;
						case 8:
							this.playerCtrl.StatusUpINT(45f);
							break;
						case 9:
							this.playerCtrl.StatusUpINT(50f);
							break;
						}
					}
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 16:
				this.timer += Time.deltaTime;
				if (this.timer > 2f && !this.destroyCheck)
				{
					if (this.playerCtrl != null)
					{
						switch (this.lvl)
						{
						case 1:
							this.playerCtrl.StatusUpMND(10f);
							break;
						case 2:
							this.playerCtrl.StatusUpMND(15f);
							break;
						case 3:
							this.playerCtrl.StatusUpMND(20f);
							break;
						case 4:
							this.playerCtrl.StatusUpMND(25f);
							break;
						case 5:
							this.playerCtrl.StatusUpMND(30f);
							break;
						case 6:
							this.playerCtrl.StatusUpMND(35f);
							break;
						case 7:
							this.playerCtrl.StatusUpMND(40f);
							break;
						case 8:
							this.playerCtrl.StatusUpMND(45f);
							break;
						case 9:
							this.playerCtrl.StatusUpMND(50f);
							break;
						}
					}
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 17:
				this.timer += Time.deltaTime;
				if (this.timer > 2f && !this.destroyCheck)
				{
					if (this.playerCtrl != null)
					{
						switch (this.lvl)
						{
						case 1:
							this.playerCtrl.StatusUpLCK(10f);
							break;
						case 2:
							this.playerCtrl.StatusUpLCK(15f);
							break;
						case 3:
							this.playerCtrl.StatusUpLCK(20f);
							break;
						case 4:
							this.playerCtrl.StatusUpLCK(25f);
							break;
						case 5:
							this.playerCtrl.StatusUpLCK(30f);
							break;
						case 6:
							this.playerCtrl.StatusUpLCK(35f);
							break;
						case 7:
							this.playerCtrl.StatusUpLCK(40f);
							break;
						case 8:
							this.playerCtrl.StatusUpLCK(45f);
							break;
						case 9:
							this.playerCtrl.StatusUpLCK(50f);
							break;
						}
					}
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 18:
				this.timer += Time.deltaTime;
				if (this.timer > 1f && !this.action)
				{
					if (base.transform.localScale.x > 0f)
					{
						if (this.mineSW)
						{
							this.instantiateManager.PlayerShiledRodSword(base.transform.position.x, base.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1);
							this.instantiateManager.PlayerShiledRodSword2(base.transform.position.x, base.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1);
						}
						else if (!this.mineSW)
						{
							this.instantiateManager.PlayerShiledRodSword(base.transform.position.x, base.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0);
							this.instantiateManager.PlayerShiledRodSword2(base.transform.position.x, base.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0);
						}
					}
					else if (base.transform.localScale.x < 0f)
					{
						if (this.mineSW)
						{
							this.instantiateManager.PlayerShiledRodSword(base.transform.position.x, base.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1);
							this.instantiateManager.PlayerShiledRodSword2(base.transform.position.x, base.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1);
						}
						else if (!this.mineSW)
						{
							this.instantiateManager.PlayerShiledRodSword(base.transform.position.x, base.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0);
							this.instantiateManager.PlayerShiledRodSword2(base.transform.position.x, base.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0);
						}
					}
					this.action = true;
				}
				if (this.timer > 4f && !this.destroyCheck)
				{
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 19:
				this.timer += Time.deltaTime;
				if (this.timer > 2f)
				{
					if (!this.action)
					{
						this.animator.SetTrigger("Roll");
						this.action = true;
					}
					if (base.transform.localScale.x > 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
					else if (base.transform.localScale.x < 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
				}
				if (this.timer > 6f && !this.destroyCheck)
				{
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 20:
				this.timer += Time.deltaTime;
				if (this.timer > 2f)
				{
					if (!this.action)
					{
						this.animator.SetTrigger("Roll");
						this.action = true;
					}
					if (base.transform.localScale.x > 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
					else if (base.transform.localScale.x < 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
				}
				if (this.timer > 6f && !this.destroyCheck)
				{
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 21:
			{
				this.timer += Time.deltaTime;
				if (this.timer > 30f)
				{
					this.GameObjectFalse();
				}
				AnimatorStateInfo currentAnimatorStateInfo4 = this.animator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo4.fullPathHash == AlucardRange.ANISTS_ShieldRod_AxeArmor_Idle)
				{
					if (base.transform.localScale.x > 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
					else if (base.transform.localScale.x < 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
					if (this.grounded && !this.action)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
						this.targetATKCol1.enabled = false;
						this.animator.SetTrigger("ATK");
						this.action = true;
					}
				}
				if (currentAnimatorStateInfo4.fullPathHash == AlucardRange.ANISTS_ShieldRod_AxeArmor_ATK)
				{
					if (base.GetComponent<Rigidbody2D>().velocity.x != 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
					if (currentAnimatorStateInfo4.normalizedTime > 1f)
					{
						this.GameObjectFalse();
					}
				}
				break;
			}
			case 22:
			{
				AnimatorStateInfo currentAnimatorStateInfo5 = this.animator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo5.fullPathHash == AlucardRange.ANISTS_ShieldRod_Dark_Out && currentAnimatorStateInfo5.normalizedTime > 1f)
				{
					this.particle1.Stop();
					this.particle2.Stop();
					this.particle3.Stop();
					this.particle4.Stop();
					this.particle5.Stop();
					this.particle6.Stop();
					this.particle7.Stop();
					this.particle8.Stop();
					this.particle9.Stop();
					this.particle1.gameObject.SetActive(false);
					this.particle2.gameObject.SetActive(false);
					this.particle3.gameObject.SetActive(false);
					this.particle4.gameObject.SetActive(false);
					this.particle5.gameObject.SetActive(false);
					this.particle6.gameObject.SetActive(false);
					this.particle7.gameObject.SetActive(false);
					this.particle8.gameObject.SetActive(false);
					this.particle9.gameObject.SetActive(false);
					this.GameObjectFalse();
				}
				break;
			}
			case 23:
				this.timer += Time.deltaTime;
				if (this.timer > 1.5f && !this.destroyCheck)
				{
					if (this.mineSW)
					{
						this.instantiateManager.PlayerShiledRodFlame(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.posHokan, this.targetPos);
						this.instantiateManager.PlayerShiledRodFlame(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.posHokan2, this.targetPos2);
						this.instantiateManager.PlayerShiledRodFlame(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.posHokan3, this.targetPos3);
					}
					else if (!this.mineSW)
					{
						this.instantiateManager.PlayerShiledRodFlame(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.posHokan, this.targetPos);
						this.instantiateManager.PlayerShiledRodFlame(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.posHokan2, this.targetPos2);
						this.instantiateManager.PlayerShiledRodFlame(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.posHokan3, this.targetPos3);
					}
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 24:
				if (this.time > 1f && !this.destroyCheck)
				{
					this.targetATKCol3.enabled = false;
					this.particle1.Stop();
					this.particle2.Stop();
					this.particle3.Stop();
					base.Invoke("GameObjectFalse", 1f);
					this.destroyCheck = true;
				}
				base.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
				this.time += Time.deltaTime * 2f;
				break;
			case 25:
				this.timer += Time.deltaTime;
				if (this.timer > 2f && !this.action)
				{
					float num = 1f;
					switch (this.lvl)
					{
					case 2:
						num = 1.2f;
						break;
					case 3:
						num = 1.4f;
						break;
					case 4:
						num = 1.6f;
						break;
					case 5:
						num = 1.8f;
						break;
					case 6:
						num = 2f;
						break;
					case 7:
						num = 2.2f;
						break;
					case 8:
						num = 2.4f;
						break;
					case 9:
						num = 2.6f;
						break;
					}
					float aTKVal = this.iNT * num;
					if (base.transform.localScale.x > 0f)
					{
						if (!this.mineSW)
						{
							this.instantiateManager.PlayerGungnirLaser(base.transform.position.x, base.transform.position.y, this.playerNumber, 0, 0, aTKVal);
						}
						else if (this.mineSW)
						{
							this.instantiateManager.PlayerGungnirLaser(base.transform.position.x, base.transform.position.y, this.playerNumber, 0, 1, aTKVal);
						}
					}
					else if (base.transform.localScale.x < 0f)
					{
						if (!this.mineSW)
						{
							this.instantiateManager.PlayerGungnirLaser(base.transform.position.x, base.transform.position.y, this.playerNumber, 1, 0, aTKVal);
						}
						else if (this.mineSW)
						{
							this.instantiateManager.PlayerGungnirLaser(base.transform.position.x, base.transform.position.y, this.playerNumber, 1, 1, aTKVal);
						}
					}
					this.action = true;
				}
				if (this.timer > 2.5f && !this.destroyCheck)
				{
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 26:
				this.timer += Time.deltaTime;
				if (this.timer > 2f && !this.destroyCheck)
				{
					if (this.ownerObj != null)
					{
						if (base.transform.localScale.x > 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerShiledRodAlucard(this.ownerObj.transform.position.x, this.ownerObj.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber, this.ownerObj);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerShiledRodAlucard(this.ownerObj.transform.position.x, this.ownerObj.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber, this.ownerObj);
							}
						}
						else if (base.transform.localScale.x < 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerShiledRodAlucard(this.ownerObj.transform.position.x, this.ownerObj.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber, this.ownerObj);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerShiledRodAlucard(this.ownerObj.transform.position.x, this.ownerObj.transform.position.y + 0.5f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber, this.ownerObj);
							}
						}
					}
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 27:
				this.timer += Time.deltaTime;
				if (this.timer > 10f && !this.destroyCheck)
				{
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				if (this.ownerObj != null)
				{
					if (base.transform.position != this.ownerObj.transform.position)
					{
						base.transform.position = this.ownerObj.transform.position;
					}
				}
				else if (this.ownerObj == null)
				{
					this.GameObjectFalse();
				}
				break;
			case 28:
				this.timer += Time.deltaTime;
				if (base.transform.localScale.x > 0f)
				{
					if (this.timer < 1f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
					else if (this.timer >= 1f)
					{
						if (!this.action)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
							this.animator.SetTrigger("ATK");
							this.action = true;
						}
						AnimatorStateInfo currentAnimatorStateInfo6 = this.animator.GetCurrentAnimatorStateInfo(0);
						if (currentAnimatorStateInfo6.fullPathHash == AlucardRange.ANISTS_TsukaimaNoKen_Idle && currentAnimatorStateInfo6.normalizedTime > 1f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
					}
				}
				else if (base.transform.localScale.x < 0f)
				{
					if (this.timer < 1f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
					else if (this.timer >= 1f)
					{
						if (!this.action)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
							this.animator.SetTrigger("ATK");
							this.action = true;
						}
						AnimatorStateInfo currentAnimatorStateInfo7 = this.animator.GetCurrentAnimatorStateInfo(0);
						if (currentAnimatorStateInfo7.fullPathHash == AlucardRange.ANISTS_TsukaimaNoKen_Idle && currentAnimatorStateInfo7.normalizedTime > 1f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
					}
				}
				if (this.timer > 3.5f && !this.destroyCheck)
				{
					this.animator.SetTrigger("Out");
					base.Invoke("GameObjectFalse", 2f);
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
					this.destroyCheck = true;
				}
				break;
			case 29:
				this.timer += Time.deltaTime;
				if (this.timer > 2f && !this.action)
				{
					switch (this.lvl)
					{
					case 1:
						if (base.transform.localScale.x > 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
							}
						}
						else if (base.transform.localScale.x < 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
							}
						}
						break;
					case 2:
						if (base.transform.localScale.x > 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 2);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 2);
							}
						}
						else if (base.transform.localScale.x < 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 2);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 2);
							}
						}
						break;
					case 3:
						if (base.transform.localScale.x > 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0);
							}
						}
						else if (base.transform.localScale.x < 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0);
							}
						}
						break;
					case 4:
						if (base.transform.localScale.x > 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
							}
						}
						else if (base.transform.localScale.x < 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
							}
						}
						break;
					case 5:
						if (base.transform.localScale.x > 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
							}
						}
						else if (base.transform.localScale.x < 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
							}
						}
						break;
					case 6:
						if (base.transform.localScale.x > 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
							}
						}
						else if (base.transform.localScale.x < 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
							}
						}
						break;
					case 7:
						if (base.transform.localScale.x > 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
							}
						}
						else if (base.transform.localScale.x < 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer1(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
							}
						}
						break;
					case 8:
						if (base.transform.localScale.x > 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
							}
						}
						else if (base.transform.localScale.x < 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer2(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
							}
						}
						break;
					case 9:
						if (base.transform.localScale.x > 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter3(base.transform.position.x + 0.5f, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter3(base.transform.position.x + 0.5f, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.playerNumber);
							}
						}
						else if (base.transform.localScale.x < 0f)
						{
							if (this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter3(base.transform.position.x - 0.5f, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.playerNumber);
							}
							else if (!this.mineSW)
							{
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Fighter3(base.transform.position.x - 0.5f, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 1);
								this.instantiateManager.PlayerAkatsukiNoKen_Archer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, 2);
								this.instantiateManager.PlayerAkatsukiNoKen_Magician3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0);
								this.instantiateManager.PlayerAkatsukiNoKen_Soccer3(base.transform.position.x, base.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.playerNumber);
							}
						}
						break;
					}
					this.action = true;
				}
				if (this.timer > 2.5f && !this.destroyCheck)
				{
					base.Invoke("GameObjectFalse", 1f);
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			case 30:
			{
				AnimatorStateInfo currentAnimatorStateInfo8 = this.animator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo8.fullPathHash == AlucardRange.AkatsukiNoKen_Soccer_Idle && currentAnimatorStateInfo8.normalizedTime > 1f)
				{
					this.GameObjectFalse();
				}
				this.timer += Time.deltaTime;
				if (this.grounded && !this.action)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
					this.eSE.SoundEffectPlay(0);
					this.particle1.Play();
					this.animator.SetTrigger("Out");
					this.action = true;
				}
				if (this.timer > 10f && !this.action && !this.destroyCheck)
				{
					this.GameObjectFalse();
					this.destroyCheck = true;
				}
				break;
			}
			case 31:
			{
				AnimatorStateInfo currentAnimatorStateInfo9 = this.animator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo9.fullPathHash == AlucardRange.AkastukiNoKen_Fighter_Out && currentAnimatorStateInfo9.normalizedTime > 1f)
				{
					this.GameObjectFalse();
				}
				if (this.action)
				{
					this.timer2 += Time.deltaTime;
					if (currentAnimatorStateInfo9.fullPathHash == AlucardRange.AkastukiNoKen_Fighter_Idle)
					{
						if (base.transform.localScale.x > 0f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
						else if (base.transform.localScale.x < 0f)
						{
							base.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, base.GetComponent<Rigidbody2D>().velocity.y);
						}
					}
				}
				this.timer += Time.deltaTime;
				if (this.grounded && !this.action)
				{
					this.eSE.SoundEffectPlay(0);
					this.particle1.Play();
					this.animator.SetTrigger("In");
					this.action = true;
				}
				if (this.timer > 10f && !this.action && !this.destroyCheck)
				{
					this.GameObjectFalse();
					this.destroyCheck = true;
				}
				if (this.timer2 > 10f && !this.destroyCheck)
				{
					this.animator.SetTrigger("Out");
					this.destroyCheck = true;
				}
				break;
			}
			case 32:
			{
				AnimatorStateInfo currentAnimatorStateInfo10 = this.animator.GetCurrentAnimatorStateInfo(0);
				if ((currentAnimatorStateInfo10.fullPathHash == AlucardRange.AkatsukiNoken_Archer_Idle || currentAnimatorStateInfo10.fullPathHash == AlucardRange.AkatsukiNoken_Archer_Idle2) && currentAnimatorStateInfo10.normalizedTime > 1f)
				{
					this.GameObjectFalse();
				}
				this.timer += Time.deltaTime;
				if (this.grounded && !this.action)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
					this.eSE.SoundEffectPlay(0);
					this.particle1.Play();
					int num2 = this.count;
					if (num2 != 1)
					{
						if (num2 == 2)
						{
							this.animator.SetTrigger("In2");
						}
					}
					else
					{
						this.animator.SetTrigger("In");
					}
					this.action = true;
				}
				if (this.timer > 10f && !this.destroyCheck)
				{
					this.GameObjectFalse();
					this.destroyCheck = true;
				}
				break;
			}
			case 33:
			{
				AnimatorStateInfo currentAnimatorStateInfo11 = this.animator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo11.fullPathHash == AlucardRange.AkatsukiNoKen_Magician_Out && currentAnimatorStateInfo11.normalizedTime > 1f)
				{
					this.GameObjectFalse();
				}
				this.timer += Time.deltaTime;
				if (this.grounded && !this.getTarget)
				{
					this.posHokan = this.hokanPosObj1.transform.position;
					this.posHokan2 = this.hokanPosObj2.transform.position;
					this.posHokan3 = this.hokanPosObj3.transform.position;
					if (base.transform.localScale.x > 0f)
					{
						this.targetPos = new Vector2(this.hokanPosObj1.transform.position.x - 5f, this.hokanPosObj1.transform.position.y);
						this.targetPos2 = new Vector2(this.hokanPosObj2.transform.position.x - 5f, this.hokanPosObj2.transform.position.y);
						this.targetPos3 = new Vector2(this.hokanPosObj3.transform.position.x - 5f, this.hokanPosObj3.transform.position.y);
					}
					else if (base.transform.localScale.x < 0f)
					{
						this.targetPos = new Vector2(this.hokanPosObj1.transform.position.x + 5f, this.hokanPosObj1.transform.position.y);
						this.targetPos2 = new Vector2(this.hokanPosObj2.transform.position.x + 5f, this.hokanPosObj2.transform.position.y);
						this.targetPos3 = new Vector2(this.hokanPosObj3.transform.position.x + 5f, this.hokanPosObj3.transform.position.y);
					}
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
					this.eSE.SoundEffectPlay(0);
					this.particle1.Play();
					this.animator.SetTrigger("Out");
					this.getTarget = true;
				}
				if (this.timer > 10f && !this.action && !this.destroyCheck)
				{
					this.GameObjectFalse();
					this.destroyCheck = true;
				}
				break;
			}
			case 34:
			{
				AnimatorStateInfo currentAnimatorStateInfo12 = this.animator.GetCurrentAnimatorStateInfo(0);
				if (currentAnimatorStateInfo12.fullPathHash == AlucardRange.AkatsukiNoKen_Magician_Arrow_Out && currentAnimatorStateInfo12.normalizedTime > 1f)
				{
					this.GameObjectFalse();
				}
				if (currentAnimatorStateInfo12.fullPathHash == AlucardRange.AkatsukiNoKen_Magician_Arrow_In && currentAnimatorStateInfo12.normalizedTime > 1f)
				{
					if (this.time > 1f && !this.destroyCheck)
					{
						this.animator.SetTrigger("Out");
						base.Invoke("GameObjectFalse", 1f);
						this.destroyCheck = true;
					}
					base.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
					this.time += Time.deltaTime * 1f;
				}
				break;
			}
			case 35:
				if (this.particle1.isStopped)
				{
					this.GameObjectFalse();
				}
				break;
			case 36:
				if (this.particle1.isStopped)
				{
					this.GameObjectFalse();
				}
				break;
			case 37:
				this.timer += Time.deltaTime;
				if (this.timer > this.timeLimit && !this.action)
				{
					this.eSE.SoundEffectPlay(0);
					this.animator.SetTrigger("ATK");
					this.action = true;
				}
				if (this.action)
				{
					if (this.time > 1f && !this.destroyCheck)
					{
						this.animator.SetTrigger("Out");
						base.Invoke("GameObjectFalse", 1f);
						this.destroyCheck = true;
					}
					base.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
					this.time += Time.deltaTime * 2.5f;
				}
				break;
			case 38:
			{
				AnimatorStateInfo currentAnimatorStateInfo13 = this.animator.GetCurrentAnimatorStateInfo(0);
				if (!this.action)
				{
					if (this.time > 1f && !this.action)
					{
						this.action = true;
					}
					base.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
					this.time += Time.deltaTime * 2.5f;
				}
				if (this.action)
				{
					this.timer += Time.deltaTime;
					if (this.timer > 10f)
					{
						this.GameObjectFalse();
					}
					if (currentAnimatorStateInfo13.fullPathHash == AlucardRange.RuneSword_Idle && currentAnimatorStateInfo13.normalizedTime > 1f)
					{
						Vector2 vector = new Vector2(base.transform.position.x, base.transform.position.y);
						Vector2 target = new Vector2(this.ownerObj.transform.position.x, this.ownerObj.transform.position.y + 0.4f);
						base.transform.position = Vector2.MoveTowards(base.transform.position, target, 3f * Time.deltaTime);
					}
				}
				break;
			}
			case 39:
				if (!this.action)
				{
					if (this.time > 1f && !this.action)
					{
						this.action = true;
					}
					base.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
					this.time += Time.deltaTime * 1.5f;
				}
				if (this.action)
				{
					this.timer += Time.deltaTime;
					if (this.timer > 4f && !this.destroyCheck)
					{
						this.particle1.Stop();
						this.animator.SetTrigger("Out");
						base.Invoke("GameObjectFalse", 1f);
						this.destroyCheck = true;
					}
				}
				break;
			case 40:
				if (!this.action)
				{
					if (this.time > 1f && !this.action)
					{
						this.action = true;
					}
					base.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
					this.time += Time.deltaTime * 1f;
				}
				if (this.action)
				{
					this.timer += Time.deltaTime;
					if (this.timer > 1f && !this.getTarget)
					{
						this.eSE.SoundEffectPlay(1);
						this.particle1.Play();
						this.animator.SetTrigger("In");
						this.getTarget = true;
					}
					if (this.getTarget)
					{
						if (this.grounded)
						{
							if (!this.destroyCheck)
							{
								this.eSE.SoundEffectPlay(2);
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
								this.particle1.Stop();
								this.particle2.Play();
								this.animator.SetTrigger("Out");
								base.Invoke("GameObjectFalse", 1f);
								this.destroyCheck = true;
							}
						}
						else if (!this.grounded)
						{
							if (base.transform.localScale.x > 0f)
							{
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, base.GetComponent<Rigidbody2D>().velocity.y);
							}
							else if (base.transform.localScale.x < 0f)
							{
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(3f, base.GetComponent<Rigidbody2D>().velocity.y);
							}
							if (this.timer > 10f && !this.destroyCheck)
							{
								this.eSE.SoundEffectPlay(2);
								base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
								this.particle1.Stop();
								this.particle2.Play();
								this.animator.SetTrigger("Out");
								base.Invoke("GameObjectFalse", 1f);
								this.destroyCheck = true;
							}
						}
					}
				}
				break;
			case 41:
				this.timer += Time.deltaTime;
				if (this.grounded || this.hitedATK)
				{
					if (!this.destroyCheck)
					{
						this.eSE.SoundEffectPlay(1);
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
						this.particle1.Stop();
						this.particle2.Stop();
						this.particle3.Play();
						this.targetATKCol3.enabled = false;
						base.Invoke("GameObjectFalse", 1f);
						this.destroyCheck = true;
					}
				}
				else if (!this.grounded)
				{
					if (base.transform.localScale.x > 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
					else if (base.transform.localScale.x < 0f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, base.GetComponent<Rigidbody2D>().velocity.y);
					}
					if (this.timer > 10f && !this.destroyCheck)
					{
						this.eSE.SoundEffectPlay(1);
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
						this.particle1.Stop();
						this.particle2.Stop();
						this.particle3.Play();
						this.targetATKCol3.enabled = false;
						base.Invoke("GameObjectFalse", 1f);
						this.destroyCheck = true;
					}
				}
				break;
			case 42:
				if (!this.action)
				{
					if (this.time > 1f && !this.action)
					{
						this.particle1.Stop();
						this.particle2.Stop();
						this.targetATKCol3.enabled = false;
						this.action = true;
					}
					base.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
					this.time += Time.deltaTime * 2.5f;
				}
				if (this.particle1.isStopped)
				{
					this.GameObjectFalse();
				}
				break;
			case 43:
				if (!this.action)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, 0.3f);
					this.timer += Time.deltaTime;
					if (this.timer > 1f)
					{
						this.targetATKCol3.enabled = true;
						this.getTarget = true;
					}
				}
				if (this.getTarget)
				{
					this.timer2 += Time.deltaTime;
					if (this.timer2 > 1f && !this.action)
					{
						this.targetATKCol3.enabled = false;
						this.particle1.Stop();
					}
				}
				if (this.action)
				{
					this.canDamage = true;
					if (this.time > 1f)
					{
						this.particle1.Stop();
					}
					base.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
					this.time += Time.deltaTime * 0.5f;
				}
				if (this.particle1.isStopped)
				{
					this.GameObjectFalse();
				}
				break;
			case 44:
				this.timer += Time.deltaTime;
				if (this.timer > 4f && this.particle1.isPlaying)
				{
					this.particle1.Stop();
					this.particle2.Stop();
					this.particle3.Stop();
					this.particle4.Stop();
				}
				if (this.particle1.isStopped)
				{
					this.GameObjectFalse();
				}
				break;
			}
		}

		// Token: 0x06002464 RID: 9316 RVA: 0x0032A6D8 File Offset: 0x003288D8
		private void FixedUpdate()
		{
			this.grounded = false;
			this.inWater = false;
			if (this.groundCheck_C != null)
			{
				this.gccMax[0] = Physics2D.OverlapPointNonAlloc(this.groundCheck_L.position, this.groundCheckCollider[0]);
				this.gccMax[1] = Physics2D.OverlapPointNonAlloc(this.groundCheck_C.position, this.groundCheckCollider[1]);
				this.gccMax[2] = Physics2D.OverlapPointNonAlloc(this.groundCheck_R.position, this.groundCheckCollider[2]);
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < this.gccMax[i]; j++)
					{
						if (this.groundCheckCollider[i][j] != null && !this.groundCheckCollider[i][j].isTrigger)
						{
							if (this.groundCheckCollider[i][j].tag == "Road" || this.groundCheckCollider[i][j].tag == "Slope" || this.groundCheckCollider[i][j].tag == "EventGround" || this.groundCheckCollider[i][j].tag == "PassThroughCollider")
							{
								this.grounded = true;
							}
							else if (this.groundCheckCollider[i][j].tag == "Water")
							{
								this.inWater = true;
							}
						}
					}
				}
			}
		}

		// Token: 0x06002465 RID: 9317 RVA: 0x0032A870 File Offset: 0x00328A70
		public void Action()
		{
			switch (this.magicNumber)
			{
			case 1:
				this.eSE.SoundEffectPlay(0);
				if (this.right)
				{
					this.particle1.Play();
					this.targetATKCol1.enabled = true;
					this.targetATKCol2.enabled = false;
				}
				if (this.left)
				{
					this.particle2.Play();
					this.targetATKCol2.enabled = true;
					this.targetATKCol1.enabled = false;
				}
				break;
			case 2:
				this.animator.ResetTrigger("Out");
				break;
			case 3:
				this.eSE.SoundEffectPlay(0);
				this.targetPos = base.transform.position;
				this.startPos = this.startPosObj1.transform.position;
				this.startPos2 = this.startPosObj2.transform.position;
				this.startPos3 = this.startPosObj3.transform.position;
				this.startPos4 = this.startPosObj4.transform.position;
				this.startPos5 = this.startPosObj5.transform.position;
				this.startPos6 = this.startPosObj6.transform.position;
				this.startPos7 = this.startPosObj7.transform.position;
				this.startPos8 = this.startPosObj8.transform.position;
				this.posHokan = this.hokanPosObj1.transform.position;
				this.posHokan2 = this.hokanPosObj2.transform.position;
				this.posHokan3 = this.hokanPosObj3.transform.position;
				this.posHokan4 = this.hokanPosObj4.transform.position;
				this.posHokan5 = this.hokanPosObj5.transform.position;
				this.posHokan6 = this.hokanPosObj6.transform.position;
				this.posHokan7 = this.hokanPosObj7.transform.position;
				this.posHokan8 = this.hokanPosObj8.transform.position;
				this.particle1.transform.position = this.startPos;
				this.particle2.transform.position = this.startPos2;
				this.particle3.transform.position = this.startPos3;
				this.particle4.transform.position = this.startPos4;
				this.particle5.transform.position = this.startPos5;
				this.particle6.transform.position = this.startPos6;
				this.particle7.transform.position = this.startPos7;
				this.particle8.transform.position = this.startPos8;
				this.particle1.Play();
				this.particle2.Play();
				this.particle3.Play();
				this.particle4.Play();
				this.particle5.Play();
				this.particle6.Play();
				this.particle7.Play();
				this.particle8.Play();
				break;
			case 4:
				this.animator.Play("AgniSwordEffect_Idle");
				this.targetATKCol1.enabled = true;
				this.animator.speed = 4f;
				break;
			case 5:
				this.eSE.SoundEffectPlay(0);
				this.particle1.Play();
				this.particle2.Play();
				this.targetATKCol1.enabled = true;
				break;
			case 6:
				this.eSE.SoundEffectPlay(0);
				this.particle1.Play();
				this.targetATKCol1.enabled = true;
				break;
			case 7:
				this.eSE.SoundEffectPlay(0);
				this.animator.Play("LevateinSwordEffect_Idle");
				this.targetATKCol1.enabled = true;
				break;
			case 8:
				this.eSE.SoundEffectPlay(0);
				this.particle1.Play();
				this.particle2.Play();
				this.particle3.Play();
				this.particle4.Play();
				break;
			case 9:
				this.eSE.SoundEffectPlay(0);
				this.animator.Play("SonicBlade_Idle");
				if (this.count == 0)
				{
					base.transform.localScale = new Vector2(base.transform.localScale.x, 1f);
				}
				else if (this.count == 1)
				{
					base.transform.localScale = new Vector2(base.transform.localScale.x, -1f);
				}
				break;
			case 10:
				this.eSE.SoundEffectPlay(0);
				break;
			case 11:
				this.posHokan = this.hokanPosObj1.transform.position;
				if (base.transform.localScale.x > 0f)
				{
					this.targetPos = new Vector2(this.hokanPosObj1.transform.position.x + 5f, this.hokanPosObj1.transform.position.y);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.targetPos = new Vector2(this.hokanPosObj1.transform.position.x - 5f, this.hokanPosObj1.transform.position.y);
				}
				this.animator.Play("MedusaHeadParent_Idle");
				this.animator.ResetTrigger("Out");
				this.eSE.SoundEffectPlay(0);
				break;
			case 12:
				this.particle1.Play();
				this.particle2.Play();
				this.particle3.Play();
				this.targetATKCol3.enabled = true;
				this.startPos = base.transform.position;
				this.eSE.SoundEffectPlay(0);
				break;
			case 13:
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShiledRod_Cow_In");
				this.eSE.SoundEffectPlay(0);
				break;
			case 14:
				this.particle1.Play();
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShiledRod_Cow_In");
				this.eSE.SoundEffectPlay(0);
				break;
			case 15:
				this.particle1.Play();
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShiledRod_Cow_In");
				this.eSE.SoundEffectPlay(0);
				break;
			case 16:
				this.particle1.Play();
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShiledRod_Cow_In");
				this.eSE.SoundEffectPlay(0);
				break;
			case 17:
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShiledRod_Cow_In");
				this.eSE.SoundEffectPlay(0);
				break;
			case 18:
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShiledRod_Cow_In");
				this.eSE.SoundEffectPlay(0);
				break;
			case 19:
				this.animator.ResetTrigger("Out");
				this.animator.ResetTrigger("Roll");
				this.animator.Play("ShieldRod_Sword_Spawn");
				this.eSE.SoundEffectPlay(0);
				break;
			case 20:
				this.animator.ResetTrigger("Out");
				this.animator.ResetTrigger("Roll");
				this.animator.Play("ShieldRod_Sword_Spawn");
				break;
			case 21:
				this.animator.ResetTrigger("ATK");
				this.animator.Play("ShieldRod_AxeArmor_In");
				this.targetATKCol1.enabled = true;
				this.eSE.SoundEffectPlay(0);
				break;
			case 22:
				this.eSE.SoundEffectPlay(0);
				this.particle1.Stop();
				this.particle2.Stop();
				this.particle3.Stop();
				this.particle4.Stop();
				this.particle5.Stop();
				this.particle6.Stop();
				this.particle7.Stop();
				this.particle8.Stop();
				this.particle9.Stop();
				this.particle1.gameObject.SetActive(true);
				this.particle2.gameObject.SetActive(true);
				this.particle3.gameObject.SetActive(true);
				this.particle4.gameObject.SetActive(true);
				this.particle5.gameObject.SetActive(true);
				this.particle6.gameObject.SetActive(true);
				this.particle7.gameObject.SetActive(true);
				this.particle8.gameObject.SetActive(true);
				this.particle9.gameObject.SetActive(true);
				break;
			case 23:
				this.posHokan = this.hokanPosObj1.transform.position;
				this.posHokan2 = this.hokanPosObj2.transform.position;
				this.posHokan3 = this.hokanPosObj3.transform.position;
				if (base.transform.localScale.x > 0f)
				{
					this.targetPos = new Vector2(this.hokanPosObj1.transform.position.x + 5f, this.hokanPosObj1.transform.position.y);
					this.targetPos2 = new Vector2(this.hokanPosObj2.transform.position.x + 5f, this.hokanPosObj2.transform.position.y);
					this.targetPos3 = new Vector2(this.hokanPosObj3.transform.position.x + 5f, this.hokanPosObj3.transform.position.y);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.targetPos = new Vector2(this.hokanPosObj1.transform.position.x - 5f, this.hokanPosObj1.transform.position.y);
					this.targetPos2 = new Vector2(this.hokanPosObj2.transform.position.x - 5f, this.hokanPosObj2.transform.position.y);
					this.targetPos3 = new Vector2(this.hokanPosObj3.transform.position.x - 5f, this.hokanPosObj3.transform.position.y);
				}
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShiledRod_Cow_In");
				this.eSE.SoundEffectPlay(0);
				break;
			case 24:
				this.startPos = base.transform.position;
				this.targetATKCol3.enabled = true;
				this.particle1.Play();
				this.particle2.Play();
				this.particle3.Play();
				this.eSE.SoundEffectPlay(0);
				break;
			case 25:
				this.particle1.Play();
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShiledRod_Cow_In");
				this.eSE.SoundEffectPlay(0);
				break;
			case 26:
				this.particle1.Play();
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShiledRod_Cow_In");
				this.eSE.SoundEffectPlay(0);
				break;
			case 27:
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShieldRod_Alucard_In");
				break;
			case 28:
				if (this.lvl < 9)
				{
					this.spriteRen.sprite = this.sprite1;
				}
				if (this.lvl >= 9)
				{
					this.spriteRen.sprite = this.sprite2;
				}
				this.animator.ResetTrigger("Out");
				this.animator.ResetTrigger("ATK");
				this.animator.Play("TsukaimaNoKen_In");
				this.eSE.SoundEffectPlay(0);
				break;
			case 29:
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShiledRod_Cow_In");
				break;
			case 30:
				if (base.transform.localScale.x > 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, -1f);
				}
				else if (base.transform.localScale.x < 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, -1f);
				}
				this.animator.ResetTrigger("Out");
				this.animator.Play("AkatsukiNoKen_Soccer_In");
				break;
			case 31:
				this.animator.ResetTrigger("Out");
				this.animator.ResetTrigger("In");
				this.animator.Play("AkatsukiNoKen_Fighter_Before");
				break;
			case 32:
				if (base.transform.localScale.x > 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.3f, -1f);
				}
				else if (base.transform.localScale.x < 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(0.3f, -1f);
				}
				this.animator.ResetTrigger("In");
				this.animator.ResetTrigger("In2");
				this.animator.Play("AkatsukiNoken_Archer_In");
				break;
			case 33:
				if (base.transform.localScale.x > 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.2f, -1f);
				}
				else if (base.transform.localScale.x < 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(0.2f, -1f);
				}
				this.animator.ResetTrigger("Out");
				this.animator.Play("AkatsukiNoKen_Magician_In");
				break;
			case 34:
				this.startPos = base.transform.position;
				this.animator.ResetTrigger("Out");
				this.animator.Play("AkatsukiNoKen_Magician_Arrow_In");
				break;
			case 35:
				this.particle1.Play();
				this.eSE.SoundEffectPlay(0);
				break;
			case 36:
				this.particle1.Play();
				this.eSE.SoundEffectPlay(0);
				break;
			case 37:
				this.startPos = base.transform.position;
				this.animator.ResetTrigger("Out");
				this.animator.ResetTrigger("ATK");
				this.animator.Play("HeavensSwordSkill_Idle");
				break;
			case 38:
				this.startPos = base.transform.position;
				this.animator.ResetTrigger("Out");
				this.animator.Play("RuneSword_Idle");
				break;
			case 39:
				this.eSE.SoundEffectPlay(0);
				this.particle1.Play();
				this.startPos = base.transform.position;
				this.animator.ResetTrigger("Out");
				this.animator.Play("ShieldRod_In");
				break;
			case 40:
				this.eSE.SoundEffectPlay(0);
				this.startPos = base.transform.position;
				this.animator.ResetTrigger("Out");
				this.animator.ResetTrigger("In");
				this.animator.Play("MoonRodRange_In");
				break;
			case 41:
				this.eSE.SoundEffectPlay(0);
				this.particle1.Play();
				this.particle2.Play();
				this.targetATKCol3.enabled = true;
				break;
			case 42:
				this.startPos = base.transform.position;
				this.eSE.SoundEffectPlay(0);
				this.particle1.Play();
				this.particle2.Play();
				this.targetATKCol3.enabled = true;
				break;
			case 43:
				this.eSE.SoundEffectPlay(0);
				this.particle1.Play();
				this.targetATKCol3.enabled = false;
				break;
			case 44:
				this.eSE.SoundEffectPlay(0);
				this.particle1.Play();
				this.particle2.Play();
				this.particle3.Play();
				this.particle4.Play();
				break;
			}
			this.targetObj = null;
			this.time = 0f;
			this.enemyBody = null;
			this.currentEnemyBody = null;
			this.bB = null;
			this.currentBB = null;
			this.timer = 0f;
			this.timer2 = 0f;
			this.destroyCheck = false;
			this.hitedATK = false;
			this.canVelo = false;
			this.grounded = false;
			this.inWater = false;
			this.hitted = false;
			this.action = false;
			this.canDamage = false;
			this.getTarget = false;
		}

		// Token: 0x06002466 RID: 9318 RVA: 0x0032BB64 File Offset: 0x00329D64
		public void CallSound()
		{
			int num = this.magicNumber;
			if (num == 2)
			{
				if (this.timer < 3f)
				{
					this.eSE.SoundEffectPlay(0);
				}
			}
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x0032BBA8 File Offset: 0x00329DA8
		public void CallAction()
		{
			int num = this.magicNumber;
			switch (num)
			{
			case 30:
				if (base.transform.localScale.x > 0f)
				{
					if (this.mineSW)
					{
						this.instantiateManager.PlayerDarkInferno(base.transform.position.x, base.transform.position.y + 0.8f, this.playerNumber, 1, this.lvl, 1, 1);
					}
					else if (!this.mineSW)
					{
						this.instantiateManager.PlayerDarkInferno(base.transform.position.x, base.transform.position.y + 0.8f, this.playerNumber, 1, this.lvl, 1, 0);
					}
				}
				else if (base.transform.localScale.x < 0f)
				{
					if (this.mineSW)
					{
						this.instantiateManager.PlayerDarkInferno(base.transform.position.x, base.transform.position.y + 0.8f, this.playerNumber, 1, this.lvl, 0, 1);
					}
					else if (!this.mineSW)
					{
						this.instantiateManager.PlayerDarkInferno(base.transform.position.x, base.transform.position.y + 0.8f, this.playerNumber, 1, this.lvl, 0, 0);
					}
				}
				break;
			default:
				if (num != 21)
				{
					if (num == 22)
					{
						this.particle1.Play();
						this.particle2.Play();
						this.particle3.Play();
						this.particle4.Play();
						this.particle5.Play();
						this.particle6.Play();
						this.particle7.Play();
						this.particle8.Play();
						this.particle9.Play();
					}
				}
				else
				{
					this.hitedATK = false;
					this.canDamage = true;
				}
				break;
			case 32:
				if (base.transform.localScale.x > 0f)
				{
					if (this.mineSW)
					{
						this.instantiateManager.PlayerArrowSniperArrow(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1f, 1, 1);
					}
					else if (!this.mineSW)
					{
						this.instantiateManager.PlayerArrowSniperArrow(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1f, 1, 0);
					}
				}
				else if (base.transform.localScale.x < 0f)
				{
					if (this.mineSW)
					{
						this.instantiateManager.PlayerArrowSniperArrow(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1f, 0, 1);
					}
					else if (!this.mineSW)
					{
						this.instantiateManager.PlayerArrowSniperArrow(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.lvl, this.iNT, this.dEX, this.berserk, 1f, 0, 0);
					}
				}
				break;
			case 33:
				if (base.transform.localScale.x > 0f)
				{
					if (this.mineSW)
					{
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.posHokan, this.targetPos);
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.posHokan2, this.targetPos2);
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 1, this.posHokan3, this.targetPos3);
					}
					else if (!this.mineSW)
					{
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.posHokan, this.targetPos);
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.posHokan2, this.targetPos2);
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 0, 0, this.posHokan3, this.targetPos3);
					}
				}
				else if (base.transform.localScale.x < 0f)
				{
					if (this.mineSW)
					{
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.posHokan, this.targetPos);
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.posHokan2, this.targetPos2);
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 1, this.posHokan3, this.targetPos3);
					}
					else if (!this.mineSW)
					{
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.posHokan, this.targetPos);
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.posHokan2, this.targetPos2);
						this.instantiateManager.PlayerAkatsukiNoKenArrow(base.transform.position.x, base.transform.position.y + 1f, this.lvl, this.iNT, this.dEX, this.berserk, 1, 0, this.posHokan3, this.targetPos3);
					}
				}
				break;
			}
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x0032C4F0 File Offset: 0x0032A6F0
		private Vector3 BezierCurve(Vector3 pt1, Vector3 pt2, Vector3 ctrlPt, float t)
		{
			if (t > 1f)
			{
				t = 1f;
			}
			Vector3 result = default(Vector3);
			float num = 1f - t;
			result.x = num * num * pt1.x + 2f * num * t * ctrlPt.x + t * t * pt2.x;
			result.y = num * num * pt1.y + 2f * num * t * ctrlPt.y + t * t * pt2.y;
			result.z = num * num * pt1.z + 2f * num * t * ctrlPt.z + t * t * pt2.z;
			return result;
		}

		// Token: 0x06002469 RID: 9321 RVA: 0x0032C5BC File Offset: 0x0032A7BC
		private void ExpPlus(int lvl)
		{
			if (this.mineSW)
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

		// Token: 0x0600246A RID: 9322 RVA: 0x0032C6E8 File Offset: 0x0032A8E8
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

		// Token: 0x0600246B RID: 9323 RVA: 0x0032C7F8 File Offset: 0x0032A9F8
		private int ReturnBool2(int num, int skillNum, EnemyBody targetEnemyBody)
		{
			int num2 = 0;
			switch (num)
			{
			case 1:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft)
					{
						num2++;
					}
					break;
				}
				break;
			case 2:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp1)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown1)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight1)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft1)
					{
						num2++;
					}
					break;
				}
				break;
			case 3:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp2)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown2)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight2)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft2)
					{
						num2++;
					}
					break;
				}
				break;
			case 4:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp3)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown3)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight3)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft3)
					{
						num2++;
					}
					break;
				}
				break;
			case 5:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp4)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown4)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight4)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft4)
					{
						num2++;
					}
					break;
				}
				break;
			case 6:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp5)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown5)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight5)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft5)
					{
						num2++;
					}
					break;
				}
				break;
			case 7:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp6)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown6)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight6)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft6)
					{
						num2++;
					}
					break;
				}
				break;
			case 8:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp7)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown7)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight7)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft7)
					{
						num2++;
					}
					break;
				}
				break;
			case 9:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp8)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown8)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight8)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft8)
					{
						num2++;
					}
					break;
				}
				break;
			case 10:
				switch (skillNum)
				{
				case 1:
					if (!targetEnemyBody.canRecive_SkillUp9)
					{
						num2++;
					}
					break;
				case 2:
					if (!targetEnemyBody.canRecive_SkillDown9)
					{
						num2++;
					}
					break;
				case 3:
					if (!targetEnemyBody.canRecive_SkillRight9)
					{
						num2++;
					}
					break;
				case 4:
					if (!targetEnemyBody.canRecive_SkillLeft9)
					{
						num2++;
					}
					break;
				}
				break;
			}
			return num2;
		}

		// Token: 0x0600246C RID: 9324 RVA: 0x0032CCB4 File Offset: 0x0032AEB4
		private void InstantiateHealBall(float x, float y)
		{
			float num = Mathf.Round(this.iNT * this.berserk);
			num /= 10f;
			int num2 = Mathf.RoundToInt(num);
			Debug.Log(num2);
			if (num2 < 1)
			{
				num2 = 1;
			}
			if (this.ownerObj != null)
			{
				this.instantiateManager.PlayerBloodyCroosHealOrb(x, y, num2, this.ownerObj);
			}
		}

		// Token: 0x0600246D RID: 9325 RVA: 0x0032CD1D File Offset: 0x0032AF1D
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x0400401E RID: 16414
		public static readonly int ANISTS_AgniSwordEffect_Idle = Animator.StringToHash("Base Layer.AgniSwordEffect_Idle");

		// Token: 0x0400401F RID: 16415
		public static readonly int ANISTS_LevateinSwordEffect_Idle = Animator.StringToHash("Base Layer.LevateinSwordEffect_Idle");

		// Token: 0x04004020 RID: 16416
		public static readonly int ANISTS_SonicBlade_Idle = Animator.StringToHash("Base Layer.SonicBlade_Idle");

		// Token: 0x04004021 RID: 16417
		public static readonly int ANISTS_ShieldRod_AxeArmor_Idle = Animator.StringToHash("Base Layer.ShieldRod_AxeArmor_Idle");

		// Token: 0x04004022 RID: 16418
		public static readonly int ANISTS_ShieldRod_AxeArmor_ATK = Animator.StringToHash("Base Layer.ShieldRod_AxeArmor_ATK");

		// Token: 0x04004023 RID: 16419
		public static readonly int ANISTS_ShieldRod_Dark_Out = Animator.StringToHash("Base Layer.ShieldRod_Dark_Out");

		// Token: 0x04004024 RID: 16420
		public static readonly int ANISTS_ShieldRod_Flame_In = Animator.StringToHash("Base Layer.ShieldRod_Flame_In");

		// Token: 0x04004025 RID: 16421
		public static readonly int ANISTS_TsukaimaNoKen_Idle = Animator.StringToHash("Base Layer.TsukaimaNoKen_Idle");

		// Token: 0x04004026 RID: 16422
		public static readonly int AkatsukiNoKen_Soccer_Idle = Animator.StringToHash("Base Layer.AkatsukiNoKen_Soccer_Idle");

		// Token: 0x04004027 RID: 16423
		public static readonly int AkastukiNoKen_Fighter_In = Animator.StringToHash("Base Layer.AkastukiNoKen_Fighter_In");

		// Token: 0x04004028 RID: 16424
		public static readonly int AkastukiNoKen_Fighter_Idle = Animator.StringToHash("Base Layer.AkastukiNoKen_Fighter_Idle");

		// Token: 0x04004029 RID: 16425
		public static readonly int AkastukiNoKen_Fighter_Out = Animator.StringToHash("Base Layer.AkastukiNoKen_Fighter_Out");

		// Token: 0x0400402A RID: 16426
		public static readonly int AkatsukiNoken_Archer_Idle = Animator.StringToHash("Base Layer.AkatsukiNoken_Archer_Idle");

		// Token: 0x0400402B RID: 16427
		public static readonly int AkatsukiNoken_Archer_Idle2 = Animator.StringToHash("Base Layer.AkatsukiNoken_Archer_Idle2");

		// Token: 0x0400402C RID: 16428
		public static readonly int AkatsukiNoKen_Magician_Arrow_In = Animator.StringToHash("Base Layer.AkatsukiNoKen_Magician_Arrow_In");

		// Token: 0x0400402D RID: 16429
		public static readonly int AkatsukiNoKen_Magician_Arrow_Out = Animator.StringToHash("Base Layer.AkatsukiNoKen_Magician_Arrow_Out");

		// Token: 0x0400402E RID: 16430
		public static readonly int AkatsukiNoKen_Magician_Out = Animator.StringToHash("Base Layer.AkatsukiNoKen_Magician_Out");

		// Token: 0x0400402F RID: 16431
		public static readonly int RuneSword_Idle = Animator.StringToHash("Base Layer.RuneSword_Idle");

		// Token: 0x04004030 RID: 16432
		public bool hitedATK;

		// Token: 0x04004031 RID: 16433
		[NonSerialized]
		public bool grounded;

		// Token: 0x04004032 RID: 16434
		[NonSerialized]
		public bool inWater;

		// Token: 0x04004033 RID: 16435
		private PlayerStatus playerStatus;

		// Token: 0x04004034 RID: 16436
		private EnemyBody enemyBody;

		// Token: 0x04004035 RID: 16437
		private EnemyBody currentEnemyBody;

		// Token: 0x04004036 RID: 16438
		private Boss01BodyDetect bB;

		// Token: 0x04004037 RID: 16439
		private Boss01BodyDetect currentBB;

		// Token: 0x04004038 RID: 16440
		private Animator animator;

		// Token: 0x04004039 RID: 16441
		public InstantiateManager instantiateManager;

		// Token: 0x0400403A RID: 16442
		private EnemySoundEffect eSE;

		// Token: 0x0400403B RID: 16443
		protected Transform groundCheck_R;

		// Token: 0x0400403C RID: 16444
		protected Transform groundCheck_C;

		// Token: 0x0400403D RID: 16445
		protected Transform groundCheck_L;

		// Token: 0x0400403E RID: 16446
		public float timer;

		// Token: 0x0400403F RID: 16447
		public float timer2;

		// Token: 0x04004040 RID: 16448
		public int lvl;

		// Token: 0x04004041 RID: 16449
		public float iNT;

		// Token: 0x04004042 RID: 16450
		public float dEX;

		// Token: 0x04004043 RID: 16451
		public float sWDamage;

		// Token: 0x04004044 RID: 16452
		public float berserk;

		// Token: 0x04004045 RID: 16453
		public bool mineSW;

		// Token: 0x04004046 RID: 16454
		public bool canVelo;

		// Token: 0x04004047 RID: 16455
		public bool destroyCheck;

		// Token: 0x04004048 RID: 16456
		public bool enemySW;

		// Token: 0x04004049 RID: 16457
		public int magicNumber;

		// Token: 0x0400404A RID: 16458
		public int playerNumber;

		// Token: 0x0400404B RID: 16459
		public int skillNumber;

		// Token: 0x0400404C RID: 16460
		private float time;

		// Token: 0x0400404D RID: 16461
		public Vector3 targetPos;

		// Token: 0x0400404E RID: 16462
		public Vector3 targetPos2;

		// Token: 0x0400404F RID: 16463
		public Vector3 targetPos3;

		// Token: 0x04004050 RID: 16464
		public Vector3 startPos;

		// Token: 0x04004051 RID: 16465
		public Vector3 posHokan;

		// Token: 0x04004052 RID: 16466
		public Vector3 startPos2;

		// Token: 0x04004053 RID: 16467
		public Vector3 posHokan2;

		// Token: 0x04004054 RID: 16468
		public Vector3 startPos3;

		// Token: 0x04004055 RID: 16469
		public Vector3 posHokan3;

		// Token: 0x04004056 RID: 16470
		public Vector3 startPos4;

		// Token: 0x04004057 RID: 16471
		public Vector3 posHokan4;

		// Token: 0x04004058 RID: 16472
		public Vector3 startPos5;

		// Token: 0x04004059 RID: 16473
		public Vector3 posHokan5;

		// Token: 0x0400405A RID: 16474
		public Vector3 startPos6;

		// Token: 0x0400405B RID: 16475
		public Vector3 posHokan6;

		// Token: 0x0400405C RID: 16476
		public Vector3 startPos7;

		// Token: 0x0400405D RID: 16477
		public Vector3 posHokan7;

		// Token: 0x0400405E RID: 16478
		public Vector3 startPos8;

		// Token: 0x0400405F RID: 16479
		public Vector3 posHokan8;

		// Token: 0x04004060 RID: 16480
		public bool getTarget;

		// Token: 0x04004061 RID: 16481
		public bool hitted;

		// Token: 0x04004062 RID: 16482
		public bool right;

		// Token: 0x04004063 RID: 16483
		public bool left;

		// Token: 0x04004064 RID: 16484
		public bool action;

		// Token: 0x04004065 RID: 16485
		public bool canDamage;

		// Token: 0x04004066 RID: 16486
		public float timeLimit;

		// Token: 0x04004067 RID: 16487
		public GameObject ownerObj;

		// Token: 0x04004068 RID: 16488
		public GameObject targetObj;

		// Token: 0x04004069 RID: 16489
		public LineRenderer lineRenderer;

		// Token: 0x0400406A RID: 16490
		public Vector2 movePos;

		// Token: 0x0400406B RID: 16491
		public Vector2 returnPos;

		// Token: 0x0400406C RID: 16492
		public PhotonView targetPV;

		// Token: 0x0400406D RID: 16493
		public int count;

		// Token: 0x0400406E RID: 16494
		public ParticleSystem particle1;

		// Token: 0x0400406F RID: 16495
		public ParticleSystem particle2;

		// Token: 0x04004070 RID: 16496
		public ParticleSystem particle3;

		// Token: 0x04004071 RID: 16497
		public ParticleSystem particle4;

		// Token: 0x04004072 RID: 16498
		public ParticleSystem particle5;

		// Token: 0x04004073 RID: 16499
		public ParticleSystem particle6;

		// Token: 0x04004074 RID: 16500
		public ParticleSystem particle7;

		// Token: 0x04004075 RID: 16501
		public ParticleSystem particle8;

		// Token: 0x04004076 RID: 16502
		public ParticleSystem particle9;

		// Token: 0x04004077 RID: 16503
		public BoxCollider2D targetATKCol1;

		// Token: 0x04004078 RID: 16504
		public BoxCollider2D targetATKCol2;

		// Token: 0x04004079 RID: 16505
		public CircleCollider2D targetATKCol3;

		// Token: 0x0400407A RID: 16506
		public GameObject trail;

		// Token: 0x0400407B RID: 16507
		public GameObject startPosObj1;

		// Token: 0x0400407C RID: 16508
		public GameObject startPosObj2;

		// Token: 0x0400407D RID: 16509
		public GameObject startPosObj3;

		// Token: 0x0400407E RID: 16510
		public GameObject startPosObj4;

		// Token: 0x0400407F RID: 16511
		public GameObject startPosObj5;

		// Token: 0x04004080 RID: 16512
		public GameObject startPosObj6;

		// Token: 0x04004081 RID: 16513
		public GameObject startPosObj7;

		// Token: 0x04004082 RID: 16514
		public GameObject startPosObj8;

		// Token: 0x04004083 RID: 16515
		public GameObject hokanPosObj1;

		// Token: 0x04004084 RID: 16516
		public GameObject hokanPosObj2;

		// Token: 0x04004085 RID: 16517
		public GameObject hokanPosObj3;

		// Token: 0x04004086 RID: 16518
		public GameObject hokanPosObj4;

		// Token: 0x04004087 RID: 16519
		public GameObject hokanPosObj5;

		// Token: 0x04004088 RID: 16520
		public GameObject hokanPosObj6;

		// Token: 0x04004089 RID: 16521
		public GameObject hokanPosObj7;

		// Token: 0x0400408A RID: 16522
		public GameObject hokanPosObj8;

		// Token: 0x0400408B RID: 16523
		public PlayerController_Alucard playerCtrl;

		// Token: 0x0400408C RID: 16524
		public string soulName;

		// Token: 0x0400408D RID: 16525
		public SpriteRenderer spriteRen;

		// Token: 0x0400408E RID: 16526
		public Sprite sprite1;

		// Token: 0x0400408F RID: 16527
		public Sprite sprite2;

		// Token: 0x04004090 RID: 16528
		public GameObject muzzle;

		// Token: 0x04004091 RID: 16529
		protected Collider2D[][] groundCheckCollider = new Collider2D[3][];

		// Token: 0x04004092 RID: 16530
		protected int[] gccMax = new int[3];
	}
}
