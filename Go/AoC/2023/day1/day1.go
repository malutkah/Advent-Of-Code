package day1

import (
	"fmt"
	"strconv"
	"strings"

	aoc "AoC/Helper"
)

func Solve() {
	var inputs = aoc.GetInput("2023", "day1", "test")
	validNumbers := []string{"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"}
	numberMap := make(map[string]int)

	for i, s := range validNumbers {
		numberMap[s] = i + 1
	}

	first := -1
	last := -1
	var allValues []int
	var numWords []string

	for _, line := range inputs {

		// parse num words
		// two1nine = ["two", "nine"]
		word := ""
		fmt.Printf("- %v\n", line)
		found := false
		for _, ch := range line {
			word += aoc.RtoS(ch)

			if num, err := strconv.Atoi(aoc.RtoS(ch)); err == nil && !found {
				if first == -1 {
					first = num
				}

				last = num

				line = strings.Replace(line, aoc.RtoS(ch), "", -1)
				fmt.Println(line)
				word = ""
				found = true
			}

			if len(word) > 2 && aoc.SliceContains(validNumbers, word) && !found {

				numWords = append(numWords, word)
				line = strings.Replace(line, word, "", -1)

				fmt.Println(line)

				if first == -1 {
					first = numberMap[word]
				}

				last = numberMap[word]

				word = ""
				found = true
			}

			found = false
		}

		if !found {
			for _, s := range validNumbers {
				if strings.Contains(word, s) {

				}
			}
		}

		fmt.Println()
		values := fmt.Sprintf("%v%v", first, last)
		allValues = append(allValues, aoc.StoI(values))
		first = -1
	}

	// fmt.Println(numWords)

	sum := 0
	for _, v := range allValues {
		sum += v
	}

	fmt.Println(allValues)
	fmt.Println(sum)
}

func Part1() {
	var inputs = aoc.GetInput("2023", "day1", "input")
	first := -1
	last := -1
	var allValues []int

	for _, line := range inputs {
		for _, c := range line {
			i := aoc.RtoS(c)
			if num, err := strconv.Atoi(i); err == nil {
				if first == -1 {
					first = num
				}
				last = num
			}
		}
		values := fmt.Sprintf("%v%v", first, last)
		allValues = append(allValues, aoc.StoI(values))
		first = -1
	}
	sum := 0
	for _, v := range allValues {
		sum += v
	}

	fmt.Println(allValues)
	fmt.Println(sum)
}
