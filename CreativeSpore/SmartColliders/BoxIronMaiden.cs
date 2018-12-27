using System;
using System.Collections.Generic;
using UnityEngine;

namespace CreativeSpore.SmartColliders
{
	// Token: 0x020004FE RID: 1278
	public class BoxIronMaiden : MonoBehaviour
	{
		// Token: 0x06003117 RID: 12567 RVA: 0x005B4638 File Offset: 0x005B2838
		private void Awake()
		{
			this.rightCheck1 = base.transform.Find("RightCheck1");
			this.rightCheck2 = base.transform.Find("RightCheck2");
			this.rightCheck3 = base.transform.Find("RightCheck3");
			this.leftCheck1 = base.transform.Find("LeftCheck1");
			this.leftCheck2 = base.transform.Find("LeftCheck2");
			this.leftCheck3 = base.transform.Find("LeftCheck3");
			this.rightCheckCollider[0] = new Collider2D[16];
			this.rightCheckCollider[1] = new Collider2D[16];
			this.rightCheckCollider[2] = new Collider2D[16];
			this.leftCheckCollider[0] = new Collider2D[16];
			this.leftCheckCollider[1] = new Collider2D[16];
			this.leftCheckCollider[2] = new Collider2D[16];
			this.rightPlayerList = new List<GameObject>();
			this.leftPlayerList = new List<GameObject>();
		}

