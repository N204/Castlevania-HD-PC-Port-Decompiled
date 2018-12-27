using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000325 RID: 805
	public class ChestGold : EnemyMain
	{
		// Token: 0x06001991 RID: 6545 RVA: 0x00141320 File Offset: 0x0013F520
		private void Start()
		{
			if (SceneManager.GetActiveScene().name == "Menu_Title_Return")
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			this.playerSpawn = GameObject.Find("StageNetwork").GetComponent<PlayerSpwan>();
			this.menuOnOff = GameObject.Find("Canvas_UI").GetComponent<MenuOnOff>();
			this.countDown = GameObject.Find("Canvas_UI/TimeLimt/TimeSec").GetComponent<CountDown>();
			this.bgmWorks = GameObject.Find("BGM").GetComponent<BGMWorks>();
			this.bgmWorks.SystemBGMCall(35);
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			base.transform.parent = this.playerStatus.enemyPrefab.transform;
		}

		// Token: 0x06001992 RID: 6546 RVA: 0x001413E8 File Offset: 0x0013F5E8
		private void Update()
		{
			if (this.animator.GetCurrentAnimatorStateInfo(0).fullPathHash == ChestGold.ANISTS_Open)
			{
				this.stageClear = true;
			}
			if (this.grounded)
			{
				this.animator.SetBool("Grounded", true);
				this.col2d.enabled = true;
			}
			if (this.stageClear && !this.checkOnce)
			{
				string stageObjectName = this.playerSpawn.stageObjectName;
				if (stageObjectName != null)
				{
					if (!(stageObjectName == "Stage/Stage01"))
					{
						if (stageObjectName == "Stage/Stage12")
						{
							int stageDifficult = this.playerStatus.stageDifficult;
							if (stageDifficult != 1)
							{
								if (stageDifficult != 2)
								{
									if (stageDifficult == 3)
									{
										if (PlayerPrefs.GetInt("BGM_Arcade") == 0)
										{
											PlayerPrefs.SetInt("BGM_Arcade", 1);
										}
									}
								}
								else if (PlayerPrefs.GetInt("BGM_XX") == 0)
								{
									PlayerPrefs.SetInt("BGM_XX", 1);
								}
							}
							else if (PlayerPrefs.GetInt("BGM_Rondo") == 0)
							{
								PlayerPrefs.SetInt("BGM_Rondo", 1);
							}
						}
					}
					else
					{
						int stageDifficult2 = this.playerStatus.stageDifficult;
						if (stageDifficult2 != 1)
						{
							if (stageDifficult2 != 2)
							{
								if (stageDifficult2 == 3)
								{
									if (PlayerPrefs.GetInt("BGM_Akatuki") == 0)
									{
										PlayerPrefs.SetInt("BGM_Akatuki", 1);
									}
								}
							}
							else if (PlayerPrefs.GetInt("BGM_Sougetu") == 0)
							{
								PlayerPrefs.SetInt("BGM_Sougetu", 1);
							}
						}
						else
						{
							int @int = PlayerPrefs.GetInt("Stage01Clear_Normal");
							int int2 = PlayerPrefs.GetInt("BGM_Others");
							int int3 = PlayerPrefs.GetInt("BGM_Gekka");
							if (@int == 0)
							{
								PlayerPrefs.SetInt("Stage01Clear_Normal", 1);
							}
							if (int2 == 0)
							{
								PlayerPrefs.SetInt("BGM_Others", 1);
							}
							if (int3 == 0)
							{
								PlayerPrefs.SetInt("BGM_Gekka", 1);
							}
						}
					}
				}
				this.countDown.start = false;
				if (this.returnLobbyTime > 0f)
				{
					this.playerSpawn.returnLobbyTime = this.returnLobbyTime;
				}
				this.playerSpawn.SaveDateAddScore();
				base.StartCoroutine(this.CallSuccess(2f));
				this.checkOnce = true;
			}
		}

		// Token: 0x06001993 RID: 6547 RVA: 0x00141648 File Offset: 0x0013F848
		private IEnumerator CallSuccess(float delay)
		{
			yield return new WaitForSeconds(delay);
			this.menuOnOff.Success();
			this.bgmWorks.SystemBGMCall(36);
			yield break;
		}

		// Token: 0x0400254F RID: 9551
		public static readonly int ANISTS_Open = Animator.StringToHash("Base Layer.Chest_Gold_Open");

		// Token: 0x04002550 RID: 9552
		public bool stageClear;

		// Token: 0x04002551 RID: 9553
		public bool checkOnce;

		// Token: 0x04002552 RID: 9554
		private PlayerSpwan playerSpawn;

		// Token: 0x04002553 RID: 9555
		public BoxCollider2D col2d;

		// Token: 0x04002554 RID: 9556
		private MenuOnOff menuOnOff;

		// Token: 0x04002555 RID: 9557
		private CountDown countDown;

		// Token: 0x04002556 RID: 9558
		private BGMWorks bgmWorks;

		// Token: 0x04002557 RID: 9559
		public float returnLobbyTime;

		// Token: 0x04002558 RID: 9560
		private PlayerStatus playerStatus;
	}
}
