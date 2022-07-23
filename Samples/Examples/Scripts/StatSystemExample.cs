using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class StatSystemExample : MonoBehaviour
{
    [SerializeField] private StatUser statUser;
    [SerializeField] private List<WeaponData> _weaponData;

    private Weapon currentWeapon;
    private Random random;

    private void Awake()
    {
        random = new Random();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        CreateRandomWeaponAndApplyStatModifiersToStatUser();
    }

    private void CreateRandomWeaponAndApplyStatModifiersToStatUser()
    {
        if (currentWeapon != null)
            currentWeapon.RemoveModifiers(statUser);

        var randomWeaponData = _weaponData[random.Next(0, _weaponData.Count)];
            
        var generatedDamage = StatModifier.GenerateFromData(randomWeaponData.baseDamage, random);
        var generatedStats = StatModifier.GenerateRandomListFromData(
            randomWeaponData.statCount, 
            randomWeaponData.possibleStatModifiers.ToList(),
            random
        );

        var weaponGameObject = new GameObject(randomWeaponData.itemName);
        currentWeapon = weaponGameObject.AddComponent<Weapon>();
        currentWeapon.Initialize(generatedDamage, generatedStats);
        currentWeapon.ApplyModifiers(statUser);
    }
}