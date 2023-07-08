using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleLoose {

        public int tentacleIndex;
        public TentacleLoose(int _tentacleIndex) {
                tentacleIndex = _tentacleIndex;
        }
}

public class TentacleTouch {

        public int tentacleIndex;
        public Vector2 targetPos;

        public TentacleTouch(int _tentacleIndex, Vector2 _targetPos) {
                tentacleIndex = _tentacleIndex;
                targetPos = _targetPos;
        }
}