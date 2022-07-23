using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatSystemExample : MonoBehaviour
{
    [SerializeField] private StatUser statUser;
    [SerializeField] private List<WeaponData> _weaponData;

    private Weapon currentWeapon;
    
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        CreateRandomWeaponAndApplyStatModifiersToStatUser();
    }

    private void CreateRandomWeaponAndApplyStatModifiersToStatUser()
    {
        if (currentWeapon != null)
            currentWeapon.RemoveModifiers(statUser);

        var randomWeaponData = _weaponData[Random.Range(0, _weaponData.Count)];
            
        var generatedDamage = StatModifier.GenerateFromData(randomWeaponData.baseDamage);
        var generatedStats = StatModifier.GenerateRandomListFromData(
            randomWeaponData.statCount, 
            randomWeaponData.possibleStatModifiers.ToList()
        );

        var weaponGameObject = new GameObject(randomWeaponData.itemName);
        currentWeapon = weaponGameObject.AddComponent<Weapon>();
        currentWeapon.Initialize(generatedDamage, generatedStats);
        currentWeapon.ApplyModifiers(statUser);
    }
}