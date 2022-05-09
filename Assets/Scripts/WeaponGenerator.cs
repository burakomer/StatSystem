using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{
    [SerializeField] private List<WeaponData> _weaponData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var randomWeaponData = _weaponData[Random.Range(0, _weaponData.Count)];
            
            var generatedDamage = StatModifier.GenerateFromData(randomWeaponData.baseDamage);
            var generatedStats = StatModifier.GenerateRandomListFromData(
                randomWeaponData.statCount, 
                randomWeaponData.possibleStatModifiers.ToList()
                );

            var weaponGameObject = new GameObject(randomWeaponData.itemName);
            var weapon = weaponGameObject.AddComponent<Weapon>();
            weapon.Initialize(generatedDamage, generatedStats);
        }
    }
}