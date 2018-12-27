using System;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x02000521 RID: 1313
	public class CameraController : MonoBehaviour
	{
		// Token: 0x060031D9 RID: 12761 RVA: 0x005C9050 File Offset: 0x005C7250
		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(this.cameraBottomLeft, this.cameraTopLeft);
			Gizmos.DrawLine(this.cameraTopLeft, this.cameraTopRight);
			Gizmos.DrawLine(this.cameraTopRight, this.cameraBottomRight);
			Gizmos.DrawLine(this.cameraBottomRight, this.cameraBottomLeft);
		}

		// Token: 0x060031DA RID: 12762 RVA: 0x005C90AC File Offset: 0x005C72AC
		private void Awake()
		{
			if (!this.testPlayStage)
			{
				this.settingChange = GameObject.Find("Stage/Stage_UI/SettingChanger").GetComponent<SettingChange>();
			}
			this.startPos = new Vector3(base.transform.position.x, base.transform.position.y, -10f);
		}

		// Token: 0x060031DB RID: 12763 RVA: 0x005C9110 File Offset: 0x005C7310
		private void Start()
		{
			this.thisCamera = base.GetComponent<Camera>();
			this.stageController = GameObject.Find("CameraRange").GetComponent<StageController>();
			this.playerSpawn = GameObject.Find("StageNetwork").GetComponent<PlayerSpwan>();
			if (!this.testPlayStage)
			{
				this.target = GameObject.Find("CameraPosZentai");
			}
			if (!this.testPlayStage)
			{
				this.menuOnOff = GameObject.Find("Stage/Stage_UI/Canvas_UI").GetComponent<MenuOnOff>();
			}
			CameraController.startWorldPointX = this.thisCamera.ViewportToWorldPoint(new Vector3(0f, 1f, this.thisCamera.nearClipPlane)).x;
			CameraController.endWorldPointX = this.thisCamera.ViewportToWorldPoint(new Vector3(1f, 1f, this.thisCamera.nearClipPlane)).x;
			CameraController.startWorldPointY = this.thisCamera.ViewportToWorldPoint(new Vector3(0f, 0f, this.thisCamera.nearClipPlane)).y;
			CameraController.endWorldPointY = this.thisCamera.ViewportToWorldPoint(new Vector3(0f, 1f, this.thisCamera.nearClipPlane)).y;
			this.thisCamera.orthographicSize = this.size4;
		}

		// Token: 0x060031DC RID: 12764 RVA: 0x005C9268 File Offset: 0x005C7468
		private void Update()
		{
			this.cameraBottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, this.distance));
			this.cameraTopRight = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, this.distance));
			this.cameraTopLeft = new Vector3(this.cameraBottomLeft.x, this.cameraTopRight.y, this.cameraBottomLeft.z);
			this.cameraBottomRight = new Vector3(this.cameraTopRight.x, this.cameraBottomLeft.y, this.cameraTopRight.z);
			this.cameraRangeWidth = Vector3.Distance(this.cameraBottomLeft, this.cameraBottomRight);
			this.cameraRangeHeight = Vector3.Distance(this.cameraBottomLeft, this.cameraTopLeft);
			if (this.target.name == "CameraPlayerTarget")
			{
				float num = Input.GetAxisRaw("CameraMoveX");
				float num2 = Input.GetAxisRaw("CameraMoveY");
				if (!Input.GetKey(KeyCode.LeftAlt))
				{
					if (this.mouseX != 0f)
					{
						this.mouseX = 0f;
					}
					if (this.mouseY != 0f)
					{
						this.mouseY = 0f;
					}
					if (num == 0f && num2 == 0f)
					{
						Vector3 vector = this.target.transform.position;
						this.newX = Mathf.Clamp(vector.x, this.stageController.StageRect.xMin + this.cameraRangeWidth / 2f, this.stageController.StageRect.xMax - this.cameraRangeWidth / 2f);
						this.newY = Mathf.Clamp(vector.y, this.stageController.StageRect.yMin + this.cameraRangeHeight / 2f, this.stageController.StageRect.yMax - this.cameraRangeHeight / 2f);
					}
					else if (num != 0f || num2 != 0f)
					{
						num *= 5f;
						num2 *= 5f;
						Vector3 vector = new Vector2(this.target.transform.position.x + num, this.target.transform.position.y + num2);
						this.newX = Mathf.Clamp(vector.x, this.stageController.StageRect.xMin + this.cameraRangeWidth / 2f, this.stageController.StageRect.xMax - this.cameraRangeWidth / 2f);
						this.newY = Mathf.Clamp(vector.y, this.stageController.StageRect.yMin + this.cameraRangeHeight / 2f, this.stageController.StageRect.yMax - this.cameraRangeHeight / 2f);
					}
				}
				if (Input.GetKey(KeyCode.LeftAlt))
				{
					float axis = Input.GetAxis("Mouse X");
					float axis2 = Input.GetAxis("Mouse Y");
					float num3 = Mathf.Clamp(Input.GetAxis("Mouse X"), -1f, 1f);
					float num4 = Mathf.Clamp(Input.GetAxis("Mouse Y"), -1f, 1f);
					this.mouseX += num3;
					this.mouseY += num4;
					Vector3 vector = new Vector2(this.target.transform.position.x + this.mouseX, this.target.transform.position.y + this.mouseY);
					this.newX = Mathf.Clamp(vector.x, this.stageController.StageRect.xMin + this.cameraRangeWidth / 2f, this.stageController.StageRect.xMax - this.cameraRangeWidth / 2f);
					this.newY = Mathf.Clamp(vector.y, this.stageController.StageRect.yMin + this.cameraRangeHeight / 2f, this.stageController.StageRect.yMax - this.cameraRangeHeight / 2f);
				}
			}
			if (base.GetComponent<Rigidbody2D>().velocity.x != 0f || base.GetComponent<Rigidbody2D>().velocity.y != 0f)
			{
				this.cameraMoving = true;
			}
			else if (base.GetComponent<Rigidbody2D>().velocity.x == 0f || base.GetComponent<Rigidbody2D>().velocity.y == 0f)
			{
				this.cameraMoving = false;
			}
			if (this.target.name == "CameraTargetBoss" || this.target.name == "CameraPlayerTarget")
			{
				if (!this.cameraMoving)
				{
					Vector3 position = new Vector3(this.newX, this.newY, base.transform.position.z);
					base.transform.position = position;
				}
				if (this.cameraBottomRight.y < this.stageController.StageRect.yMin)
				{
					Vector3 position = new Vector3(base.transform.position.x, this.stageController.StageRect.yMin + this.cameraRangeHeight / 2f, base.transform.position.z);
					base.transform.position = position;
				}
				if (this.cameraBottomLeft.y < this.stageController.StageRect.yMin)
				{
					Vector3 position = new Vector3(base.transform.position.x, this.stageController.StageRect.yMin + this.cameraRangeHeight / 2f, base.transform.position.z);
					base.transform.position = position;
				}
				if (this.cameraTopLeft.y > this.stageController.StageRect.yMax)
				{
					Vector3 position = new Vector3(base.transform.position.x, this.stageController.StageRect.yMax - this.cameraRangeHeight / 2f, base.transform.position.z);
					base.transform.position = position;
				}
				if (this.cameraTopRight.y > this.stageController.StageRect.yMax)
				{
					Vector3 position = new Vector3(base.transform.position.x, this.stageController.StageRect.yMax - this.cameraRangeHeight / 2f, base.transform.position.z);
					base.transform.position = position;
				}
			}
			if (!this.testPlayStage && !this.playerSpawn.startLevel)
			{
				Vector3 vector = this.target.transform.position;
				this.newX = Mathf.Clamp(vector.x, this.stageController.StageRect.xMin + this.cameraRangeWidth / 2f, this.stageController.StageRect.xMax - this.cameraRangeWidth / 2f);
				this.newY = Mathf.Clamp(vector.y, this.stageController.StageRect.yMin + this.cameraRangeHeight / 2f, this.stageController.StageRect.yMax - this.cameraRangeHeight / 2f);
			}
			if (!this.testPlayStage && this.playerSpawn.startLevel && !this.cameraStart)
			{
				this.target = GameObject.Find("CameraTargetBoss");
				Vector3 vector = this.target.transform.position;
				this.newX = Mathf.Clamp(vector.x, this.stageController.StageRect.xMin + this.cameraRangeWidth / 2f, this.stageController.StageRect.xMax - this.cameraRangeWidth / 2f);
				this.newY = Mathf.Clamp(vector.y, this.stageController.StageRect.yMin + this.cameraRangeHeight / 2f, this.stageController.StageRect.yMax - this.cameraRangeHeight / 2f);
				this.timer += Time.deltaTime;
				if (this.timer < this.timerCam1 && this.thisCamera.orthographicSize > this.size1)
				{
					this.thisCamera.orthographicSize -= 1f;
				}
				if (this.timer > this.timerCam2)
				{
					if (this.thisCamera.orthographicSize < this.size4)
					{
						this.thisCamera.orthographicSize += 1f;
					}
					if (this.thisCamera.orthographicSize >= this.size4)
					{
						this.cameraStart = true;
						if (!this.testPlayStage)
						{
							this.menuOnOff.canInput = true;
						}
					}
				}
			}
			if (this.cameraStart && !this.cameraActive)
			{
				this.target = GameObject.Find("CameraPlayerTarget");
				Vector3 vector = this.target.transform.position;
				this.newX = Mathf.Clamp(vector.x, this.stageController.StageRect.xMin + this.cameraRangeWidth / 2f, this.stageController.StageRect.xMax - this.cameraRangeWidth / 2f);
				this.newY = Mathf.Clamp(vector.y, this.stageController.StageRect.yMin + this.cameraRangeHeight / 2f, this.stageController.StageRect.yMax - this.cameraRangeHeight / 2f);
				this.timer2 += Time.deltaTime;
				if (this.thisCamera.orthographicSize > this.size1)
				{
					this.thisCamera.orthographicSize -= 3.5f;
				}
				if (this.thisCamera.orthographicSize <= this.size1)
				{
					this.cameraActive = true;
				}
			}
			if (this.cameraActive && !this.playerSpawn.endGame)
			{
				if (this.thisCamera.orthographicSize < this.size4)
				{
					this.target = GameObject.Find("CameraPlayerTarget");
				}
				else if (this.thisCamera.orthographicSize >= this.size4)
				{
					this.target = GameObject.Find("CameraPosZentai");
				}
				if (Input.GetButtonDown("CameraZoom"))
				{
					this.cameraZoomCount++;
					this.zoomCheck = false;
				}
				if (this.cameraZoomCount >= 4)
				{
					this.cameraZoomCount = 0;
				}
				if (this.cameraZoomCount == 0)
				{
					switch (this.cameraZoomNumber1)
					{
					case 0:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size1)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size1)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size1;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size1)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size1)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size1;
								}
							}
						}
						break;
					case 1:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size1)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size1)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size1;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size1)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size1)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size1;
								}
							}
						}
						break;
					case 2:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size2)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size2)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size2;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size2)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size2)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size2;
								}
							}
						}
						break;
					case 3:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size3)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size3)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size3;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size3)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size3)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size3;
								}
							}
						}
						break;
					}
				}
				else if (this.cameraZoomCount == 1)
				{
					switch (this.cameraZoomNumber2)
					{
					case 0:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size2)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size2)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size2;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size2)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size2)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size2;
								}
							}
						}
						break;
					case 1:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size1)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size1)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size1;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size1)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size1)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size1;
								}
							}
						}
						break;
					case 2:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size2)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size2)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size2;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size2)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size2)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size2;
								}
							}
						}
						break;
					case 3:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size3)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size3)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size3;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size3)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size3)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size3;
								}
							}
						}
						break;
					}
				}
				else if (this.cameraZoomCount == 2)
				{
					switch (this.cameraZoomNumber3)
					{
					case 0:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size3)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size3)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size3;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size3)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size3)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size3;
								}
							}
						}
						break;
					case 1:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size1)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size1)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size1;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size1)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size1)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size1;
								}
							}
						}
						break;
					case 2:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size2)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size2)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size2;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size2)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size2)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size2;
								}
							}
						}
						break;
					case 3:
						if (!this.zoomCheck)
						{
							if (this.thisCamera.orthographicSize > this.size3)
							{
								this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize <= this.size3)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size3;
								}
							}
							else if (this.thisCamera.orthographicSize < this.size3)
							{
								this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
								if (this.thisCamera.orthographicSize >= this.size3)
								{
									this.zoomCheck = true;
									this.thisCamera.orthographicSize = this.size3;
								}
							}
						}
						break;
					}
				}
				else if (this.cameraZoomCount == 3 && !this.zoomCheck)
				{
					if (this.thisCamera.orthographicSize > this.size4)
					{
						this.thisCamera.orthographicSize -= Time.deltaTime * this.cameraZoomSpeed;
						if (this.thisCamera.orthographicSize <= this.size4)
						{
							this.zoomCheck = true;
							this.thisCamera.orthographicSize = this.size4;
						}
					}
					else if (this.thisCamera.orthographicSize < this.size4)
					{
						this.thisCamera.orthographicSize += Time.deltaTime * this.cameraZoomSpeed;
						if (this.thisCamera.orthographicSize >= this.size4)
						{
							this.zoomCheck = true;
							this.thisCamera.orthographicSize = this.size4;
						}
					}
				}
			}
			if (this.bossTargetText != null && this.cameraStart)
			{
				if (this.thisCamera.orthographicSize >= this.size4)
				{
					this.bossTargetText.enabled = true;
				}
				else if (this.thisCamera.orthographicSize < this.size4)
				{
					this.bossTargetText.enabled = false;
				}
			}
		}

		// Token: 0x060031DD RID: 12765 RVA: 0x005CA9FC File Offset: 0x005C8BFC
		private void FixedUpdate()
		{
			if (!this.testPlayStage && this.settingChange.changeCameraSet)
			{
				this.cameraZoomSpeed = this.settingChange.cameraZoomSpeed;
				this.cameraZoomNumber1 = this.settingChange.cameraZoomNum1;
				this.cameraZoomNumber2 = this.settingChange.cameraZoomNum2;
				this.cameraZoomNumber3 = this.settingChange.cameraZoomNum3;
			}
		}

		// Token: 0x060031DE RID: 12766 RVA: 0x005CAA68 File Offset: 0x005C8C68
		public void Reset()
		{
			this.cameraZoomSpeed = PlayerPrefs.GetFloat("CameraZoomSpeed") * 3f;
			this.cameraZoomNumber1 = PlayerPrefs.GetInt("CameraZoomNumber1");
			this.cameraZoomNumber2 = PlayerPrefs.GetInt("CameraZoomNumber2");
			this.cameraZoomNumber3 = PlayerPrefs.GetInt("CameraZoomNumber3");
			if (this.cameraZoomSpeed == 0f)
			{
				this.cameraZoomSpeed = 30f;
			}
			this.target = GameObject.Find("CameraPosZentai");
			this.thisCamera.orthographicSize = this.size4;
			this.cameraActive = false;
			this.cameraMoving = false;
			this.cameraCanMove = false;
			this.cameraStart = false;
			this.cameraZoomCount = 0;
			this.timer = 0f;
			this.timer2 = 0f;
			this.zoomCheck = false;
			base.transform.position = this.startPos;
		}

		// Token: 0x04006423 RID: 25635
		public GameObject target;

		// Token: 0x04006424 RID: 25636
		private Camera thisCamera;

		// Token: 0x04006425 RID: 25637
		private MenuOnOff menuOnOff;

		// Token: 0x04006426 RID: 25638
		private StageController stageController;

		// Token: 0x04006427 RID: 25639
		private float distance = 10f;

		// Token: 0x04006428 RID: 25640
		private PlayerSpwan playerSpawn;

		// Token: 0x04006429 RID: 25641
		public MeshRenderer bossTargetText;

		// Token: 0x0400642A RID: 25642
		private SettingChange settingChange;

		// Token: 0x0400642B RID: 25643
		public bool cameraActive;

		// Token: 0x0400642C RID: 25644
		public bool cameraMoving;

		// Token: 0x0400642D RID: 25645
		public bool cameraCanMove;

		// Token: 0x0400642E RID: 25646
		public bool cameraStart;

		// Token: 0x0400642F RID: 25647
		public int cameraZoomCount;

		// Token: 0x04006430 RID: 25648
		public static float startWorldPointX;

		// Token: 0x04006431 RID: 25649
		public static float endWorldPointX;

		// Token: 0x04006432 RID: 25650
		public static float startWorldPointY;

		// Token: 0x04006433 RID: 25651
		public static float endWorldPointY;

		// Token: 0x04006434 RID: 25652
		public float timer;

		// Token: 0x04006435 RID: 25653
		public float timer2;

		// Token: 0x04006436 RID: 25654
		public float cameraZoomSpeed;

		// Token: 0x04006437 RID: 25655
		public int cameraZoomNumber1;

		// Token: 0x04006438 RID: 25656
		public int cameraZoomNumber2;

		// Token: 0x04006439 RID: 25657
		public int cameraZoomNumber3;

		// Token: 0x0400643A RID: 25658
		public bool zoomCheck;

		// Token: 0x0400643B RID: 25659
		private Vector3 cameraBottomLeft;

		// Token: 0x0400643C RID: 25660
		private Vector3 cameraTopLeft;

		// Token: 0x0400643D RID: 25661
		private Vector3 cameraBottomRight;

		// Token: 0x0400643E RID: 25662
		private Vector3 cameraTopRight;

		// Token: 0x0400643F RID: 25663
		public float cameraRangeWidth;

		// Token: 0x04006440 RID: 25664
		public float cameraRangeHeight;

		// Token: 0x04006441 RID: 25665
		public float newX;

		// Token: 0x04006442 RID: 25666
		public float newY;

		// Token: 0x04006443 RID: 25667
		public float size1;

		// Token: 0x04006444 RID: 25668
		public float size2;

		// Token: 0x04006445 RID: 25669
		public float size3;

		// Token: 0x04006446 RID: 25670
		public float size4;

		// Token: 0x04006447 RID: 25671
		public float timerCam1 = 1f;

		// Token: 0x04006448 RID: 25672
		public float timerCam2 = 2f;

		// Token: 0x04006449 RID: 25673
		public float mouseX;

		// Token: 0x0400644A RID: 25674
		public float mouseY;

		// Token: 0x0400644B RID: 25675
		public bool testPlayStage;

		// Token: 0x0400644C RID: 25676
		private Vector3 startPos;
	}
}
