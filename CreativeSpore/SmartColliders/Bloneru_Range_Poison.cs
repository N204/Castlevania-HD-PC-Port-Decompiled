using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000283 RID: 643
	public class Bloneru_Range_Poison : MonoBehaviour
	{
		// Token: 0x06001314 RID: 4884 RVA: 0x000D4D0A File Offset: 0x000D2F0A
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
		}

		// Token: 0x06001315 RID: 4885 RVA: 0x000D4D30 File Offset: 0x000D2F30
		private void Update()
		{
			this.timer += Time.deltaTime;
			Vector2 lhs = new Vector2(base.transform.position.x, base.transform.position.y);
			int num = this.count;
			if (num != 1)
			{
				if (num == 2)
				{
					this.movePos = new Vector2(base.transform.position.x + 1f, base.transform.position.y);
					if (lhs != this.movePos)
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.movePos, this.speed * Time.deltaTime);
					}
				}
			}
			else
			{
				this.movePos = new Vector2(base.transform.position.x - 1f, base.transform.position.y);
				if (lhs != this.movePos)
				{
					base.transform.position = Vector2.MoveTowards(base.transform.position, this.movePos, this.speed * Time.deltaTime);
				}
			}
			if (this.timer > 10f && !this.destroyCheck)
			{
				this.animator.SetTrigger("Out");
				base.Invoke("GameObjectFalse", 2f);
				this.destroyCheck = true;
			}
		}

		// Token: 0x06001316 RID: 4886 RVA: 0x000D4EE4 File Offset: 0x000D30E4
		public void Action()
		{
			int stageDifficult = this.playerStatus.stageDifficult;
			if (stageDifficult != 1)
			{
				if (stageDifficult != 2)
				{
					if (stageDifficult == 3)
					{
						this.speed = 2f;
					}
				}
				else
				{
					this.speed = 1.5f;
				}
			}
			else
			{
				this.speed = 1f;
			}
			int num = this.count;
			if (num != 1)
			{
				if (num == 2)
				{
					if (base.transform.localScale.x > 0f)
					{
						this.DirTurn();
					}
				}
			}
			else if (base.transform.localScale.x < 0f)
			{
				this.DirTurn();
			}
			this.timer = 0f;
			this.destroyCheck = false;
			this.animator.ResetTrigger("Out");
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x000D4FD4 File Offset: 0x000D31D4
		private void DirTurn()
		{
			base.transform.localScale = new Vector3(base.transform.localScale.x * -1f, base.transform.localScale.y, base.transform.localScale.z);
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x000D5030 File Offset: 0x000D3230
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04001A66 RID: 6758
		public InstantiateManager instantiateManager;

		// Token: 0x04001A67 RID: 6759
		public float timer;

		// Token: 0x04001A68 RID: 6760
		public bool destroyCheck;

		// Token: 0x04001A69 RID: 6761
		public int count;

		// Token: 0x04001A6A RID: 6762
		public float speed = 1f;

		// Token: 0x04001A6B RID: 6763
		private Vector2 movePos;

		// Token: 0x04001A6C RID: 6764
		private Animator animator;

		// Token: 0x04001A6D RID: 6765
		private PlayerStatus playerStatus;
	}
}
