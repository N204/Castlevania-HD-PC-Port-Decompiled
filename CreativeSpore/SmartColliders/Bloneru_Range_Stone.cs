using System;
using System.Collections;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000284 RID: 644
	public class Bloneru_Range_Stone : MonoBehaviour
	{
		// Token: 0x0600131A RID: 4890 RVA: 0x000D5056 File Offset: 0x000D3256
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.playerStatus = GameObject.Find("PlayerStatus").GetComponent<PlayerStatus>();
			this.enemyBody = base.GetComponent<EnemyBody>();
		}

		// Token: 0x0600131B RID: 4891 RVA: 0x000D5088 File Offset: 0x000D3288
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!this.damaged && (other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKFire" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper"))
			{
				if (base.transform.localScale.x > 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, base.GetComponent<Rigidbody2D>().velocity.y);
				}
				else if (base.transform.localScale.x < 0f)
				{
					base.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, base.GetComponent<Rigidbody2D>().velocity.y);
				}
				this.animator.SetTrigger("Damage");
				base.StartCoroutine(this.EnumReturnBool(1f));
				this.damaged = true;
			}
		}

		// Token: 0x0600131C RID: 4892 RVA: 0x000D52FC File Offset: 0x000D34FC
		private void Update()
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.animator.GetCurrentAnimatorStateInfo(0);
			this.timer += Time.deltaTime;
			Vector2 lhs = new Vector2(base.transform.position.x, base.transform.position.y);
			if (!this.damaged)
			{
				this.upDownTimer += Time.deltaTime;
				if (currentAnimatorStateInfo.fullPathHash == Bloneru_Range_Stone.ANISTS_Idle)
				{
					if (this.upDownTimer < 2f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, 0.3f);
					}
					else if (this.upDownTimer > 2f)
					{
						base.GetComponent<Rigidbody2D>().velocity = new Vector2(base.GetComponent<Rigidbody2D>().velocity.x, -0.3f);
					}
					else if (this.upDownTimer > 4f)
					{
						this.upDownTimer = 0f;
					}
				}
			}
			if (this.enemyBody.hp <= 0f && !this.destroyCheck)
			{
				this.animator.SetTrigger("Dead");
				this.animator.SetTrigger("Out");
				base.Invoke("GameObjectFalse", 2f);
				this.destroyCheck = true;
			}
			if (!this.damaged)
			{
				if (base.transform.localScale.x > 0f)
				{
					this.movePos = new Vector2(base.transform.position.x - 1f, base.transform.position.y);
					if (lhs != this.movePos)
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.movePos, this.speed * Time.deltaTime);
					}
				}
				else if (base.transform.localScale.x < 0f)
				{
					this.movePos = new Vector2(base.transform.position.x + 1f, base.transform.position.y);
					if (lhs != this.movePos)
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, this.movePos, this.speed * Time.deltaTime);
					}
				}
			}
			if (this.timer > 10f && !this.destroyCheck)
			{
				this.animator.SetTrigger("Out");
				base.Invoke("GameObjectFalse", 2f);
				this.destroyCheck = true;
			}
		}

		// Token: 0x0600131D RID: 4893 RVA: 0x000D5604 File Offset: 0x000D3804
		private IEnumerator EnumReturnBool(float delay)
		{
			yield return new WaitForSeconds(delay);
			base.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, base.GetComponent<Rigidbody2D>().velocity.y);
			this.damaged = false;
			yield break;
		}

		// Token: 0x0600131E RID: 4894 RVA: 0x000D5628 File Offset: 0x000D3828
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
						this.enemyBody.hp = 300f;
					}
				}
				else
				{
					this.speed = 1.5f;
					this.enemyBody.hp = 200f;
				}
			}
			else
			{
				this.speed = 1f;
				this.enemyBody.hp = 100f;
			}
			this.enemyBody.hp *= (float)this.playerStatus.stageDifficult;
			this.upDownTimer = 0f;
			this.timer = 0f;
			this.destroyCheck = false;
			this.animator.ResetTrigger("Dead");
			this.animator.ResetTrigger("Damaged");
			this.animator.ResetTrigger("Out");
			this.animator.Play("Bloneru_Range_Stone_Idle");
		}

		// Token: 0x0600131F RID: 4895 RVA: 0x000D5736 File Offset: 0x000D3936
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04001A6E RID: 6766
		public static readonly int ANISTS_Idle = Animator.StringToHash("Base Layer.Bloneru_Range_Stone_Idle");

		// Token: 0x04001A6F RID: 6767
		public InstantiateManager instantiateManager;

		// Token: 0x04001A70 RID: 6768
		public float upDownTimer;

		// Token: 0x04001A71 RID: 6769
		public float timer;

		// Token: 0x04001A72 RID: 6770
		public bool destroyCheck;

		// Token: 0x04001A73 RID: 6771
		public float speed = 1f;

		// Token: 0x04001A74 RID: 6772
		private Vector2 movePos;

		// Token: 0x04001A75 RID: 6773
		private Animator animator;

		// Token: 0x04001A76 RID: 6774
		private EnemyBody enemyBody;

		// Token: 0x04001A77 RID: 6775
		private PlayerStatus playerStatus;

		// Token: 0x04001A78 RID: 6776
		public bool damaged;
	}
}
