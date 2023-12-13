package day6

import (
	aoc "AoC/Helper"
	"fmt"
	"strings"
)

func Solve() {
	var inputs = aoc.GetInput("2022", "day6", "test")

	for _, v := range inputs {

		// Initialize a buffer to store the last four characters received.
		buffer := ""

		// Loop through the input string one character at a time.
		for i := 0; i < len(v); i++ {
			// Add the current character to the buffer.
			buffer = buffer + aoc.Uint8ToS(v[i])

			// If the buffer has more than four characters, remove the first character.
			if len(buffer) > 14 {
				buffer = buffer[1:]
			}

			// If the buffer has four characters, check if they are all different.
			if len(buffer) == 14 {
				// Split the buffer into a slice of individual characters.
				chars := strings.Split(buffer, "")

				// Initialize a map to keep track of the frequency of each character.
				freq := make(map[string]int)

				// Loop through the slice of characters.
				for _, char := range chars {
					// Increment the frequency of the current character.
					freq[char]++
				}

				// Initialize a flag to track whether all characters are different.
				allDifferent := true

				// Loop through the frequency map.
				for _, count := range freq {
					// If any character appears more than once, set the flag to false.
					if count > 1 {
						allDifferent = false
						break
					}
				}

				// If all characters are different, print the current index and break from the loop.
				if allDifferent {
					fmt.Println(i + 1)
					break
				}
			}
		}

	}

}
