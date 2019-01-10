/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 7.12 Try Catch Finally                                    *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter7_12
{
    using System;
    using System.IO;
    using UnityEngine;

    public class TryCatchFinally : MonoBehaviour
    {
        #region Chapter 7.12.1 Try Catch Finally: A Basic Example
        /* * * * * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 7.12.1 Try Catch Finally: A Basic Example   *
         * * * * * * * * * * * * * * * * * * * * * * * * * * * */
        void DontUseTryCatch()
        {
            int i = 0;
            i = int.Parse("1");
            // this does work, and we get 1
            Debug.Log("i is " + i);

            int j = 0;
            //j = int.Parse("One");
            /* uncomment to see the error */

            Debug.Log("j is " + j);
            // never gets called if there's an error
            // the game stopped.
        }

        void UseTryCatch()
        {
            int i = 0;
            try
            {
                i = int.Parse("One");
            }
            catch
            {
                i = 1;
            }
            Debug.Log("i is " + i);
        }

        void UseTryCatchWithException()
        {
            int i = 0;
            try
            {
                i = int.Parse("One");
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                i = 1;
            }
            Debug.Log("i is " + i);
        }

        void UseCheckExceptions()
        {
            object[] objs = new object[] { 7.0, "23", null, "Seventeen" };
            Debug.Log("Check for Exception.");
            foreach (object o in objs)
            {
                CheckException(o);
            }
        }

        void CheckException(object o)
        {
            int i = 0;
            try
            {
                i = (int)o;
                Debug.Log("I guess it wasn't an int.");
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        #endregion

        #region Chapter 7.12.2 Exception Messages
        /* * * * * * * * * * * * * * * * * * *
         * Section 7.12.2 Exception Messages *
         * * * * * * * * * * * * * * * * * * */
        void UseExceptions()
        {
            object[] objs = new object[] { 7.0, "23", null, "Seventeen" };
            foreach (object o in objs)
            {
                CheckExceptionType(o);
            }
        }

        void CheckExceptionType(object o)
        {
            int i = 0;
            try
            {
                Debug.Log("Got: " + o);
                i = (int)o;
            }
            catch (NullReferenceException e)
            {
                Debug.Log("NullReferenceException " + e.Message);
            }
            catch (InvalidCastException e)
            {
                Debug.Log("InvalidCastException " + e.Message);
            }
            catch (Exception e)
            {
                Debug.Log("Unexpected Exception " + e.Message);
            }
        }

        public void TextInputChanged(string input)
        {
            ConvertFromStringToInt(input);
        }

        void ConvertFromStringToInt(string input)
        {
            int i = 0;
            try
            {
                i = int.Parse(input);
                Debug.Log("int parse successful, got " + i);
            }

            catch (Exception e)
            {
                Debug.Log(e);
                try
                {
                    i = (int)float.Parse(input);
                    Debug.Log("float parse successful, got " + i);
                }
                catch
                {
                    Debug.Log("input wasn't a float or an int.");
                }
            }
        }
        #endregion

        #region Chapter 7.12.3 Custom Exceptions
        /* * * * * * * * * * * * * * *
         * 7.12.3 Custom Exceptions  *
         * * * * * * * * * * * * * * */
        void UseCustomExceptions()
        {
            int[] inputs = new int[] { 0, 1, -10, 50, 100, 3000 };
            foreach (int i in inputs)
            {
                try
                {
                    ValidateRange(i);
                    Debug.Log("input: " + i + " is in range.");
                    /* this works a little bit like this   */
                    /*    MyException e;                   */
                    /*                └─────→──┐           */
                    /*    ValidateRange(i, out e);         */
                }   /*             ┌────────←──┘           */
                catch (MyException e)
                {
                    Debug.Log(e.Message + "value bypassed:" + e.Number);
                }
            }
        }

        void ValidateRange(int i)
        {
            if (i > 100)
            {
                MyException e = new MyException(i + " is above range.");
                e.Number = 100;
                throw e;
            }
            else if (i < 0)
            {
                MyException e = new MyException(i + " is below range.");
                e.Number = 0;
                throw e;
            }
        }

        class MyException : Exception
        {
            public int Number;
            public MyException()
            {
            }
            public MyException(string message) : base(message)
            {
            }
            public MyException(string message, Exception innerException)
            : base(message, innerException)
            {
            }
        }
        #endregion

        #region Chapter 7.12.4 Finally
        /* * * * * * * * * * * * * *
         * Section 7.12.4 Finally  *
         * * * * * * * * * * * * * */

        void UseFinally()
        {
            try
            {
                ValidateRange(101);
            }
            catch (MyException e)
            {
                Debug.Log(e.Message);
            }
            finally
            {
                Debug.Log("Done.");
            }
        }
        #endregion

        #region chapter 7.12.5 Try Catch and Finally in Use
        /* * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 7.12.5 Try Catch and Finally in Use   *
         * * * * * * * * * * * * * * * * * * * * * * * * */
        void UseWriteToFile()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            FileStream file = null;
            FileInfo info = null;
            try
            {
                info = new FileInfo(path + "//FinalFile.txt");
                file = info.OpenWrite();
                for (int i = 0; i < 255; i++)
                {
                    file.WriteByte((byte)i);
                }
            }
            catch (FileNotFoundException e)
            {
                Debug.Log(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Debug.Log(e.Message);
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }
        #endregion
        private void Start()
        {
            /* * * * * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 7.12.1 Try Catch Finally: A Basic Example   *
             * * * * * * * * * * * * * * * * * * * * * * * * * * * */
            DontUseTryCatch();
            UseTryCatch();
            UseTryCatchWithException();
            UseCheckExceptions();

            /* * * * * * * * * * * * * * * * * * *
             * Section 7.12.2 Exception Messages *
             * * * * * * * * * * * * * * * * * * */
            UseExceptions();

            /* * * * * * * * * * * * * * *
             * 7.12.3 Custom Exceptions  *
             * * * * * * * * * * * * * * */
            UseCustomExceptions();

            /* * * * * * * * * * * * * *
             * Section 7.12.4 Finally  *
             * * * * * * * * * * * * * */
            UseFinally();

            /* * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 7.12.5 Try Catch and Finally in Use   *
             * * * * * * * * * * * * * * * * * * * * * * * * */
            UseWriteToFile();
        }
    }
}
