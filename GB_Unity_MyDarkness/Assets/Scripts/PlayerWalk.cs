using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

// Максимов Дмитрий
public class PlayerWalk : MonoBehaviour
{
	[SerializeField] float _speed; // Скорость персонажа
	[SerializeField] Vector3 _direction;
	[SerializeField] GameObject _flashLight; // Фонарик	
	[SerializeField] GameObject soundFX; // Звуки
	[SerializeField] GameObject textShow; // Уведомление
	bool _keyOne, _keyTwo, _flashGet; // Проверка наличия у персонажа предметов
	bool isFlash = true; // Фонарик работает?

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

	void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.tag == "KeyOne") // Ключ 1
		{
			soundFX.transform.GetChild(0).GetComponent<AudioSource>().Play();
			UnityEngine.Object.Destroy(collision.gameObject);
			_keyOne = true;
		}
		if (collision.gameObject.tag == "KeyTwo") // Ключ 2
		{
			soundFX.transform.GetChild(0).GetComponent<AudioSource>().Play();
			UnityEngine.Object.Destroy(collision.gameObject);
			_keyTwo = true;
		}
		if (collision.gameObject.tag == "DoorOne") // Дверь 1
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
			else
			{
				soundFX.transform.GetChild(4).GetComponent<AudioSource>().Play();
			}
		}
		if (collision.gameObject.tag == "DoorTwo") // Дверь 2
		{
			if (collision.gameObject.GetComponent<DoorOpen>()._isOpen)
			{
				collision.gameObject.GetComponent<DoorOpen>().Teleport(gameObject);
			}
			else if (_keyTwo)
			{
				collision.gameObject.GetComponent<DoorOpen>().Unlock();
				// Переход на другой уровень
			}
			else
			{
				soundFX.transform.GetChild(4).GetComponent<AudioSource>().Play();
			}
		}
		if (collision.gameObject.tag == "DoorSecret" || collision.gameObject.tag == "DoorClose") // Звуки для остальных дверей
		{
			soundFX.transform.GetChild(4).GetComponent<AudioSource>().Play();
		}
		if (collision.gameObject.tag == "Next") // Переход между этажами
		{
			collision.gameObject.GetComponent<NextFloor>().Teleport(gameObject);
		}
		if (collision.gameObject.tag == "RadioOn") // Включение звуков радио
		{
			soundFX.transform.GetChild(7).GetComponent<AudioSource>().Play();
			UnityEngine.Object.Destroy(collision.gameObject);
		}
		if (collision.gameObject.tag == "Flash") // Подбор фонарика
		{
			soundFX.transform.GetChild(1).GetComponent<AudioSource>().Play();
			UnityEngine.Object.Destroy(collision.gameObject);
			_flashGet = true;
			_flashLight.SetActive(true);
		}
	}

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
}
