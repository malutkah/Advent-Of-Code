package day1

import (
	aoc "AoC/Helper"
	"fmt"
	"sort"
)

func Solve() {
	var inputs = aoc.GetInput("2022", "day1", "input")

	calories := 0
	var cals []int

	for c := 0; c < len(inputs); c++ {
		if inputs[c] != "" {
			calories += aoc.StoI(inputs[c])
		}

		if inputs[c] == "" || c == len(inputs)-1 {
			cals = append(cals, calories)
			calories = 0
		}
	}

	_, max := aoc.MinMax(cals)
	fmt.Printf("max value is: %d\n\n", max)

	sort.Slice(cals, func(i, j int) bool {
		return cals[i] > cals[j]
	})

	fmt.Printf("top three sum is: %d\n\n", cals[0]+cals[1]+cals[2])

}
