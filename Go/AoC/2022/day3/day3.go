package day3

import (
	aoc "AoC/Helper"
	"fmt"
	"strings"
	"unicode"
)

func Solve() {
	var inputs = aoc.GetInput("2022", "day3", "input")
	var items []string
	var groups []string
	group := 0
	for _, rucksack := range inputs {
		// ===== Part 1 ====== //
		//firstCompartment := rucksack[:len(rucksack)/2]
		//secondCompartment := rucksack[len(rucksack)/2:]

		//search:
		//	for _, i1 := range firstCompartment {
		//		for _, i2 := range secondCompartment {
		//			if i1 == i2 {
		//				items = append(items, string(i2))
		//				break search
		//			}
		//		}
		//	}
		//========================================================

		// ===== Part 2 ====== //
		// find item (letter) that appears in all three compartments
		groups = append(groups, rucksack)
		group++

		if group == 3 {

		search:
			for _, r1 := range groups[0] {
				for _, r2 := range groups[1] {
					for _, r3 := range groups[2] {
						if r1 == r2 && r1 == r3 && r2 == r3 {
							items = append(items, string(r1))
							break search
						}
					}
				}
			}

			groups = nil
			group = 0
		}
		//========================================================

	}

	p := 0
	for _, i := range items {
		p += getPriority(i)
	}
	fmt.Println(p)
}

func getPriority(item string) int {
	p := 0

	var prioMap = map[string]int{"a": 1, "b": 2, "c": 3, "d": 4, "e": 5, "f": 6, "g": 7, "h": 8, "i": 9, "j": 10, "k": 11, "l": 12, "m": 13, "n": 14, "o": 15, "p": 16, "q": 17, "r": 18, "s": 19, "t": 20, "u": 21, "v": 22, "w": 23, "x": 24, "y": 25, "z": 26}
	r := []rune(item)

	p = prioMap[item]
	if unicode.IsUpper(r[0]) {
		l := strings.ToLower(item)
		e := prioMap[l]
		p = e + 26
	}

	return p
}
