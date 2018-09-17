/*
 * Chapter 6.13 Inheritance Again
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class InheritanceAgain : MonoBehaviour
{
    /*
     * Section 6.13.1 Function Overrides
     * 
     * Instantiate a Parent of the ParentClass object.
     * 
     */

    private void Start()
    {
        {
            /*
             * Example 6.13.1.1 A Basic Example.
             * 
             * Instantiation happens here.
             */

            ParentClass parent = new ParentClass();
            parent.ParentFunction();
            /*           ↑
             * Parent calls on it's function call.
             *           │
             *         ╭─────────────╮
             *         │ ParentClass │
             *         ╰──┬──────────╯
             *            │
             *            ╰───→ParentFunction()┐
             *                    │            │
             *                    ├→FunctionA()┤
             *                    ╰→FunctionB()┴→────┐
             *         ╭────────────╮                ↓                 
             *         │ ChildClass │           ╔════╧═════════════════╗
             *         ╰──┬─────────╯           ║ChildClass            ║
             *            │                     ║calls the parent's    ║
             *            ╰→ChildFunction()     ║version of FunctionB()║
             *            ┊  │                  ╚════╤═════════════════╝
             *            ┊  ╰→ParentFunction()┐     ↓
             *            ┊       │            │     │
             *            ┊       ├→FunctionA()┤     ↓
             *            ┊       ╰→FunctionB()┴←────┘
             *            ┊  //child class
             *            ╰┈┈┈┈┈┈┈┈new FunctionB()
             *                      │
             *            ┌─────────┴──────────────────┐
             *            │new hides the parent version│
             *            │of the FunctionB() this     │
             *            │version of FunctionB() isn't│
             *            │called by ChildFunction()   │
             *            └────────────────────────────┘
             *           
             *           however when we use override the following happens.
             *           
             *         ╭────────────╮                     ↓                 
             *         │ ChildClass │                ╔════╧═════════════════╗
             *         ╰──┬─────────╯                ║ChildClass            ║
             *            │                          ║calls the parent's    ║
             *            ╰─→ChildFunction()         ║version of FunctionB()║
             *            ┊   │                      ╚════╤═════════════════╝
             *            ┊   ╰→ParentFunction()┐         ↓
             *            ┊        │            │         │
             *            ┊        ├→FunctionB()┴←────────┘
             *            ┊╭──────←┴←virtual FunctionA()
             *            ┊│             │            ╔═════════════════════════════╗
             *            ┊↓             └────────────╢ virtual tells FunctionA()   ║
             *            ┊│                          ║ to change what the Parent   ║
             *            ┊↓  //child class           ║ version does if an override ║
             *            ┊╰→ override FunctionA()    ║ version is present in the   ║
             *            ╰┈┈┈┈┈┈┈┈new FunctionB()    ║ child class but is called   ║
             *                                        ║ when the parent version     ║
             *                                        ║ is called.                  ║
             *                                        ╚═════════════════════════════╝
             */
            ChildClass child = new ChildClass();
            child.ChildFunction();
            /*         ↑                             *
             * The child calls the ChildFunction()   *
             * which skips the child's version of    *
             * FunctionB() but does use the child    *
             * version of FunctionA since it's using *
             * override                              */
        }
        {
            /*
             * Section 6.13.2 Class Inheritance
             */
            ZombieClass zombie = new ZombieClass();
            VampireClass vampire = new VampireClass();
            // zombie.HitPoints = 10;
            // vampire.HitPoints = 10;
            /* Assignment of HitPoints = 10
             * every time might be redundant.
             * so they've been added to the
             * constructor of BaseMonsterClass
             */
            Debug.Log(zombie.TakeDamage(5));
            Debug.Log(vampire.TakeDamage(5));
        }
        {
            ZombieClass zombie = new ZombieClass();
            /*
             * Section 6.13.3 Object
             * After adding an override
             * for the ToString() function
             * in zombie we can get a custom
             * Debug.Log() function from it.
             */
            Debug.Log(zombie);
            // "I'm a Zombie!"
        }
    }
}

public class ParentClass
{
    public void ParentFunction()
    {
        Debug.Log("Parent Says Hello.");
        FunctionA();
        FunctionB();
    }

    /* the virtual keyword informs any class        *
     * inheriting from this one that the function   *
     * is allowed to be overridden                  *
     *        ↓                                     */
    public virtual void FunctionA()
    {
        Debug.Log("Parent Function A Says Hello.");
    }

    public void FunctionB()
    {
        Debug.Log("Parent Function B Says Hello.");
    }
}

public class ChildClass : ParentClass
{
    public void ChildFunction()
    {
        ParentFunction();
    }

    /* the override keyword tells the function      *
     * that it's still to be called when the parent *
     * version is called.                           *
     *        ↓                                     */
    public override void FunctionA()
    {
        /*
         * Section 6.13.1.1.1 Base
         */
        base.FunctionA();
        /*  ↑                              *
         * "Parent Function A Says Hello." *
         * base.FunctionA() indicates      *
         * we will call the parent version *
         * of the FunctionA() followed     *
         * by the additions added by the   *
         * child class                     *
         *  ↓                              */
        Debug.Log("Child's Addition to Function A.");
        /* in most cases base will preceed any   *
         * additions, but there's no restriction *
         * on where base can appear              */
    }

    /* Adding the new keyword to the prefix of the      *
     * function definition *hides* the parent's version *
     * and creates a new function with the same name.   *
     *      ↓                                           */
    public new void FunctionB()
    {
        Debug.Log("Child's New FunctionB? I'm too new and not called from anywhere.");
    }
}

/*
 * Section 6.14.2 Class Inheritance
 */

class BaseMonsterClass
{
    public int HitPoints;
    public GameObject gameObject;
    public BaseMonsterClass()
    {
        HitPoints = 10;
        gameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Debug.Log("A New Monster Rises!");
    }

    public virtual int TakeDamage(int damage) // ─→╮                     
    {                                         //   │                     
        return HitPoints - damage;            //  The virtual function   
    }                                         //  is taken over by the   
}                                             //  override version in    
                                              //  zombie.                
class ZombieClass : BaseMonsterClass          //   │                     
{                                             //   │                     
    public int BrainsEaten;                   //   │                     
                                              //   │                     
    public override int TakeDamage(int damage)// ←─╯                     
    {                                  
        return base.TakeDamage(damage);       // base.TakeDamage(damage); re-uses
    }                                         // the original implementation
    /* Commenting out the above TakeDamage           */
    /* will mean to use the original implementation  */
    /* of TakeDamage from the BaseMonsterClass       */

    public override string ToString()
    {
        return "I'm a Zombie!";
    }
}

class VampireClass : BaseMonsterClass
{
    public int BloodSucked;
    public override int TakeDamage(int damage)
    {
        return HitPoints - (damage / 2); // doesn't use base, so it's a new
    }                                    // version of the original
}
