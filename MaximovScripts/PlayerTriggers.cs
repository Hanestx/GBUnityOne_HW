using System.Collections;
using UnityEngine;


namespace MyDark
{
    public class PlayerTriggers : MonoBehaviour
    {
        #region Fields

	    [SerializeField] private GameObject _textFlashShow; // Уведомление
        [SerializeField] private GameObject _flashLight;
		[SerializeField] private GameObject _soundFX;

	    private bool _keyOne, _keyTwo, _flashGet; // Проверка наличия у персонажа предметов
	    private bool _isFlash = true;

        #endregion


        #region UnityMethods

		private void Update()
		{
            FlashOn();
		}

        #endregion


        #region OnTrigger

	    private void OnTriggerEnter(Collider collision)
	    {
	    	if (collision.CompareTag("KeyOne")) // Ключ 1
	    	{
	    		UnityEngine.Object.Destroy(collision.gameObject);
	    		_keyOne = true;
	    		Play(0);
	    	}
    
	    	if (collision.CompareTag("KeyTwo")) // Ключ 2
	    	{
                Play(0);
	    		UnityEngine.Object.Destroy(collision.gameObject);
	    		_keyTwo = true;
	    	}
    
	    	if (collision.CompareTag("DoorOne")) // Дверь 1
	    	{
	    		if (collision.gameObject.GetComponent<DoorOpen>()._isOpen) // Если дверь открыта
	    		{
                    Play(3);
	    			collision.gameObject.GetComponent<DoorOpen>().Teleport(gameObject); // ТП в другую комнату
	    		}
	    		else if (_keyOne) // Есть ключ? : Да
	    		{
                    Play(5);
	    			collision.gameObject.GetComponent<DoorOpen>().Unlock(); // Открываем дверь
	    			collision.gameObject.GetComponent<DoorOpen>().Teleport(gameObject); 
	    		}
	    		else Play(4);
	    		
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
		    	else Play(4);
		    }
    
		    if (collision.CompareTag("DoorSecret") || collision.CompareTag("DoorClose")) // Звуки для остальных дверей
		    {
		    	Play(4);
		    }
    
		    if (collision.CompareTag("Next")) // Переход между этажами
		    {
		    	collision.gameObject.GetComponent<NextFloor>().Teleport(gameObject);
		    }
    
		    if (collision.CompareTag( "RadioOn")) // Включение звуков радио
		    {
		    	Play(7);
		    	UnityEngine.Object.Destroy(collision.gameObject);
		    }
    
		    if (collision.CompareTag("Flash")) // Подбор фонарика
		    {
		    	Play(1);
		    	UnityEngine.Object.Destroy(collision.gameObject);
		    	_flashGet = true;
		    	_flashLight.SetActive(true);
		    }
	    }

	    #endregion


	    #region Methods

	    private void FlashOn() // Работа фонарика
	    {
	    	if (Input.GetKeyDown(KeyCode.F))
	    	{
	    		if (_flashGet)
	    		{
	    			if (_isFlash)
	    			{
	    				Play(2);
	    				_flashLight.transform.GetChild(0).gameObject.SetActive(true);
	    				_isFlash = false;
	    			}
	    			else 
	    			{
	    				Play(2);
	    				_flashLight.transform.GetChild(0).gameObject.SetActive(false);
	    				_isFlash = true;
	    			}
	    		}
	    		else
	    		{
	    			Play(6);
	    			_textFlashShow.SetActive(true);
	    			StartCoroutine(Wait());
	    		}
	    	}
	    }

	    IEnumerator Wait()
	    {
	     	yield return new WaitForSeconds(2f);
	    	_textFlashShow.SetActive(false);
	    	yield break;
	    }

		private void Play (int numSound)
        {
            _soundFX.transform.GetChild(numSound).GetComponent<AudioSource>().Play();
        }
    
	    #endregion
    }
}
