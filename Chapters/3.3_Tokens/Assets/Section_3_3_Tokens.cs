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
}
