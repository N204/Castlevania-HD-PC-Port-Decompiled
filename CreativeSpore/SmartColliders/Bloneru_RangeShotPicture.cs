using System;
using System.Collections;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000286 RID: 646
	public class Bloneru_RangeShotPicture : MonoBehaviour
	{
		// Token: 0x06001328 RID: 4904 RVA: 0x000D580F File Offset: 0x000D3A0F
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
		}

		// Token: 0x06001329 RID: 4905 RVA: 0x000D5820 File Offset: 0x000D3A20
		private void Update()
		{
			Vector2 lhs = new Vector2(base.transform.position.x, base.transform.position.y);
			if (!this.turn)
			{
				if (lhs != this.startPos)
				{
					base.transform.position = Vector2.MoveTowards(base.transform.position, this.startPos, 2f * Time.deltaTime);
				}
				else if (lhs == this.startPos)
				{
					this.turn = true;
				}
			}
			else if (this.turn)
			{
				if (lhs != this.targetPos)
				{
					base.transform.position = Vector2.MoveTowards(base.transform.position, this.targetPos, 2f * Time.deltaTime);
				}
				else if (lhs == this.targetPos && !this.destroyCheck)
				{
					this.animator.SetTrigger("Out");
					int num = this.count;
					if (num != 1)
					{
						if (num != 2)
						{
							if (num == 3)
							{
								if (!this.rightPos)
								{
									if (!this.up)
									{
										this.instantiateManager.EnemyBloneru_Range_Curse(base.transform.position.x, base.transform.position.y - 2f, this.atkVal, 0, 0);
										base.Invoke("GameObjectFalse", 1f);
									}
									else if (this.up)
									{
										this.instantiateManager.EnemyBloneru_Range_Curse(base.transform.position.x, base.transform.position.y + 0.4f, this.atkVal, 0, 1);
										base.Invoke("GameObjectFalse", 1f);
									}
								}
								else if (this.rightPos)
								{
									if (!this.up)
									{
										this.instantiateManager.EnemyBloneru_Range_Curse(base.transform.position.x, base.transform.position.y - 2f, this.atkVal, 1, 0);
										base.Invoke("GameObjectFalse", 1f);
									}
									else if (this.up)
									{
										this.instantiateManager.EnemyBloneru_Range_Curse(base.transform.position.x, base.transform.position.y + 0.4f, this.atkVal, 1, 1);
										base.Invoke("GameObjectFalse", 1f);
									}
								}
							}
						}
						else
						{
							this.instantiateManager.EnemyBloneru_Range_Poison(base.transform.position.x, base.transform.position.y - 2f, this.atkVal, 1);
							this.instantiateManager.EnemyBloneru_Range_Poison(base.transform.position.x, base.transform.position.y - 2f, this.atkVal, 2);
							base.Invoke("GameObjectFalse", 1f);
						}
					}
					else
					{
						base.StartCoroutine(this.EnumInstant(0f));
					}
					this.destroyCheck = true;
				}
			}
		}

		// Token: 0x0600132A RID: 4906 RVA: 0x000D5BC8 File Offset: 0x000D3DC8
		private IEnumerator EnumInstant(float delay)
		{
			yield return new WaitForSeconds(delay);
			if (this.instantCount < 10)
			{
				if (!this.rightPos)
				{
					this.instantiateManager.EnemyBloneru_Range_Stone(UnityEngine.Random.Range(base.transform.position.x - 0.5f, base.transform.position.x - 0.2f), UnityEngine.Random.Range(base.transform.position.y - 0.5f, base.transform.position.y + 0.2f), this.atkVal, 0);
				}
				else if (this.rightPos)
				{
					this.instantiateManager.EnemyBloneru_Range_Stone(UnityEngine.Random.Range(base.transform.position.x + 0.2f, base.transform.position.x + 0.5f), UnityEngine.Random.Range(base.transform.position.y - 0.5f, base.transform.position.y + 0.2f), this.atkVal, 1);
				}
				base.StartCoroutine(this.EnumInstant(0.5f));
				this.instantCount++;
			}
			else if (this.instantCount >= 10)
			{
				this.instantCount = 0;
				this.GameObjectFalse();
			}
			yield break;
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x000D5BEC File Offset: 0x000D3DEC
		public void Action()
		{
			this.turn = false;
			this.destroyCheck = false;
			this.instantCount = 0;
			this.startPos = new Vector2(base.transform.position.x, base.transform.position.y + 2f);
			int num = this.count;
			if (num != 1)
			{
				if (num != 2)
				{
					if (num == 3)
					{
						if (!this.up)
						{
							if (!this.rightPos)
							{
								this.targetPos = new Vector2(base.transform.position.x - 1.5f, base.transform.position.y + 1.7f);
							}
							else if (this.rightPos)
							{
								this.targetPos = new Vector2(base.transform.position.x + 1.5f, base.transform.position.y + 1.7f);
							}
						}
						else if (this.up)
						{
							if (!this.rightPos)
							{
								this.targetPos = new Vector2(base.transform.position.x - 1.5f, base.transform.position.y + 2.3f);
							}
							else if (this.rightPos)
							{
								this.targetPos = new Vector2(base.transform.position.x + 1.5f, base.transform.position.y + 2.3f);
							}
						}
					}
				}
				else if (!this.rightPos)
				{
					this.targetPos = new Vector2(base.transform.position.x - 2f, base.transform.position.y + 2f);
				}
				else if (this.rightPos)
				{
					this.targetPos = new Vector2(base.transform.position.x + 2f, base.transform.position.y + 2f);
				}
			}
			else if (!this.rightPos)
			{
				this.targetPos = new Vector2(base.transform.position.x - 0.2f, base.transform.position.y);
			}
			else if (this.rightPos)
			{
				this.targetPos = new Vector2(base.transform.position.x + 0.2f, base.transform.position.y);
			}
		}

		// Token: 0x0600132C RID: 4908 RVA: 0x000D5EE7 File Offset: 0x000D40E7
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04001A7E RID: 6782
		public InstantiateManager instantiateManager;

		// Token: 0x04001A7F RID: 6783
		public bool destroyCheck;

		// Token: 0x04001A80 RID: 6784
		public int count;

		// Token: 0x04001A81 RID: 6785
		public bool up;

		// Token: 0x04001A82 RID: 6786
		public float atkVal;

		// Token: 0x04001A83 RID: 6787
		private Vector2 startPos;

		// Token: 0x04001A84 RID: 6788
		private Vector2 targetPos;

		// Token: 0x04001A85 RID: 6789
		public bool turn;

		// Token: 0x04001A86 RID: 6790
		public bool rightPos;

		// Token: 0x04001A87 RID: 6791
		private Animator animator;

		// Token: 0x04001A88 RID: 6792
		public int instantCount;
	}
}
