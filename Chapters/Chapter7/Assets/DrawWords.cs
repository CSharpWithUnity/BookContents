/*
 * Chapter 7.4.6 DrawWords
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public static class DrawWords
{
    public static float size = 0.4f;
    public static void DrawWord(string word, float scale, Vector3 position, Color color)
    {
        //convert to uppercase first
        string uLetters = word.ToUpper();
        char[] letters = uLetters.ToCharArray();
        if (letters.Length > 0)
        {
            for (int i = 0; i < letters.Length; i++)
            {
                float offset = (i * scale);
                Vector3 offsetPosition = new Vector3(offset + position.x, position.y, position.z);
                DrawWord(letters[i], scale, offsetPosition, color);
            }
        }
    }

    public static void DrawWord(char c, float scale, Vector3 position, Color color)
    {
        Vector3[] lines = ToVectorArray(c);
        for (int i = 1; i < lines.Length; i++)
        {
            Vector3 start = (lines[i - 1] * scale);
            start.x *= size;
            Vector3 end = (lines[i] * scale);
            end.x *= size;
            Debug.DrawLine(start + position, end + position, color);
        }
    }

    public static Vector3[] ToVectorArray(char c)
    {
        switch (c)
        {
            case 'A' :
	            return A;
            case 'B':
                return B;
            case 'C':
                return C;
            case 'D':
                return D;
            case 'E':
                return E;
            case 'F':
                return F;
            case 'G':
                return G;
            case 'H':
                return H;
            case 'I':
                return I;
            case 'J':
                return J;
            case 'K':
                return K;
            case 'L':
                return L;
            case 'M':
                return M;
            case 'N':
                return N;
            case 'O':
                return O;
            case 'P':
                return P;
            case 'Q':
                return Q;
            case 'R':
                return R;
            case 'S':
                return S;
            case 'T':
                return T;
            case 'U':
                return U;
            case 'V':
                return V;
            case 'W':
                return W;
            case 'X':
                return X;
            case 'Y':
                return Y;
            case 'Z':
                return Z;
            default:
                return space;
        }
    }
    public static Vector3[] space = new[] {
        new Vector3(0, 0, 0),
        new Vector3(0, 0, 0)
    };
    public static Vector3[] A = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(0, 1, 0),
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(1, -1, 0)
    };

    public static Vector3[] B = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(1, -1, 0),
        new Vector3(-1, -1, 0)
    };

    public static Vector3[] C = new[]{
        new Vector3(1, -1, 0),
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0)
    };

    public static Vector3[] D = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(1, 0, 0),
        new Vector3(0, -1, 0),
        new Vector3(-1, -1, 0)
    };

    public static Vector3[] E = new[]{
        new Vector3(1, -1, 0),
        new Vector3(-1, -1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(0, 0, 0),
        new Vector3(-1, 0, 0),
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0),
    };

    public static Vector3[] F = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(0, 0, 0),
        new Vector3(-1, 0, 0),
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0)
    };

    public static Vector3[] G = new[]{
        new Vector3(0, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(1, -1, 0),
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0),
    };

    public static Vector3[] H = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(1, 0, 0),
        new Vector3(1, 1, 0),
        new Vector3(1, -1, 0),
    };

    public static Vector3[] I = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(1, -1, 0),
        new Vector3(0, -1, 0),
        new Vector3(0, 1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0),
    };

    public static Vector3[] J = new[]{
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(0, -1, 0),
        new Vector3(-1, 0, 0),
    };

    public static Vector3[] K = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(1, 1, 0),
        new Vector3(-1, 0, 0),
        new Vector3(1, -1, 0)
    };

    public static Vector3[] L = new[]{
        new Vector3(-1, 1, 0),
        new Vector3(-1, -1, 0),
        new Vector3(1, -1, 0)
    };

    public static Vector3[] M = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(0, 0, 0),
        new Vector3(1, 1, 0),
        new Vector3(1, -1, 0),
    };

    public static Vector3[] N = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(1, -1, 0),
        new Vector3(1, 1, 0)
    };

    public static Vector3[] O = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0),
        new Vector3(1, -1, 0),
        new Vector3(-1, -1, 0)
    };

    public static Vector3[] P = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0),
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0)
    };

    public static Vector3[] Q = new[]{
        new Vector3(1, -1, 0),
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0),
        new Vector3(1, -1, 0),
        new Vector3(0, 0, 0)
    };

    public static Vector3[] R = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0),
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0),
        new Vector3(1, -1, 0)
    };

    public static Vector3[] S = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(1, -1, 0),
        new Vector3(1, 0, 0),
        new Vector3(-1, 0, 0),
        new Vector3(0, 1, 0),
        new Vector3(1, 1, 0)
    };

    public static Vector3[] T = new[]{
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0),
        new Vector3(0, 1, 0),
        new Vector3(0, -1, 0)
    };

    public static Vector3[] U = new[]{
        new Vector3(-1, 1, 0),
        new Vector3(-1, -1, 0),
        new Vector3(1, -1, 0),
        new Vector3(1, 1, 0)
    };

    public static Vector3[] V = new[]{
        new Vector3(-1, 1, 0),
        new Vector3(0, -1, 0),
        new Vector3(1, 1, 0)
    };

    public static Vector3[] W = new[]{
        new Vector3(-1, 1, 0),
        new Vector3(-1, -1, 0),
        new Vector3(0, 0, 0),
        new Vector3(1, -1, 0),
        new Vector3(1, 1, 0)
    };

    public static Vector3[] X = new[]{
        new Vector3(-1, -1, 0),
        new Vector3(0, 0, 0),
        new Vector3(-1, 1, 0),
        new Vector3(0, 0, 0),
        new Vector3(1, 1, 0),
        new Vector3(0, 0, 0),
        new Vector3(1, -1, 0)
    };

    public static Vector3[] Y = new[]{
        new Vector3(0, -1, 0),
        new Vector3(0, 0, 0),
        new Vector3(-1, 1, 0),
        new Vector3(0, 0, 0),
        new Vector3(1, 1, 0)
    };

    public static Vector3[] Z = new[]{
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0),
        new Vector3(-1, -1, 0),
        new Vector3(1, -1, 0)
    };
}	
