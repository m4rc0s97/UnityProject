using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Pistol : MonoBehaviour
{
	public	Camera m_camera;
	public GameObject bulletHole;
	public	Transform m_weapon;
	public	Player m_Owner; 

	public  float     m_damage        = 80.0f;				
	public  float     m_forceToApply  = 200.0f;				
	public  float     m_weaponRange   = 9999999.0f;						
	public  Texture2D m_crosshairTexture;					
    public  AudioClip m_fireSound;							
    private bool      m_canShot = true;

	private int m_maxAmmo = 20;
	public int m_actualAmmo = 20;
	public int m_bulletsPerShot = 1;
	public float m_bulletsPerSecond = 2;
	public float m_fireRate = 1 / 2;
	float timeCounter = 0.0f;


	private float crossHairSize = 50.0f;


	private void Update()
	{
		timeCounter += Time.deltaTime;


		if (m_canShot && timeCounter >= m_fireRate && m_actualAmmo > 0)
		{
			if (Input.GetButton("Fire1"))
			{
				Shot();
				m_actualAmmo--;
				timeCounter = 0;
				
			}
		}
		else if (Input.GetButtonUp("Fire1"))
        { 
			m_canShot = true;
        }

	}

	private void OnGUI()
	{
		Vector2 center = new Vector2((Screen.width / 2) - crossHairSize / 2, (Screen.height / 2) - crossHairSize / 2);
		Rect auxRect = new Rect(center.x, center.y, crossHairSize, crossHairSize);
		GUI.DrawTexture(auxRect, m_crosshairTexture, ScaleMode.StretchToFill);
	}

	private void Shot()
	{
		m_canShot = false;

		Ray mouseRay = m_camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		Debug.DrawRay(mouseRay.origin, mouseRay.direction * 100, Color.red);

		RaycastHit hit;
		
		if (Physics.Raycast(mouseRay, out hit))
		{

			Debug.Log("Hit " + hit.transform.name);
			Instantiate(bulletHole, hit.point + hit.normal * 0.0001f, Quaternion.LookRotation(Vector3.up, hit.normal));
			bulletHole.transform.up = hit.normal;
			if (hit.rigidbody)
			{
				hit.rigidbody.AddForce(mouseRay.direction * m_forceToApply);
				//Debug.Log("Hit " + hit.transform.gameObject.name);
				//GameObject cubePointCast = GameObject.Find("CubePoint");

				//CubePoint point = hit.transform.gameObject.GetComponent<CubePoint>();
				/*if(point != null)
					m_Owner.m_score += point.givenPoints;*/
				
			}
		}

		GetComponent<AudioSource>().PlayOneShot(m_fireSound);
		
	}
}
