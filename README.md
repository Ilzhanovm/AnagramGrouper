# AnagramGrouper
Provides a class to group words into Lists of anagrams.

## Usage

- Create AnagramGrouper instance

```cs
AnagramGrouper grouper = new();
```

- Pass List of words to GroupAnnagrams method

```cs
List<string> words = new() { "ток", "рост", "кот", "торс", "Кто", "фывап", "рок" };

var result = grouper.GroupAnnagrams(words);
```

### How HashString method works

AnagramGrouper instance stores a unique hash value (a power of 2) for every character encountered.
Hash for a word is the sum of the hash values of its characters.
To account for multiple entries of the same character, separate hash values are stored for the second and each subsequent occurrence of the character.

#### Examples

Let's say we have this hash values for the first four characters.

|| a | b | c | d |
| - | - | - | - | - |
| decimal | 1 | 2 | 4 | 8 |
| binary | 1 | 10 | 100 | 1000 |

Words will be translated as such:

"ab" ==> 11b
"ca" ==> 101b
"da" ==> 1001b

If we met a new character, we add new hash value to the table:

|| a | b | c | d | 私 |
| - | - | - | - | - | - |
| decimal | 1 | 2 | 4 | 8 | 16 |
| binary | 1 | 10 | 100 | 1000 | 10000 |

If we encounter a word with multiple occurrences of a character, we add a new hash value for each new entry:

|| a | b | c | d | cc | ccc |
| - | - | - | - | - | - | - |
| decimal | 1 | 2 | 4 | 8 | 16 | 32 |
| binary | 1 | 10 | 100 | 1000 | 10000 | 100000