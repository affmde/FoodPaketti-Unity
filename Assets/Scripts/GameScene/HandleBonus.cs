using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HandleBonus : MonoBehaviour
{
	public bool		bonusOn;
	[SerializeField]
	public Slider		slider;
	[SerializeField]
	private float		bonusMaxTime = 8;
	private float		bonusTime;
	public float		currentAmount;


	private void Start()
	{
		bonusTime = bonusMaxTime;
		slider.value = 0;
		slider.gameObject.SetActive(false);
	}

	/*private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.name == "Bonus(Clone)")
		{
			slider.gameObject.SetActive(true);
			bonusOn = true;
			PlayerPrefs.SetInt("multiplier", 2);
			Destroy(col.collider.gameObject);
			currentAmount = 1;
		}
	}*/


	private void	Bonus()
	{
		bonusTime -= Time.deltaTime;
		currentAmount = Mathf.Clamp01(bonusTime / bonusMaxTime);
		slider.value = currentAmount;
		if (bonusTime <= 0)
		{
			PlayerPrefs.SetInt("multiplier", 1);
			bonusTime = bonusMaxTime;
			currentAmount = 0;
			bonusOn = false;
			slider.gameObject.SetActive(false);
		}
	}


	private void Update()
	{
		if (bonusOn)
			Bonus();
	}


}
