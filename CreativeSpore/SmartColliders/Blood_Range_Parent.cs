using System;
using System.Collections;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000289 RID: 649
	public class Blood_Range_Parent : MonoBehaviour
	{
		// Token: 0x0600133B RID: 4923 RVA: 0x000D640A File Offset: 0x000D460A
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.ese = base.GetComponent<EnemySoundEffect>();
		}

		// Token: 0x0600133C RID: 4924 RVA: 0x000D6424 File Offset: 0x000D4624
		private void Update()
		{
			Vector2 lhs = new Vector2(base.transform.position.x, base.transform.position.y);
			if (lhs != this.movePos)
			{
				base.transform.position = Vector2.MoveTowards(base.transform.position, this.movePos, this.speed * Time.deltaTime);
			}
			else if (lhs == this.movePos && !this.destroyCheck)
			{
				this.animator.SetTrigger("Out");
				base.Invoke("GameObjectFalse", 1f);
				if (this.first)
				{
					switch (this.count)
					{
					case 1:
						this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.secoundPos.x, this.secoundPos.y, this.atkVal, 1, 1);
						break;
					case 2:
						this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.secoundPos.x, this.secoundPos.y, this.atkVal, 3, 1);
						break;
					case 3:
						this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.secoundPos.x, this.secoundPos.y, this.atkVal, 2, 1);
						break;
					case 4:
						this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.secoundPos.x, this.secoundPos.y, this.atkVal, 5, 1);
						break;
					case 5:
						this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.secoundPos.x, this.secoundPos.y, this.atkVal, 4, 1);
						break;
					case 6:
						this.instantiateManager.EnemyBloneru_Blood_Range_Parent(this.secoundPos.x, this.secoundPos.y, this.atkVal, 6, 1);
						break;
					}
				}
				this.destroyCheck = true;
			}
		}

		// Token: 0x0600133D RID: 4925 RVA: 0x000D6640 File Offset: 0x000D4840
		private IEnumerator EnumInstant(float delay)
		{
			yield return new WaitForSeconds(delay);
			if (!this.destroyCheck)
			{
				int num = UnityEngine.Random.Range(0, 10);
				if (num < 5)
				{
					this.instantiateManager.EnemyBloneru_Blood_Range(base.transform.position.x, base.transform.position.y, this.atkVal);
				}
				else if (num >= 5)
				{
					this.instantiateManager.EnemyBloneru_Blood_Range2(base.transform.position.x, base.transform.position.y, this.atkVal);
				}
				base.StartCoroutine(this.EnumInstant(0.05f));
			}
			yield break;
		}

		// Token: 0x0600133E RID: 4926 RVA: 0x000D6664 File Offset: 0x000D4864
		public void Action()
		{
			switch (this.count)
			{
			case 1:
				this.movePos = new Vector2(base.transform.position.x + 5f, base.transform.position.y);
				this.secoundPos = new Vector2(base.transform.position.x, base.transform.position.y - 2.3f);
				break;
			case 2:
				this.movePos = new Vector2(base.transform.position.x + 3f, base.transform.position.y - 3f);
				this.secoundPos = new Vector2(base.transform.position.x + 3f, base.transform.position.y);
				break;
			case 3:
				this.movePos = new Vector2(base.transform.position.x - 3f, base.transform.position.y - 3f);
				this.secoundPos = new Vector2(base.transform.position.x - 3f, base.transform.position.y);
				break;
			case 4:
				this.movePos = new Vector2(base.transform.position.x + 3f, base.transform.position.y - 1.5f);
				this.secoundPos = this.movePos;
				break;
			case 5:
				this.movePos = new Vector2(base.transform.position.x - 3f, base.transform.position.y - 1.5f);
				this.secoundPos = this.movePos;
				break;
			case 6:
				this.movePos = new Vector2(base.transform.position.x - 5f, base.transform.position.y);
				this.secoundPos = new Vector2(base.transform.position.x, base.transform.position.y - 2.3f);
				break;
			}
			base.transform.LookAt2D(this.movePos);
			this.destroyCheck = false;
			this.animator.ResetTrigger("Out");
			this.animator.Play("Blood_Range_Parent_Idle");
			base.StartCoroutine(this.EnumInstant(0f));
			this.ese.SoundEffectPlay(0);
		}

		// Token: 0x0600133F RID: 4927 RVA: 0x000D6978 File Offset: 0x000D4B78
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04001A92 RID: 6802
		public InstantiateManager instantiateManager;

		// Token: 0x04001A93 RID: 6803
		public bool destroyCheck;

		// Token: 0x04001A94 RID: 6804
		public int count;

		// Token: 0x04001A95 RID: 6805
		public float atkVal;

		// Token: 0x04001A96 RID: 6806
		public float speed = 1f;

		// Token: 0x04001A97 RID: 6807
		public bool first;

		// Token: 0x04001A98 RID: 6808
		private Vector2 movePos;

		// Token: 0x04001A99 RID: 6809
		private Animator animator;

		// Token: 0x04001A9A RID: 6810
		private Transform lookAtPos;

		// Token: 0x04001A9B RID: 6811
		private Vector2 secoundPos;

		// Token: 0x04001A9C RID: 6812
		private EnemySoundEffect ese;
	}
}
