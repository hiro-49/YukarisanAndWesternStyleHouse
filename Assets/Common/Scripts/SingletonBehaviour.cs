using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T> {
	private static T instance;
	public static T Instance {
		get {
			if (instance == null){
				instance = (T)FindObjectOfType(typeof(T));
			}
			if (instance == null){
				Debug.LogError(typeof(T) + "is nothing");
			}
			return instance;
		}
	}

	protected virtual void Awake(){
		CheckInstance();
		DontDestroyOnLoad(gameObject);
	}

	protected bool CheckInstance(){
		if(instance == null){
			instance = (T)this;
			return true;
		} else if(Instance == this){
			return true;
		}

		Destroy(this.gameObject);
		return false;
	}

}
