
class OperatorTokens
{
    /*
     *  Commas
     * 
     */

    void someFunction()
    {
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

        int e = 0; int f = 1;
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
    }
}