using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x0200032A RID: 810
	public class BloodyCrossHealOrb : MonoBehaviour
	{
		// Token: 0x060019CE RID: 6606 RVA: 0x00155868 File Offset: 0x00153A68
		private void Awake()
		{
			this.eSE = base.GetComponent<EnemySoundEffect>();
		}

		// Token: 0x060019CF RID: 6607 RVA: 0x00155878 File Offset: 0x00153A78
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.tag == "PlayerBody" && other.transform.parent.gameObject == this.target)
			{
				this.currentPlayerBody = other.GetComponent<BoxCollider2D>();
				if (!this.hitedATK)
				{
					float x = base.transform.position.x;
					float y = base.transform.position.y;
					if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController>())
					{
						PlayerController component = this.currentPlayerBody.transform.parent.GetComponent<PlayerController>();
						if (!this.mpHeal)
						{
							component.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Shanoa>())
					{
						PlayerController_Shanoa component2 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Shanoa>();
						if (!this.mpHeal)
						{
							component2.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component2.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Jonathan>())
					{
						PlayerController_Jonathan component3 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Jonathan>();
						if (!this.mpHeal)
						{
							component3.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component3.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Charotte>())
					{
						PlayerController_Charotte component4 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Charotte>();
						if (!this.mpHeal)
						{
							component4.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component4.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Albus>())
					{
						PlayerController_Albus component5 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Albus>();
						if (!this.mpHeal)
						{
							component5.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component5.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Soma>())
					{
						PlayerController_Soma component6 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Soma>();
						if (!this.mpHeal)
						{
							component6.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component6.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Alucard>())
					{
						PlayerController_Alucard component7 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Alucard>();
						if (!this.mpHeal)
						{
							component7.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component7.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Julius>())
					{
						PlayerController_Julius component8 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Julius>();
						if (!this.mpHeal)
						{
							component8.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component8.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Yoko>())
					{
						PlayerController_Yoko component9 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Yoko>();
						if (!this.mpHeal)
						{
							component9.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component9.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Maria>())
					{
						PlayerController_Maria component10 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Maria>();
						if (!this.mpHeal)
						{
							component10.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component10.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Simon>())
					{
						PlayerController_Simon component11 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Simon>();
						if (!this.mpHeal)
						{
							component11.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component11.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Fuma>())
					{
						PlayerController_Fuma component12 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Fuma>();
						if (!this.mpHeal)
						{
							component12.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component12.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Add1>())
					{
						PlayerController_Add1 component13 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Add1>();
						if (!this.mpHeal)
						{
							component13.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component13.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Add2>())
					{
						PlayerController_Add2 component14 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Add2>();
						if (!this.mpHeal)
						{
							component14.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component14.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Add3>())
					{
						PlayerController_Add3 component15 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Add3>();
						if (!this.mpHeal)
						{
							component15.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component15.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Add4>())
					{
						PlayerController_Add4 component16 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Add4>();
						if (!this.mpHeal)
						{
							component16.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component16.HPMPHeal(0f, this.healPoint);
						}
					}
					else if (this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Add5>())
					{
						PlayerController_Add5 component17 = this.currentPlayerBody.transform.parent.GetComponent<PlayerController_Add5>();
						if (!this.mpHeal)
						{
							component17.HPMPHeal(this.healPoint, 0f);
						}
						else if (this.mpHeal)
						{
							component17.HPMPHeal(0f, this.healPoint);
						}
					}
					this.hitedATK = true;
				}
			}
		}

		// Token: 0x060019D0 RID: 6608 RVA: 0x00156118 File Offset: 0x00154318
		private void Update()
		{
			if (this.target != null)
			{
				if (!this.destroyCheck && !this.hitedATK)
				{
					this.targetPos = new Vector2(this.target.transform.position.x, this.target.transform.position.y + 0.3f);
					if (this.time > 1f)
					{
					}
					base.transform.position = this.BezierCurve(this.startPos, this.targetPos, this.posHokan, this.time);
					this.time += Time.deltaTime * 2.5f;
				}
			}
			else if (this.target == null)
			{
				this.GameObjectFalse();
			}
			if (!this.destroyCheck)
			{
				this.timer += Time.deltaTime;
				if (this.timer >= 5f)
				{
					foreach (ParticleSystem particleSystem in this.hitPS)
					{
						particleSystem.Play();
					}
					this.boxCol2d.enabled = false;
					base.Invoke("GameObjectFalse", 2f);
					this.eSE.SoundEffectPlay(1);
					this.trail.enabled = false;
					this.destroyCheck = true;
				}
				if (this.hitedATK)
				{
					foreach (ParticleSystem particleSystem2 in this.hitPS)
					{
						particleSystem2.Play();
					}
					foreach (ParticleSystem particleSystem3 in this.targetPS)
					{
						particleSystem3.Stop();
					}
					this.boxCol2d.enabled = false;
					base.Invoke("GameObjectFalse", 2f);
					this.eSE.SoundEffectPlay(1);
					this.trail.enabled = false;
					this.destroyCheck = true;
				}
			}
		}

		// Token: 0x060019D1 RID: 6609 RVA: 0x00156338 File Offset: 0x00154538
		public void Action()
		{
			this.startPos = base.transform.position;
			this.posHokan = new Vector2(UnityEngine.Random.Range(base.transform.position.x - 2f, base.transform.position.x + 2f), UnityEngine.Random.Range(base.transform.position.y - 1f, base.transform.position.y - 2f));
			this.targetPos = new Vector2(this.target.transform.position.x, this.target.transform.position.y + 0.3f);
			foreach (ParticleSystem particleSystem in this.hitPS)
			{
				particleSystem.Stop();
			}
			foreach (ParticleSystem particleSystem2 in this.targetPS)
			{
				particleSystem2.Play();
			}
			this.trail.enabled = true;
			this.timer = 0f;
			this.time = 0f;
			this.destroyCheck = false;
			this.hitedATK = false;
			this.currentPlayerBody = null;
			this.boxCol2d.enabled = true;
			this.eSE.SoundEffectPlay(0);
		}

		// Token: 0x060019D2 RID: 6610 RVA: 0x001564CC File Offset: 0x001546CC
		private Vector3 BezierCurve(Vector3 pt1, Vector3 pt2, Vector3 ctrlPt, float t)
		{
			if (t > 1f)
			{
				t = 1f;
			}
			Vector3 result = default(Vector3);
			float num = 1f - t;
			result.x = num * num * pt1.x + 2f * num * t * ctrlPt.x + t * t * pt2.x;
			result.y = num * num * pt1.y + 2f * num * t * ctrlPt.y + t * t * pt2.y;
			result.z = num * num * pt1.z + 2f * num * t * ctrlPt.z + t * t * pt2.z;
			return result;
		}

		// Token: 0x060019D3 RID: 6611 RVA: 0x00156597 File Offset: 0x00154797
		public void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(base.gameObject);
		}

		// Token: 0x04002670 RID: 9840
		public BoxCollider2D currentPlayerBody;

		// Token: 0x04002671 RID: 9841
		public InstantiateManager instantiateManager;

		// Token: 0x04002672 RID: 9842
		public ParticleSystem[] targetPS;

		// Token: 0x04002673 RID: 9843
		public TrailRenderer trail;

		// Token: 0x04002674 RID: 9844
		public ParticleSystem[] hitPS;

		// Token: 0x04002675 RID: 9845
		public CircleCollider2D boxCol2d;

		// Token: 0x04002676 RID: 9846
		private EnemySoundEffect eSE;

		// Token: 0x04002677 RID: 9847
		public Vector3 startPos;

		// Token: 0x04002678 RID: 9848
		public Vector3 targetPos;

		// Token: 0x04002679 RID: 9849
		public Vector3 posHokan;

		// Token: 0x0400267A RID: 9850
		public float timer;

		// Token: 0x0400267B RID: 9851
		public float healPoint;

		// Token: 0x0400267C RID: 9852
		public bool destroyCheck;

		// Token: 0x0400267D RID: 9853
		public bool hitedATK;

		// Token: 0x0400267E RID: 9854
		public bool mpHeal;

		// Token: 0x0400267F RID: 9855
		private float time;

		// Token: 0x04002680 RID: 9856
		public GameObject target;
	}
}
