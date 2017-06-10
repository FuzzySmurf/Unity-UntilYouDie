using Apex.LoadBalancing;
using Apex.Units;
using UnityEngine;

namespace Fuzzy.Helper.Apex
{
    public static class FollowMaster
    {
        public static ILoadBalancedHandle Follow(this IUnitFacade unit, Transform target, float minimalMoveDiff = 0.5f,
            float checkInterval = 0.1f) {
            Vector3 lastRecordedTargetPosition = target.position;
            unit.MoveTo(lastRecordedTargetPosition, false);

            return LoadBalancer.defaultBalancer.Execute((ignored) =>
            {
                bool updateMoveOrder = (lastRecordedTargetPosition - target.position).sqrMagnitude > minimalMoveDiff;

                if (updateMoveOrder) {
                    lastRecordedTargetPosition = target.position;
                    unit.MoveTo(lastRecordedTargetPosition, false);
                }

                return true;
            },
                checkInterval,
                true);
        }
    }
}