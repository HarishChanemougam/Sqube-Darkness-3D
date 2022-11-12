using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    private static SaveData _current;
    public static SaveData Current 
    { 
        get 
        {
            if( _current == null )
            {
                _current = new SaveData();
            }
            return _current; 
        } 
    }
    public PlayerProfile _playerProfile;
}
