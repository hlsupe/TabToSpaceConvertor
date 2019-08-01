# TabToSpacesConvertor
Converts tabs to a configurable number of spaces.

This is a cleaner version of what I had posted on Stack Overflow account at https://stackoverflow.com/questions/508033/convert-tabs-to-spaces-in-a-net-string/41963144#41963144, along with some unit tests.

# Program Logic

The solution converts tab with up to 4 or 8 spaces.

The logic iterates through the input string, one character at a time and keeps track of the current position (column #) in the output string.

* If it encounters \t (tab char) - Finds the next tab stop, calculates how many spaces it needs to get to the next tab stop, converts \t with those number of spaces.
* If \n (newline) - Appends it to the output string and Resets the position pointer to 1 on the new line. A newline on Windows is \r\n and that on UNIX (or flavors) is \n, so I suppose this should work for both platforms. I have tested on Windows, but don't have UNIX handy.
* Any other characters - Appends it to the output string and increments the position.