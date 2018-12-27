using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020002E9 RID: 745
	public class Balow : EnemyMain
	{
		// Token: 0x06001747 RID: 5959 RVA: 0x0011BCF0 File Offset: 0x00119EF0
		protected override void Awake()
		{
			base.Awake();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.mesh = base.transform.Find("TargetText").GetComponent<MeshRenderer>();
			this.cameraCtrl = GameObject.Find("MainCamera").GetComponent<CameraController>();
			this.cameraCtrl.bossTargetText = this.mesh;
			this.chestPos = GameObject.Find("Stage/Stage13/ChestPos").transform;
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
			this.targetDoor = GameObject.Find("Stage/Stage13/StageBase/Stage1/Object/StepSwitch3/Door1").GetComponent<Door1TimeLag>();
			this.rangeWeaponATK1 = 35f;
		}

		// Token: 0x06001748 RID: 5960 RVA: 0x0011BDA4 File Offset: 0x00119FA4
		private void Start()
		{
			int stageDifficult = this.playerStatus.stageDifficult;
			if (stageDifficult != 1)
			{
				if (stageDifficult != 2)
				{
					if (stageDifficult == 3)
					{
						this.rangeWeaponATK1 *= 8f;
					}
				}
				else
				{
					this.rangeWeaponATK1 *= 5f;
				}
			}
			else
			{
				this.rangeWeaponATK1 *= 2f;
			}
			this.startHp = this.enemyBody.hp;
			this.targetPlayer = GameObject.FindGameObjectWithTag("Player");
			this.myPV = base.GetComponent<PhotonView>();
			this.eCV = base.GetComponent<EnemySoundEffect>();
			this.eSE = base.transform.Find("SoundEffect").GetComponent<EnemySoundEffect>();
			this.targetAnim = GameObject.Find("Canvas_UI/Archive").GetComponent<Animator>();
			this.targetText = GameObject.Find("Canvas_UI/Archive/ArchiveText").GetComponent<Text>();
			this.targetImage = GameObject.Find("Canvas_UI/Archive/UnLockImage").GetComponent<Image>();
			this.menuOnOff = GameObject.Find("Canvas_UI").GetComponent<MenuOnOff>();
			this.bgmWorks = GameObject.Find("Stage/Stage_UI/BGM").GetComponent<BGMWorks>();
			this.bgmWorks = GameObject.Find("BGM").GetComponent<BGMWorks>();
			this.playerSpawn = GameObject.Find("Stage/Stage13/StageNetwork").GetComponent<PlayerSpwan>();
			this.idlePos = new Vector2(this.middlePos.transform.position.x, this.middlePos.transform.position.y);
			int @int = PlayerPrefs.GetInt("SatsujinSliding");
			if (@int > 0)
			{
				this.alreadyUnlockArchive = true;
			}
			int int2 = PlayerPrefs.GetInt("SkeltonFive");
			if (int2 > 0)
			{
				this.alreadyUnlockArchive2 = true;
			}
			int int3 = PlayerPrefs.GetInt("JigokunoCombination");
			if (int3 > 0)
			{
				this.alreadyUnlockArchive3 = true;
			}
			this.bossBGM = PlayerPrefs.GetInt("BGMBoss13");
			if (this.bossBGM == 0)
			{
				this.bossBGM = 830;
			}
			int stageDifficult2 = this.playerStatus.stageDifficult;
			if (stageDifficult2 != 2)
			{
				if (stageDifficult2 == 3)
				{
					this.speed *= 1.5f;
				}
			}
			else
			{
				this.speed *= 1.25f;
			}
			foreach (EnemyBody enemyBody in this.targetEB)
			{
				enemyBody.blocked = true;
			}
		}

		// Token: 0x06001749 RID: 5961 RVA: 0x0011C034 File Offset: 0x0011A234
		private void OnTriggerEnter2D(Collider2D other)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (other.transform.parent != null)
			{
				this.lastDMG = other.transform.parent.gameObject;
			}
			if (currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_Idle && (other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && !this.deadCheck)
			{
				int num = UnityEngine.Random.Range(0, 4);
				if (num == 0)
				{
					this.CVCall(20);
				}
				else if (num == 1)
				{
					this.CVCall(21);
				}
				else if (num == 2)
				{
					this.CVCall(22);
				}
				else if (num == 3)
				{
					this.CVCall(23);
				}
			}
		}

		// Token: 0x0600174A RID: 5962 RVA: 0x0011C28C File Offset: 0x0011A48C
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (this.playerStatus != null && this.playerSpawn.startLevel && !this.check3 && PhotonNetwork.isMasterClient)
			{
				this.lang = this.playerStatus.language;
				this.myPV.RPC("ReciveSetLanguage", PhotonTargets.Others, new object[]
				{
					this.lang
				});
				this.check3 = true;
			}
			if ((currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_Idle || currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Usutio || currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Tonitorusu || currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Gurobusu || currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Gurobusu_Ready || currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Gurando || currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Gurando_Idle || currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Gurando_Up || currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Gurando_Ground) && !this.InTargetPositionCheck(this.idlePos, 0.1f))
			{
				base.transform.position = Vector2.MoveTowards(base.transform.position, this.idlePos, 1f * Time.deltaTime);
			}
			if (currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Tonitorusu_Idle)
			{
				switch (this.tonitorusuCount)
				{
				case 0:
					this.targetTonitorusuPos = new Vector2(this.rightLimtTrans.transform.position.x, this.rightLimtTrans.transform.position.y + 1f);
					if (!this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.targetTonitorusuPos, this.speed * Time.deltaTime);
					}
					if (this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						this.tonitorusuCount = 1;
					}
					break;
				case 1:
					this.targetTonitorusuPos = new Vector2(this.rightLimtTrans.transform.position.x, this.rightLimtTrans.transform.position.y);
					if (!this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.targetTonitorusuPos, this.speed * Time.deltaTime);
					}
					if (this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						this.CVCallRandom(1);
						this.tonitorusuCount = 2;
					}
					break;
				case 2:
					this.targetTonitorusuPos = new Vector2(this.leftLimtTrans.transform.position.x, this.leftLimtTrans.transform.position.y);
					if (!this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.targetTonitorusuPos, this.speed * Time.deltaTime);
					}
					if (this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						this.tonitorusuCount = 3;
					}
					break;
				case 3:
					this.targetTonitorusuPos = new Vector2(this.leftLimtTrans.transform.position.x, this.leftLimtTrans.transform.position.y + 1f);
					if (!this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.targetTonitorusuPos, this.speed * Time.deltaTime);
					}
					if (this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						this.tonitorusuCount = 4;
					}
					break;
				case 4:
					this.targetTonitorusuPos = new Vector2(this.rightLimtTrans.transform.position.x, this.rightLimtTrans.transform.position.y + 1f);
					if (!this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.targetTonitorusuPos, this.speed * Time.deltaTime);
					}
					if (this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						this.targetTonitorusuPos = new Vector2(this.targetPlayer.transform.position.x, this.targetPlayer.transform.position.y + 0.5f);
						this.tonitorusuCount = 5;
					}
					break;
				case 5:
					if (!this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.targetTonitorusuPos, this.speed * Time.deltaTime);
					}
					if (this.InTargetPositionCheck(this.targetTonitorusuPos, 0.1f))
					{
						this.SoundEffectStop();
						this.animator.SetBool("ATK3", false);
						this.tonitorusuCount = 6;
					}
					break;
				}
			}
			if (!this.curse && this.enemyBody.canCurse)
			{
				this.myPV.RPC("ReciveCurse", PhotonTargets.Others, new object[0]);
				this.curseTimer = 0f;
				this.curse = true;
			}
			if (this.curse)
			{
				if (!this.animator.GetBool("Curse"))
				{
					this.animator.SetBool("Curse", true);
				}
			}
			else if (!this.curse && this.animator.GetBool("Curse"))
			{
				this.animator.SetBool("Curse", false);
			}
			if (!this.poison && this.enemyBody.canPoison)
			{
				this.myPV.RPC("RecivePoison", PhotonTargets.Others, new object[0]);
				base.StartCoroutine(this.EnumPoisonDamage(3f));
				this.poisonTimer = 0f;
				this.poison = true;
			}
			if (this.poison)
			{
				if (!this.animator.GetBool("Poison"))
				{
					this.animator.SetBool("Poison", true);
				}
			}
			else if (!this.poison && this.animator.GetBool("Poison"))
			{
				this.animator.SetBool("Poison", false);
			}
		}

		// Token: 0x0600174B RID: 5963 RVA: 0x0011C9E0 File Offset: 0x0011ABE0
		protected override void FixedUpdate()
		{
			base.FixedUpdate();
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (PhotonNetwork.isMasterClient && this.activeAI && this.targetPlayer == null)
			{
				this.targetPlayer = this.serchTag(base.gameObject, "Player");
				int num = this.ReturnTargetNumber(this.targetPlayer.name);
				this.myPV.RPC("ReciveTarget", PhotonTargets.Others, new object[]
				{
					num
				});
				if (this.targetPlayer.GetComponent<PlayerController_Shanoa>() != null)
				{
					int num2 = UnityEngine.Random.Range(0, 2);
					if (num2 != 0)
					{
						if (num2 == 1)
						{
							this.CVCall(31);
						}
					}
					else
					{
						this.CVCall(30);
					}
				}
			}
			if (this.activeAI && !this.check)
			{
				this.playerSpawn.bossBattle = true;
				this.check = true;
			}
			if (!this.deadCheck && this.playerSpawn.endGame && !this.cvCheck)
			{
				if (this.targetPlayer.GetComponent<PlayerController_Shanoa>() != null)
				{
					this.CVCall(29);
				}
				else if (this.targetPlayer.GetComponent<PlayerController_Shanoa>() == null)
				{
					int num3 = UnityEngine.Random.Range(0, 2);
					if (num3 != 0)
					{
						if (num3 == 1)
						{
							this.CVCall(28);
						}
					}
					else
					{
						this.CVCall(27);
					}
				}
				this.cvCheck = true;
			}
			if (PhotonNetwork.isMasterClient && this.activeAI && !this.deadCheck)
			{
				this.searchTargetTimer += Time.deltaTime;
				if (this.searchTargetTimer > 10f)
				{
					this.targetPlayer = this.serchTag(base.gameObject, "Player");
					int num4 = this.ReturnTargetNumber(this.targetPlayer.name);
					this.myPV.RPC("ReciveTarget", PhotonTargets.Others, new object[]
					{
						num4
					});
					if (this.targetPlayer.GetComponent<PlayerController_Shanoa>() != null)
					{
						int num5 = UnityEngine.Random.Range(0, 2);
						if (num5 != 0)
						{
							if (num5 == 1)
							{
								this.CVCall(31);
							}
						}
						else
						{
							this.CVCall(30);
						}
					}
					this.searchTargetTimer = 0f;
				}
				if (!this.bgmCheck && PhotonNetwork.isMasterClient)
				{
					this.bgmWorks.ChangeBGMCall(this.bossBGM);
					this.bgmCheck = true;
				}
			}
			if (currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Gurobusu_Ready && this.InTargetPositionCheck(this.idlePos, 0.1f))
			{
				this.CVCall(3);
				this.animator.SetTrigger("ATK2_2");
			}
			if (currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Gurobusu && currentAnimatorStateInfo.normalizedTime > 1f)
			{
				this.animator.SetBool("ATK2", false);
				this.idlePos = new Vector2(this.middlePos.transform.position.x, this.middlePos.transform.position.y);
			}
			if (currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Gurando_Idle)
			{
				this.animTimer += Time.deltaTime;
				this.idlePos = new Vector2(this.middlePos.transform.position.x, this.middlePos.transform.position.y);
				if (this.animTimer > 3.5f)
				{
					this.CVCall(9);
					this.animator.SetBool("ATK4", false);
					this.animTimer = 0f;
				}
			}
			if (currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Usutio_Idle)
			{
				this.animTimer += Time.deltaTime;
				if (this.InTargetPositionCheck(this.idlePos, 0.1f) && !this.canUsutio)
				{
					this.CVCall(1);
					base.StartCoroutine(this.EnumCVCall(3f, 2));
					this.RangeUsutio();
					this.canUsutio = true;
				}
				if (this.animTimer > 6f)
				{
					this.animator.SetBool("ATK1", false);
					this.animTimer = 0f;
				}
			}
			if (currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Gurando && this.InTargetPositionCheck(this.idlePos, 0.1f))
			{
				this.animator.SetTrigger("ATK4_2");
			}
			if (currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Gurando_Up && currentAnimatorStateInfo.normalizedTime > 1f)
			{
				this.idlePos = new Vector2(base.transform.position.x, base.transform.position.y + 3f);
			}
			if (currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Tekken_Ready && currentAnimatorStateInfo.normalizedTime > 1f)
			{
				int num6 = this.switchTekkenVoice;
				if (num6 != 0)
				{
					if (num6 == 1)
					{
						this.CVCall(15);
					}
				}
				else
				{
					this.CVCall(10);
				}
				this.animator.SetTrigger("ATK5");
				base.transform.position = new Vector2(this.targetPlayer.transform.position.x + 1f, this.targetPlayer.transform.position.y);
				if (base.transform.localScale.x > 0f)
				{
					this.DirTurn();
				}
			}
			if (currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_ATK_Tekken && currentAnimatorStateInfo.normalizedTime > 1f)
			{
				switch (this.tekkenCount)
				{
				case 1:
				{
					int num7 = this.switchTekkenVoice;
					if (num7 != 0)
					{
						if (num7 == 1)
						{
							this.CVCall(16);
						}
					}
					else
					{
						this.CVCall(11);
					}
					this.animator.SetTrigger("ATK5");
					base.transform.position = new Vector2(this.targetPlayer.transform.position.x - 1f, this.targetPlayer.transform.position.y);
					if (base.transform.localScale.x < 0f)
					{
						this.DirTurn();
					}
					break;
				}
				case 2:
				{
					int num8 = this.switchTekkenVoice;
					if (num8 != 0)
					{
						if (num8 == 1)
						{
							this.CVCall(17);
						}
					}
					else
					{
						this.CVCall(12);
					}
					this.animator.SetTrigger("ATK5");
					base.transform.position = new Vector2(this.targetPlayer.transform.position.x + 1f, this.targetPlayer.transform.position.y);
					if (base.transform.localScale.x > 0f)
					{
						this.DirTurn();
					}
					break;
				}
				case 3:
				{
					int num9 = this.switchTekkenVoice;
					if (num9 != 0)
					{
						if (num9 == 1)
						{
							this.CVCall(18);
						}
					}
					else
					{
						this.CVCall(13);
					}
					this.animator.SetTrigger("ATK5");
					base.transform.position = new Vector2(this.targetPlayer.transform.position.x - 1f, this.targetPlayer.transform.position.y);
					if (base.transform.localScale.x < 0f)
					{
						this.DirTurn();
					}
					break;
				}
				case 4:
				{
					int num10 = this.switchTekkenVoice;
					if (num10 != 0)
					{
						if (num10 == 1)
						{
							this.CVCall(19);
						}
					}
					else
					{
						this.CVCall(14);
					}
					this.animator.SetTrigger("ATK5");
					base.transform.position = new Vector2(this.targetPlayer.transform.position.x + 1f, this.targetPlayer.transform.position.y);
					if (base.transform.localScale.x > 0f)
					{
						this.DirTurn();
					}
					break;
				}
				case 5:
					base.transform.position = new Vector2(this.middlePos.transform.position.x, this.middlePos.transform.position.y);
					if (this.animator.GetBool("ATK5_2"))
					{
						this.animator.SetBool("ATK5_2", false);
						this.tekkenCount = 0;
					}
					break;
				}
			}
			if (this.targetPlayer != null)
			{
				if (base.transform.localScale.x < 0f)
				{
					if (base.transform.position.x < this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = true;
					}
					else if (base.transform.position.x > this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = false;
					}
				}
				else if (base.transform.localScale.x > 0f)
				{
					if (base.transform.position.x > this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = true;
					}
					else if (base.transform.position.x < this.targetPlayer.transform.position.x)
					{
						this.playerBackSide = false;
					}
				}
			}
			if (this.BeginEnemyCommonWork() && PhotonNetwork.isMasterClient && this.activeAI)
			{
				this.FixedUpdateAI();
				this.EndEnemyCommonWork();
			}
		}

		// Token: 0x0600174C RID: 5964 RVA: 0x0011D4F4 File Offset: 0x0011B6F4
		public bool BeginEnemyCommonWork()
		{
			if (this.enemyBody.hp <= 0f)
			{
				if (!this.deadCheck)
				{
					this.Dead();
					this.myPV.RPC("ReciveDead", PhotonTargets.Others, new object[0]);
					this.deadCheck = true;
				}
				return false;
			}
			this.animator.enabled = true;
			return this.CheckAction();
		}

		// Token: 0x0600174D RID: 5965 RVA: 0x00004F4D File Offset: 0x0000314D
		public void EndEnemyCommonWork()
		{
		}

		// Token: 0x0600174E RID: 5966 RVA: 0x0011D564 File Offset: 0x0011B764
		public bool CheckAction()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			return currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_Dead && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_Sleep && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_ATK_Gurobusu && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_ATK_Gurando && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_ATK_Gurando_Idle && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_ATK_Gurando_Up && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_ATK_Tekken && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_ATK_Tekken_Ready && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_ATK_Tekken_End && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_ATK_Tonitorusu && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_ATK_Tonitorusu_Idle && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_ATK_Usutio && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_ATK_Usutio_Idle && currentAnimatorStateInfo.fullPathHash != Balow.ANISTS_Dead_Idle;
		}

		// Token: 0x0600174F RID: 5967 RVA: 0x0011D670 File Offset: 0x0011B870
		private void FixedUpdateAI()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if ((this.enemyAists == Balow.ENEMYAISTS.ATK1 || this.enemyAists == Balow.ENEMYAISTS.ATK2 || this.enemyAists == Balow.ENEMYAISTS.ATK3 || this.enemyAists == Balow.ENEMYAISTS.ATK4 || this.enemyAists == Balow.ENEMYAISTS.ATK5) && currentAnimatorStateInfo.fullPathHash == Balow.ANISTS_Idle)
			{
				this.enemyAists = Balow.ENEMYAISTS.WAIT;
			}
			if (this.activeAI && this.canAI)
			{
				int num = this.SelectRandomAIState();
				if (num < 20)
				{
					this.enemyAists = Balow.ENEMYAISTS.ATK1;
					this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
					{
						1,
						0
					});
				}
				else if (num < 40)
				{
					this.enemyAists = Balow.ENEMYAISTS.ATK2;
					this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
					{
						2,
						0
					});
				}
				else if (num < 60)
				{
					this.enemyAists = Balow.ENEMYAISTS.ATK3;
					this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
					{
						3,
						0
					});
				}
				else if (num < 80)
				{
					this.enemyAists = Balow.ENEMYAISTS.ATK4;
					this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
					{
						4,
						0
					});
				}
				else if (num < 100)
				{
					int num2 = UnityEngine.Random.Range(0, 2);
					this.switchTekkenVoice = num2;
					this.enemyAists = Balow.ENEMYAISTS.ATK5;
					this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
					{
						5,
						num2
					});
				}
			}
			switch (this.enemyAists)
			{
			case Balow.ENEMYAISTS.WAIT:
				this.timetest2 += Time.deltaTime;
				if (this.timetest2 > UnityEngine.Random.Range(this.waitTimeMin, this.waitTimeMax))
				{
					this.canAI = true;
					this.timetest2 = 0f;
				}
				break;
			case Balow.ENEMYAISTS.ATK1:
				if (!this.animator.GetBool("ATK1"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.animTimer = 0f;
					this.idlePos = new Vector2(this.middlePos.transform.position.x, this.middlePos.transform.position.y);
					this.canUsutio = false;
					this.animator.SetBool("ATK1", true);
				}
				this.canAI = false;
				break;
			case Balow.ENEMYAISTS.ATK2:
				if (!this.animator.GetBool("ATK2"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.position.x > this.targetPlayer.transform.position.x)
					{
						this.idlePos = new Vector2(this.rightPos.transform.position.x, this.rightPos.transform.position.y);
					}
					else if (base.transform.position.x < this.targetPlayer.transform.position.x)
					{
						this.idlePos = new Vector2(this.leftPos.transform.position.x, this.leftPos.transform.position.y);
					}
					this.animator.SetBool("ATK2", true);
				}
				this.canAI = false;
				break;
			case Balow.ENEMYAISTS.ATK3:
				if (!this.animator.GetBool("ATK3"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.CVCall(4);
					this.idlePos = new Vector2(this.middlePos.transform.position.x, this.middlePos.transform.position.y);
					this.tonitorusuCount = 0;
					this.animator.SetBool("ATK3", true);
				}
				this.canAI = false;
				break;
			case Balow.ENEMYAISTS.ATK4:
				if (!this.animator.GetBool("ATK4"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.position.x > this.targetPlayer.transform.position.x)
					{
						this.idlePos = new Vector2(this.rightPos.transform.position.x, this.rightLimtTrans.transform.position.y);
					}
					else if (base.transform.position.x < this.targetPlayer.transform.position.x)
					{
						this.idlePos = new Vector2(this.leftPos.transform.position.x, this.rightLimtTrans.transform.position.y);
					}
					this.animTimer = 0f;
					this.animator.SetBool("ATK4", true);
				}
				this.canAI = false;
				break;
			case Balow.ENEMYAISTS.ATK5:
				if (!this.animator.GetBool("ATK5_2"))
				{
					this.animator.SetBool("ATK5_2", true);
					this.tekkenCount = 0;
				}
				this.canAI = false;
				break;
			}
		}

		// Token: 0x06001750 RID: 5968 RVA: 0x0011DC55 File Offset: 0x0011BE55
		public void EnemyKillsCountPlus()
		{
			this.menuOnOff.enemyKills++;
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0011DC6C File Offset: 0x0011BE6C
		public void ArchiveCheck()
		{
			GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
			foreach (GameObject gameObject in array)
			{
				if (gameObject.GetComponent<PlayerController>() != null)
				{
					PlayerController component = gameObject.GetComponent<PlayerController>();
					if (component.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Shanoa>() != null)
				{
					PlayerController_Shanoa component2 = gameObject.GetComponent<PlayerController_Shanoa>();
					if (component2.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Jonathan>() != null)
				{
					PlayerController_Jonathan component3 = gameObject.GetComponent<PlayerController_Jonathan>();
					if (component3.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Charotte>() != null)
				{
					PlayerController_Charotte component4 = gameObject.GetComponent<PlayerController_Charotte>();
					if (component4.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Albus>() != null)
				{
					PlayerController_Albus component5 = gameObject.GetComponent<PlayerController_Albus>();
					if (component5.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Soma>() != null)
				{
					PlayerController_Soma component6 = gameObject.GetComponent<PlayerController_Soma>();
					if (component6.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Alucard>() != null)
				{
					PlayerController_Alucard component7 = gameObject.GetComponent<PlayerController_Alucard>();
					if (component7.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Julius>() != null)
				{
					PlayerController_Julius component8 = gameObject.GetComponent<PlayerController_Julius>();
					if (component8.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Yoko>() != null)
				{
					PlayerController_Yoko component9 = gameObject.GetComponent<PlayerController_Yoko>();
					if (component9.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Maria>() != null)
				{
					PlayerController_Maria component10 = gameObject.GetComponent<PlayerController_Maria>();
					if (component10.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Simon>() != null)
				{
					PlayerController_Simon component11 = gameObject.GetComponent<PlayerController_Simon>();
					if (component11.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Fuma>() != null)
				{
					PlayerController_Fuma component12 = gameObject.GetComponent<PlayerController_Fuma>();
					if (component12.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Add1>() != null)
				{
					PlayerController_Add1 component13 = gameObject.GetComponent<PlayerController_Add1>();
					if (component13.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Add2>() != null)
				{
					PlayerController_Add2 component14 = gameObject.GetComponent<PlayerController_Add2>();
					if (component14.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Add3>() != null)
				{
					PlayerController_Add3 component15 = gameObject.GetComponent<PlayerController_Add3>();
					if (component15.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Add4>() != null)
				{
					PlayerController_Add4 component16 = gameObject.GetComponent<PlayerController_Add4>();
					if (component16.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
				if (gameObject.GetComponent<PlayerController_Add5>() != null)
				{
					PlayerController_Add5 component17 = gameObject.GetComponent<PlayerController_Add5>();
					if (component17.isSkelton)
					{
						this.skeltonPlayers++;
					}
				}
			}
			if (this.skeltonPlayers >= 5 && !this.alreadyUnlockArchive2)
			{
				this.targetText.text = "スケルトンファイブ";
				this.targetImage.sprite = this.archiveSprite2;
				this.targetAnim.SetTrigger("UnLock");
				PlayerPrefs.SetInt("SkeltonFive", 1);
				this.alreadyUnlockArchive2 = true;
			}
			if (!this.alreadyUnlockArchive && this.enemyBody.hitSlidingKick)
			{
				this.targetText.text = "殺人スライディング";
				this.targetImage.sprite = this.archiveSprite;
				this.targetAnim.SetTrigger("UnLock");
				PlayerPrefs.SetInt("SatsujinSliding", 1);
				this.alreadyUnlockArchive = true;
			}
			if (!this.alreadyUnlockArchive3 && this.lastDMG != null && this.lastDMG.tag == "DualCrush")
			{
				this.targetText.text = "地獄のコンビネーション";
				this.targetImage.sprite = this.archiveSprite3;
				this.targetAnim.SetTrigger("UnLock");
				PlayerPrefs.SetInt("JigokunoCombination", 1);
				this.alreadyUnlockArchive3 = true;
			}
			if (this.enemyBody.ownATKHitted)
			{
				this.playerStatus.data_Balow++;
				this.playerStatus.score += this.score;
				this.playerStatus.killCount++;
				this.playerStatus.killCountAll++;
			}
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x0011E194 File Offset: 0x0011C394
		public void Dead()
		{
			this.targetDoor.up = true;
			this.cVSounds = GameObject.FindGameObjectWithTag("Player").GetComponent<CVSounds>();
			this.cVSounds.KillBoss();
			this.targetDeadCol2d.enabled = true;
			base.GetComponent<Rigidbody2D>().gravityScale = 1f;
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
			int num = UnityEngine.Random.Range(0, 3);
			if (num == 0)
			{
				this.CVCall(24);
			}
			else if (num == 1)
			{
				this.CVCall(25);
			}
			else if (num == 2)
			{
				this.CVCall(26);
			}
			this.animator.SetTrigger("Dead");
			if (PhotonNetwork.isMasterClient)
			{
				base.Invoke("AppearChestBox", 3f);
			}
		}

		// Token: 0x06001753 RID: 5971 RVA: 0x0011E27C File Offset: 0x0011C47C
		public void AppearChestBox()
		{
			GameObject gameObject = PhotonNetwork.Instantiate("Chest_Gold", new Vector3(this.chestPos.position.x, this.chestPos.position.y, 0f), Quaternion.identity, 0);
			ItemsChest component = gameObject.GetComponent<ItemsChest>();
			component.boxLevel = this.playerStatus.stageDifficult;
			ChestGold component2 = gameObject.GetComponent<ChestGold>();
			component2.returnLobbyTime = this.returnLobbyTime;
		}

		// Token: 0x06001754 RID: 5972 RVA: 0x00097E10 File Offset: 0x00096010
		public int SelectRandomAIState()
		{
			return UnityEngine.Random.Range(0, 100);
		}

		// Token: 0x06001755 RID: 5973 RVA: 0x0011E2F7 File Offset: 0x0011C4F7
		public void SetAIState(Balow.ENEMYAISTS sts, float t)
		{
			this.aiActionTimeStart = Time.fixedTime;
			this.aiActionTimeLength = t;
			this.enemyAists = sts;
		}

		// Token: 0x06001756 RID: 5974 RVA: 0x0011E314 File Offset: 0x0011C514
		public float GetDistancePlayer()
		{
			return this.targetPlayer.transform.position.y - base.transform.position.y;
		}

		// Token: 0x06001757 RID: 5975 RVA: 0x0011E350 File Offset: 0x0011C550
		public float GetDistanceTarget()
		{
			float num = base.transform.position.x - this.targetPlayer.transform.position.x;
			if (num < 0f)
			{
				num *= -1f;
			}
			return num;
		}

		// Token: 0x06001758 RID: 5976 RVA: 0x0011E3A0 File Offset: 0x0011C5A0
		private IEnumerator EnumPoisonDamage(float delay)
		{
			yield return new WaitForSeconds(delay);
			if (this.poison)
			{
				this.enemyBody.ActionDamagePoison(base.transform.position.x, base.transform.position.y + 0.5f);
				base.StartCoroutine(this.EnumPoisonDamage(3f));
			}
			yield break;
		}

		// Token: 0x06001759 RID: 5977 RVA: 0x0011E3C4 File Offset: 0x0011C5C4
		private void RangeUsutio()
		{
			this.instantiateManager.EnemyUsutio(base.transform.position.x, base.transform.position.y + 1f, this.rangeWeaponATK1, this.targetPlayer, 3f);
			this.instantiateManager.EnemyUsutio(base.transform.position.x + 0.2f, base.transform.position.y + 0.8f, this.rangeWeaponATK1, this.targetPlayer, 3.7f);
			this.instantiateManager.EnemyUsutio(base.transform.position.x + 0.4f, base.transform.position.y + 0.6f, this.rangeWeaponATK1, this.targetPlayer, 4.4f);
			this.instantiateManager.EnemyUsutio(base.transform.position.x + 0.2f, base.transform.position.y + 0.4f, this.rangeWeaponATK1, this.targetPlayer, 5.1f);
			this.instantiateManager.EnemyUsutio(base.transform.position.x, base.transform.position.y + 0.2f, this.rangeWeaponATK1, this.targetPlayer, 5.8f);
			this.instantiateManager.EnemyUsutio(base.transform.position.x - 0.2f, base.transform.position.y + 0.4f, this.rangeWeaponATK1, this.targetPlayer, 6.5f);
			this.instantiateManager.EnemyUsutio(base.transform.position.x - 0.4f, base.transform.position.y + 0.6f, this.rangeWeaponATK1, this.targetPlayer, 7.2f);
			this.instantiateManager.EnemyUsutio(base.transform.position.x - 0.2f, base.transform.position.y + 0.8f, this.rangeWeaponATK1, this.targetPlayer, 7.9f);
		}

		// Token: 0x0600175A RID: 5978 RVA: 0x0011E64C File Offset: 0x0011C84C
		public void ActiveAI()
		{
			if (PhotonNetwork.isMasterClient && base.GetComponent<Rigidbody2D>() == null)
			{
				this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
				{
					6,
					0
				});
				base.gameObject.AddComponent<Rigidbody2D>();
				base.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
				base.GetComponent<Rigidbody2D>().gravityScale = 0f;
				foreach (EnemyBody enemyBody in this.targetEB)
				{
					enemyBody.blocked = false;
				}
				this.CVCall(0);
				this.animator.SetTrigger("Active");
				this.targetCol2d.SetActive(true);
				this.activeAI = true;
			}
		}

		// Token: 0x0600175B RID: 5979 RVA: 0x0011E718 File Offset: 0x0011C918
		private void DirTurn()
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x * -1f, base.transform.localScale.y, base.transform.localScale.z);
		}

		// Token: 0x0600175C RID: 5980 RVA: 0x0011E774 File Offset: 0x0011C974
		public void countPlus()
		{
			this.tekkenCount++;
		}

		// Token: 0x0600175D RID: 5981 RVA: 0x0011E784 File Offset: 0x0011C984
		public void InstantShot(int val)
		{
			if (val != 1)
			{
				if (val == 2)
				{
					if (base.transform.localScale.x > 0f)
					{
						this.instantiateManager.EnemyGurobusu(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 0, 1);
						this.instantiateManager.EnemyGurobusu(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 0, 2);
					}
					else if (base.transform.localScale.x < 0f)
					{
						this.instantiateManager.EnemyGurobusu(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 1, 1);
						this.instantiateManager.EnemyGurobusu(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 1, 2);
					}
				}
			}
			else
			{
				int stageDifficult = this.playerStatus.stageDifficult;
				if (stageDifficult != 1)
				{
					if (stageDifficult != 2)
					{
						if (stageDifficult == 3)
						{
							this.instantiateManager.EnemyBalowGrando(base.transform.position.x, base.transform.position.y + 0.1f, 5, 0);
							this.instantiateManager.EnemyBalowGrando(base.transform.position.x, base.transform.position.y + 0.1f, 5, 1);
						}
					}
					else
					{
						this.instantiateManager.EnemyBalowGrando(base.transform.position.x, base.transform.position.y + 0.1f, 4, 0);
						this.instantiateManager.EnemyBalowGrando(base.transform.position.x, base.transform.position.y + 0.1f, 4, 1);
					}
				}
				else
				{
					this.instantiateManager.EnemyBalowGrando(base.transform.position.x, base.transform.position.y + 0.1f, 3, 0);
					this.instantiateManager.EnemyBalowGrando(base.transform.position.x, base.transform.position.y + 0.1f, 3, 1);
				}
			}
		}

		// Token: 0x0600175E RID: 5982 RVA: 0x0011EAA4 File Offset: 0x0011CCA4
		public void CVCall(int num)
		{
			int num2 = this.lang;
			if (num2 != 0)
			{
				if (num2 == 1)
				{
					switch (num)
					{
					case 0:
						this.eCV.SoundEffectPlay(32);
						break;
					case 1:
						this.eCV.SoundEffectPlay(33);
						break;
					case 2:
						this.eCV.SoundEffectPlay(34);
						break;
					case 3:
						this.eCV.SoundEffectPlay(35);
						break;
					case 4:
						this.eCV.SoundEffectPlay(36);
						break;
					case 5:
						this.eCV.SoundEffectPlay(37);
						break;
					case 6:
						this.eCV.SoundEffectPlay(38);
						break;
					case 7:
						this.eCV.SoundEffectPlay(39);
						break;
					case 8:
						this.eCV.SoundEffectPlay(40);
						break;
					case 9:
						this.eCV.SoundEffectPlay(41);
						break;
					case 10:
						this.eCV.SoundEffectPlay(42);
						break;
					case 11:
						this.eCV.SoundEffectPlay(43);
						break;
					case 12:
						this.eCV.SoundEffectPlay(44);
						break;
					case 13:
						this.eCV.SoundEffectPlay(45);
						break;
					case 14:
						this.eCV.SoundEffectPlay(46);
						break;
					case 15:
						this.eCV.SoundEffectPlay(47);
						break;
					case 16:
						this.eCV.SoundEffectPlay(48);
						break;
					case 17:
						this.eCV.SoundEffectPlay(49);
						break;
					case 18:
						this.eCV.SoundEffectPlay(50);
						break;
					case 19:
						this.eCV.SoundEffectPlay(51);
						break;
					case 20:
						this.eCV.SoundEffectPlay(52);
						break;
					case 21:
						this.eCV.SoundEffectPlay(53);
						break;
					case 22:
						this.eCV.SoundEffectPlay(54);
						break;
					case 23:
						this.eCV.SoundEffectPlay(55);
						break;
					case 24:
						this.eCV.SoundEffectPlay(56);
						break;
					case 25:
						this.eCV.SoundEffectPlay(57);
						break;
					case 26:
						this.eCV.SoundEffectPlay(58);
						break;
					case 27:
						this.eCV.SoundEffectPlay(59);
						break;
					case 28:
						this.eCV.SoundEffectPlay(60);
						break;
					case 29:
						this.eCV.SoundEffectPlay(61);
						break;
					case 30:
						this.eCV.SoundEffectPlay(62);
						break;
					case 31:
						this.eCV.SoundEffectPlay(63);
						break;
					case 32:
						this.eCV.SoundEffectPlay(64);
						break;
					}
				}
			}
			else
			{
				this.eCV.SoundEffectPlay(num);
			}
		}

		// Token: 0x0600175F RID: 5983 RVA: 0x0011EDC4 File Offset: 0x0011CFC4
		private IEnumerator EnumCVCall(float delay, int val)
		{
			yield return new WaitForSeconds(delay);
			this.CVCall(val);
			yield break;
		}

		// Token: 0x06001760 RID: 5984 RVA: 0x0011EDF0 File Offset: 0x0011CFF0
		public void CVCallRandom(int val)
		{
			if (val != 1)
			{
				if (val != 2)
				{
					if (val == 3)
					{
						int num = UnityEngine.Random.Range(0, 3);
						if (num == 0)
						{
							this.CVCall(24);
						}
						else if (num == 1)
						{
							this.CVCall(25);
						}
						else if (num == 2)
						{
							this.CVCall(26);
						}
					}
				}
				else
				{
					int num2 = UnityEngine.Random.Range(0, 2);
					if (num2 == 0)
					{
						this.CVCall(7);
					}
					else if (num2 == 1)
					{
						this.CVCall(8);
					}
				}
			}
			else
			{
				int num3 = UnityEngine.Random.Range(0, 2);
				if (num3 == 0)
				{
					this.CVCall(5);
				}
				else if (num3 == 1)
				{
					this.CVCall(6);
				}
			}
		}

		// Token: 0x06001761 RID: 5985 RVA: 0x0011EEB4 File Offset: 0x0011D0B4
		public void SoundEffectCall(int num)
		{
			this.eSE.SoundEffectPlay(num);
		}

		// Token: 0x06001762 RID: 5986 RVA: 0x0011EEC2 File Offset: 0x0011D0C2
		public void SoundEffectStop()
		{
			this.eSE.SoundEffectStop();
		}

		// Token: 0x06001763 RID: 5987 RVA: 0x0011EED0 File Offset: 0x0011D0D0
		public void VelocityX(float Vx)
		{
			if (base.transform.localScale.x > 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(Vx, base.GetComponent<Rigidbody2D>().velocity.y);
			}
			else if (base.transform.localScale.x < 0f)
			{
				base.GetComponent<Rigidbody2D>().velocity = new Vector2(-1f * Vx, base.GetComponent<Rigidbody2D>().velocity.y);
			}
		}

		// Token: 0x06001764 RID: 5988 RVA: 0x0011EF6C File Offset: 0x0011D16C
		public void VelocityY(float Vy)
		{
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, Vy);
		}

		// Token: 0x06001765 RID: 5989 RVA: 0x0011EFA0 File Offset: 0x0011D1A0
		[PunRPC]
		private void ReciveTarget(int num)
		{
			this.targetPlayer = GameObject.Find(this.ReturnTargetName(num));
			if (this.targetPlayer.GetComponent<PlayerController_Shanoa>() != null)
			{
				int num2 = UnityEngine.Random.Range(0, 2);
				if (num2 != 0)
				{
					if (num2 == 1)
					{
						this.CVCall(31);
					}
				}
				else
				{
					this.CVCall(30);
				}
			}
			if (!this.activeAI)
			{
				this.activeAI = true;
			}
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x0011F01B File Offset: 0x0011D21B
		[PunRPC]
		private void ReciveDead()
		{
			if (!this.deadCheck)
			{
				this.Dead();
				this.deadCheck = true;
			}
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x0011F035 File Offset: 0x0011D235
		[PunRPC]
		private void ReciveSetLanguage(int val)
		{
			this.lang = val;
		}

		// Token: 0x06001768 RID: 5992 RVA: 0x0011F040 File Offset: 0x0011D240
		[PunRPC]
		private void ReciveState(int val, int val2)
		{
			switch (val)
			{
			case 1:
				if (!this.animator.GetBool("ATK1"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.animTimer = 0f;
					this.idlePos = new Vector2(this.middlePos.transform.position.x, this.middlePos.transform.position.y);
					this.canUsutio = false;
					this.animator.SetBool("ATK1", true);
				}
				this.canAI = false;
				break;
			case 2:
				if (!this.animator.GetBool("ATK2"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.position.x > this.targetPlayer.transform.position.x)
					{
						this.idlePos = new Vector2(this.rightPos.transform.position.x, this.rightPos.transform.position.y);
					}
					else if (base.transform.position.x < this.targetPlayer.transform.position.x)
					{
						this.idlePos = new Vector2(this.leftPos.transform.position.x, this.leftPos.transform.position.y);
					}
					this.animator.SetBool("ATK2", true);
				}
				this.canAI = false;
				break;
			case 3:
				if (!this.animator.GetBool("ATK3"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.CVCall(4);
					this.idlePos = new Vector2(this.middlePos.transform.position.x, this.middlePos.transform.position.y);
					this.tonitorusuCount = 0;
					this.animator.SetBool("ATK3", true);
				}
				this.canAI = false;
				break;
			case 4:
				if (!this.animator.GetBool("ATK4"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.position.x > this.targetPlayer.transform.position.x)
					{
						this.idlePos = new Vector2(this.rightPos.transform.position.x, this.rightLimtTrans.transform.position.y);
					}
					else if (base.transform.position.x < this.targetPlayer.transform.position.x)
					{
						this.idlePos = new Vector2(this.leftPos.transform.position.x, this.rightLimtTrans.transform.position.y);
					}
					this.animTimer = 0f;
					this.animator.SetBool("ATK4", true);
				}
				this.canAI = false;
				break;
			case 5:
				this.switchTekkenVoice = val2;
				if (!this.animator.GetBool("ATK5_2"))
				{
					this.animator.SetBool("ATK5_2", true);
					this.tekkenCount = 0;
				}
				this.canAI = false;
				break;
			case 6:
				if (base.GetComponent<Rigidbody2D>() == null)
				{
					base.gameObject.AddComponent<Rigidbody2D>();
					base.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
					base.GetComponent<Rigidbody2D>().gravityScale = 0f;
					foreach (EnemyBody enemyBody in this.targetEB)
					{
						enemyBody.blocked = false;
					}
					this.CVCall(0);
					this.animator.SetTrigger("Active");
					this.targetCol2d.SetActive(true);
					this.activeAI = true;
				}
				break;
			}
		}

		// Token: 0x06001769 RID: 5993 RVA: 0x00098AA0 File Offset: 0x00096CA0
		[PunRPC]
		private void ReciveCurse()
		{
			this.curseTimer = 0f;
			if (!this.curse)
			{
				this.curse = true;
			}
		}

		// Token: 0x0600176A RID: 5994 RVA: 0x00098ABF File Offset: 0x00096CBF
		[PunRPC]
		private void RecivePoison()
		{
			this.poisonTimer = 0f;
			if (!this.poison)
			{
				this.poison = true;
			}
		}

		// Token: 0x040021BA RID: 8634
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Balow_Idle_Air");

		// Token: 0x040021BB RID: 8635
		public static readonly int ANISTS_Sleep = Animator.StringToHash("Base Layer.Balow_Idle");

		// Token: 0x040021BC RID: 8636
		public static readonly int ANISTS_ATK_Usutio = Animator.StringToHash("Base Layer.Balow_ATK_Usutio");

		// Token: 0x040021BD RID: 8637
		public static readonly int ANISTS_ATK_Usutio_Idle = Animator.StringToHash("Base Layer.Balow_ATK_Usutio_Idle");

		// Token: 0x040021BE RID: 8638
		public static readonly int ANISTS_ATK_Gurobusu = Animator.StringToHash("Base Layer.Balow_ATK_Gurobusu");

		// Token: 0x040021BF RID: 8639
		public static readonly int ANISTS_ATK_Gurobusu_Ready = Animator.StringToHash("Base Layer.Balow_ATK_Gurobusu_Ready");

		// Token: 0x040021C0 RID: 8640
		public static readonly int ANISTS_ATK_Tonitorusu = Animator.StringToHash("Base Layer.Balow_ATK_Tonitorusu");

		// Token: 0x040021C1 RID: 8641
		public static readonly int ANISTS_ATK_Tonitorusu_Idle = Animator.StringToHash("Base Layer.Balow_ATK_Tonitorusu_Idle");

		// Token: 0x040021C2 RID: 8642
		public static readonly int ANISTS_ATK_Gurando = Animator.StringToHash("Base Layer.Balow_ATK_Grando");

		// Token: 0x040021C3 RID: 8643
		public static readonly int ANISTS_ATK_Gurando_Ground = Animator.StringToHash("Base Layer.Balow_ATK_Grando_Ground ");

		// Token: 0x040021C4 RID: 8644
		public static readonly int ANISTS_ATK_Gurando_Up = Animator.StringToHash("Base Layer.Balow_ATK_Grando_Up");

		// Token: 0x040021C5 RID: 8645
		public static readonly int ANISTS_ATK_Gurando_Idle = Animator.StringToHash("Base Layer.Balow_ATK_Grando_Idle");

		// Token: 0x040021C6 RID: 8646
		public static readonly int ANISTS_ATK_Tekken = Animator.StringToHash("Base Layer.Balow_ATK_Tekken");

		// Token: 0x040021C7 RID: 8647
		public static readonly int ANISTS_ATK_Tekken_Ready = Animator.StringToHash("Base Layer.Balow_ATK_Tekken_Ready");

		// Token: 0x040021C8 RID: 8648
		public static readonly int ANISTS_ATK_Tekken_End = Animator.StringToHash("Base Layer.Balow_ATK_Tekken_End");

		// Token: 0x040021C9 RID: 8649
		public static readonly int ANISTS_Dead = Animator.StringToHash("Base Layer.Balow_Dead");

		// Token: 0x040021CA RID: 8650
		public static readonly int ANISTS_Dead_Idle = Animator.StringToHash("Base Layer.Balow_Dead_Idle");

		// Token: 0x040021CB RID: 8651
		protected float aiActionTimeLength;

		// Token: 0x040021CC RID: 8652
		protected float aiActionTimeStart;

		// Token: 0x040021CD RID: 8653
		public Balow.ENEMYAISTS enemyAists;

		// Token: 0x040021CE RID: 8654
		public float speed = 1.2f;

		// Token: 0x040021CF RID: 8655
		public bool activeAI;

		// Token: 0x040021D0 RID: 8656
		public float timetest2;

		// Token: 0x040021D1 RID: 8657
		public float waitTimeMin = 3f;

		// Token: 0x040021D2 RID: 8658
		public float waitTimeMax = 4f;

		// Token: 0x040021D3 RID: 8659
		public float searchTargetTimer;

		// Token: 0x040021D4 RID: 8660
		public float startHp;

		// Token: 0x040021D5 RID: 8661
		public bool playerBackSide;

		// Token: 0x040021D6 RID: 8662
		public bool canAI;

		// Token: 0x040021D7 RID: 8663
		public bool deadCheck;

		// Token: 0x040021D8 RID: 8664
		public bool bgmCheck;

		// Token: 0x040021D9 RID: 8665
		public EnemyBody enemyBody;

		// Token: 0x040021DA RID: 8666
		private GameObject[] allPlayer;

		// Token: 0x040021DB RID: 8667
		public Transform chestPos;

		// Token: 0x040021DC RID: 8668
		private EnemySoundEffect eCV;

		// Token: 0x040021DD RID: 8669
		private EnemySoundEffect eSE;

		// Token: 0x040021DE RID: 8670
		private Animator targetAnim;

		// Token: 0x040021DF RID: 8671
		private Text targetText;

		// Token: 0x040021E0 RID: 8672
		private Image targetImage;

		// Token: 0x040021E1 RID: 8673
		public Sprite archiveSprite;

		// Token: 0x040021E2 RID: 8674
		public Sprite archiveSprite2;

		// Token: 0x040021E3 RID: 8675
		public Sprite archiveSprite3;

		// Token: 0x040021E4 RID: 8676
		public bool alreadyUnlockArchive;

		// Token: 0x040021E5 RID: 8677
		public bool alreadyUnlockArchive2;

		// Token: 0x040021E6 RID: 8678
		public bool alreadyUnlockArchive3;

		// Token: 0x040021E7 RID: 8679
		private MenuOnOff menuOnOff;

		// Token: 0x040021E8 RID: 8680
		public int skeltonPlayers;

		// Token: 0x040021E9 RID: 8681
		private PlayerStatus playerStatus;

		// Token: 0x040021EA RID: 8682
		private PhotonView myPV;

		// Token: 0x040021EB RID: 8683
		public GameObject targetPlayer;

		// Token: 0x040021EC RID: 8684
		private BGMWorks bgmWorks;

		// Token: 0x040021ED RID: 8685
		public int bossBGM;

		// Token: 0x040021EE RID: 8686
		public int score;

		// Token: 0x040021EF RID: 8687
		public PlayerSpwan playerSpawn;

		// Token: 0x040021F0 RID: 8688
		public bool check;

		// Token: 0x040021F1 RID: 8689
		public int lang;

		// Token: 0x040021F2 RID: 8690
		public CVSounds cVSounds;

		// Token: 0x040021F3 RID: 8691
		public GameObject lastDMG;

		// Token: 0x040021F4 RID: 8692
		public Transform muzzle;

		// Token: 0x040021F5 RID: 8693
		public float rangeWeaponATK1;

		// Token: 0x040021F6 RID: 8694
		public int boxLevel;

		// Token: 0x040021F7 RID: 8695
		public float returnLobbyTime;

		// Token: 0x040021F8 RID: 8696
		private MeshRenderer mesh;

		// Token: 0x040021F9 RID: 8697
		private CameraController cameraCtrl;

		// Token: 0x040021FA RID: 8698
		public InstantiateManager instantiateManager;

		// Token: 0x040021FB RID: 8699
		public EnemyBody[] targetEB;

		// Token: 0x040021FC RID: 8700
		private Vector2 upPos;

		// Token: 0x040021FD RID: 8701
		private Vector2 returnPos;

		// Token: 0x040021FE RID: 8702
		public Transform rightLimtTrans;

		// Token: 0x040021FF RID: 8703
		public Transform leftLimtTrans;

		// Token: 0x04002200 RID: 8704
		public bool check3;

		// Token: 0x04002201 RID: 8705
		private Vector2 idlePos;

		// Token: 0x04002202 RID: 8706
		private Vector2 targetTonitorusuPos;

		// Token: 0x04002203 RID: 8707
		public int tonitorusuCount;

		// Token: 0x04002204 RID: 8708
		public Transform rightPos;

		// Token: 0x04002205 RID: 8709
		public Transform leftPos;

		// Token: 0x04002206 RID: 8710
		public Transform middlePos;

		// Token: 0x04002207 RID: 8711
		public float animTimer;

		// Token: 0x04002208 RID: 8712
		public int tekkenCount;

		// Token: 0x04002209 RID: 8713
		public BoxCollider2D targetDeadCol2d;

		// Token: 0x0400220A RID: 8714
		public bool canUsutio;

		// Token: 0x0400220B RID: 8715
		public int switchTekkenVoice;

		// Token: 0x0400220C RID: 8716
		public bool cvCheck;

		// Token: 0x0400220D RID: 8717
		public Door1TimeLag targetDoor;

		// Token: 0x0400220E RID: 8718
		public GameObject targetCol2d;

		// Token: 0x020002EA RID: 746
		public enum ENEMYAISTS
		{
			// Token: 0x04002210 RID: 8720
			WAIT,
			// Token: 0x04002211 RID: 8721
			ATK1,
			// Token: 0x04002212 RID: 8722
			ATK2,
			// Token: 0x04002213 RID: 8723
			ATK3,
			// Token: 0x04002214 RID: 8724
			ATK4,
			// Token: 0x04002215 RID: 8725
			ATK5
		}
	}
}
