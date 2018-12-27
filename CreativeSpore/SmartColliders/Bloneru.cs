using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200027D RID: 637
	public class Bloneru : EnemyMain
	{
		// Token: 0x060012D8 RID: 4824 RVA: 0x000D0E14 File Offset: 0x000CF014
		protected override void Awake()
		{
			base.Awake();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.mesh = base.transform.Find("TargetText").GetComponent<MeshRenderer>();
			this.cameraCtrl = GameObject.Find("MainCamera").GetComponent<CameraController>();
			this.cameraCtrl.bossTargetText = this.mesh;
			this.chestPos = GameObject.Find("Stage/Stage04/ChestPos").transform;
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
			this.bossRoomPicture = GameObject.Find("Stage/Stage04/StageBase/Stage1/Object/BossRoomPicture").GetComponent<BossRoomPicture>();
		}

		// Token: 0x060012D9 RID: 4825 RVA: 0x000D0EBC File Offset: 0x000CF0BC
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
			this.playerSpawn = GameObject.Find("Stage/Stage04/StageNetwork").GetComponent<PlayerSpwan>();
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
			int int4 = PlayerPrefs.GetInt("Hard4_Clear");
			if (int4 > 0)
			{
				this.alreadyUnlockArchive4 = true;
			}
			this.bossBGM = PlayerPrefs.GetInt("BGMBoss04");
			if (this.bossBGM == 0)
			{
				this.bossBGM = 6;
			}
			int stageDifficult2 = this.playerStatus.stageDifficult;
			if (stageDifficult2 != 2)
			{
				if (stageDifficult2 == 3)
				{
					this.speed *= 2f;
				}
			}
			else
			{
				this.speed *= 1.5f;
			}
			foreach (EnemyBody enemyBody in this.targetEB)
			{
				enemyBody.blocked = true;
			}
		}

		// Token: 0x060012DA RID: 4826 RVA: 0x000D1110 File Offset: 0x000CF310
		private void OnTriggerEnter2D(Collider2D other)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if (other.transform.parent != null)
			{
				this.lastDMG = other.transform.parent.gameObject;
			}
			if (currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_Idle && (other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && !this.deadCheck)
			{
				int num = UnityEngine.Random.Range(0, 2);
				if (num == 0)
				{
					this.CVCall(9);
				}
				else if (num == 1)
				{
					this.CVCall(10);
				}
			}
		}

		// Token: 0x060012DB RID: 4827 RVA: 0x000D1340 File Offset: 0x000CF540
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
			if (PhotonNetwork.isMasterClient && !this.activeAI && this.startHp > this.enemyBody.hp)
			{
				this.targetPlayer = this.serchTag(base.gameObject, "Player");
				int num = this.ReturnTargetNumber(this.targetPlayer.name);
				this.myPV.RPC("ReciveTarget", PhotonTargets.Others, new object[]
				{
					num
				});
				this.activeAI = true;
			}
			if (this.activeAI && !this.check2)
			{
				this.animator.SetTrigger("GoBattle");
				this.check2 = true;
			}
			if (currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Picture || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Picture2 || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_PictureAttack || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Picture_Return)
			{
				switch (this.pictureCount)
				{
				case 0:
					if (this.speed != 0.5f)
					{
						this.speed = 0.5f;
					}
					if (!this.InTargetPositionCheck(this.upPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.upPos, this.speed * Time.deltaTime);
					}
					else if (this.InTargetPositionCheck(this.upPos, 0.1f))
					{
						this.upPos = new Vector2(this.targetPlayer.transform.position.x, this.targetPlayer.transform.position.y);
						this.animator.SetBool("ATK_Picture", true);
						this.pictureCount = 1;
					}
					break;
				case 1:
					if (this.speed != 3f)
					{
						this.speed = 3f;
					}
					if (!this.InTargetPositionCheck(this.upPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.upPos, this.speed * Time.deltaTime);
					}
					else if (this.InTargetPositionCheck(this.upPos, 0.1f))
					{
						this.upPos = new Vector2(this.targetPlayer.transform.position.x, this.targetPlayer.transform.position.y + 2f);
						this.animator.SetBool("ATK_Picture", false);
						this.pictureCount = 2;
					}
					break;
				case 2:
					if (this.speed != 1f)
					{
						this.speed = 1f;
					}
					if (!this.InTargetPositionCheck(this.upPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.upPos, this.speed * Time.deltaTime);
					}
					else if (this.InTargetPositionCheck(this.upPos, 0.1f))
					{
						this.upPos = new Vector2(this.targetPlayer.transform.position.x, this.targetPlayer.transform.position.y);
						this.animator.SetBool("ATK_Picture", true);
						this.pictureCount = 3;
					}
					break;
				case 3:
					if (this.speed != 3f)
					{
						this.speed = 3f;
					}
					if (!this.InTargetPositionCheck(this.upPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.upPos, this.speed * Time.deltaTime);
					}
					else if (this.InTargetPositionCheck(this.upPos, 0.1f))
					{
						this.upPos = new Vector2(this.targetPlayer.transform.position.x, this.targetPlayer.transform.position.y + 2f);
						this.animator.SetBool("ATK_Picture", false);
						this.pictureCount = 4;
					}
					break;
				case 4:
					if (this.speed != 1f)
					{
						this.speed = 1f;
					}
					if (!this.InTargetPositionCheck(this.upPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.upPos, this.speed * Time.deltaTime);
					}
					else if (this.InTargetPositionCheck(this.upPos, 0.1f))
					{
						this.pictureCount = 5;
					}
					break;
				case 5:
					if (this.speed != 2f)
					{
						this.speed = 2f;
					}
					if (!this.InTargetPositionCheck(this.returnPos, 0.1f))
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.returnPos, this.speed * Time.deltaTime);
					}
					else if (this.InTargetPositionCheck(this.returnPos, 0.1f))
					{
						this.animator.SetBool("Picture", false);
						this.pictureCount = 6;
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

		// Token: 0x060012DC RID: 4828 RVA: 0x000D1AFC File Offset: 0x000CFCFC
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
			}
			if (this.activeAI && !this.check)
			{
				this.playerSpawn.bossBattle = true;
				this.check = true;
			}
			if (PhotonNetwork.isMasterClient && this.activeAI)
			{
				this.searchTargetTimer += Time.deltaTime;
				if (this.searchTargetTimer > 10f)
				{
					this.targetPlayer = this.serchTag(base.gameObject, "Player");
					int num2 = this.ReturnTargetNumber(this.targetPlayer.name);
					this.myPV.RPC("ReciveTarget", PhotonTargets.Others, new object[]
					{
						num2
					});
					this.searchTargetTimer = 0f;
				}
				if (!this.bgmCheck && PhotonNetwork.isMasterClient)
				{
					this.bgmWorks.ChangeBGMCall(this.bossBGM);
					this.bgmCheck = true;
				}
			}
			if (base.GetComponent<Rigidbody2D>() != null)
			{
				if (currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Picture || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Picture2 || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_PictureAttack || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Picture_Return)
				{
					if (base.GetComponent<Rigidbody2D>().gravityScale != 0f)
					{
						base.GetComponent<Rigidbody2D>().gravityScale = 0f;
					}
				}
				else if (base.GetComponent<Rigidbody2D>().gravityScale != 1.7f)
				{
					base.GetComponent<Rigidbody2D>().gravityScale = 1.7f;
				}
			}
			if (currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Spray && currentAnimatorStateInfo.normalizedTime > 1f)
			{
				this.animator.SetBool("ATK_Spray", false);
				int num3 = this.summonCount;
				if (num3 != 1)
				{
					if (num3 != 2)
					{
						if (num3 == 3)
						{
							this.animator.SetBool("ATK_Summon3", true);
						}
					}
					else
					{
						this.animator.SetBool("ATK_Summon2", true);
					}
				}
				else
				{
					this.animator.SetBool("ATK_Summon1", true);
				}
			}
			if ((currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Blood1 || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Blood2 || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Blood3 || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Blood4 || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Summon1 || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Summon2 || currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_ATK_Summon3) && currentAnimatorStateInfo.normalizedTime > 1f)
			{
				this.animator.SetBool("ATK_Blood1", false);
				this.animator.SetBool("ATK_Blood2", false);
				this.animator.SetBool("ATK_Blood3", false);
				this.animator.SetBool("ATK_Blood4", false);
				this.animator.SetBool("ATK_Summon1", false);
				this.animator.SetBool("ATK_Summon2", false);
				this.animator.SetBool("ATK_Summon3", false);
			}
			if (this.targetPlayer != null)
			{
				if (base.transform.localScale.x > 0f)
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
				else if (base.transform.localScale.x < 0f)
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

		// Token: 0x060012DD RID: 4829 RVA: 0x000D2014 File Offset: 0x000D0214
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

		// Token: 0x060012DE RID: 4830 RVA: 0x00004F4D File Offset: 0x0000314D
		public void EndEnemyCommonWork()
		{
		}

		// Token: 0x060012DF RID: 4831 RVA: 0x000D2084 File Offset: 0x000D0284
		public bool CheckAction()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			return currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_Blood1 && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_Blood2 && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_Blood3 && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_Blood4 && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_Picture && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_Picture2 && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_PictureAttack && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_Picture_Return && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_Spray && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_Summon1 && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_Summon2 && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_ATK_Summon3 && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_Dead && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_Sleep && currentAnimatorStateInfo.fullPathHash != Bloneru.ANISTS_WakeUp;
		}

		// Token: 0x060012E0 RID: 4832 RVA: 0x000D21A0 File Offset: 0x000D03A0
		private void FixedUpdateAI()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			if ((this.enemyAists == Bloneru.ENEMYAISTS.ATK_BlOODLINE1 || this.enemyAists == Bloneru.ENEMYAISTS.ATK_BlOODLINE2 || this.enemyAists == Bloneru.ENEMYAISTS.ATK_BlOODLINE3 || this.enemyAists == Bloneru.ENEMYAISTS.ATK_BlOODLINE4 || this.enemyAists == Bloneru.ENEMYAISTS.ATK_PICTURE || this.enemyAists == Bloneru.ENEMYAISTS.ATK_SUMMON1 || this.enemyAists == Bloneru.ENEMYAISTS.ATK_SUMMON2 || this.enemyAists == Bloneru.ENEMYAISTS.ATK_SUMMON3) && currentAnimatorStateInfo.fullPathHash == Bloneru.ANISTS_Idle)
			{
				this.enemyAists = Bloneru.ENEMYAISTS.WAIT;
			}
			if (this.activeAI && this.canAI)
			{
				int num = this.SelectRandomAIState();
				switch (this.aICount)
				{
				case 0:
					if (num < 25)
					{
						this.enemyAists = Bloneru.ENEMYAISTS.ATK_BlOODLINE1;
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							2,
							0
						});
						this.aICount++;
					}
					else if (num < 50)
					{
						this.enemyAists = Bloneru.ENEMYAISTS.ATK_BlOODLINE2;
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							3,
							0
						});
						this.aICount++;
					}
					else if (num < 75)
					{
						this.enemyAists = Bloneru.ENEMYAISTS.ATK_BlOODLINE3;
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							4,
							0
						});
						this.aICount++;
					}
					else if (num <= 100)
					{
						this.enemyAists = Bloneru.ENEMYAISTS.ATK_BlOODLINE4;
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							5,
							0
						});
						this.aICount++;
					}
					break;
				case 1:
					if (num < 25)
					{
						this.enemyAists = Bloneru.ENEMYAISTS.ATK_BlOODLINE1;
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							2,
							0
						});
						this.aICount++;
					}
					else if (num < 50)
					{
						this.enemyAists = Bloneru.ENEMYAISTS.ATK_BlOODLINE2;
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							3,
							0
						});
						this.aICount++;
					}
					else if (num < 75)
					{
						this.enemyAists = Bloneru.ENEMYAISTS.ATK_BlOODLINE3;
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							4,
							0
						});
						this.aICount++;
					}
					else if (num <= 100)
					{
						this.enemyAists = Bloneru.ENEMYAISTS.ATK_BlOODLINE4;
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							5,
							0
						});
						this.aICount++;
					}
					break;
				case 2:
					if (num < 32)
					{
						this.enemyAists = Bloneru.ENEMYAISTS.ATK_SUMMON1;
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							6,
							0
						});
						this.aICount++;
					}
					else if (num < 66)
					{
						this.enemyAists = Bloneru.ENEMYAISTS.ATK_SUMMON2;
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							7,
							0
						});
						this.aICount++;
					}
					else if (num <= 100)
					{
						this.enemyAists = Bloneru.ENEMYAISTS.ATK_SUMMON3;
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							8,
							0
						});
						this.aICount++;
					}
					break;
				case 3:
					if (num < 32)
					{
						this.returnPos = new Vector2(this.rightTrans.position.x, this.rightTrans.transform.position.y);
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							9,
							1
						});
					}
					else if (num < 66)
					{
						this.returnPos = new Vector2(this.middleTrans.position.x, this.middleTrans.transform.position.y);
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							9,
							2
						});
					}
					else if (num <= 100)
					{
						this.returnPos = new Vector2(this.leftTrans.position.x, this.leftTrans.transform.position.y);
						this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
						{
							9,
							3
						});
					}
					this.upPos = new Vector2(base.transform.position.x, base.transform.position.y + 2f);
					this.pictureCount = 0;
					this.enemyAists = Bloneru.ENEMYAISTS.ATK_PICTURE;
					this.aICount = 0;
					break;
				}
			}
			switch (this.enemyAists)
			{
			case Bloneru.ENEMYAISTS.WAIT:
				this.timetest2 += Time.deltaTime;
				if (this.timetest2 > UnityEngine.Random.Range(this.waitTimeMin, this.waitTimeMax))
				{
					this.canAI = true;
					this.timetest2 = 0f;
				}
				break;
			case Bloneru.ENEMYAISTS.ATK_BlOODLINE1:
				if (!this.animator.GetBool("ATK_Blood1"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.localScale.x > 0f)
					{
						this.bossRoomPicture.AnimSwitch(6);
					}
					else if (base.transform.localScale.x < 0f)
					{
						this.bossRoomPicture.AnimSwitch(2);
					}
					this.animator.SetBool("ATK_Blood1", true);
				}
				this.canAI = false;
				break;
			case Bloneru.ENEMYAISTS.ATK_BlOODLINE2:
				if (!this.animator.GetBool("ATK_Blood2"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.localScale.x > 0f)
					{
						this.bossRoomPicture.AnimSwitch(5);
					}
					else if (base.transform.localScale.x < 0f)
					{
						this.bossRoomPicture.AnimSwitch(1);
					}
					this.animator.SetBool("ATK_Blood2", true);
				}
				this.canAI = false;
				break;
			case Bloneru.ENEMYAISTS.ATK_BlOODLINE3:
				if (!this.animator.GetBool("ATK_Blood3"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.localScale.x > 0f)
					{
						this.bossRoomPicture.AnimSwitch(7);
					}
					else if (base.transform.localScale.x < 0f)
					{
						this.bossRoomPicture.AnimSwitch(4);
					}
					this.animator.SetBool("ATK_Blood3", true);
				}
				this.canAI = false;
				break;
			case Bloneru.ENEMYAISTS.ATK_BlOODLINE4:
				if (!this.animator.GetBool("ATK_Blood4"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.localScale.x > 0f)
					{
						this.bossRoomPicture.AnimSwitch(8);
					}
					else if (base.transform.localScale.x < 0f)
					{
						this.bossRoomPicture.AnimSwitch(3);
					}
					this.animator.SetBool("ATK_Blood4", true);
				}
				this.canAI = false;
				break;
			case Bloneru.ENEMYAISTS.ATK_PICTURE:
				if (!this.animator.GetBool("Picture"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.animator.SetBool("Picture", true);
				}
				this.canAI = false;
				break;
			case Bloneru.ENEMYAISTS.ATK_SUMMON1:
				if (!this.animator.GetBool("ATK_Spray"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.animator.SetBool("ATK_Spray", true);
					this.summonCount = 1;
				}
				this.canAI = false;
				break;
			case Bloneru.ENEMYAISTS.ATK_SUMMON2:
				if (!this.animator.GetBool("ATK_Spray"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.animator.SetBool("ATK_Spray", true);
					this.summonCount = 2;
				}
				this.canAI = false;
				break;
			case Bloneru.ENEMYAISTS.ATK_SUMMON3:
				if (!this.animator.GetBool("ATK_Spray"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.animator.SetBool("ATK_Spray", true);
					this.summonCount = 3;
				}
				this.canAI = false;
				break;
			}
		}

		// Token: 0x060012E1 RID: 4833 RVA: 0x000D2B52 File Offset: 0x000D0D52
		public void EnemyKillsCountPlus()
		{
			this.menuOnOff.enemyKills++;
		}

		// Token: 0x060012E2 RID: 4834 RVA: 0x000D2B68 File Offset: 0x000D0D68
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
			if (this.playerStatus.stageDifficult >= 2 && !this.alreadyUnlockArchive4)
			{
				PlayerPrefs.SetInt("Hard4_Clear", 1);
				this.alreadyUnlockArchive4 = true;
			}
			if (this.enemyBody.ownATKHitted)
			{
				this.playerStatus.data_Bloneru++;
				this.playerStatus.score += this.score;
				this.playerStatus.killCount++;
				this.playerStatus.killCountAll++;
			}
		}

		// Token: 0x060012E3 RID: 4835 RVA: 0x000D30C0 File Offset: 0x000D12C0
		public void Dead()
		{
			this.cVSounds = GameObject.FindGameObjectWithTag("Player").GetComponent<CVSounds>();
			this.cVSounds.KillBoss();
			this.animator.SetTrigger("Dead");
			if (this.playerStatus.charaNumber == 5)
			{
				float soul = this.GetSoul(this.playerStatus.soulEaterRing);
				if (soul > 99.5f)
				{
					GameObject[] array = GameObject.FindGameObjectsWithTag("Player");
					foreach (GameObject gameObject in array)
					{
						PhotonView component = gameObject.GetComponent<PhotonView>();
						if (component.isMine)
						{
							PlayerController_Soma component2 = gameObject.GetComponent<PlayerController_Soma>();
							this.instantiateManager.PlayerSoulBlue(base.transform.position.x, base.transform.position.y + 0.5f, gameObject, component2, "ブローネル");
						}
					}
				}
			}
			if (PhotonNetwork.isMasterClient)
			{
				base.Invoke("AppearChestBox", 3f);
			}
		}

		// Token: 0x060012E4 RID: 4836 RVA: 0x000D31D0 File Offset: 0x000D13D0
		public void AppearChestBox()
		{
			GameObject gameObject = PhotonNetwork.Instantiate("Chest_Gold", new Vector3(this.chestPos.position.x, this.chestPos.position.y, 0f), Quaternion.identity, 0);
			ItemsChest component = gameObject.GetComponent<ItemsChest>();
			component.boxLevel = this.playerStatus.stageDifficult;
			ChestGold component2 = gameObject.GetComponent<ChestGold>();
			component2.returnLobbyTime = this.returnLobbyTime;
		}

		// Token: 0x060012E5 RID: 4837 RVA: 0x00097E10 File Offset: 0x00096010
		public int SelectRandomAIState()
		{
			return UnityEngine.Random.Range(0, 100);
		}

		// Token: 0x060012E6 RID: 4838 RVA: 0x000D324B File Offset: 0x000D144B
		public void SetAIState(Bloneru.ENEMYAISTS sts, float t)
		{
			this.aiActionTimeStart = Time.fixedTime;
			this.aiActionTimeLength = t;
			this.enemyAists = sts;
		}

		// Token: 0x060012E7 RID: 4839 RVA: 0x000D3268 File Offset: 0x000D1468
		public float GetDistancePlayer()
		{
			return this.targetPlayer.transform.position.y - base.transform.position.y;
		}

		// Token: 0x060012E8 RID: 4840 RVA: 0x000D32A4 File Offset: 0x000D14A4
		public float GetDistanceTarget()
		{
			float num = base.transform.position.x - this.targetPlayer.transform.position.x;
			if (num < 0f)
			{
				num *= -1f;
			}
			return num;
		}

		// Token: 0x060012E9 RID: 4841 RVA: 0x000D32F4 File Offset: 0x000D14F4
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

		// Token: 0x060012EA RID: 4842 RVA: 0x000D3318 File Offset: 0x000D1518
		private IEnumerator EnumReturnAnim(float delay)
		{
			yield return new WaitForSeconds(delay);
			this.animator.SetBool("Down", false);
			yield break;
		}

		// Token: 0x060012EB RID: 4843 RVA: 0x000D333C File Offset: 0x000D153C
		public void ActiveAI()
		{
			if (PhotonNetwork.isMasterClient && base.GetComponent<Rigidbody2D>() == null)
			{
				this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
				{
					11,
					0
				});
				base.gameObject.AddComponent<Rigidbody2D>();
				base.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
				base.GetComponent<Rigidbody2D>().gravityScale = 1f;
				foreach (EnemyBody enemyBody in this.targetEB)
				{
					enemyBody.blocked = false;
				}
				this.activeAI = true;
			}
		}

		// Token: 0x060012EC RID: 4844 RVA: 0x000D33E4 File Offset: 0x000D15E4
		private void DirTurn()
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x * -1f, base.transform.localScale.y, base.transform.localScale.z);
		}

		// Token: 0x060012ED RID: 4845 RVA: 0x000D3440 File Offset: 0x000D1640
		public void InstantShot(int val)
		{
			switch (val)
			{
			case 0:
				base.StartCoroutine(this.EnumInstantBlood(0f));
				break;
			case 1:
				if (base.transform.localScale.x > 0f)
				{
					this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 1, 0);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 6, 0);
				}
				break;
			case 2:
				if (base.transform.localScale.x > 0f)
				{
					this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 2, 0);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 3, 0);
				}
				break;
			case 3:
				if (base.transform.localScale.x > 0f)
				{
					this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 4, 0);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 5, 0);
				}
				break;
			case 4:
				if (base.transform.localScale.x > 0f)
				{
					this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 5, 0);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 4, 0);
				}
				break;
			case 5:
				if (base.transform.localScale.x > 0f)
				{
					this.instantiateManager.EnemyBloneru_RangeShotPicture(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 2, 0, 0);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.instantiateManager.EnemyBloneru_RangeShotPicture(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 2, 0, 1);
				}
				break;
			case 6:
				if (base.transform.localScale.x > 0f)
				{
					this.instantiateManager.EnemyBloneru_RangeShotPicture(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 3, 0, 0);
					this.instantiateManager.EnemyBloneru_RangeShotPicture(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 3, 1, 0);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.instantiateManager.EnemyBloneru_RangeShotPicture(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 3, 0, 1);
					this.instantiateManager.EnemyBloneru_RangeShotPicture(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 3, 1, 1);
				}
				break;
			case 7:
				if (base.transform.localScale.x > 0f)
				{
					this.instantiateManager.EnemyBloneru_RangeShotPicture(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 1, 0, 0);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.instantiateManager.EnemyBloneru_RangeShotPicture(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1, 1, 0, 1);
				}
				break;
			}
		}

		// Token: 0x060012EE RID: 4846 RVA: 0x000D3AE0 File Offset: 0x000D1CE0
		private IEnumerator EnumInstantBlood(float delay)
		{
			yield return new WaitForSeconds(delay);
			if (this.instantBloodCount < 15)
			{
				this.instantiateManager.EnemyBloneru_Blood_Spray(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1);
				this.instantiateManager.EnemyBloneru_Blood_Spray(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1);
				this.instantiateManager.EnemyBloneru_Blood_Spray(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1);
				this.instantiateManager.EnemyBloneru_Blood_Spray(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1);
				this.instantiateManager.EnemyBloneru_Blood_Spray(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1);
				this.instantiateManager.EnemyBloneru_Blood_Spray(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1);
				this.instantiateManager.EnemyBloneru_Blood_Spray(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1);
				this.instantiateManager.EnemyBloneru_Blood_Spray(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1);
				this.instantiateManager.EnemyBloneru_Blood_Spray(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1);
				this.instantiateManager.EnemyBloneru_Blood_Spray(this.muzzle.transform.position.x, this.muzzle.transform.position.y, this.rangeWeaponATK1);
				base.StartCoroutine(this.EnumInstantBlood(0.2f));
				this.instantBloodCount++;
			}
			else if (this.instantBloodCount >= 15)
			{
				this.instantBloodCount = 0;
			}
			yield break;
		}

		// Token: 0x060012EF RID: 4847 RVA: 0x000D3B04 File Offset: 0x000D1D04
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
						this.eCV.SoundEffectPlay(11);
						break;
					case 1:
						this.eCV.SoundEffectPlay(12);
						break;
					case 2:
						this.eCV.SoundEffectPlay(13);
						break;
					case 3:
						this.eCV.SoundEffectPlay(14);
						break;
					case 4:
						this.eCV.SoundEffectPlay(15);
						break;
					case 5:
						this.eCV.SoundEffectPlay(16);
						break;
					case 6:
						this.eCV.SoundEffectPlay(17);
						break;
					case 7:
						this.eCV.SoundEffectPlay(18);
						break;
					case 8:
						this.eCV.SoundEffectPlay(19);
						break;
					case 9:
						this.eCV.SoundEffectPlay(20);
						break;
					case 10:
						this.eCV.SoundEffectPlay(21);
						break;
					}
				}
			}
			else
			{
				this.eCV.SoundEffectPlay(num);
			}
		}

		// Token: 0x060012F0 RID: 4848 RVA: 0x000D3C3D File Offset: 0x000D1E3D
		public void SoundEffectCall(int num)
		{
			this.eSE.SoundEffectPlay(num);
		}

		// Token: 0x060012F1 RID: 4849 RVA: 0x000D3C4B File Offset: 0x000D1E4B
		public void SoundEffectStop()
		{
			this.eSE.SoundEffectStop();
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x000D3C58 File Offset: 0x000D1E58
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

		// Token: 0x060012F3 RID: 4851 RVA: 0x000D3CF4 File Offset: 0x000D1EF4
		public void VelocityY(float Vy)
		{
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, Vy);
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x000D3D25 File Offset: 0x000D1F25
		[PunRPC]
		private void ReciveTarget(int num)
		{
			this.targetPlayer = GameObject.Find(this.ReturnTargetName(num));
			if (!this.activeAI)
			{
				this.activeAI = true;
			}
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x000D3D4B File Offset: 0x000D1F4B
		[PunRPC]
		private void ReciveDead()
		{
			if (!this.deadCheck)
			{
				this.Dead();
				this.deadCheck = true;
			}
		}

		// Token: 0x060012F6 RID: 4854 RVA: 0x000D3D65 File Offset: 0x000D1F65
		[PunRPC]
		private void ReciveSetLanguage(int val)
		{
			this.lang = val;
		}

		// Token: 0x060012F7 RID: 4855 RVA: 0x000D3D70 File Offset: 0x000D1F70
		[PunRPC]
		private void ReciveState(int val, int val2)
		{
			switch (val)
			{
			case 2:
				if (!this.animator.GetBool("ATK_Blood1"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.localScale.x > 0f)
					{
						this.bossRoomPicture.AnimSwitch(6);
					}
					else if (base.transform.localScale.x < 0f)
					{
						this.bossRoomPicture.AnimSwitch(2);
					}
					this.animator.SetBool("ATK_Blood1", true);
				}
				this.canAI = false;
				break;
			case 3:
				if (!this.animator.GetBool("ATK_Blood2"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.localScale.x > 0f)
					{
						this.bossRoomPicture.AnimSwitch(5);
					}
					else if (base.transform.localScale.x < 0f)
					{
						this.bossRoomPicture.AnimSwitch(1);
					}
					this.animator.SetBool("ATK_Blood2", true);
				}
				this.canAI = false;
				break;
			case 4:
				if (!this.animator.GetBool("ATK_Blood3"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.localScale.x > 0f)
					{
						this.bossRoomPicture.AnimSwitch(7);
					}
					else if (base.transform.localScale.x < 0f)
					{
						this.bossRoomPicture.AnimSwitch(4);
					}
					this.animator.SetBool("ATK_Blood3", true);
				}
				this.canAI = false;
				break;
			case 5:
				if (!this.animator.GetBool("ATK_Blood4"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					if (base.transform.localScale.x > 0f)
					{
						this.bossRoomPicture.AnimSwitch(8);
					}
					else if (base.transform.localScale.x < 0f)
					{
						this.bossRoomPicture.AnimSwitch(3);
					}
					this.animator.SetBool("ATK_Blood4", true);
				}
				this.canAI = false;
				break;
			case 6:
				if (!this.animator.GetBool("ATK_Spray"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.animator.SetBool("ATK_Spray", true);
					this.summonCount = 1;
				}
				this.canAI = false;
				break;
			case 7:
				if (!this.animator.GetBool("ATK_Spray"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.animator.SetBool("ATK_Spray", true);
					this.summonCount = 2;
				}
				this.canAI = false;
				break;
			case 8:
				if (!this.animator.GetBool("ATK_Spray"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.animator.SetBool("ATK_Spray", true);
					this.summonCount = 1;
				}
				this.canAI = false;
				break;
			case 9:
				if (val2 != 1)
				{
					if (val2 != 2)
					{
						if (val2 == 3)
						{
							this.returnPos = new Vector2(this.leftTrans.position.x, this.leftTrans.transform.position.y);
						}
					}
					else
					{
						this.returnPos = new Vector2(this.middleTrans.position.x, this.middleTrans.transform.position.y);
					}
				}
				else
				{
					this.returnPos = new Vector2(this.rightTrans.position.x, this.rightTrans.transform.position.y);
				}
				this.pictureCount = 0;
				this.upPos = new Vector2(base.transform.position.x, base.transform.position.y + 2f);
				if (!this.animator.GetBool("Picture"))
				{
					if (this.playerBackSide)
					{
						this.DirTurn();
					}
					this.animator.SetBool("Picture", true);
				}
				this.canAI = false;
				break;
			case 11:
				Debug.Log("Active");
				if (base.GetComponent<Rigidbody2D>() == null)
				{
					base.gameObject.AddComponent<Rigidbody2D>();
					base.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
					base.GetComponent<Rigidbody2D>().gravityScale = 1f;
					foreach (EnemyBody enemyBody in this.targetEB)
					{
						enemyBody.blocked = false;
					}
					this.activeAI = true;
				}
				break;
			}
		}

		// Token: 0x060012F8 RID: 4856 RVA: 0x00098AA0 File Offset: 0x00096CA0
		[PunRPC]
		private void ReciveCurse()
		{
			this.curseTimer = 0f;
			if (!this.curse)
			{
				this.curse = true;
			}
		}

		// Token: 0x060012F9 RID: 4857 RVA: 0x00098ABF File Offset: 0x00096CBF
		[PunRPC]
		private void RecivePoison()
		{
			this.poisonTimer = 0f;
			if (!this.poison)
			{
				this.poison = true;
			}
		}

		// Token: 0x040019F3 RID: 6643
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Bloneru_Idle_Battle");

		// Token: 0x040019F4 RID: 6644
		public static readonly int ANISTS_Sleep = Animator.StringToHash("Base Layer.Bloneru_Idle");

		// Token: 0x040019F5 RID: 6645
		public static readonly int ANISTS_WakeUp = Animator.StringToHash("Base Layer.Bloneru_GoBattle");

		// Token: 0x040019F6 RID: 6646
		public static readonly int ANISTS_ATK_Blood1 = Animator.StringToHash("Base Layer.Bloneru_ATK_BloodPicture_A");

		// Token: 0x040019F7 RID: 6647
		public static readonly int ANISTS_ATK_Blood2 = Animator.StringToHash("Base Layer.Bloneru_ATK_BloodPicture_B");

		// Token: 0x040019F8 RID: 6648
		public static readonly int ANISTS_ATK_Blood3 = Animator.StringToHash("Base Layer.Bloneru_ATK_BloodPicture_C");

		// Token: 0x040019F9 RID: 6649
		public static readonly int ANISTS_ATK_Blood4 = Animator.StringToHash("Base Layer.Bloneru_ATK_BloodPicture_D");

		// Token: 0x040019FA RID: 6650
		public static readonly int ANISTS_ATK_Spray = Animator.StringToHash("Base Layer.Bloneru_ATK_BloodSpray");

		// Token: 0x040019FB RID: 6651
		public static readonly int ANISTS_ATK_Summon1 = Animator.StringToHash("Base Layer.Bloneru_ATK_Summon_Stone");

		// Token: 0x040019FC RID: 6652
		public static readonly int ANISTS_ATK_Summon2 = Animator.StringToHash("Base Layer.Bloneru_ATK_Summon_Poison");

		// Token: 0x040019FD RID: 6653
		public static readonly int ANISTS_ATK_Summon3 = Animator.StringToHash("Base Layer.Bloneru_ATK_Summon_Curse");

		// Token: 0x040019FE RID: 6654
		public static readonly int ANISTS_ATK_Picture = Animator.StringToHash("Base Layer.Bloneru_ATK_PictureMove");

		// Token: 0x040019FF RID: 6655
		public static readonly int ANISTS_ATK_Picture2 = Animator.StringToHash("Base Layer.Bloneru_PictureMove2");

		// Token: 0x04001A00 RID: 6656
		public static readonly int ANISTS_ATK_PictureAttack = Animator.StringToHash("Base Layer.Bloneru_ATK_Picture");

		// Token: 0x04001A01 RID: 6657
		public static readonly int ANISTS_ATK_Picture_Return = Animator.StringToHash("Base Layer.Bloneru_PictureMove_Return");

		// Token: 0x04001A02 RID: 6658
		public static readonly int ANISTS_Dead = Animator.StringToHash("Base Layer.Bloneru_Dead");

		// Token: 0x04001A03 RID: 6659
		protected float aiActionTimeLength;

		// Token: 0x04001A04 RID: 6660
		protected float aiActionTimeStart;

		// Token: 0x04001A05 RID: 6661
		public Bloneru.ENEMYAISTS enemyAists;

		// Token: 0x04001A06 RID: 6662
		public float speed = 1.2f;

		// Token: 0x04001A07 RID: 6663
		public bool activeAI;

		// Token: 0x04001A08 RID: 6664
		public float timetest2;

		// Token: 0x04001A09 RID: 6665
		public float waitTimeMin = 3f;

		// Token: 0x04001A0A RID: 6666
		public float waitTimeMax = 4f;

		// Token: 0x04001A0B RID: 6667
		public float searchTargetTimer;

		// Token: 0x04001A0C RID: 6668
		public float startHp;

		// Token: 0x04001A0D RID: 6669
		public bool playerBackSide;

		// Token: 0x04001A0E RID: 6670
		public bool canAI;

		// Token: 0x04001A0F RID: 6671
		public bool deadCheck;

		// Token: 0x04001A10 RID: 6672
		public bool bgmCheck;

		// Token: 0x04001A11 RID: 6673
		public EnemyBody enemyBody;

		// Token: 0x04001A12 RID: 6674
		private GameObject[] allPlayer;

		// Token: 0x04001A13 RID: 6675
		public Transform chestPos;

		// Token: 0x04001A14 RID: 6676
		private EnemySoundEffect eCV;

		// Token: 0x04001A15 RID: 6677
		private EnemySoundEffect eSE;

		// Token: 0x04001A16 RID: 6678
		private Animator targetAnim;

		// Token: 0x04001A17 RID: 6679
		private Text targetText;

		// Token: 0x04001A18 RID: 6680
		private Image targetImage;

		// Token: 0x04001A19 RID: 6681
		public Sprite archiveSprite;

		// Token: 0x04001A1A RID: 6682
		public Sprite archiveSprite2;

		// Token: 0x04001A1B RID: 6683
		public Sprite archiveSprite3;

		// Token: 0x04001A1C RID: 6684
		public bool alreadyUnlockArchive;

		// Token: 0x04001A1D RID: 6685
		public bool alreadyUnlockArchive2;

		// Token: 0x04001A1E RID: 6686
		public bool alreadyUnlockArchive3;

		// Token: 0x04001A1F RID: 6687
		public bool alreadyUnlockArchive4;

		// Token: 0x04001A20 RID: 6688
		private MenuOnOff menuOnOff;

		// Token: 0x04001A21 RID: 6689
		public int skeltonPlayers;

		// Token: 0x04001A22 RID: 6690
		private PlayerStatus playerStatus;

		// Token: 0x04001A23 RID: 6691
		private PhotonView myPV;

		// Token: 0x04001A24 RID: 6692
		public GameObject targetPlayer;

		// Token: 0x04001A25 RID: 6693
		private BGMWorks bgmWorks;

		// Token: 0x04001A26 RID: 6694
		public int bossBGM;

		// Token: 0x04001A27 RID: 6695
		public int score;

		// Token: 0x04001A28 RID: 6696
		public PlayerSpwan playerSpawn;

		// Token: 0x04001A29 RID: 6697
		public bool check;

		// Token: 0x04001A2A RID: 6698
		public int lang;

		// Token: 0x04001A2B RID: 6699
		public CVSounds cVSounds;

		// Token: 0x04001A2C RID: 6700
		public GameObject lastDMG;

		// Token: 0x04001A2D RID: 6701
		public Transform muzzle;

		// Token: 0x04001A2E RID: 6702
		public float rangeWeaponATK1;

		// Token: 0x04001A2F RID: 6703
		public int boxLevel;

		// Token: 0x04001A30 RID: 6704
		public float returnLobbyTime;

		// Token: 0x04001A31 RID: 6705
		private MeshRenderer mesh;

		// Token: 0x04001A32 RID: 6706
		private CameraController cameraCtrl;

		// Token: 0x04001A33 RID: 6707
		public InstantiateManager instantiateManager;

		// Token: 0x04001A34 RID: 6708
		public int aICount;

		// Token: 0x04001A35 RID: 6709
		public int pictureCount;

		// Token: 0x04001A36 RID: 6710
		public EnemyBody[] targetEB;

		// Token: 0x04001A37 RID: 6711
		private Vector2 upPos;

		// Token: 0x04001A38 RID: 6712
		private Vector2 returnPos;

		// Token: 0x04001A39 RID: 6713
		public Transform rightTrans;

		// Token: 0x04001A3A RID: 6714
		public Transform middleTrans;

		// Token: 0x04001A3B RID: 6715
		public Transform leftTrans;

		// Token: 0x04001A3C RID: 6716
		public bool check2;

		// Token: 0x04001A3D RID: 6717
		public int instantBloodCount;

		// Token: 0x04001A3E RID: 6718
		public int summonCount;

		// Token: 0x04001A3F RID: 6719
		public bool check3;

		// Token: 0x04001A40 RID: 6720
		public BossRoomPicture bossRoomPicture;

		// Token: 0x0200027E RID: 638
		public enum ENEMYAISTS
		{
			// Token: 0x04001A42 RID: 6722
			WAIT,
			// Token: 0x04001A43 RID: 6723
			ATK_BlOODLINE1,
			// Token: 0x04001A44 RID: 6724
			ATK_BlOODLINE2,
			// Token: 0x04001A45 RID: 6725
			ATK_BlOODLINE3,
			// Token: 0x04001A46 RID: 6726
			ATK_BlOODLINE4,
			// Token: 0x04001A47 RID: 6727
			ATK_PICTURE,
			// Token: 0x04001A48 RID: 6728
			ATK_SUMMON1,
			// Token: 0x04001A49 RID: 6729
			ATK_SUMMON2,
			// Token: 0x04001A4A RID: 6730
			ATK_SUMMON3
		}
	}
}
