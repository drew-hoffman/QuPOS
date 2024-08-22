# QuPOS Code Assignment

#### Assumptions
* Capitalization doesn't matter. I search using `StringComparison.OrdinalIgnoreCase`, and hope for the best (see "Edge cases" below).
* The ability to read the code is more important than the ability to optimize memory and CPU cycles away. I could probably make an awesome for-loop that doesn't create any `string`s or transform objects, but it would be a bear to read or make any changes to.
* Only the `WordFinder` class is unit tested.
* I've written this using .net MAUI, because it seemed more relevant. I wouldn't run .net maui code in the cloud unless I had a good reason to though.

#### If this were going into production
* I would add logging
* Errors are not handled. I assume you are passing a list of 0 or more items that won't crash the server.
* Depending on the hardware and load, I'd consider adding metrics around the Find() runtime, and if necessary, the `private` helper functions as well.
* Edge cases aren't handled very well:
	* * "Hello" is different from "HELLO" in the wordstream list.
	* * Putting "Hello", "HELLO", and "hello" into the matrix will return 3 hits.
	* * Really, we need to discuss capitalization. Can I just `.toUpperCase()` everything or do we need to support [i11n](https://www.moserware.com/2008/02/does-your-code-pass-turkey-test.html) too?
	* * I haven't tried making words out of 😃 yet, but I'm sure someone will.