class Section_3_3_Tokens
{
    /*
     * ┌─────────────┐    ┌─────────────┐
     * │ punctuation │    │ punctuation │ 
     * └─────┬───────┘    └─────┬───────┘
     *       └───┐              └──┐         
     *           │                 │
     *          I'm a little teapot.
     *          ─┬─ ┬ ──┬─── ──┬─── 
     *           │  │   │   ┌──┴───┐
     *           │  │   │   │ noun │ 
     *       ┌───┘  │   │   └──────┘
     *       │      │ ┌─┴─────────┐
     *       │  ┌───┘ │ adjective │
     *       │  │     └───────────┘
     *       │┌─┴───────┐
     *       ││ article │
     *       │└─────────┘
     * ┌─────┴───────────────┐
     * │ contraction: I + am │
     * │ pronoun:            │
     * │ form of to be.      │
     * └─────────────────────┘
     */

    int i = 0;

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
     */

    int j = 0; int k = 1;
    /*
     * the above is perfectly valid, but
     * it's not as readable as:
     * int j = 0;
     * int k = 1;
     */

    void thing()
    {

    }

    /*    ┌──────────────────┐ ┌───────────────────┐
     *    │ Open Parenthesis │ │ Close Parenthesis │
     *    └───────────┬──────┘ └────┬──────────────┘
     *                │             │
     *                └──────┐┌─────┘
     *            void thing ()
     *                 
     * the above is called a method declaration, also called a function declaration
     * So far as object oriented programming is concerned, or OOP Methods were things
     * that gave an output in return to an input. Functions were things that could
     * operate in isolation.
     */

    int[] arrayOfNumbers = { 1, (int)3.0, 9000 };

    /*
     * the above is another use of the curly braces
     * 
     *  ┌──────────────┐ ┌──────────────┐
     *  │ opening curly│ │ closing curly│
     *  │ brace        │ │ brace        │
     *  └───────┬──────┘ └─────┬────────┘
     *  ┌───────┘           ┌──┘       
     *  │                   │
     *  { 1, (int)3.0, 9000 }
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
    }

    void QuotationMarks()
    {
        System.Console.Write(" use straight quotes. ");
        // this line uses regular " quote marks

        //System.Console.Write(“ this wont work... ”);
        // the line above uses fancy quotes that most word processors will
        // automatically insert when you use quotation marks.
        // uncomment it if you'd like to see where the error occurs

    }

    void imAFunction()
    {
        // this doesn't make modifications to any values
        // outside of this declaration
        System.Console.Write("im a function");
    }

    int v = 0;
    // a variable declared outside of the scope
    // of the method below

    void imAMethod()
    {
        // A method makes
        // modifications to values
        // outside of it's declared scope
        // so if you copied the line from void imAMethod() to the closing }
        // and pasted it in another class, you'd need to include the inv v = 0;
        // or else this Method wouldn't work

        v = 1;
        // the above v is not declared inside of the scope of the method.
    }
}
