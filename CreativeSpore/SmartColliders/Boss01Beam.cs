using System;
using System.Collections;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020001F8 RID: 504
	public class Boss01Beam : MonoBehaviour
	{
		// Token: 0x06000D6B RID: 3435 RVA: 0x0008F428 File Offset: 0x0008D628
		private void Awake()
		{
			this.bossStage01 = base.transform.parent.parent.GetComponent<BossStage01>();
			base.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
			this.instantiateManager = GameObject.Find("InstantiateManager").GetComponent<InstantiateManager>();
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x0008F47C File Offset: 0x0008D67C
		private void Update()
		{
			if (this.check)
			{
				RaycastHit raycastHit;
				if (Physics.Raycast(base.transform.position, base.transform.forward, out raycastHit, this.MaxLength))
				{
					this.isHit = true;
					this.NowLength = raycastHit.distance;
					if (this.MakeParticle)
					{
						UnityEngine.Object.Instantiate<GameObject>(this._Effect, raycastHit.point, raycastHit.transform.rotation);
					}
					else
					{
						this._Effect.transform.position = raycastHit.point;
						this._Effect.transform.rotation = raycastHit.transform.rotation;
					}
				}
				else
				{
					this.isHit = false;
					this.NowLength = this.MaxLength;
				}
				this.ChildParticleCheck();
				Boss01Beam.State laserState = this.LaserState;
				if (laserState != Boss01Beam.State.Start)
				{
					if (laserState == Boss01Beam.State.End)
					{
						this.bossStage01.beamGoWidth = false;
						this.CurrentWidth -= 0.1f;
						this.CurrentPitch -= 0.025f;
						if (this.CurrentPitch < 0f)
						{
							this.CurrentPitch = 0f;
						}
						this.SoundEffect.pitch = Mathf.Clamp(this.CurrentPitch, 0f, 1f);
						if (this.CurrentWidth <= 0f)
						{
							this.CurrentWidth = 0f;
							this.ChildParticleCheck();
							this.GameObjectFalse();
						}
						this._LineRenderer.SetWidth(this.CurrentWidth, this.CurrentWidth);
					}
				}
				else
				{
					if (!this.bossStage01.beamGoWidth)
					{
						this.CurrentWidth = 0.1f;
					}
					this._LineRenderer.SetWidth(this.CurrentWidth, this.CurrentWidth);
					if (this.bossStage01.beamGoWidth)
					{
						this.CurrentWidth += 0.1f;
						this._LineRenderer.SetWidth(this.CurrentWidth, this.CurrentWidth);
						this.CurrentPitch += 0.05f;
						if (this.CurrentPitch > 1f)
						{
							this.CurrentPitch = 1f;
						}
						this.SoundEffect.pitch = Mathf.Clamp(this.CurrentPitch, 0f, 1f);
						if (this.CurrentWidth >= this.Width)
						{
							this.CurrentWidth = this.Width;
							this._LineRenderer.SetWidth(this.Width, this.Width);
							base.StartCoroutine(this.DelayLoopFunction(2.5f));
						}
					}
				}
				Vector3 position = base.transform.position + new Vector3(base.transform.forward.x * (this.NowLength - 1f), base.transform.forward.y * (this.NowLength - 1f), base.transform.forward.z * (this.NowLength - 1f));
				this._LineRenderer.SetPosition(0, base.transform.position);
				this._LineRenderer.SetPosition(1, position);
				this._LineRenderer.material.SetTextureOffset("_MainTex", new Vector2(-Time.time * 30f * this.Offset, 0f));
				this._LineRenderer.GetComponent<Renderer>().materials[0].mainTextureScale = new Vector2(this.NowLength / 10f, this._LineRenderer.GetComponent<Renderer>().materials[0].mainTextureScale.y);
			}
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x0008F830 File Offset: 0x0008DA30
		private IEnumerator DelayLoopFunction(float Time)
		{
			yield return new WaitForSeconds(Time);
			this.LaserState = Boss01Beam.State.End;
			yield break;
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x0008F854 File Offset: 0x0008DA54
		private void ChildParticleCheck()
		{
			ParticleSystem[] componentsInChildren = this._Effect.GetComponentsInChildren<ParticleSystem>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (this.isHit && this.CurrentWidth > 0f)
				{
					this.LightIntensity += 0.1f;
					this._Light.intensity = Mathf.Clamp(this.LightIntensity, 0f, 1f);
					componentsInChildren[i].Play();
				}
				else
				{
					componentsInChildren[i].Stop();
					this._Light.intensity = 0f;
				}
			}
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x0008F8F4 File Offset: 0x0008DAF4
		public void Action()
		{
			this.LaserState = Boss01Beam.State.Start;
			this.CurrentWidth = 0f;
			this.CurrentPitch = 0f;
			this.LightIntensity = 1f;
			this.NowLength = 0f;
			if (!(LineRenderer)base.transform.gameObject.GetComponent("LineRenderer"))
			{
				base.gameObject.AddComponent<LineRenderer>();
			}
			if (!this.MakeParticle)
			{
				this.instantiateManager.EnemyBeam(base.transform.position.x, base.transform.position.y, this);
			}
			this._LineRenderer = base.GetComponent<LineRenderer>();
			this._LineRenderer.material = this._Material;
			this._LineRenderer.SetWidth(0f, 0f);
			this._LineRenderer.SetColors(this.StartColor, this.EndColor);
			this.check = true;
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x0008F9F2 File Offset: 0x0008DBF2
		private void GameObjectFalse()
		{
			this.instantiateManager.releaseBall(this.laserObj);
		}

		// Token: 0x04001209 RID: 4617
		public float Width = 1.5f;

		// Token: 0x0400120A RID: 4618
		public float beamStartLimitWidth = 1f;

		// Token: 0x0400120B RID: 4619
		private float CurrentWidth;

		// Token: 0x0400120C RID: 4620
		public float Offset = 1f;

		// Token: 0x0400120D RID: 4621
		public float MaxLength = float.PositiveInfinity;

		// Token: 0x0400120E RID: 4622
		public Color StartColor;

		// Token: 0x0400120F RID: 4623
		public Color EndColor;

		// Token: 0x04001210 RID: 4624
		public Transform LaserHitEffect;

		// Token: 0x04001211 RID: 4625
		public Material _Material;

		// Token: 0x04001212 RID: 4626
		public bool MakeParticle;

		// Token: 0x04001213 RID: 4627
		private bool isHit;

		// Token: 0x04001214 RID: 4628
		public AudioSource SoundEffect;

		// Token: 0x04001215 RID: 4629
		private float CurrentPitch;

		// Token: 0x04001216 RID: 4630
		public Light _Light;

		// Token: 0x04001217 RID: 4631
		private float LightIntensity = 1f;

		// Token: 0x04001218 RID: 4632
		private LineRenderer _LineRenderer;

		// Token: 0x04001219 RID: 4633
		private float NowLength;

		// Token: 0x0400121A RID: 4634
		public GameObject _Effect;

		// Token: 0x0400121B RID: 4635
		public BossStage01 bossStage01;

		// Token: 0x0400121C RID: 4636
		public bool check;

		// Token: 0x0400121D RID: 4637
		private InstantiateManager instantiateManager;

		// Token: 0x0400121E RID: 4638
		public GameObject laserObj;

		// Token: 0x0400121F RID: 4639
		private Boss01Beam.State LaserState;

		// Token: 0x020001F9 RID: 505
		private enum State
		{
			// Token: 0x04001221 RID: 4641
			Start,
			// Token: 0x04001222 RID: 4642
			End
		}
	}
}
