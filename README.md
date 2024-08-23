# QuPOS Code Assignment

#### Assumptions and notes
* Capitalization doesn't matter. I search using `StringComparison.OrdinalIgnoreCase`, and hope for the best (see "Input edge cases" below).
* Rather than searching by row and then by column, I rotate the entire grid. This lets me a) reuse the search function, and b) I can keep rotating the grid to search right to left or bottom to top.
* I could probably make an awesome nested for-loop that doesn't create any `string`s or transform objects, but it would be a bear to read or make any changes to.
* Only the `WordFinder` class is unit tested.
* I've written this using the .net MAUI framework, because it seemed more relevant to the job. I wouldn't normally include a framework.
* The UI is an afterthought. It provides a UI for using the WordFinder class, but nothing more.
* Per the documentation, but still worth calling out, I don't search for words right to left, down to up, or on a diagonal.
* Input is more or less assumed to be happy-path, with minimal input filtering for empty strings.
* Output is ordered by frequency descending.

 
#### To make this production ready
* I would add logging.
* Errors are not handled. They should be.
* Depending on the hardware and load, I'd consider adding metrics around the Find() runtime, and if necessary, the `private` helper functions as well.
* Input edge cases aren't handled very well:
	* * "Hello" is different from "HELLO" in the wordstream list.
	* * Capitalization isn't handled. Can I just `.toUpper()` everything or do we need to support [i11n](https://www.moserware.com/2008/02/does-your-code-pass-turkey-test.html) too?
	* * I haven't tried making words out of emojis (😃).
	* * I assume that valid characters for the wordstream and matrix are in the english alphabet (A-Z) and not whitespaces, zero width spaces, and the like.
