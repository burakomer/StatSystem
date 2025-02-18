#if ODIN_INSPECTOR
using System.Collections;
using System.Collections.Generic;
using PandaEngine.StatSystem.Utils;
using Sirenix.OdinInspector;

namespace PandaEngine.StatSystem
{
    public static class OdinUtils
    {
        #region INSTANCES

        private static List<StatType> StatTypeInstances =>
            AssetDatabaseUtils.FindAssetInstances<StatType>();

        private static List<StatCalculationType> StatCalculationTypeInstances =>
            AssetDatabaseUtils.FindAssetInstances<StatCalculationType>();

        #endregion

        #region VALUE DROPDOWNS

        public static IEnumerable AllStatTypeIdsDropdown => StatTypeInstances
            .FindAll(statType => !string.IsNullOrWhiteSpace(statType.Id))
            .ConvertAll(statType => new ValueDropdownItem(statType.Id, statType.Id));

        public static IEnumerable AllStatCalculationTypeIdsDropdown => StatCalculationTypeInstances
            .FindAll(calculationType => !string.IsNullOrWhiteSpace(calculationType.Id))
            .ConvertAll(calculationType => new ValueDropdownItem(calculationType.Id, calculationType.Id));

        #endregion
    }
}
#endif