		// Token: 0x06003118 RID: 12568 RVA: 0x005B473C File Offset: 0x005B293C
		private void Update()
		{
			if (this.rightPlayerList.Count > this.leftPlayerList.Count)
			{
				if (!this.leftHit)
				{
					if (this.rightPlayerList.Count - this.leftPlayerList.Count < 2)
					{
						Vector2 lhs = new Vector2(base.transform.position.x, base.transform.position.y);
						Vector2 vector = new Vector2(base.transform.position.x - 1f, base.transform.position.y);
						if (lhs != vector)
						{
							base.transform.position = Vector2.MoveTowards(base.transform.position, vector, this.speed * Time.deltaTime);
						}
					}
					else if (this.rightPlayerList.Count - this.leftPlayerList.Count >= 2)
					{
						Vector2 lhs2 = new Vector2(base.transform.position.x, base.transform.position.y);
						Vector2 vector2 = new Vector2(base.transform.position.x - 1f, base.transform.position.y);
						if (lhs2 != vector2)
						{
							base.transform.position = Vector2.MoveTowards(base.transform.position, vector2, this.speed * 2f * Time.deltaTime);
						}
					}
				}
			}
			else if (this.rightPlayerList.Count < this.leftPlayerList.Count && !this.rightHit)
			{
				if (this.leftPlayerList.Count - this.rightPlayerList.Count < 2)
				{
					Vector2 lhs3 = new Vector2(base.transform.position.x, base.transform.position.y);
					Vector2 vector3 = new Vector2(base.transform.position.x + 1f, base.transform.position.y);
					if (lhs3 != vector3)
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, vector3, this.speed * Time.deltaTime);
					}
				}
				else if (this.leftPlayerList.Count - this.rightPlayerList.Count >= 2)
				{
					Vector2 lhs4 = new Vector2(base.transform.position.x, base.transform.position.y);
					Vector2 vector4 = new Vector2(base.transform.position.x + 1f, base.transform.position.y);
					if (lhs4 != vector4)
					{
						base.transform.position = Vector2.MoveTowards(base.transform.position, vector4, this.speed * 2f * Time.deltaTime);
					}
				}
			}
		}

		// Token: 0x06003119 RID: 12569 RVA: 0x005B4AB4 File Offset: 0x005B2CB4
		private void FixedUpdate()
		{
			this.rightHit = false;
			this.leftHit = false;
			if (this.rightPlayerList != null)
			{
				foreach (GameObject gameObject in this.rightPlayerList)
				{
					if (gameObject.GetComponent<PlayerBodyCollider>() != null)
					{
						PlayerBodyCollider component = gameObject.GetComponent<PlayerBodyCollider>();
						if (!component.hitMoveBox)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.GetComponent<ShanoaBodyCollider>() != null)
					{
						ShanoaBodyCollider component2 = gameObject.GetComponent<ShanoaBodyCollider>();
						if (!component2.hitMoveBox)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController>() != null)
					{
						PlayerController component3 = gameObject.transform.parent.GetComponent<PlayerController>();
						if (!component3.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component3.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Shanoa>() != null)
					{
						PlayerController_Shanoa component4 = gameObject.transform.parent.GetComponent<PlayerController_Shanoa>();
						if (!component4.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component4.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Jonathan>() != null)
					{
						PlayerController_Jonathan component5 = gameObject.transform.parent.GetComponent<PlayerController_Jonathan>();
						if (!component5.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component5.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Charotte>() != null)
					{
						PlayerController_Charotte component6 = gameObject.transform.parent.GetComponent<PlayerController_Charotte>();
						if (!component6.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component6.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Albus>() != null)
					{
						PlayerController_Albus component7 = gameObject.transform.parent.GetComponent<PlayerController_Albus>();
						if (!component7.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component7.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Soma>() != null)
					{
						PlayerController_Soma component8 = gameObject.transform.parent.GetComponent<PlayerController_Soma>();
						if (!component8.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component8.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Alucard>() != null)
					{
						PlayerController_Alucard component9 = gameObject.transform.parent.GetComponent<PlayerController_Alucard>();
						if (!component9.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component9.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Julius>() != null)
					{
						PlayerController_Julius component10 = gameObject.transform.parent.GetComponent<PlayerController_Julius>();
						if (!component10.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component10.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Yoko>() != null)
					{
						PlayerController_Yoko component11 = gameObject.transform.parent.GetComponent<PlayerController_Yoko>();
						if (!component11.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component11.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Maria>() != null)
					{
						PlayerController_Maria component12 = gameObject.transform.parent.GetComponent<PlayerController_Maria>();
						if (!component12.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component12.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Simon>() != null)
					{
						PlayerController_Simon component13 = gameObject.transform.parent.GetComponent<PlayerController_Simon>();
						if (!component13.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component13.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Fuma>() != null)
					{
						PlayerController_Fuma component14 = gameObject.transform.parent.GetComponent<PlayerController_Fuma>();
						if (!component14.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component14.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Add1>() != null)
					{
						PlayerController_Add1 component15 = gameObject.transform.parent.GetComponent<PlayerController_Add1>();
						if (!component15.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component15.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Add2>() != null)
					{
						PlayerController_Add2 component16 = gameObject.transform.parent.GetComponent<PlayerController_Add2>();
						if (!component16.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component16.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Add3>() != null)
					{
						PlayerController_Add3 component17 = gameObject.transform.parent.GetComponent<PlayerController_Add3>();
						if (!component17.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component17.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Add4>() != null)
					{
						PlayerController_Add4 component18 = gameObject.transform.parent.GetComponent<PlayerController_Add4>();
						if (!component18.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component18.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
					if (gameObject.transform.parent.GetComponent<PlayerController_Add5>() != null)
					{
						PlayerController_Add5 component19 = gameObject.transform.parent.GetComponent<PlayerController_Add5>();
						if (!component19.running)
						{
							this.rightPlayerList.Remove(gameObject);
						}
						if (component19.transform.localScale.x > 0f)
						{
							this.rightPlayerList.Remove(gameObject);
						}
					}
				}
			}
			if (this.leftPlayerList != null)
			{
				foreach (GameObject gameObject2 in this.leftPlayerList)
				{
					if (gameObject2.GetComponent<PlayerBodyCollider>() != null)
					{
						PlayerBodyCollider component20 = gameObject2.GetComponent<PlayerBodyCollider>();
						if (!component20.hitMoveBox)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.GetComponent<ShanoaBodyCollider>() != null)
					{
						ShanoaBodyCollider component21 = gameObject2.GetComponent<ShanoaBodyCollider>();
						if (!component21.hitMoveBox)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController>() != null)
					{
						PlayerController component22 = gameObject2.transform.parent.GetComponent<PlayerController>();
						if (!component22.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component22.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Shanoa>() != null)
					{
						PlayerController_Shanoa component23 = gameObject2.transform.parent.GetComponent<PlayerController_Shanoa>();
						if (!component23.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component23.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Jonathan>() != null)
					{
						PlayerController_Jonathan component24 = gameObject2.transform.parent.GetComponent<PlayerController_Jonathan>();
						if (!component24.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component24.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Charotte>() != null)
					{
						PlayerController_Charotte component25 = gameObject2.transform.parent.GetComponent<PlayerController_Charotte>();
						if (!component25.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component25.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Albus>() != null)
					{
						PlayerController_Albus component26 = gameObject2.transform.parent.GetComponent<PlayerController_Albus>();
						if (!component26.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component26.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Soma>() != null)
					{
						PlayerController_Soma component27 = gameObject2.transform.parent.GetComponent<PlayerController_Soma>();
						if (!component27.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component27.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Alucard>() != null)
					{
						PlayerController_Alucard component28 = gameObject2.transform.parent.GetComponent<PlayerController_Alucard>();
						if (!component28.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component28.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Julius>() != null)
					{
						PlayerController_Julius component29 = gameObject2.transform.parent.GetComponent<PlayerController_Julius>();
						if (!component29.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component29.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Yoko>() != null)
					{
						PlayerController_Yoko component30 = gameObject2.transform.parent.GetComponent<PlayerController_Yoko>();
						if (!component30.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component30.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Maria>() != null)
					{
						PlayerController_Maria component31 = gameObject2.transform.parent.GetComponent<PlayerController_Maria>();
						if (!component31.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component31.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Simon>() != null)
					{
						PlayerController_Simon component32 = gameObject2.transform.parent.GetComponent<PlayerController_Simon>();
						if (!component32.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component32.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Fuma>() != null)
					{
						PlayerController_Fuma component33 = gameObject2.transform.parent.GetComponent<PlayerController_Fuma>();
						if (!component33.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component33.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Add1>() != null)
					{
						PlayerController_Add1 component34 = gameObject2.transform.parent.GetComponent<PlayerController_Add1>();
						if (!component34.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component34.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Add2>() != null)
					{
						PlayerController_Add2 component35 = gameObject2.transform.parent.GetComponent<PlayerController_Add2>();
						if (!component35.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component35.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Add3>() != null)
					{
						PlayerController_Add3 component36 = gameObject2.transform.parent.GetComponent<PlayerController_Add3>();
						if (!component36.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component36.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Add4>() != null)
					{
						PlayerController_Add4 component37 = gameObject2.transform.parent.GetComponent<PlayerController_Add4>();
						if (!component37.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component37.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
					if (gameObject2.transform.parent.GetComponent<PlayerController_Add5>() != null)
					{
						PlayerController_Add5 component38 = gameObject2.transform.parent.GetComponent<PlayerController_Add5>();
						if (!component38.running)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
						if (component38.transform.localScale.x < 0f)
						{
							this.leftPlayerList.Remove(gameObject2);
						}
					}
				}
			}
			this.rccMax[0] = Physics2D.OverlapPointNonAlloc(this.rightCheck1.position, this.rightCheckCollider[0]);
			this.rccMax[1] = Physics2D.OverlapPointNonAlloc(this.rightCheck2.position, this.rightCheckCollider[1]);
			this.rccMax[2] = Physics2D.OverlapPointNonAlloc(this.rightCheck3.position, this.rightCheckCollider[2]);
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < this.rccMax[i]; j++)
				{
					if (this.rightCheckCollider[i][j] != null && !this.rightCheckCollider[i][j].isTrigger)
					{
						if (this.rightCheckCollider[i][j].tag == "Road")
						{
							this.rightHit = true;
						}
						else if (this.rightCheckCollider[i][j].tag == "PlayerBody")
						{
							if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController>() != null)
							{
								PlayerController component39 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController>();
								if (component39.transform.localScale.x < 0f && component39.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Shanoa>() != null)
							{
								PlayerController_Shanoa component40 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Shanoa>();
								if (component40.transform.localScale.x < 0f && component40.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Jonathan>() != null)
							{
								PlayerController_Jonathan component41 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Jonathan>();
								if (component41.transform.localScale.x < 0f && component41.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Charotte>() != null)
							{
								PlayerController_Charotte component42 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Charotte>();
								if (component42.transform.localScale.x < 0f && component42.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Albus>() != null)
							{
								PlayerController_Albus component43 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Albus>();
								if (component43.transform.localScale.x < 0f && component43.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Soma>() != null)
							{
								PlayerController_Soma component44 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Soma>();
								if (component44.transform.localScale.x < 0f && component44.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Alucard>() != null)
							{
								PlayerController_Alucard component45 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Alucard>();
								if (component45.transform.localScale.x < 0f && component45.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Julius>() != null)
							{
								PlayerController_Julius component46 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Julius>();
								if (component46.transform.localScale.x < 0f && component46.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Yoko>() != null)
							{
								PlayerController_Yoko component47 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Yoko>();
								if (component47.transform.localScale.x < 0f && component47.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Maria>() != null)
							{
								PlayerController_Maria component48 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Maria>();
								if (component48.transform.localScale.x < 0f && component48.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Simon>() != null)
							{
								PlayerController_Simon component49 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Simon>();
								if (component49.transform.localScale.x < 0f && component49.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Fuma>() != null)
							{
								PlayerController_Fuma component50 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Fuma>();
								if (component50.transform.localScale.x < 0f && component50.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Add1>() != null)
							{
								PlayerController_Add1 component51 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Add1>();
								if (component51.transform.localScale.x < 0f && component51.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Add2>() != null)
							{
								PlayerController_Add2 component52 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Add2>();
								if (component52.transform.localScale.x < 0f && component52.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Add3>() != null)
							{
								PlayerController_Add3 component53 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Add3>();
								if (component53.transform.localScale.x < 0f && component53.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Add4>() != null)
							{
								PlayerController_Add4 component54 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Add4>();
								if (component54.transform.localScale.x < 0f && component54.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
							else if (this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Add5>() != null)
							{
								PlayerController_Add5 component55 = this.rightCheckCollider[i][j].transform.parent.GetComponent<PlayerController_Add5>();
								if (component55.transform.localScale.x < 0f && component55.running && !this.rightPlayerList.Contains(this.rightCheckCollider[i][j].gameObject))
								{
									this.rightPlayerList.Add(this.rightCheckCollider[i][j].gameObject);
								}
							}
						}
					}
				}
			}
			this.lccMax[0] = Physics2D.OverlapPointNonAlloc(this.leftCheck1.position, this.leftCheckCollider[0]);
			this.lccMax[1] = Physics2D.OverlapPointNonAlloc(this.leftCheck2.position, this.leftCheckCollider[1]);
			this.lccMax[2] = Physics2D.OverlapPointNonAlloc(this.leftCheck3.position, this.leftCheckCollider[2]);
			for (int k = 0; k < 3; k++)
			{
				for (int l = 0; l < this.lccMax[k]; l++)
				{
					if (this.leftCheckCollider[k][l] != null && !this.leftCheckCollider[k][l].isTrigger)
					{
						if (this.leftCheckCollider[k][l].tag == "Road")
						{
							this.leftHit = true;
						}
						else if (this.leftCheckCollider[k][l].tag == "PlayerBody")
						{
							if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController>() != null)
							{
								PlayerController component56 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController>();
								if (component56.transform.localScale.x > 0f && component56.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Shanoa>() != null)
							{
								PlayerController_Shanoa component57 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Shanoa>();
								if (component57.transform.localScale.x > 0f && component57.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Jonathan>() != null)
							{
								PlayerController_Jonathan component58 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Jonathan>();
								if (component58.transform.localScale.x > 0f && component58.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Charotte>() != null)
							{
								PlayerController_Charotte component59 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Charotte>();
								if (component59.transform.localScale.x > 0f && component59.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Albus>() != null)
							{
								PlayerController_Albus component60 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Albus>();
								if (component60.transform.localScale.x > 0f && component60.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Soma>() != null)
							{
								PlayerController_Soma component61 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Soma>();
								if (component61.transform.localScale.x > 0f && component61.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Alucard>() != null)
							{
								PlayerController_Alucard component62 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Alucard>();
								if (component62.transform.localScale.x > 0f && component62.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Julius>() != null)
							{
								PlayerController_Julius component63 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Julius>();
								if (component63.transform.localScale.x > 0f && component63.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Yoko>() != null)
							{
								PlayerController_Yoko component64 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Yoko>();
								if (component64.transform.localScale.x > 0f && component64.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Maria>() != null)
							{
								PlayerController_Maria component65 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Maria>();
								if (component65.transform.localScale.x > 0f && component65.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Simon>() != null)
							{
								PlayerController_Simon component66 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Simon>();
								if (component66.transform.localScale.x > 0f && component66.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Fuma>() != null)
							{
								PlayerController_Fuma component67 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Fuma>();
								if (component67.transform.localScale.x > 0f && component67.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Add1>() != null)
							{
								PlayerController_Add1 component68 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Add1>();
								if (component68.transform.localScale.x > 0f && component68.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Add2>() != null)
							{
								PlayerController_Add2 component69 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Add2>();
								if (component69.transform.localScale.x > 0f && component69.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Add3>() != null)
							{
								PlayerController_Add3 component70 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Add3>();
								if (component70.transform.localScale.x > 0f && component70.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Add4>() != null)
							{
								PlayerController_Add4 component71 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Add4>();
								if (component71.transform.localScale.x > 0f && component71.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
							else if (this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Add5>() != null)
							{
								PlayerController_Add5 component72 = this.leftCheckCollider[k][l].transform.parent.GetComponent<PlayerController_Add5>();
								if (component72.transform.localScale.x > 0f && component72.running && !this.leftPlayerList.Contains(this.leftCheckCollider[k][l].gameObject))
								{
									this.leftPlayerList.Add(this.leftCheckCollider[k][l].gameObject);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x040062AE RID: 25262
		protected Transform rightCheck1;

		// Token: 0x040062AF RID: 25263
		protected Transform rightCheck2;

		// Token: 0x040062B0 RID: 25264
		protected Transform rightCheck3;

		// Token: 0x040062B1 RID: 25265
		protected Transform leftCheck1;

		// Token: 0x040062B2 RID: 25266
		protected Transform leftCheck2;

		// Token: 0x040062B3 RID: 25267
		protected Transform leftCheck3;

		// Token: 0x040062B4 RID: 25268
		protected Collider2D[][] rightCheckCollider = new Collider2D[3][];

		// Token: 0x040062B5 RID: 25269
		protected int[] rccMax = new int[3];

		// Token: 0x040062B6 RID: 25270
		protected Collider2D[][] leftCheckCollider = new Collider2D[3][];

		// Token: 0x040062B7 RID: 25271
		protected int[] lccMax = new int[3];

		// Token: 0x040062B8 RID: 25272
		public List<GameObject> rightPlayerList;

		// Token: 0x040062B9 RID: 25273
		public List<GameObject> leftPlayerList;

		// Token: 0x040062BA RID: 25274
		public float speed = 0.5f;

		// Token: 0x040062BB RID: 25275
		public bool rightHit;

		// Token: 0x040062BC RID: 25276
		public bool leftHit;
	}
}
