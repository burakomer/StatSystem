using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{
    [SerializeField] private List<WeaponData> _weaponDatas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var randomWeaponData = _weaponDatas[Random.Range(0, _weaponDatas.Count)];

            var generatedDamage = Random.Range(randomWeaponData.minBaseDamage, randomWeaponData.maxBaseDamage + 1);
            
            var possibleStatDatas = randomWeaponData.possibleStats.ToList();
            var generatedStats = new List<Stat>(randomWeaponData.statCount);

            for (var i = 0; i < randomWeaponData.statCount; i++)
            {
                var randomStatData = possibleStatDatas[Random.Range(0, possibleStatDatas.Count)];
                possibleStatDatas.Remove(randomStatData);

                var generatedStat = new Stat(
                    randomStatData.statType, 
                    randomStatData.statModifyType, 
                    Random.Range(randomStatData.minValue, randomStatData.maxValue + 1)
                );

                generatedStats.Add(generatedStat);
            }

            var weaponGameObject = new GameObject(randomWeaponData.itemName);
            var weapon = weaponGameObject.AddComponent<Weapon>();
            weapon.Initialize(generatedDamage, generatedStats);
        }
    }
}