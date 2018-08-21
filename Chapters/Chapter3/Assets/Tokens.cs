// Chapter 3.4 Tokens

using UnityEngine;

public class Tokens : MonoBehaviour
{
    /*
     * Section 3.4 Tokens
     * 
     *            ┌─────────────┐   ┌─────────────┐
     *            │ punctuation │   │ punctuation │ 
     *            └─────┬───────┘   └─────┬───────┘
     *                  │                 │        
     *                  │                 │
     *                 I'm a little teapot.
     *                 ─┬─ ┬ ───┬── ──┬─── 
     *                  │  │    │     └────┐
     *                  │  │    │        ┌─┴────┐
     *                  │  │    └──────┐ │ noun │ 
     *              ┌───┘  └───────┐   │ └──────┘
     *   ┌──────────┴──────────┐   │ ┌─┴─────────┐
     *   │ contraction: I + am │   │ │ adjective │
     *   │ pronoun:            │   │ └───────────┘
     *   │ form of to be.      │ ┌─┴───────┐
     *   └─────────────────────┘ │ article │
     *                           └─────────┘
     */

    int i = 0;

    /*
     * Section 3.4.1 Writing C#
     * 
     *       ┌────────────┐ ┌─────────┐
     *       │ identifier │ │ literal │ 
     *       └────┬───────┘ └──┬──────┘
     *            └──┐         │         
     *               │   ┌─────┘
     *           int i = 0;
     *            │    │  └──┐
     *            │    │  ┌──┴────────┐
     *    ┌───────┘    │  │ separator │
     *    │            │  └───────────┘
     * ┌──┴──────┐ ┌───┴────────┐
     * │ keyword │ │ assignment │
     * └─────────┘ │ operator   │
     *             └────────────┘
     */

    int j = 0; int k = 1;


    /*
     * Section 3.3.3 Separator Tokens
     * 
     * the above is perfectly valid, but
     * it's not as readable as:
     * 
     * int j = 0;
     * int k = 1;
     * 
     * the l below us being assigned a 0 zero.
     * this works since the 0 is a literal of
     * type int, so this is a valid assignment
     */

    int l = 0;

    /*
     * Section 3.3.3 Separator Tokens Cont...
     * 
     * the line below is trying to assign the letter
     * O to the variable m which fails.
     * Uncomment the line to see what the error looks
     * like.
     * 
     */
    //int m = O;

    void thing()
    {

    }

    /*
     * Section 3.3.3 Separator Tokens Cont...
     * 
     *    ┌──────────────────┐ ┌───────────────────┐
     *    │ Open Parenthesis │ │ Close Parenthesis │
     *    └───────────┬──────┘ └────┬──────────────┘
     *                └──────┐┌─────┘
     *            void thing ()
     *                 
     *  the above is called a method declaration, also called a function declaration
     *  So far as object oriented programming is concerned, or OOP Methods were things
     *  that gave an output in return to an input. Functions were things that could
     *  operate in isolation.
     *  
     *  under 'void thing()' is a pair of curly braces:
     *  
     *  {
     *  
     *  }
     *  
     *  these indicate the start and end of the work that thing () is going to do.
     *  
     */

    int[] arrayOfNumbers = { 1, (int)3.0, 9000 };

    /*
     * Section 3.3.3 Separator Tokens Cont...
     * 
     * the above is another use of the curly braces
     * 
     *   ┌──────────────┐ ┌──────────────┐
     *   │ opening curly│ │ closing curly│
     *   │ brace        │ │ brace        │
     *   └───────┬──────┘ └─────┬────────┘
     *         ┌─┘              └──┐    
     *         │                   │
     *         { 1, (int)3.0, 9000 }
     *            │         │
     *            └────┬────┘
     *            ┌────┴──────┐
     *            │ separator │
     *            │ tokens    │
     *            └───────────┘
     *      
     *  (int)3.0
     *  observe this in the middle of the array assignment.
     *      
     *     3.0
     *  ┌───┴───┐
     *  │ dot   │
     *  │ token │
     *  └───────┘
     *   the dot changes the int to a double.
     *   (int) tells C# to change double to int
     *   of course if it were 3.1 then the int
     *   is 3 and the .1 will be lost.
     *  
     *  { 0, 1, 2 }
     *  another more simple example.
     *  
     *  {0,0,0}
     *  the white space isn't necessary
     *  but it's easier to read.
     *  
     *  
     */

