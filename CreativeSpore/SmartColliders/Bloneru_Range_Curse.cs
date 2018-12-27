using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000282 RID: 642
	public class Bloneru_Range_Curse : MonoBehaviour
	{
		// Token: 0x0600130E RID: 4878 RVA: 0x000D499D File Offset: 0x000D2B9D
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.ese = base.GetComponent<EnemySoundEffect>();
		}

		// Token: 0x0600130F RID: 4879 RVA: 0x000D49CC File Offset: 0x000D2BCC
		private void Update()
		{
			this.timer += Time.deltaTime;
			Vector2 lhs = new Vector2(base.transform.position.x, base.transform.position.y);
			if (this.timer > this.waitTime)
			{
				if (!this.check)
				{
					this.ese.SoundEffectPlay(0);
					this.check = true;
				}
				if (base.transform.localScale.x > 0f)
				{
					this.movePos = new Vector2(base.transform.position.x - 1f, base.transform.position.y);
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.movePos = new Vector2(base.transform.position.x + 1f, base.transform.position.y);
				}
				if (lhs != this.movePos)
				{
					base.transform.position = Vector2.MoveTowards(base.transform.position, this.movePos, this.speed * Time.deltaTime);
				}
			}
			if (this.timer > 15f && !this.destroyCheck)
			{
				this.animator.SetTrigger("Out");
				base.Invoke("GameObjectFalse", 2f);
				this.destroyCheck = true;
			}
		}

		// Token: 0x06001310 RID: 4880 RVA: 0x000D4B84 File Offset: 0x000D2D84
		public void Action()
		{
			if (!this.hanten)
			{
				this.waitTime = 2f;
				if (base.transform.localScale.y < 0f)
				{
					this.DirTurn();
				}
			}
			else if (this.hanten)
			{
				this.waitTime = 3f;
				if (base.transform.localScale.y > 0f)
				{
					this.DirTurn();
				}
			}
			int stageDifficult = this.playerStatus.stageDifficult;
			if (stageDifficult != 1)
			{
				if (stageDifficult != 2)
				{
					if (stageDifficult == 3)
					{
						this.speed = 3f;
					}
				}
				else
				{
					this.speed = 2.5f;
				}
			}
			else
			{
				this.speed = 2f;
			}
			this.timer = 0f;
			this.destroyCheck = false;
			this.animator.ResetTrigger("Out");
			this.check = false;
		}

		// Token: 0x06001311 RID: 4881 RVA: 0x000D4C88 File Offset: 0x000D2E88
		private void DirTurn()
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.y * -1f, base.transform.localScale.z);
		}

		// Token: 0x06001312 RID: 4882 RVA: 0x000D4CE4 File Offset: 0x000D2EE4
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04001A5A RID: 6746
		public InstantiateManager instantiateManager;

		// Token: 0x04001A5B RID: 6747
		public float waitTime;

		// Token: 0x04001A5C RID: 6748
		public float timer;

		// Token: 0x04001A5D RID: 6749
		public bool destroyCheck;

		// Token: 0x04001A5E RID: 6750
		public int count;

		// Token: 0x04001A5F RID: 6751
		public float speed = 1f;

		// Token: 0x04001A60 RID: 6752
		public bool hanten;

		// Token: 0x04001A61 RID: 6753
		private Vector2 movePos;

		// Token: 0x04001A62 RID: 6754
		private Animator animator;

		// Token: 0x04001A63 RID: 6755
		private PlayerStatus playerStatus;

		// Token: 0x04001A64 RID: 6756
		private EnemySoundEffect ese;

		// Token: 0x04001A65 RID: 6757
		public bool check;
	}
}
