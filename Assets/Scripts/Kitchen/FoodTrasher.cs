using System;

using UnityEngine;

using JetBrains.Annotations;

namespace CookingPrototype.Kitchen
{
    [RequireComponent(typeof(FoodPlace))]
    public sealed class FoodTrasher : MonoBehaviour
    {

        FoodPlace _place = null;
        float _timer = 0f;

        void Start()
        {
            _place = GetComponent<FoodPlace>();
            _timer = Time.realtimeSinceStartup;
        }

        /// <summary>
        /// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
        /// </summary>
        [UsedImplicitly]
        public void TryTrashFood()
        {
            //If overcooked food is present - remove it entirely
            //Else - do nothing
            if (!_place.IsFree && _place.CurFood.CurStatus == Food.FoodStatus.Overcooked)
                _place.FreePlace();
        }
    }
}