    void QuotationMarks()
    {
        System.Console.Write(" use straight quotes. ");
        // this line uses regular " quote marks

        //System.Console.Write(“ this wont work... ”);
        // the line above uses fancy quotes that most word processors will
        // automatically insert when you use quotation marks.
        // uncomment it if you'd like to see where the error occurs

    }

    /*
     * Section 3.3.3 Separator tokens cont...
     * " are usually used in text editors, smart quotes like
     * the ones that are give in fancy word processors 
     * like “ and ” aren't recognized here.
     * 
     */

    void StatementSeparation()
    {
        int a = 0;
        System.Console.Write(a);
        
        // some random scope
        {
            // int a = 1;
            System.Console.Write(a);
        }

        /* code needs to be separated into small chunks
         * to help separate code into usable parts we
         * use separator tokens.
         */
        int aa = 0;
        /*
         * the ; indicates the end of a statement.
         */

        int b = 1; int c = 2;
        /*
         * multiple statements can appear on the same line
         * but it's not common practice to do so.
         */

        {
            int d = 1;
        }

        /* 
         * the curly braces isolate int d = 1; by separating
         * it from the rest of the code in the Separators()
         * function. more on this in a later chapter on scope
         * in chapter 4.8
         */

        /*
         * where are commas supposed to be used?
         * they're used to keep values apart so
         * they can be parsed as separate things
         */

        int a = 0, b = 1;
        /* 
         * the above statement creates two variables
         * assigns them values, but only indicates
         * the type once.
         */

        //int c = 0, int d = 1;
        /*
         * the above code fails
         * the lexer isn't expecting
         * the keyword int following the ,
         * after the first assignment.
         */

        int e = 0;
        int f = 1;
        /*
         * the above code passes
         * since the ; ends the first
         * statement and the second
         * declaration is expected
         * since ; tells the lexer to
         * read a new statement, not
         * just a continuation of a previous
         * statement.
         */

        int g = 0;
        int h = 1;
        /*
         * the above passes as well since
         * these are two independent statements,
         * they just appear on two different lines.
         */
    }

    /*
     * Section 3.3.4 Operator Tokens
     * 
     * Operator tokens are often characters used in math operations like
     * Addition Operator is + or - for Divide we use / rather than ÷
     * ┌───┬───────────────────────┐
     * │ = │ Assignment Operator   │
     * ├───┼───────────────────────┤
     * │ + │ Addition Operator     │
     * ├───┼───────────────────────┤
     * │ - │ Subtraction Operatorr │
     * ├───┼───────────────────────┤
     * │ * │ Multiply Operator     │
     * ├───┼───────────────────────┤
     * │ / │ Divide Operator       │
     * ├───┼───────────────────────┤
     * │ % │ Remainder Operator    │
     * └───┴───────────────────────┘
     * 
     */

    void OperatorTokens()
    {
        int AdditionOperator = 1 + 1;
        System.Console.WriteLine("AdditionOperator Result = " + AdditionOperator);

        int SubtractionOperator = 1 - 1;
        System.Console.WriteLine("SubtractionOperator Result = " + SubtractionOperator);

        int MultiplyOperator = 2 * 2;
        System.Console.WriteLine("MultiplyOperator Result = " + MultiplyOperator);

        int DivideOperator = 10 / 2;
        System.Console.WriteLine("DivideOperator Result = " + DivideOperator);

        int ModuloOperator = 10 / 3;
        System.Console.WriteLine("ModuloOperator Result = " + ModuloOperator);


    }

    /*
     * Section 3.3.4 Literals
     * 
     * values are literals
     * numbers like 1 or 1.0 are both literals
     * large values like 10,000 should be written
     * as 10000 witout the comma.
     * Remember we saw { 0, 1, 2 } which can also be
     * {0,1,2} without the white space.
     * 
     * So how does the compiler know the difference between
     * {10,000,1,2} and { 10,000, 1, 2} the compiler will see both
     * as a 10 a 000 followed by 1 and finally a 2.
     * 
     * It's a bit hard to read really large numbers like 1234567891
     * or 1,234,567,891. As humans we need to read these numbers
     * with billions, millions, thousands, and hundreds, computers don't.
     * 
     * when the following function is used in the Start()
     * function you'll see it prints out
     * someInts: 10
     * someInts: 0
     * someInts: 10000
     */

