using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
	#region Fields

	[SerializeField] private float _speed;
	[SerializeField] private Vector3 _direction;
	[SerializeField] private GameObject _flashLight;
	[SerializeField] private GameObject soundFX;
	[SerializeField] private GameObject textShow; // Уведомление

	private bool _keyOne, _keyTwo, _flashGet; // Проверка наличия у персонажа предметов
	private bool isFlash = true;

	#endregion


	#region UnityMethods

	void FixedUpdate()
	{
		_direction.x = Input.GetAxis("Horizontal");
		_direction.z = Input.GetAxis("Vertical");
		Vector3 translation = _direction * _speed * Time.deltaTime;
		transform.Translate(translation);
	}

	void Update()
	{
		FlashOn(); //
	}

	#endregion


	#region OnTrigger

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.CompareTag("KeyOne")) // Ключ 1
		{
			soundFX.transform.GetChild(0).GetComponent<AudioSource>().Play();
			UnityEngine.Object.Destroy(collision.gameObject);
			_keyOne = true;
		}

		if (collision.CompareTag("KeyTwo")) // Ключ 2
		{
			soundFX.transform.GetChild(0).GetComponent<AudioSource>().Play();
			UnityEngine.Object.Destroy(collision.gameObject);
			_keyTwo = true;
		}

		if (collision.CompareTag("DoorOne")) // Дверь 1
		{
			if (collision.gameObject.GetComponent<DoorOpen>()._isOpen) // Если дверь открыта
			{
				collision.gameObject.GetComponent<DoorOpen>().Teleport(gameObject); // ТП в другую комнату
				soundFX.transform.GetChild(3).GetComponent<AudioSource>().Play();
			}
			else if (_keyOne) // Есть ключ? : Да
			{
				collision.gameObject.GetComponent<DoorOpen>().Unlock(); // Открываем дверь
				collision.gameObject.GetComponent<DoorOpen>().Teleport(gameObject); 
				soundFX.transform.GetChild(5).GetComponent<AudioSource>().Play();
			}
			else soundFX.transform.GetChild(4).GetComponent<AudioSource>().Play();
			
		}

		if (collision.CompareTag("DoorTwo")) // Дверь 2
		{
			if (collision.gameObject.GetComponent<DoorOpen>()._isOpen)
			{
				collision.gameObject.GetComponent<DoorOpen>().Teleport(gameObject);
			}
			else if (_keyTwo)
			{
				collision.gameObject.GetComponent<DoorOpen>().Unlock(); // Тут будет переход на другой уровень
			}
			else 
			{
				soundFX.transform.GetChild(4).GetComponent<AudioSource>().Play();
			}
		}

		if (collision.CompareTag("DoorSecret") || collision.CompareTag("DoorClose")) // Звуки для остальных дверей
		{
			soundFX.transform.GetChild(4).GetComponent<AudioSource>().Play();
		}

		if (collision.CompareTag("Next")) // Переход между этажами
		{
			collision.gameObject.GetComponent<NextFloor>().Teleport(gameObject);
		}

		if (collision.CompareTag( "RadioOn")) // Включение звуков радио
		{
			soundFX.transform.GetChild(7).GetComponent<AudioSource>().Play();
			UnityEngine.Object.Destroy(collision.gameObject);
		}

		if (collision.CompareTag("Flash")) // Подбор фонарика
		{
			soundFX.transform.GetChild(1).GetComponent<AudioSource>().Play();
			UnityEngine.Object.Destroy(collision.gameObject);
			_flashGet = true;
			_flashLight.SetActive(true);
		}
	}

	#endregion


	#region Methods

	void FlashOn() // Работа фонарика
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			if (_flashGet)
			{
				if (isFlash)
				{
					soundFX.transform.GetChild(2).GetComponent<AudioSource>().Play();
					_flashLight.transform.GetChild(0).gameObject.SetActive(true);
					isFlash = false;
				}
				else 
				{
					soundFX.transform.GetChild(2).GetComponent<AudioSource>().Play();
					_flashLight.transform.GetChild(0).gameObject.SetActive(false);
					isFlash = true;
				}
			}
			else
			{
				textShow.SetActive(true);
				soundFX.transform.GetChild(6).GetComponent<AudioSource>().Play();
				StartCoroutine(Wait());
			}
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2f);
		textShow.SetActive(false);
		yield break;
	}

	#endregion
}
