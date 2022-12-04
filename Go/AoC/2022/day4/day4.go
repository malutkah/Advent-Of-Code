package day4

import (
	aoc "AoC/Helper"
	"fmt"
	"strings"
)

func Solve() {
	var inputs = aoc.GetInput("2022", "day4", "test")

	for _, i := range inputs {
		sections := strings.Split(i, ",")

		s1 := sections[0]
		s2 := sections[1]

		// section 1
		pair1 := strings.Split(s1, "-")
		id1 := aoc.StoI(pair1[0])
		id2 := aoc.StoI(pair1[1])
		// get range
		for i := 0; i <= 9; i++ {
			if i >= id1 && i <= id2 {
				fmt.Printf("%d", i)
			} else {
				fmt.Print(".")
			}
		}
		fmt.Printf(": %v\n", pair1)

		// section 2
		pair2 := strings.Split(s2, "-")
		id1 = aoc.StoI(pair2[0])
		id2 = aoc.StoI(pair2[1])

		for i := 0; i <= 9; i++ {
			if i >= id1 && i <= id2 {
				fmt.Printf("%d", i)
			} else {
				fmt.Print(".")
			}
		}
		fmt.Printf(": %v\n\n", pair2)

	}
}
