/*
 * Chapter 7.10 Class Constructors Revisited
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using System.IO;
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

        public void TreadmillUpdated()
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
        public readonly static string ProjectPath = System.IO.Directory.GetCurrentDirectory();
        public static void WritePatternExample()
        {
            string filePath = ProjectPath + "\\pattern.txt";
            // filePath = C:\Users\[user name]\Documents\BookContents\Chapters\Chapter7\pattern.txt

            StreamWriter writer = new StreamWriter(filePath);
            string defaultPattern =
                "Treadmill_Left\n" +
                "Treadmill_Center\n" +
                "Treadmill_Right\n" +
                "Treadmill_Right\n" +
                "Treadmill_Center\n" +
                "Treadmill_Left";
            // easier to read than a really long string.

            writer.Write(defaultPattern);
            writer.Close();
        }

        public static string ReadPattern()
        {
            string filePath = ProjectPath + "\\pattern.txt";
            // filePath = C:\Users\[user name]\Documents\BookContents\Chapters\Chapter7\pattern.txt

            StreamReader reader = new StreamReader(filePath);
            string readPattern = reader.ReadToEnd();
            /* reads something like "Treadmill_Left\nTreadmill_Center\nTreadmill_Right\n */
            /* until it reaches the end of the file.                                     */
            reader.Close();
            return readPattern;
        }
        
        public static string[] PatternToArray(string pattern)
        {
            //remove trailing '\n'
            pattern.TrimEnd(new char[] { '\n' });
            /* if there was a "Treadmill_Center\n" at the end this will */
            /* cut it off.                                              */

            string[] patternArray = pattern.Split('\n');
            /* breaks this into string[]{ "Treadmill_Center", "Treadmill_Left"} */
            /* an array with each string part between the \n chars.             */

            return patternArray;
        }

        public static void AppendPattern(ObstacleType obstacle)
        {
            string previousPattern = ReadPattern();
            /* previous string might be like "Treadmill_Center" since we    */
            /* trim the trailing \n                                         */
            
            string newPattern = previousPattern + "\n" + obstacle.ToString();
            /* this adds a new "Treadmill_Left + "\nTreadmill_Center"       */
            /* to the end of the previous string                            */

            string filePath = ProjectPath + "\\pattern.txt";
            // filePath = C:\Users\[user name]\Documents\BookContents\Chapters\Chapter7\pattern.txt
            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(newPattern);
            writer.Close();
        }
    }

    void UseTreadmillManger()
    {
        TreadmillManager.WritePatternExample();

        TreadmillManager.AppendPattern(ObstacleType.Treadmill_Center);
        TreadmillManager.AppendPattern(ObstacleType.Treadmill_Center);
        TreadmillManager.AppendPattern(ObstacleType.Treadmill_Center);
        TreadmillManager.AppendPattern(ObstacleType.Treadmill_Empty);
        TreadmillManager.AppendPattern(ObstacleType.Treadmill_Empty);
        TreadmillManager.AppendPattern(ObstacleType.Treadmill_Empty);

        string pattern = TreadmillManager.ReadPattern();
        // gets the pattern of segments from disk

        string[] obstacleArray = TreadmillManager.PatternToArray(pattern);
        // gets the converted string to string[]{ "Treadmill_Left", "Treadmill_Center" } etc...

        int numSegments = obstacleArray.Length;
        // get the number of segments in the array

        for (int i = 0; i < numSegments; i++)
        {
            switch (obstacleArray[i])
            {
                case "Treadmill_Empty":
                    new TreadmillSegment(0.015f, ObstacleType.Treadmill_Empty, ref UpdateTreadmill);
                    break;
                case "Treadmill_Center":
                    new TreadmillSegment(0.015f, ObstacleType.Treadmill_Center, ref UpdateTreadmill);
                    break;
                case "Treadmill_Left":
                    new TreadmillSegment(0.015f, ObstacleType.Treadmill_Left, ref UpdateTreadmill);
                    break;
                case "Treadmill_Right":
                    new TreadmillSegment(0.015f, ObstacleType.Treadmill_Right, ref UpdateTreadmill);
                    break;
            }
        }
    }

    void Start()
    {
        //UseTreadmillSegments();
        UseTreadmillManger();
    }

    void Update()
    {
        UpdateTreadmillSegments();
    }

}
