using Core.FSM;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;


public class DefenseTargeting 
{
    public enum TargetType
    { 
        First,
        Last,
        Close
    }
    public static InvadingPawnStateMachine GetTarget(DefenseBehavoir CurrentDefense, TargetType TargetMethod)
    {
        Collider[] EnemiesInRange = Physics.OverlapSphere(CurrentDefense.transform.position, CurrentDefense.Range, CurrentDefense.EnemiesLayer);
        if (EnemiesInRange.Length == 0)
        {
            return null;
        }
        NativeArray<EnemyData> EnemiestoCalc = new NativeArray<EnemyData>(EnemiesInRange.Length, Allocator.TempJob);
        NativeArray<Vector3> NodePosition = new NativeArray<Vector3>(GameLoopManager.NodePosition, Allocator.TempJob);
        NativeArray<float> NodeDistance = new NativeArray<float>(GameLoopManager.NodeDistances, Allocator.TempJob);
        NativeArray<int> EnemyToIndex = new NativeArray<int>(new int[] { -1}, Allocator.TempJob);
        int EnemyIndexToReturn = -1;
        for (int i = 0; i < EnemiestoCalc.Length; i++)
        {
            InvadingPawnStateMachine currentEnemy = EnemiesInRange[i].GetComponentInParent<InvadingPawnStateMachine>();
            int EnemyIndexInList = GameLoopManager.CurrentEnemies.FindIndex(x => x == currentEnemy);
            EnemiestoCalc[i] = new EnemyData(currentEnemy.transform.position, currentEnemy.NodeIndex, currentEnemy.GetComponent<Health>().health, EnemyIndexInList);
        }
        SearchForEnemy enemySearch = new SearchForEnemy
        {
            _enemiestoCalc = EnemiestoCalc,
            _nodePostion = NodePosition,
            _enemyToIndex = EnemyToIndex,
            _nodeDistance = NodeDistance,
            //CompareVal = Mathf.Infinity,
            TargetingType = (int)TargetMethod,
            defPositon = CurrentDefense.transform.position
        };
        switch ((int)TargetMethod)
        {
            case 0: // first
                enemySearch.CompareVal = Mathf.Infinity;
                break;
            case 1: //last
                enemySearch.CompareVal = Mathf.NegativeInfinity;
                break;
            case 2: // close
                goto case 0;
        }
        JobHandle dependency = new JobHandle();
        JobHandle SearchJobHandle = enemySearch.Schedule(EnemiestoCalc.Length, dependency);
        SearchJobHandle.Complete();
        EnemyIndexToReturn = EnemiestoCalc[EnemyToIndex[0]].EnemyIndex;
        EnemiestoCalc.Dispose();
        NodePosition.Dispose();
        EnemyToIndex.Dispose();
        NodeDistance.Dispose();
        if (EnemyIndexToReturn == -1)
        {
            return null;
        }
        if (EnemyIndexToReturn < 0)
        {
            return null;
        }
        return GameLoopManager.CurrentEnemies[EnemyIndexToReturn];
        
    }
    struct EnemyData
    {
        public EnemyData(Vector3 position, int nodeIndex, float hp,int enemyIndex)
        {
            EnemyPosition = position;
            NodeIndex = nodeIndex;
            Health = hp;
            EnemyIndex = enemyIndex;
        }
        public int NodeIndex;
        public float Health;
        public Vector3 EnemyPosition;
        public int EnemyIndex;
    }
    struct SearchForEnemy : IJobFor
    {
       public NativeArray<EnemyData> _enemiestoCalc;
        public NativeArray<Vector3> _nodePostion;
        public NativeArray<int> _enemyToIndex;
        public NativeArray<float> _nodeDistance;
        public float CompareVal;
        public int TargetingType;
        public Vector3 defPositon;
        public void Execute(int index)
        {
            float currentDistanceToEnd=0;
            float DistanceToEnemy = 0;
            switch (TargetingType)
            {
                case 0: //first
                     currentDistanceToEnd = GetDistanceToEnd(_enemiestoCalc[index]);
                    if (currentDistanceToEnd < CompareVal)
                    {
                        _enemyToIndex[0] = index;
                        CompareVal = currentDistanceToEnd;
                    }
                    break;

                case 1: // last
                     currentDistanceToEnd = GetDistanceToEnd(_enemiestoCalc[index]);
                    if (currentDistanceToEnd > CompareVal)
                    {
                        _enemyToIndex[0] = index;
                        CompareVal = currentDistanceToEnd;
                    }
                    break;


                case 2: // close
                    DistanceToEnemy = Vector3.Distance(defPositon, _enemiestoCalc[index].EnemyPosition);
                    if (DistanceToEnemy < CompareVal)
                    {
                        _enemyToIndex[0] = index;
                        CompareVal = DistanceToEnemy;
                    }
                    break;
            }
        }
        private float GetDistanceToEnd(EnemyData enemyToEval)
        {
            float finalDistance = Vector3.Distance(enemyToEval.EnemyPosition, _nodePostion[enemyToEval.NodeIndex]);
            for (int i = enemyToEval.NodeIndex; i < _nodeDistance.Length; i++)
            {
                finalDistance += _nodeDistance[i];
            }
            return finalDistance;
        }
    }
}
