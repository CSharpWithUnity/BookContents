/*
 * Chapter 3.6 KeyWords
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

#region Chapter 3.6 Keywords
class ClassName
{
}

/*
 * Section 3.5 Keywords
 * 
 * ┌─────────────────┐ ┌────────────┐
 * │ Keyword "class" │ │ Identifier │
 * └───────┬─────────┘ └────┬───────┘
 *   ┌─────┘ ┌──────────────┘
 * ──┴── ────┴────
 * class ClassName
 * { ─┐
 * } ─┤
 *    │
 * ┌──┴───────────────────────────────────┐
 * │ Opening and Closing Separator Tokens │
 * └──────────────────────────────────────┘
 * This creates a new class object called "ClassName"
 * Note: class needs to be all lower case.
 */

class Charles { }

/*
 * Section 3.5.1 the class Keyword
 * The above is also a valid class declaration
 * Since there's nothing between the {} Charles
 * has no data, and doesn't do much of anything
 * right now.
 * a list of every keyword in C#
 *   ┌────────┐
 * ╔═╡Reserved╞════════════════════════╗
 * ║ └────────┘                        ║
 * ║ abstract as base bool             ║
 * ║ break byte case catch             ║
 * ║ char checked class const          ║
 * ║ continue decimal default delegate ║
 * ║ do double else enum               ║
 * ║ event explicit extern false       ║
 * ║ finally fixed float for           ║
 * ║ foreach goto if implicit          ║
 * ║ in int interface internal         ║
 * ║ is lock long namespace            ║
 * ║ new null object operator          ║
 * ║ out override params private       ║
 * ║ protected public readonly ref     ║
 * ║ return sbyte sealed short         ║
 * ║ sizeof stackalloc static string   ║
 * ║ struct switch this throw          ║
 * ║ true try typeof uint              ║
 * ║ ulong unchecked unsafe ushort     ║
 * ║ using using static virtual void   ║
 * ║ volatile while                    ║
 * ║ ┌─────────────────────┐           ║
 * ╟─┤Contextually Reserved├───────────╢
 * ║ └─────────────────────┘           ║
 * ║ add alias ascending               ║
 * ║ async await descending            ║
 * ║ dynamic from get                  ║
 * ║ global group into                 ║
 * ║ join let nameof                   ║
 * ║ orderby partial(type)             ║
 * ║ partial (method)                  ║
 * ║ remove select set                 ║
 * ║ value var when(filter condition)  ║
 * ║ where (generic type constraint)   ║
 * ║ where (query clause)              ║
 * ║ yield                             ║
 * ╚═══════════════════════════════════╝
 */
#endregion

class Reserved
{
    /* uncomment the lines below to
     * reveal the error.
     */
     
     //int abstract = 0;
    
    /* yield is only reserved in context
     * when used as a command after the keyword
     * return
     * uncommenting the line below will
     * not produce an error
     */
    
    //int yield = 0;
 }

/*
 * to see the error delete the // infront of the line
 * above and see what Unity says about line 81 in this
 * file.
 * 
 * yield can be used as a variable name
 * but it's also used for other purposes, so be aware
 * that some keywords can be tricky to use.
 */
 class Condition
{
    void TheIfKeyword()
    {
        /*                   */
        /* ┌───────────────┐ */
        /* │ keyword "int" │ */
        /* └───────┬───────┘ */
        /*         │         */
        /*┌────────┘         */
        /*┴                  */
        int i = 0;

        /*                    */
        /* ┌─────────────────┐*/
        /* │ keyword "float" │*/
        /* └───────┬─────────┘*/
        /*         │          */
        /* ┌───────┘          */
        /* ┴                  */
        float f = 3.14159f;

        /*                     */
        /* ┌──────────────────┐*/
        /* │ keyword "string" │*/
        /* └───────┬──────────┘*/
        /*         │           */
        /* ┌───────┘           */
        /* ┴                   */
        string s = "some words in quotes";

        if (i < 10)
        {
            // Code goes here.
        }

        /* Section 3.5.1 cont.
         * ┌──────────────┐ ┌───────────┐
         * │ keyword "if" │ │ Condition │
         * └───────┬──────┘ └────┬──────┘
         *         │             │
         *  ┌──────┘ ┌───────────┘
         * ─┴ ───────┴──
         * if ( i < 10 )
         * {
         *     // Code goes here.
         * }
         * 
         */

        UnityEngine.Debug.Log(i + f + s);
    }
}
