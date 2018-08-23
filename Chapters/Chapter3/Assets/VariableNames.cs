
using UnityEngine;


public class VariableNames : MonoBehaviour
{
    /*
     * Section 3.10 Variable Names
     */

    public int SomeLongComplexHardToRememberVariableName;

    /* SomeCleverFunction(TopLeftCorner – SomeThickness + OffsetFromSomePosition,
     * BottomRightCorner – SomeThickness + OffsetFromSomePosition);
     * 
     * CleverFunc(TL-Thk+Ofst, LR-Thk+Ofst);
     *
     */

    int a;

    /* what does a even do?
     */

    // int 8;

    /* unmcomment the line above
     * int 8; isn't valid since
     * 8 is a literal, which is like
     * a keyword, so it's reserved
     * for being used as a value
     * not an identifier.
     */

    int varNumber2;

    /* a number is allowed
     * to appear in a variable name
     * along with some other characters.
     */

    //int 13thInt;

    /* uncomment the line above to
     * show the error produced.
     */

    //int $;
    //int this-that;
    //int (^_^);

    /* The above uses various
     * special characters and a keyword.
     * uncomment to see the errors produced.
     */

    //int spaces are bad;

    /* White space between identifiers
     * or tokens infers that you're
     * creating multiple different identifiers
     * for different variables.
     */

    int ADifferenceInCase;
    int adifferenceincase;

    /* C# is case sensative, so
     * the above two variable names
     * can live with one another
     * and not conflict.
     */

    int @home;
    //int noone@home;
    //int nobodyhome@;
    
    /* The @ symbol cannot appear
     * in the middle or end of a
     * variable name.
     * Uncomment the two lines above
     * to see what the errors are.
     */
}
