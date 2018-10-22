/*
 * Chapter 7.10 Class Constructors Revisited
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using UnityEngine;

public class ClassConstructors : MonoBehaviour
{
    /*
     * Section 7.10 Class Constructors
     */
    
    enum ObstacleType
    {
        Treadmill_Empty,
        Treadmill_Center,
        Treadmill_Left,
        Treadmill_Right
    }

    class TreadmillSegment
    {
        static int Segments;
        private float Speed;
        private int StepSize;
        private int Step;
        private GameObject Segment;

        public TreadmillSegment(float speed, ObstacleType obstacle, ref TreadmillUpdate treadmillUpdater)
        {
            Speed = speed;
            Segment = Instantiate(Resources.Load(obstacle.ToString()) as GameObject);
            treadmillUpdater += TreadmillUpdated;

            StepSize = (int)(1 / Speed);
            Step = Segments * StepSize;
            Segments++;
        }

        void TreadmillUpdated()
        {
            int totalSteps = Segments * StepSize;
            Segment.transform.position = new Vector3()
            {
                z = -(float)(Step++ % totalSteps) * Speed
            };
        }
    }

    private delegate void TreadmillUpdate();
    private TreadmillUpdate UpdateTreadmill;
    void UseTreadmillSegments()
    {
        int numSegments = 7;
        for (int i = 0; i < numSegments; i++)
        {
            ObstacleType obstacle = (ObstacleType)(i % 4);
            new TreadmillSegment(0.015f, obstacle, ref UpdateTreadmill);
        }
    }

    void UpdateTreadmillSegments()
    {
        if (UpdateTreadmill != null)
        {
            UpdateTreadmill();
        }
    }

    /*
     * Section 7.10.2 Classes that manage classes
     */
    class TreadmillManager
    {
        public void StartTreadmill()
        {
            
        }

        public void DestroyTreadmill()
        {
            
        }

        public void UpdateTreadmill()
        {

        }
        public int Segments;
        public float Speed;
    }

    void Start()
    {
        UseTreadmillSegments();
    }

    void Update()
    {
        UpdateTreadmillSegments();
    }

}
