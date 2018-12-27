using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020001F7 RID: 503
	public class Boss01Active : MonoBehaviour
	{
		// Token: 0x06000D68 RID: 3432 RVA: 0x0008F01C File Offset: 0x0008D21C
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent")
			{
				if (this.bossStage01 != null)
				{
					if (!this.bossStage01.goBattle)
					{
						this.bossStage01.goBattle = true;
						this.bossStage01.activeAI = true;
					}
					if (this.bossStage01.targetPlayer == null)
					{
						this.bossStage01.targetPlayer = other.gameObject;
					}
				}
				else if (this.boss02 != null)
				{
					if (this.boss02.gameObject.GetComponent<Rigidbody2D>() == null)
					{
						this.boss02.gameObject.AddComponent<Rigidbody2D>();
						this.boss02.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
						this.boss02.GetComponent<Rigidbody2D>().gravityScale = 1.7f;
					}
					if (!this.boss02.goBattle)
					{
						this.boss02.goBattle = true;
						this.boss02.activeAI = true;
					}
					if (this.boss02.targetPlayer == null)
					{
						this.boss02.targetPlayer = other.gameObject;
					}
				}
				else if (this.enemy_Menace != null)
				{
					if (!this.enemy_Menace.activeAI)
					{
						this.enemy_Menace.ActiveAI();
					}
				}
				else if (this.bloneru != null)
				{
					if (!this.bloneru.activeAI)
					{
						this.bloneru.ActiveAI();
					}
				}
				else if (this.balow != null)
				{
					if (!this.balow.activeAI)
					{
						this.balow.ActiveAI();
					}
				}
				else if (this.enemy_Dracula != null)
				{
					if (!this.enemy_Dracula.activeAI)
					{
						this.enemy_Dracula.ActiveAI();
					}
				}
				else if (this.enemy_Dracula_OoE != null)
				{
					if (!this.enemy_Dracula_OoE.activeAI)
					{
						this.enemy_Dracula_OoE.ActiveAI();
					}
				}
				else if (this.enemy_Asyutarute != null)
				{
					if (!this.enemy_Asyutarute.activeAI)
					{
						this.enemy_Asyutarute.ActiveAI();
					}
				}
				else if (this.enemy_Region != null)
				{
					if (!this.enemy_Region.activeAI)
					{
						this.enemy_Region.ActiveAI();
					}
				}
				else if (this.boss_PuppetMaster != null)
				{
					if (!this.boss_PuppetMaster.activeAI)
					{
						this.boss_PuppetMaster.activeAI = true;
					}
					if (this.boss_PuppetMaster.targetPlayer == null)
					{
						this.boss_PuppetMaster.targetPlayer = other.gameObject;
					}
				}
				else if (this.kani != null)
				{
					if (!this.kani.activeAI)
					{
						this.kani.SetActive();
					}
				}
				else if (this.death != null)
				{
					int num = this.switchVal;
					if (num != 1)
					{
						if (num == 2)
						{
							this.death.ActiveAI();
						}
					}
					else
					{
						this.death.ActiveAIBefore();
					}
				}
			}
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x0008F388 File Offset: 0x0008D588
		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.tag == "PlayerBodyEvent" && this.boss02 != null)
			{
				PhotonView component = other.transform.parent.GetComponent<PhotonView>();
				if (!component.isMine || this.boss02.goBattle)
				{
				}
			}
		}

		// Token: 0x040011FC RID: 4604
		public BossStage01 bossStage01;

		// Token: 0x040011FD RID: 4605
		public Boss02 boss02;

		// Token: 0x040011FE RID: 4606
		public Enemy_Menace enemy_Menace;

		// Token: 0x040011FF RID: 4607
		public Boss_PuppetMaster boss_PuppetMaster;

		// Token: 0x04001200 RID: 4608
		public Bloneru bloneru;

		// Token: 0x04001201 RID: 4609
		public Enemy_Kani kani;

		// Token: 0x04001202 RID: 4610
		public Balow balow;

		// Token: 0x04001203 RID: 4611
		public Enemy_Death death;

		// Token: 0x04001204 RID: 4612
		public Enemy_Dracula enemy_Dracula;

		// Token: 0x04001205 RID: 4613
		public Enemy_Dracula_OoE enemy_Dracula_OoE;

		// Token: 0x04001206 RID: 4614
		public Enemy_Asyutarute enemy_Asyutarute;

		// Token: 0x04001207 RID: 4615
		public Enemy_Region enemy_Region;

		// Token: 0x04001208 RID: 4616
		public int switchVal;
	}
}
