using System;
using System.Collections;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000506 RID: 1286
	public class BigHammer : MonoBehaviour
	{
		// Token: 0x06003142 RID: 12610 RVA: 0x005B8260 File Offset: 0x005B6460
		private void Awake()
		{
			this.animator = base.GetComponent<Animator>();
			this.hammerAnim = this.hammer.GetComponent<Animator>();
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
			this.eSE = base.transform.Find("CanHitGear").GetComponent<EnemySoundEffect>();
			this.eSE2 = this.hammerAnim.GetComponent<EnemySoundEffect>();
			this.myPV = base.GetComponent<PhotonView>();
		}

		// Token: 0x06003143 RID: 12611 RVA: 0x005B82D8 File Offset: 0x005B64D8
		private void OnTriggerEnter2D(Collider2D other)
		{
			if ((other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && this.swingCheck && this.canSwing && !this.hitCheck)
			{
				this.instantiateManager.HitEffectEnemy(other.transform.position.x, other.transform.position.y);
				if (PhotonNetwork.isMasterClient && this.count < 49)
				{
					this.hammerAnim.SetTrigger("Back");
					this.animator.SetTrigger("Right");
					this.count++;
					this.SetRotationZ();
					this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
					{
						1
					});
				}
				this.timer = 0f;
				this.hitCheck = true;
			}
		}

		// Token: 0x06003144 RID: 12612 RVA: 0x005B855C File Offset: 0x005B675C
		private void OnTriggerStay2D(Collider2D other)
		{
			if ((other.tag == "PlayerATKArm" || other.tag == "PlayerATKChain" || other.tag == "PlayerATKMagic" || other.tag == "PlayerMagic" || other.tag == "PlayerATKHit" || other.tag == "PlayerATKCut" || other.tag == "PlayerATKPoke" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKIce" || other.tag == "PlayerATKThunder" || other.tag == "PlayerATKStone" || other.tag == "PlayerATKLight" || other.tag == "PlayerATKDark" || other.tag == "PlayerATKPoison" || other.tag == "PlayerATKCurse" || other.tag == "PlayerATKKick" || other.tag == "PlayerATKSpinningKick" || other.tag == "PlayerATKSlidingKick" || other.tag == "PlayerATKTackle" || other.tag == "PlayerATKUpper") && this.swingCheck && this.canSwing && !this.hitCheck)
			{
				this.instantiateManager.HitEffectEnemy(other.transform.position.x, other.transform.position.y);
				if (PhotonNetwork.isMasterClient && this.count < 49)
				{
					this.hammerAnim.SetTrigger("Back");
					this.animator.SetTrigger("Right");
					this.count++;
					this.SetRotationZ();
					this.myPV.RPC("ReciveState", PhotonTargets.Others, new object[]
					{
						1
					});
				}
				this.timer = 0f;
				this.hitCheck = true;
			}
		}

		// Token: 0x06003145 RID: 12613 RVA: 0x005B87E0 File Offset: 0x005B69E0
		private void Update()
		{
			if (this.hitCheck)
			{
				this.timer += Time.deltaTime;
				if (this.timer >= 2f)
				{
					this.timer = 0f;
					this.hitCheck = false;
				}
			}
			if (this.canReturn)
			{
				float z = this.hammer.transform.localEulerAngles.z;
				if (z >= this.setRotationZ)
				{
					this.angle -= 1f;
					this.hammer.transform.localRotation = Quaternion.Euler(this.hammer.transform.localRotation.x, this.hammer.transform.localRotation.y, this.angle);
					foreach (GameObject gameObject in this.bigGear)
					{
						gameObject.transform.localRotation = Quaternion.Euler(gameObject.transform.localRotation.x, gameObject.transform.localRotation.y, this.angle);
					}
				}
				else if (z <= this.setRotationZ)
				{
					this.canReturn = false;
					if (this.count >= 49)
					{
						this.eSE2.SoundEffectPlay(0);
						this.check = true;
						Animator component = this.switchLever.GetComponent<Animator>();
						component.SetBool("SwitchLever", false);
						this.canSwing = false;
						this.swingCheck = false;
						this.count = 0;
						this.hammerRotationZ = 0f;
						this.setRotationZ = 0f;
						this.angle = 0f;
						this.timer = 0f;
						base.StartCoroutine(this.SetBool(3f));
					}
				}
			}
			if (this.swingCheck)
			{
				if (!this.switchLever.leverFixed)
				{
					this.switchLever.leverFixed = true;
				}
			}
			else if (!this.swingCheck)
			{
				if (this.switchLever.leverFixed)
				{
					this.switchLever.leverFixed = false;
				}
				if (this.switchLever.leverOn && !this.check)
				{
					this.swingCheck = true;
				}
			}
			if (this.swingCheck && !this.canSwing)
			{
				if (!this.animator.GetBool("Left"))
				{
					this.animator.SetBool("Left", true);
				}
				if (!this.targetATKCol.enabled)
				{
					this.targetATKCol.enabled = true;
				}
				this.hammerRotationZ += 2f;
				if (this.hammerRotationZ >= 150f)
				{
					this.animator.SetBool("Left", false);
					if (this.targetATKCol.enabled)
					{
						this.targetATKCol.enabled = false;
					}
					this.canSwing = true;
				}
				this.hammer.transform.localRotation = Quaternion.Euler(this.hammer.transform.localRotation.x, this.hammer.transform.localRotation.y, this.hammerRotationZ);
				foreach (GameObject gameObject2 in this.bigGear)
				{
					gameObject2.transform.localRotation = Quaternion.Euler(gameObject2.transform.localRotation.x, gameObject2.transform.localRotation.y, this.hammerRotationZ);
				}
				foreach (GameObject gameObject3 in this.smallGear)
				{
					gameObject3.transform.localRotation = Quaternion.Euler(gameObject3.transform.localRotation.x, gameObject3.transform.localRotation.y, this.hammerRotationZ * 10f);
				}
			}
		}

		// Token: 0x06003146 RID: 12614 RVA: 0x005B8C10 File Offset: 0x005B6E10
		private IEnumerator SetBool(float delay)
		{
			yield return new WaitForSeconds(delay);
			this.check = false;
			yield break;
		}

		// Token: 0x06003147 RID: 12615 RVA: 0x005B8C34 File Offset: 0x005B6E34
		private void SetRotationZ()
		{
			this.angle = this.hammer.transform.localEulerAngles.z;
			int num = 150 - 3 * this.count;
			this.setRotationZ = (float)num;
			this.canReturn = true;
		}

		// Token: 0x06003148 RID: 12616 RVA: 0x005B8C7D File Offset: 0x005B6E7D
		public void Sound()
		{
			this.eSE.SoundEffectPlay(0);
		}

		// Token: 0x06003149 RID: 12617 RVA: 0x005B8C8C File Offset: 0x005B6E8C
		public void Reset()
		{
			this.canSwing = false;
			this.swingCheck = false;
			this.hitCheck = false;
			this.canReturn = false;
			this.check = false;
			this.timer = 0f;
			this.hammerRotationZ = 0f;
			this.setRotationZ = 0f;
			this.angle = 0f;
			this.count = 0;
		}

		// Token: 0x0600314A RID: 12618 RVA: 0x005B8CF0 File Offset: 0x005B6EF0
		[PunRPC]
		private void ReciveState(int val)
		{
			if (val == 1)
			{
				this.hammerAnim.SetTrigger("Back");
				this.animator.SetTrigger("Right");
				this.count++;
				this.SetRotationZ();
			}
		}

		// Token: 0x040062F3 RID: 25331
		public GameObject hammer;

		// Token: 0x040062F4 RID: 25332
		public GameObject[] bigGear;

		// Token: 0x040062F5 RID: 25333
		public GameObject[] smallGear;

		// Token: 0x040062F6 RID: 25334
		public BoxCollider2D targetATKCol;

		// Token: 0x040062F7 RID: 25335
		public bool canSwing;

		// Token: 0x040062F8 RID: 25336
		public bool swingCheck;

		// Token: 0x040062F9 RID: 25337
		public bool hitCheck;

		// Token: 0x040062FA RID: 25338
		public bool canReturn;

		// Token: 0x040062FB RID: 25339
		public bool check;

		// Token: 0x040062FC RID: 25340
		public float timer;

		// Token: 0x040062FD RID: 25341
		public float hammerRotationZ;

		// Token: 0x040062FE RID: 25342
		public float setRotationZ;

		// Token: 0x040062FF RID: 25343
		public float angle;

		// Token: 0x04006300 RID: 25344
		public int count;

		// Token: 0x04006301 RID: 25345
		public SwitchLever switchLever;

		// Token: 0x04006302 RID: 25346
		private Animator animator;

		// Token: 0x04006303 RID: 25347
		private Animator hammerAnim;

		// Token: 0x04006304 RID: 25348
		private InstantiateManager instantiateManager;

		// Token: 0x04006305 RID: 25349
		private EnemySoundEffect eSE;

		// Token: 0x04006306 RID: 25350
		private EnemySoundEffect eSE2;

		// Token: 0x04006307 RID: 25351
		private PhotonView myPV;
	}
}