     void Literal()
     {
        int i = 0;
        int j = i + 1;
     }
    /*
     *    ┌────────────┐ ┌─────────┐
     *    │ identifier │ │ literal │ 
     *    └────┬───────┘ └──┬──────┘
     *         └──┐         │         
     *            │   ┌─────┘
     *        int i = 0;
     *         │    │  │ 
     *         │    │  └──┐
     *         │    │  ┌──┴────────┐
     *      ┌──┘    │  │ separator │
     *      │       │  └───────────┘
     *      │  ┌────┴───────┐
     *      │  │ assignment │
     *      │  │ operator   │
     *      │  └────────────┘
     *   ┌──┴──────┐
     *   │ keyword │
     *   └─────────┘
     *   
     *   int j = i + 1;
     *       │   │   │
     *       │   │   └─┐
     *       │   └┐ ┌──┴────────────────┐
     *       │    │ │ this is a literal │
     *       │    │ └───────────────────┘
     *       │ ┌──┴─────────────────┐  
     *    ┌──┘ │ i is not a literal │
     *    │    └────────────────────┘
     * ┌──┴────────────┐
     * │ not a literal │
     * └───────────────┘
     */
    int[] someInts = { 10,000, 10000 };
    void ShowSomeInts()
    {
        foreach (int i in someInts)
        {
            Debug.Log("someInts: " + i);
        }
        /*
         * Section 3.3.4 continued...
         */

        float degrees;
        float radians = 3.14159f;

        degrees = (radians * Mathf.PI) / 180;
        Debug.Log("Degrees from 3.14159 Radians = " + degrees);
    }

    /*
     * Section 3.3.5 Transitive and Non-Transitive Operations
     * The below shows various results with very similar numbers
     * separation of values using () can change the order
     * of operations in very specific ways.
     * Be aware of this when calculating your work.
     */
    int a = 1 + 2 - 4 + 7;
    int b = 7 + 4 - 2 + 1;
    int c = (7 + 4) - (2 + 1);
    int d = (1 + 2) - (4 + 7);
    void ShowAResultAndBResult()
    {
        Debug.Log("the result of A: " + a);
        Debug.Log("the result of B: " + b);
        Debug.Log("the result of C: " + c);
        Debug.Log("the result of D: " + d);
    }
    /*
     * Section 3.3.7 Putting it all together
     * The statement below appears in the start function.
     *     ┌──────┐ ┌────────────┐ ┌────────────┐ ┌───────────┐ ┌───────────┐
     *     │ type │ │ identifier │ │ assignment │ │ literal   │ │ separator │
     *     └──┬───┘ └──────┬─────┘ │ operator   │ │ gives     │ └─────┬─────┘
     *        │            │       └─────┬──────┘ │ i a value │       │
     *        │┌───────────┘             │        └─────┬─────┘       │
     *        ││ ┌───────────────────────┘              │             │
     *        ││ │ ┌────────────────────────────────────┘             │ 
     *      ┌─┘│ │ │┌─────────────────────────────────────────────────┘
     *      │  │ │ ││
     *     int i = 0;             ┌─────────────────────────────────────────┐
     *              ┌─────────────┤ compares the value of i is less than 10 │
     *     while (i < 10)         └─────────────────────────────────────────┘
     *    ┌{                      ┌──────────────────────────────────┐
     *    │ ↓  Debug.Log(i);──────┤ prints to console the value of i │
     *   ┌┤ ↓  i++;──────────┐    └──────────────────────────────────┘
     *   │└}                 │    ┌───────────────────────────────┐
     *   │                   └────┤ increases the value of i by 1 │
     *   │                        └───────────────────────────────┘
     *   │ ┌───────────────────────────┐ 
     *   └─┤ repeats operation until i │
     *     │ is no longer less than 10 │
     *     └───────────────────────────┘
     */

    public void Start()
    {
        // Delete the // at the beginning of the
        // line where ShowSomeInts(); appears
        // this will "uncomment" the line and
        // the compiler will see it and run that
        // line to execute the code.

        // ShowSomeInts();
        
        // the above shows
        // someInt: 10 
        // someInt: 0
        // someInt: 10000

        //ShowAResultAndBResult();
        
        // the above shows
        // The result of A: 6
        // The result of B: 10
        // The result of C: 8
        // The result of D: -8

        int i = 0;
        while (i < 10)
        {
            Debug.Log(i);
            i++;
        }
    }
}
