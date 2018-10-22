/*
 * Chapter 7.10 Class Constructors Revisited
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class ClassConstructors : MonoBehaviour
{
    enum ObstacleType
    {
        TreadMill_Empty,
        TreadMill_Center,
        TreadMill_Left,
        TreadMill_Right
    }

    class TreadMillSegment
    {
        static int Segments;
        private float Speed;
        private int StepSize;
        private int Step;
        private GameObject Segment;

        public TreadMillSegment(float speed, ObstacleType obstacle, ref TreadmillUpdate updater)
        {
            Speed = speed;
            Segment = Instantiate(Resources.Load(obstacle.ToString()) as GameObject);
            updater += Updated;

            StepSize = (int)(1 / Speed);
            Step = Segments * StepSize;
            Segments++;
        }

        void Updated()
        {
            int totalSteps = Segments * StepSize;
            Segment.transform.position = new Vector3()
            {
                z = -(float)(Step++ % totalSteps) * Speed
            };
        }
    }

    private delegate void TreadmillUpdate();
    private TreadmillUpdate DoUpdate;

    void Start()
    {
        int numSegments = 7;
        for (int i = 0; i < numSegments; i++)
        {
            ObstacleType obstacle = (ObstacleType)(i%4);
            new TreadMillSegment(0.015f, obstacle, ref DoUpdate);
        }
    }
    
    void Update()
    {
        if (DoUpdate != null)
        {
            DoUpdate();
        }
    }
}
