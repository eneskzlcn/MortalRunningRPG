using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Have not been designed yet. Probably the resource and game configurations management
    will not done in this way
*/
public class GameConfiguratingManagement : MonoBehaviour
{
    [SerializeField] private IItem[] gameItems;
    void Awake()
    {
        ConfigureGameProperties();
    }
    void Update()
    {
        
    }
    void ConfigureGameProperties()
    {
        for (int i = 0; i < gameItems.Length; i++)
        {
            
        }
    }
}
